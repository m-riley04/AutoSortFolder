using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

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
        public List<string> blacklist;

        private string[] filePaths;
        private string[] folderPaths;

        public Anchor()
        {
            this.id = 0;
            this.directory = "";
            this.status = AnchorStatus.IDLE;
            this.method = SortingMethod.NONE;
            this.sorted = false;
            this.blacklist = new List<string>();
        }

        public Anchor(int id, string directory, SortingMethod method, bool sorted, List<string> blacklist)
        {
            this.id = id;
            this.directory = directory;
            this.status = AnchorStatus.IDLE;
            this.method = method;
            this.sorted = sorted;
            this.blacklist = blacklist;
        }

        public static List<string> GenerateDefaultBlacklist()
        {
            List<string> blacklist = new List<string>();

            // Append all valid characters
            string validCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789`~!@#$%^&()_+-=[]{};',.";
            foreach (char c in validCharacters) blacklist.Add(c.ToString());
            
            // Append all extensions
            List<string> allExtensions = new List<string>();
            foreach (KeyValuePair<string, string[]> pair in FileExtensions.Extensions) foreach (string ext in pair.Value) allExtensions.Add(ext);
            blacklist.AddRange(allExtensions);

            // Append all categories
            List<string> allCategories = new List<string>();
            foreach (KeyValuePair<string, string[]> pair in FileExtensions.Extensions) allCategories.Add(pair.Key);
            blacklist.AddRange(allCategories);

            // Append specific folders/files
            blacklist.Append("other");

            // Cast to array
            return blacklist;
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

            // Create the filesorter
            FileSorter sorter = new FileSorter(this.blacklist);

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
                        sorter.SortByExtension(path, this.directory);
                        break;

                    case SortingMethod.ALPHABETICAL:
                        sorter.SortByAlphabet(path, this.directory);
                        break;

                    case SortingMethod.DATE_CREATED:
                        sorter.SortByDate(path, this.directory, FileSorter.DateSortCategory.CREATED);
                        break;

                    case SortingMethod.DATE_MODIFIED:
                        sorter.SortByDate(path, this.directory, FileSorter.DateSortCategory.MODIFIED);
                        break;

                    case SortingMethod.DATE_ACCESSED:
                        sorter.SortByDate(path, this.directory, FileSorter.DateSortCategory.ACCESSED);
                        break;

                    default:
                        throw new ArgumentNullException("No sorting method selected");
                }

                // Increment the number of processed files
                processedFiles++;
                progressReporter((processedFiles * 100) / totalFiles);
            }

            // Update the blacklist
            this.blacklist = sorter.blacklist;

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
