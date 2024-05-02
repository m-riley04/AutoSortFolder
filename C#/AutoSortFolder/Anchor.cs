using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSortFolder
{
    public class Anchor
    {
        public int id;
        public string directory;
        public AnchorStatus status;
        public SortingMethod method;

        private string[] filePaths;
        private string[] folderPaths;

        public Anchor()
        {
            this.id = 0;
            this.directory = "...";
            this.status = AnchorStatus.IDLE;
            this.method = SortingMethod.NONE;
        }

        public Anchor(int id, string directory, SortingMethod method)
        {
            this.id = id;
            this.directory = directory;
            this.status = AnchorStatus.IDLE;
            this.method = method;
        }

        /// <summary>
        /// Activates the anchor's sorting method
        /// </summary>
        public void Activate()
        {
            this.status = AnchorStatus.ACTIVE;
            this.Sort();
        }

        /// <summary>
        /// Deactivates the anchor's sorting method
        /// </summary>
        public void Deactivate()
        {
            this.status = AnchorStatus.IDLE;
        }

        /// <summary>
        /// Sorts the anchor based on the set sorting method
        /// </summary>
        public void Sort()
        {
            // Check if the anchor directory exists
            if (!Directory.Exists(this.directory)) throw new DirectoryNotFoundException();

            // Get current files
            this.filePaths = Directory.GetFiles(this.directory);
            this.folderPaths = Directory.GetDirectories(this.directory);

            // Select the sorting method
            switch (this.method)
            {
                case SortingMethod.NONE:
                    throw new Exception("No sorting method selected");

                case SortingMethod.EXTENSION:
                    this.SortByExtension();
                    break;

                case SortingMethod.ALPHABETICAL:
                    this.SortByAlphabet();
                    break;

                case SortingMethod.DATE_CREATED:
                    this.SortByDateCreated();
                    break;

                case SortingMethod.DATE_MODIFIED:
                    this.SortByDateModified();
                    break;

                case SortingMethod.DATE_ACCESSED:
                    this.SortByDateAccessed();
                    break;

                default:
                    throw new Exception("No sorting method selected");
            }
        }

        private void SortByExtension()
        {
            // Initialize category
            string extensionCategory = "other";
            string folderDirectory = this.directory + "\\" + extensionCategory;

            // Iterate through all files
            foreach (string filePath in this.filePaths)
            {
                string fileName = Path.GetFileName(filePath);
                string fileExtension = Path.GetExtension(filePath);

                // Iterate through and get the category
                foreach (KeyValuePair<string, string[]> item in FileExtensions.Extensions)
                {
                    if (item.Value.Contains(fileExtension))
                    {
                        extensionCategory = item.Key;

                        // Check if the category folder isn't created
                        folderDirectory = this.directory + "\\" + extensionCategory;
                        if (!Directory.Exists(folderDirectory)) Directory.CreateDirectory(folderDirectory);

                        // Break out of the loop
                        break;
                    }
                }

                // TODO - Check if the file already exists in the destination folder

                // Move the file to the folder
                File.Move(filePath, folderDirectory + "\\" + fileName);
            }
        }

        private void SortByAlphabet()
        {
            // Iterate through all files
            foreach (string filePath in this.filePaths)
            {
                string fileName = Path.GetFileName(filePath);
                char c = fileName[0];
                string folderDirectory = this.directory + "\\" + c;

                // Check if the directory already exists
                if (!Directory.Exists(folderDirectory)) Directory.CreateDirectory(folderDirectory);

                // TODO - Check if the file already exists in the destination folder

                // Move the file to the folder
                File.Move(filePath, folderDirectory + "\\" + fileName);
            }
        }

        private void SortByDateCreated()
        {
            // Iterate through all files
            foreach (string filePath in this.filePaths)
            {
                string fileName = Path.GetFileName(filePath);
                DateTime date = File.GetCreationTime(filePath);
                string folderDirectory = this.directory + "\\" + date.Date.ToString();

                // Check if the directory already exists
                if (!Directory.Exists(folderDirectory)) Directory.CreateDirectory(folderDirectory);

                // TODO - Check if the file already exists in the destination folder

                // Move the file to the folder
                File.Move(filePath, folderDirectory + "\\" + fileName);
            }
        }

        private void SortByDateModified()
        {
            // Iterate through all files
            foreach (string filePath in this.filePaths)
            {
                string fileName = Path.GetFileName(filePath);
                DateTime date = File.GetLastWriteTime(filePath);
                string folderDirectory = this.directory + "\\" + date.Date.ToString();

                // Check if the directory already exists
                if (!Directory.Exists(folderDirectory)) Directory.CreateDirectory(folderDirectory);

                // TODO - Check if the file already exists in the destination folder

                // Move the file to the folder
                File.Move(filePath, folderDirectory + "\\" + fileName);
            }
        }

        private void SortByDateAccessed()
        {
            // Iterate through all files
            foreach (string filePath in this.filePaths)
            {
                string fileName = Path.GetFileName(filePath);
                DateTime date = File.GetLastAccessTime(filePath);
                string folderDirectory = this.directory + "\\" + date.Date.ToString();

                // Check if the directory already exists
                if (!Directory.Exists(folderDirectory)) Directory.CreateDirectory(folderDirectory);

                // TODO - Check if the file already exists in the destination folder

                // Move the file to the folder
                File.Move(filePath, folderDirectory + "\\" + fileName);
            }
        }

        public void Unsort()
        {
            if (!Directory.Exists(this.directory)) throw new DirectoryNotFoundException();

            // Get current files
            folderPaths = Directory.GetDirectories(this.directory);

            // Iterate through every folder
            foreach (string folderPath in this.folderPaths)
            {
                if (!Directory.Exists(folderPath)) throw new DirectoryNotFoundException();

                // Iterate through all files within the current folder
                foreach (string filePath in Directory.GetFiles(folderPath))
                {
                    string fileName = Path.GetFileName(filePath);

                    // Move the file out of the current folder to the
                    Console.WriteLine("From " + filePath + " to " + this.directory + "\\" + fileName);
                    File.Move(filePath, this.directory + "\\" + fileName);
                }

                // Delete the directory
                Directory.Delete(folderPath);
            }

        }
    }
}
