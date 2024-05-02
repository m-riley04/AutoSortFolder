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
using System.Text.Json;

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

            PopulateAnchors();
            UpdateUI();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void UpdateUI()
        {
            if (app.currentAnchor == null)
            {
                ResetUI();
                return;
            }

            bool isIdle = app.currentAnchor.status == AnchorStatus.IDLE;
            bool isActive = app.currentAnchor.status == AnchorStatus.ACTIVE;

            // Update Labels
            label_status.Text = app.currentAnchor.status.ToString();
            
            // Update Buttons
            button_start.Enabled = isIdle;
            button_stop.Enabled = isActive;
            button_unsort.Enabled = isIdle;
            button_selectFolder.Enabled = isIdle;
            button_select.Enabled = (listbox_anchors.SelectedIndex != -1 && listbox_anchors.SelectedIndex != app.anchors.IndexOf(app.currentAnchor));

            // Update dropdowns
            combobox_sortingMethod.Enabled = isIdle;
            combobox_sortingMethod.SelectedIndex = (int)app.currentAnchor.method;

            // Update fields
            textbox_folderDirectory.Text = app.currentAnchor.directory;

            // Update listbox
        }

        private void ResetUI()
        {
            // Update Labels
            label_status.Text = "NONE";

            // Update Buttons
            button_start.Enabled = false;
            button_stop.Enabled = false;
            button_unsort.Enabled = false;
            button_selectFolder.Enabled = false;

            // Update dropdowns
            combobox_sortingMethod.Enabled = false;
            combobox_sortingMethod.SelectedIndex = 0;

            // Update fields
            textbox_folderDirectory.Text = "";

            // List
            listbox_anchors.Items.Clear();
            foreach (Anchor anchor in app.anchors)
            {
                if (anchor != null) listbox_anchors.Items.Add((listbox_anchors.Items.Count + 1) + ") " + anchor.directory);
            }
        }

        private void PopulateAnchors()
        {
            listbox_anchors.Items.Clear();
            foreach (Anchor anchor in app.anchors)
            {
                listbox_anchors.Items.Add((listbox_anchors.Items.Count + 1) + ") " + anchor.directory);
            }
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            app.currentAnchor.Activate();

            UpdateUI();
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            app.currentAnchor.Deactivate();

            UpdateUI();
        }

        private void button_selectFolder_Click(object sender, EventArgs e)
        {
            // Check if the anchor is set
            if (app.currentAnchor == null)
            {
                app.currentAnchor = app.anchors[0];
            }

            if (app.currentAnchor.status != AnchorStatus.IDLE) throw new Exception("Cannot change anchor point folder while sorting is in progress");

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                app.currentAnchor.directory = folderBrowserDialog.SelectedPath;
                UpdateUI();
            }
        }

        private void button_unsort_Click(object sender, EventArgs e)
        {
            app.currentAnchor.Unsort();
        }

        private void combobox_sortingMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (app.currentAnchor != null) app.currentAnchor.method = (SortingMethod)combobox_sortingMethod.SelectedIndex;
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            app.SaveAnchors();
        }

        private void button_load_Click(object sender, EventArgs e)
        {
            app.LoadAnchors();
            PopulateAnchors();
            UpdateUI();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            Anchor newAnchor = new Anchor(listbox_anchors.Items.Count + 1, "...", SortingMethod.NONE);
            app.anchors.Add(newAnchor);
            app.currentAnchor = newAnchor;
            listbox_anchors.Items.Add((listbox_anchors.Items.Count+1) + ") " + newAnchor.directory);

            this.UpdateUI();
        }

        private void button_remove_Click(object sender, EventArgs e)
        {
            int index = listbox_anchors.SelectedIndex;
            if (index != -1)
            {
                app.anchors.RemoveAt(index);
            }

            PopulateAnchors();
            UpdateUI();
        }

        private void listbox_anchors_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listbox_anchors.SelectedIndex;
            if (index != -1 && index != app.anchors.IndexOf(app.currentAnchor)) button_select.Enabled = true;
            else button_select.Enabled = false;
        }

        private void button_select_Click(object sender, EventArgs e)
        {
            if (listbox_anchors.SelectedIndex != -1) app.currentAnchor = app.anchors[listbox_anchors.SelectedIndex];
            PopulateAnchors();
            UpdateUI();

        }
    }

    public class App
    {
        public Anchor currentAnchor;
        public List<Anchor> anchors = new List<Anchor>();
        public string anchorSavePath = Directory.GetCurrentDirectory() + "\\" + "anchors.json";
        public App()
        {
            if (!File.Exists(anchorSavePath))
            {
                // Create blank anchor
                this.currentAnchor = new Anchor();
                this.anchors.Add(this.currentAnchor);

                // Save the new anchor
                this.SaveAnchors();
                return;
            }

            this.LoadAnchors();
        }

        public void SaveAnchors()
        {
            var options = new JsonSerializerOptions()
            {
                IncludeFields = true,
            };

            File.WriteAllText(anchorSavePath, JsonSerializer.Serialize(anchors, options));
        }

        public string LoadAnchors()
        {
            var options = new JsonSerializerOptions()
            {
                IncludeFields = true,
            };

            string jsonString = File.ReadAllText(this.anchorSavePath);
            this.anchors = JsonSerializer.Deserialize<List<Anchor>>(jsonString, options);
            return jsonString;
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
        DATE_MODIFIED,
        DATE_ACCESSED
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

    public class FileExtensions
    {
        public static readonly Dictionary<string, string[]> Extensions = new Dictionary<string, string[]> {
            { "text", new string[] { ".txt", ".doc", ".docx", ".rtf", ".tex", ".wpd", ".wp5" } },
            { "document", new string[] { ".pdf", ".key", ".odp", ".pps", ".ppt", ".pptx", ".potx", ".potm", ".pot", ".ppam", ".ppsm", ".ppsx" } },
            { "audio", new string[] { ".aif", ".aifc", ".aiff", ".cda", ".mid", ".midi", ".mp3", ".mpa", ".ogg", ".wav", ".wma", ".wpl", ".aac", ".adt", ".adts" } },
            { "compressed", new string[] { ".7z", ".arg", ".deb", ".pkg", ".rar", ".rpm", ".gz", ".z", ".zip" } },
            { "disc", new string[] { ".bin", ".dmg", ".iso", ".toast", ".vcd" } },
            { "data", new string[] { ".csv", ".dat", ".db", ".dbf", ".log", ".mdb", ".sav", ".sql", ".tar", ".xml", ".ab", ".accdb", ".accde", ".accdr", ".accdt" } },
            { "email", new string[] { ".email", ".eml", ".emlx", ".msg", ".oft", ".ost", ".pst", ".vcf" } },
            { "executable", new string[] { ".apk", ".bat", ".bin", ".com", ".exe", ".gadget", ".jar", ".msi", ".wsf" } },
            { "font", new string[] { ".fnt", ".fon", ".otf", ".ttf" } },
            { "image", new string[] { ".jpg", ".jpeg", ".JPG", ".JPEG", ".gif", ".bmp", ".ico", ".png", ".ps", ".svg", ".tif", ".tiff" } },
            { "internet", new string[] { ".asp", ".aspx", ".cer", ".cfm", ".css", ".htm", ".html", ".js", ".jsp", ".part", ".rss", ".xhtml" } },
            { "programming", new string[] { ".c", ".cgi", ".pl", ".class", ".cpp", ".cs", ".h", ".java", ".php", ".py", ".sh", ".swift", ".vb" } },
            { "spreadsheet", new string[] { ".ods", ".xls", ".xlsm", ".xlt", ".xltm", ".xlsx" } },
            { "system", new string[] { ".bak", ".cab", ".cfg", ".cpl", ".cur", ".dll", ".dmp", ".drv", ".icns", ".ini", ".lnk", ".sys", ".tmp" } },
            { "video", new string[] { ".3g2", ".3gp", ".avi", ".flv", ".h264", ".m4v", ".mkv", ".mov", ".mp4", ".mpg", ".mpeg", ".rm", ".swf", ".vob", ".wmv" } },
            { "adobe", new string[] { ".ai", ".psd", ".indd", ".prproj", ".aep" } }
        };
    }

}
