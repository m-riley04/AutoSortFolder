using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.IO;
using System.Drawing.Drawing2D;

namespace AutoSortFolder
{
    public partial class Window : Form
    {
        public App app;

        public Window()
        {
            InitializeComponent();

            // Create the app
            app = new App();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            app.currentAnchor.Activate();
            label_status.Text = app.currentAnchor.status.ToString();
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            app.currentAnchor.Deactivate();
            label_status.Text = app.currentAnchor.status.ToString();
        }

        private void button_selectFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                app.currentAnchor.directory = folderBrowserDialog.SelectedPath;
                textbox_folderDirectory.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void button_unsort_Click(object sender, EventArgs e)
        {
            app.currentAnchor.Unsort();
        }
    }

    public class App
    {
        public Anchor currentAnchor;
        public App()
        {
            currentAnchor = new Anchor();
        }

        public void ActivateCurrentAnchor()
        {
            currentAnchor.Activate();
        }

        public void DeactivateCurrentAnchor()
        {
            currentAnchor.Deactivate();
        }
    }

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
        DATE_UPDATED
    }

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
            this.directory = "";
            this.status = AnchorStatus.IDLE;
            this.method = SortingMethod.EXTENSION;
        }

        public Anchor(int id, string directory, SortingMethod method)
        {
            this.id = id;
            this.directory = directory;
            this.status = AnchorStatus.IDLE;
            this.method = method;
        }

        public void Activate()
        {
            this.status = AnchorStatus.ACTIVE;
            this.Sort();
        }

        public void Deactivate()
        {
            this.status = AnchorStatus.IDLE;
        }

        public void Sort()
        {
            // Check if the anchor directory exists
            if (!Directory.Exists(this.directory)) throw new DirectoryNotFoundException();

            // Get current files
            filePaths = Directory.GetFiles(this.directory);

            switch (this.method)
            {
                case SortingMethod.EXTENSION:
                    this.SortByExtension();
                    break;
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
                Console.WriteLine("From " + filePath + " to " + folderDirectory + "\\" + fileName);
                File.Move(filePath, folderDirectory + "\\" + fileName);
            }
        }

        public void Unsort()
        {
            if (!Directory.Exists(this.directory)) throw new DirectoryNotFoundException();

            // Get current files
            folderPaths = Directory.GetDirectories(this.directory);

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
