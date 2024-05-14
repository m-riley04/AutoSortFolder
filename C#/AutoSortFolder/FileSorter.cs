using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace AutoSortFolder
{
    public class FileSorter
    {
        public List<string> blacklist;

        public FileSorter()
        {
            this.blacklist = new List<string>();
        }

        public FileSorter(List<string> blacklist)
        {
            this.blacklist = blacklist;
        }

        /// <summary>
        /// Sorts a file based on it's file extension. Moves it into a folder of the extension's category
        /// </summary>
        /// <param name="path"></param>
        /// <param name="directory"></param>
        public void SortByExtension(string path, string directory)
        {
            string name = Path.GetFileName(path);

            // Check if the file is in the blacklist
            if (this.blacklist.Contains(name))
            {
                Console.WriteLine($"File/directory name {0} is in blacklist.", name);
                return;
            }

            string extension = Path.GetExtension(path);
            string extensionCategory = "other"; // Default folder name
            string sortedFolderPath = directory + "\\" + extensionCategory;

            // Iterate through and get the category
            foreach (KeyValuePair<string, string[]> item in FileExtensions.Extensions)
            {
                if (item.Value.Contains(extension))
                {
                    extensionCategory = item.Key;

                    // Check if the category folder isn't created
                    sortedFolderPath = directory + "\\" + extensionCategory;
                    if (!Directory.Exists(sortedFolderPath)) Directory.CreateDirectory(sortedFolderPath);

                    break;
                }
            }

            // Move the file to the folder
            MoveSafe(path, sortedFolderPath + "\\" + name);

            // Update the blacklist
            if (!blacklist.Contains(extensionCategory)) this.blacklist.Add(extensionCategory);
        }

        /// <summary>
        /// Sorts a file based on the first character
        /// </summary>
        /// <param name="path"></param>
        /// <param name="directory"></param>
        public void SortByAlphabet(string path, string directory)
        {
            string name = Path.GetFileName(path);

            // Check if the file is in the blacklist
            if (blacklist.Contains(name))
            {
                Console.WriteLine($"File/directory name {0} is in blacklist.", name); 
                return;
            }

            char c = name[0];
            string sortedFolderPath = directory + "\\" + c;

            // Check if the directory already exists
            if (!Directory.Exists(sortedFolderPath)) Directory.CreateDirectory(sortedFolderPath);

            // Move the file to the folder
            MoveSafe(path, sortedFolderPath + "\\" + name);

            // Update the blacklist
            if (!blacklist.Contains(c.ToString())) this.blacklist.Add(c.ToString());
        }

        public enum DateSortCategory
        {
            CREATED,
            MODIFIED,
            ACCESSED
        }

        public enum DateComponent
        {
            DATE,
            DAY,
            MONTH,
            YEAR,
            WEEKDAY
        }

        /// <summary>
        /// Sorts a file based on the creation date
        /// </summary>
        /// <param name="path"></param>
        /// <param name="directory"></param>
        public void SortByDate(string path, string directory, DateSortCategory category = DateSortCategory.CREATED, DateComponent component = DateComponent.DATE)
        {
            string name = Path.GetFileName(path);

            // Check if the file is in the blacklist
            if (blacklist.Contains(name))
            {
                Console.WriteLine($"File/directory name {0} is in blacklist.", name);
                return;
            }

            // Get the date based on the category
            DateTime date;
            switch (category) {
                case DateSortCategory.CREATED:
                    date = File.GetCreationTime(path);
                    break;
                case DateSortCategory.MODIFIED:
                    date = File.GetLastWriteTime(path);
                    break;
                case DateSortCategory.ACCESSED:
                    date = File.GetLastAccessTime(path);
                    break;
                default:
                    date = File.GetCreationTime(path);
                    break;
            }

            // Get the date component from the date
            string folderName;
            switch (component)
            {
                case DateComponent.DATE:
                    folderName = date.Date.Date.ToString("MM-dd-yyyy").Replace("/", "-").Replace(":", "_");
                    break;
                case DateComponent.DAY:
                    folderName = date.Day.ToString();
                    break;
                case DateComponent.MONTH:
                    folderName = date.Month.ToString();
                    break;
                case DateComponent.YEAR:
                    folderName = date.Year.ToString();
                    break;
                case DateComponent.WEEKDAY:
                    folderName = date.DayOfWeek.ToString();
                    break;
                default:
                    folderName = "other";
                    break;
            }

            string sortedFolderPath = directory + "\\" + folderName;

            // Check if the directory already exists
            if (!Directory.Exists(sortedFolderPath)) Directory.CreateDirectory(sortedFolderPath);

            // Move the file to the folder
            MoveSafe(path, sortedFolderPath + "\\" + name);

            // Update the blacklist
            if (!blacklist.Contains(folderName)) this.blacklist.Add(folderName.ToString());
        }

        /// <summary>
        /// Safely moves a file without overwriting. If the file already exists in the directory, it tries again until it adds enough numbers to the end
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="destPath"></param>
        public static void MoveSafe(string sourcePath, string destPath)
        {
            // Get attributes of the path and check if its a file or directory
            FileAttributes attr = File.GetAttributes(sourcePath);
            bool isDirectory = attr.HasFlag(FileAttributes.Directory);

            try
            {
                if (isDirectory) FileSorter.CopyDirectory(sourcePath, destPath, true, false);
                else File.Copy(sourcePath, destPath, false);
            }
            catch (IOException ex)
            {
                // Add a number to the end if theres a duplicate file
                int count = 0;
                string name = Path.GetFileNameWithoutExtension(destPath);
                string extension = Path.GetExtension(destPath);
                string destDirPath = destPath.Substring(0, destPath.Length - (name + extension).Length);
                string dupePath;

                // Attempt to find new name
                int timeout = 99999999;
                while (true)
                {
                    // Construct new duplicate path
                    dupePath = destDirPath;
                    dupePath += name + "(" + count + ")" + extension;

                    // Check if the new dupe path is unique
                    if (!File.Exists(dupePath)) break;

                    count++;

                    // Check if timeout was reached
                    if (count >= timeout) throw new Exception("Timeout reached when attempting to find a new name");
                }

                // Copy again
                if (isDirectory) FileSorter.CopyDirectory(sourcePath, dupePath, true, false);
                else File.Copy(sourcePath, dupePath, false);
            }
            finally
            {
                // Delete the original
                if (isDirectory) Directory.Delete(sourcePath, true);
                else File.Delete(sourcePath); // Delete the original
            }
        }

        /// <summary>
        /// Recursively copies a directory to another destination. Originally written by Microsoft from their documentation, modified by me to add overwrite protections.
        /// </summary>
        /// <param name="sourceDir"></param>
        /// <param name="destinationDir"></param>
        /// <param name="recursive"></param>
        /// <exception cref="DirectoryNotFoundException"></exception>
        /// <exception cref="IOException"></exception>
        static void CopyDirectory(string sourceDir, string destinationDir, bool recursive, bool overwrite)
        {
            // Get information about the source directory
            var dir = new DirectoryInfo(sourceDir);

            // Check if the source directory exists
            if (!dir.Exists)
                throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");

            // Cache directories before we start copying
            DirectoryInfo[] dirs = dir.GetDirectories();

            // Check for overwriting on the destination directory - my modification
            if (!overwrite && Directory.Exists(destinationDir)) 
                throw new IOException("Destination directory already exists.");

            // Create the destination directory
            Directory.CreateDirectory(destinationDir);

            // Get the files in the source directory and copy to the destination directory
            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(targetFilePath);
            }

            // If recursive and copying subdirectories, recursively call this method
            if (recursive)
            {
                foreach (DirectoryInfo subDir in dirs)
                {
                    string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                    CopyDirectory(subDir.FullName, newDestinationDir, true, overwrite);
                }
            }
        }
    }
}
