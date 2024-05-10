using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSortFolder
{
    public enum AnchorStatus
    {
        IDLE,
        ACTIVE,
        ERROR
    }
    public enum SortingMethod
    {
        NONE,
        EXTENSION,
        ALPHABETICAL,
        DATE_CREATED,
        DATE_MODIFIED,
        DATE_ACCESSED
    }

    public class Anchor
    {
        public int id;
        public string directory;
        public AnchorStatus status;
        public SortingMethod method;
        public bool sorted;

        private string[] filePaths;
        private string[] folderPaths;

        public Anchor()
        {
            this.id = 0;
            this.directory = "";
            this.status = AnchorStatus.IDLE;
            this.method = SortingMethod.NONE;
            this.sorted = false;
        }

        public Anchor(int id, string directory, SortingMethod method, bool sorted)
        {
            this.id = id;
            this.directory = directory;
            this.status = AnchorStatus.IDLE;
            this.method = method;
            this.sorted = sorted;
        }

        public void Activate()
        {
            this.status = AnchorStatus.ACTIVE;
        }

        public void Deactivate()
        {
            this.status = AnchorStatus.IDLE;
        }

        /// <summary>
        /// Sorts the anchor based on the set sorting method
        /// </summary>
        /// <param name="progressReporter"></param>
        /// <exception cref="DirectoryNotFoundException"></exception>
        public void Sort(Action<int> progressReporter)
        {
            // Check if the anchor directory exists
            if (!Directory.Exists(this.directory)) throw new DirectoryNotFoundException();

            // Get current files
            this.filePaths = Directory.GetFiles(this.directory);
            this.folderPaths = Directory.GetDirectories(this.directory);
            IEnumerable<string> allPaths = this.filePaths.Concat(this.folderPaths);

            // File progress reporter
            int totalFiles = allPaths.Count();
            int processedFiles = 0;

            // Go through each file
            foreach (string path in allPaths)
            {
                // Select the sorting method
                switch (this.method)
                {
                    case SortingMethod.NONE:
                        throw new ArgumentNullException("No sorting method selected");

                    case SortingMethod.EXTENSION:
                        FileSorter.SortByExtension(path, this.directory);
                        break;

                    case SortingMethod.ALPHABETICAL:
                        FileSorter.SortByAlphabet(path, this.directory);
                        break;

                    case SortingMethod.DATE_CREATED:
                        FileSorter.SortByDate(path, this.directory, FileSorter.DateSortCategory.CREATED);
                        break;

                    case SortingMethod.DATE_MODIFIED:
                        FileSorter.SortByDate(path, this.directory, FileSorter.DateSortCategory.MODIFIED);
                        break;

                    case SortingMethod.DATE_ACCESSED:
                        FileSorter.SortByDate(path, this.directory, FileSorter.DateSortCategory.ACCESSED);
                        break;

                    default:
                        throw new ArgumentNullException("No sorting method selected");
                }

                // Increment the number of processed files
                processedFiles++;
                progressReporter((processedFiles * 100) / totalFiles);
            }

            // Set sorted
            this.sorted = true;

            // Get the current folders in the directories
            this.folderPaths = Directory.GetDirectories(this.directory);
        }

        /// <summary>
        /// Unsorts a main directory by moving all files out of each subdirectory
        /// </summary>
        /// <param name="progressReporter"></param>
        /// <exception cref="DirectoryNotFoundException"></exception>
        public void Unsort(Action<int> progressReporter)
        {
            // Check if the anchor directory exists
            if (!Directory.Exists(this.directory)) throw new DirectoryNotFoundException();

            // Get current files
            folderPaths = Directory.GetDirectories(this.directory);

            // File progress reporter
            int totalFolders = this.folderPaths.Length;
            int processedFiles = 0;

            // Iterate through every folder
            foreach (string folderPath in this.folderPaths)
            {
                if (!Directory.Exists(folderPath)) throw new DirectoryNotFoundException();

                // Iterate through all files within the current folder
                foreach (string filePath in Directory.GetFiles(folderPath))
                {
                    string fileName = Path.GetFileName(filePath);

                    // Move the file out of the current folder to the
                    FileSorter.MoveSafe(filePath, this.directory + "\\" + fileName);
                }

                // Delete the directory
                Directory.Delete(folderPath);

                // Increment the number of processed folders
                processedFiles++;
                progressReporter((processedFiles * 100) / totalFolders);
            }

        }
    }
}
