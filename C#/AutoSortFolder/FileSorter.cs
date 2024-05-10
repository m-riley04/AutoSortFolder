using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSortFolder
{
    public static class FileSorter
    {

        /// <summary>
        /// Sorts a file based on it's file extension. Moves it into a folder of the extension's category
        /// </summary>
        /// <param name="path"></param>
        /// <param name="directory"></param>
        public static void SortByExtension(string path, string directory)
        {
            string name = Path.GetFileName(path);
            string extension = Path.GetExtension(path);
            string extensionCategory = "other";
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
        }

        /// <summary>
        /// Sorts a file based on the first character
        /// </summary>
        /// <param name="path"></param>
        /// <param name="directory"></param>
        public static void SortByAlphabet(string path, string directory)
        {
            string name = Path.GetFileName(path);
            char c = name[0];
            string sortedFolderPath = directory + "\\" + c;

            // Check if the directory already exists
            if (!Directory.Exists(sortedFolderPath)) Directory.CreateDirectory(sortedFolderPath);

            // Move the file to the folder
            MoveSafe(path, sortedFolderPath + "\\" + name);
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
        public static void SortByDate(string path, string directory, DateSortCategory category = DateSortCategory.CREATED, DateComponent component = DateComponent.DATE)
        {
            string fileName = Path.GetFileName(path);

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
                    folderName = date.Date.ToString();
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
            MoveSafe(path, sortedFolderPath + "\\" + fileName);
        }

        /// <summary>
        /// Safely moves a file without overwriting. If the file already exists in the directory, it tries again until it adds enough numbers to the end
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="destPath"></param>
        public static void MoveSafe(string sourcePath, string destPath)
        {
            try
            {
                File.Copy(sourceFilePath, destFilePath, false);
            } catch (IOException ex)
            {
                // Add a number to the end if theres a duplicate file
                int count = 0;
                string fileName = Path.GetFileNameWithoutExtension(destFilePath);
                string fileExtension = Path.GetExtension(destFilePath);
                string destDirPath = destFilePath.Substring(0, destFilePath.Length-(fileName + fileExtension).Length);
                string dupeFilePath;

                // Attempt to find new name
                while (true)
                {
                    dupeFilePath = destDirPath;
                    dupeFilePath += fileName + "(" + count + ")" + fileExtension;

                    // Check if the new dupe path doesn't exist
                    if (!File.Exists(dupeFilePath)) {
                        break;
                    }

                    count++;
                }

                // Copy again
                File.Copy(sourceFilePath, dupeFilePath, false);
            } finally
            {
                File.Delete(sourceFilePath); // Delete the original
            }
        }
    }
}
