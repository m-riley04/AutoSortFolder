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
        /// <param name="filePath"></param>
        /// <param name="directory"></param>
        public static void SortByExtension(string filePath, string directory)
        {
            string fileName = Path.GetFileName(filePath);
            string fileExtension = Path.GetExtension(filePath);
            string extensionCategory = "other";
            string sortedFolderPath = directory + "\\" + extensionCategory;

            // Iterate through and get the category
            foreach (KeyValuePair<string, string[]> item in FileExtensions.Extensions)
            {
                if (item.Value.Contains(fileExtension))
                {
                    extensionCategory = item.Key;

                    // Check if the category folder isn't created
                    sortedFolderPath = directory + "\\" + extensionCategory;
                    if (!Directory.Exists(sortedFolderPath)) Directory.CreateDirectory(sortedFolderPath);

                    // Break out of the loop
                    break;
                }
            }

            // Move the file to the folder
            MoveSafe(filePath, sortedFolderPath + "\\" + fileName);
        }

        /// <summary>
        /// Sorts a file based on the first character
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="directory"></param>
        public static void SortByAlphabet(string filePath, string directory)
        {
            string fileName = Path.GetFileName(filePath);
            char c = fileName[0];
            string sortedFolderPath = directory + "\\" + c;

            // Check if the directory already exists
            if (!Directory.Exists(sortedFolderPath)) Directory.CreateDirectory(sortedFolderPath);

            // Move the file to the folder
            MoveSafe(filePath, sortedFolderPath + "\\" + fileName);
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
        /// <param name="filePath"></param>
        /// <param name="directory"></param>
        public static void SortByDate(string filePath, string directory, DateSortCategory category = DateSortCategory.CREATED, DateComponent component = DateComponent.DATE)
        {
            string fileName = Path.GetFileName(filePath);

            // Get the date based on the category
            DateTime date;
            switch (category) {
                case DateSortCategory.CREATED:
                    date = File.GetCreationTime(filePath);
                    break;
                case DateSortCategory.MODIFIED:
                    date = File.GetLastWriteTime(filePath);
                    break;
                case DateSortCategory.ACCESSED:
                    date = File.GetLastAccessTime(filePath);
                    break;
                default:
                    date = File.GetCreationTime(filePath);
                    break;
            }

            // Get the date component from the date
            string folderName = "other";
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
            MoveSafe(filePath, sortedFolderPath + "\\" + fileName);
        }

        /// <summary>
        /// Safely moves a file without overwriting. If the file already exists in the directory, it tries again until it adds enough numbers to the end
        /// </summary>
        /// <param name="sourceFilePath"></param>
        /// <param name="destFilePath"></param>
        private static void MoveSafe(string sourceFilePath, string destFilePath)
        {
            try
            {
                File.Copy(sourceFilePath, destFilePath, false);
            } catch (IOException ex)
            {
                // Add a number to the end if theres a duplicate file
                int count = 0;
                string dupeFilePath;
                while (true)
                {
                    dupeFilePath = destFilePath;
                    dupeFilePath += "(" + count + ")";

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
                File.Delete(sourceFilePath);
            }
        }
    }
}
