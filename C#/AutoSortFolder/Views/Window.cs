using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace AutoSortFolder
{
    public partial class Window : Form
    {
       
        public Controller controller;
        FileStream filestream;
        StreamWriter writer;
        TextWriter oldWriter = Console.Out;
        public readonly string testPath = @"C:\Users\vex10\Desktop\testOriginal"; // Path for testing/verifying anchor sorting

        public Window()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Create the controller
            controller = new Controller();

            InitializeUI();
            PopulateAnchors();
            UpdateSettingsUI();
            UpdateMenuUI();
            UpdateTrayUI();
        }

        #region High-Level Functionality Methods
        private void SaveAnchors()
        {
            try
            {
                controller.SaveAnchors();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }
        }

        private void LoadAnchors()
        {
            try
            {
                controller.LoadAnchors();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }

            PopulateAnchors();
            UpdateAnchorListUI();
            UpdateCurrentAnchorUI();
        }

        private void SaveSettings()
        {
            try
            {
                controller.SaveSettings();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }
        }

        private void LoadSettings()
        {
            try
            {
                controller.LoadSettings();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }

            UpdateSettingsUI();
        }

        private void StartAnchorSorting()
        {
            if (controller.settings.autoSave) SaveAnchors();

            // Functionality
            try
            {
                // Checking for nullities
                if (controller.currentAnchor == null) return;
                if (controller.currentAnchor.method == SortingMethod.NONE) throw new Exception("No sorting method selected");
                if (!Directory.Exists(controller.currentAnchor.directory)) throw new DirectoryNotFoundException("The anchor directory does not exist. Please choose another directory.");

                if (controller.currentAnchor.sorted) UnsortAnchor(); // Unsort the folder to re-sort it

                if (!sorterWorker.IsBusy)
                {
                    // Start the asynchronous operation.
                    sorterWorker.RunWorkerAsync();
                    controller.ActivateCurrentAnchor();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }

            // Update UI
            UpdateCurrentAnchorUI();
            UpdateAnchorListUI();
            UpdateMenuUI();
            UpdateTrayUI();
        }

        private void StopAnchorSorting()
        {
            try
            {
                if (controller.currentAnchor == null) throw new NullReferenceException("No anchor is currently selected.");

                if (sorterWorker.WorkerSupportsCancellation)
                {
                    // Cancel the asynchronous operation.
                    sorterWorker.CancelAsync();
                    controller.DeactivateCurrentAnchor();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }

            if (controller.settings.autoSave) SaveAnchors();

            UpdateCurrentAnchorUI();
            UpdateAnchorListUI();
            UpdateMenuUI();
            UpdateTrayUI();
        }

        private void SelectAnchorFolder()
        {
            try
            {
                // Check if the anchor is set
                if (controller.currentAnchor == null) throw new NullReferenceException("No anchor is currently selected.");

                if (controller.currentAnchor.status != AnchorStatus.IDLE) throw new Exception("Cannot change anchor point folder while sorting is in progress");

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    controller.currentAnchor.directory = folderBrowserDialog.SelectedPath;
                    UpdateCurrentAnchorUI();
                    UpdateAnchorListUI();
                    UpdateMenuUI();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }

            if (controller.settings.autoSave) SaveAnchors();
        }

        private void UnsortAnchor()
        {
            try
            {
                if (controller.currentAnchor == null) throw new NullReferenceException("No anchor is currently selected.");
                if (!Directory.Exists(controller.currentAnchor.directory)) throw new DirectoryNotFoundException("The anchor directory does not exist. Please choose another directory.");

                controller.currentAnchor.Unsort(progress => { });
                controller.currentAnchor.sorted = false;
            }
            catch (Exception err)
            {
                MessageBox.Show($"{err.Message}", "Error");
            }

            PopulateCurrentAnchorTree();
            UpdateCurrentAnchorUI();
            UpdateAnchorListUI();
            UpdateMenuUI();
            UpdateTrayUI();

            if (controller.settings.autoSave) SaveAnchors();
        }

        private void RemoveAnchor()
        {
            try
            {
                if (controller.currentAnchor == null) throw new NullReferenceException("No anchor is currently selected.");
                int index = listbox_anchors.SelectedIndex;
                if (index != -1) controller.anchors.RemoveAt(index);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }

            PopulateAnchors();
            UpdateAnchorListUI();
            UpdateCurrentAnchorUI();
            UpdateMenuUI();
            UpdateTrayUI();

            if (controller.settings.autoSave) SaveAnchors();
        }

        private void AddAnchor()
        {
            try
            {
                int index = listbox_anchors.Items.Count + 1;
                Anchor newAnchor = new Anchor(index, "New Anchor " + index, "", SortingMethod.NONE, false, new List<string>());
                controller.anchors.Add(newAnchor);
                controller.currentAnchor = newAnchor;
                listbox_anchors.Items.Add(newAnchor.id + ") " + newAnchor.directory);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }

            UpdateAnchorListUI();
            UpdateCurrentAnchorUI();
            UpdateMenuUI();
            UpdateTrayUI();

            if (controller.settings.autoSave) SaveAnchors();
        }
        
        private void ResetBlacklist()
        {
            try
            {
                if (controller.currentAnchor == null) throw new NullReferenceException("No anchor is currently selected.");

                controller.currentAnchor.blacklist.Clear();
            } 
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }
            

            UpdateCurrentAnchorUI();
        }

        private void OpenURLInBrowser(string url)
        {
            try
            {
                System.Diagnostics.Process.Start(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error");
            }
        }

        private void ExitProgram()
        {
            this.Close();
        }

        private void RestartProgram()
        {
            Application.Restart();
        }

        private void ShowApplicationInfo()
        {
            MessageBox.Show($"AutoSortFolder\nVersion: {this.ProductVersion}\nCreator: Riley Meyerkorth", "Application Info");
        }

        private void ApplyAnchorName()
        {
            try
            {
                if (controller.currentAnchor == null) throw new NullReferenceException("No anchor is currently selected.");
                controller.currentAnchor.name = textboxAnchorName.Text;

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }

            PopulateAnchors();
            UpdateAnchorListUI();
        }

        #endregion

        #region UI Update Methods

        private void InitializeUI()
        {
            // Update Buttons
            button_start.Enabled = false;
            button_stop.Enabled = false;
            button_unsort.Enabled = false;
            button_selectFolder.Enabled = false;
            buttonResetBlacklist.Enabled = false;
            buttonOpenDirectory.Enabled = false;
            button_remove.Enabled = false;

            // Update dropdowns
            combobox_sortingMethod.Enabled = false;

            // Update textboxes
            textboxAnchorName.Enabled = false;

            // Update menu items
            removeToolStripMenuItem.Enabled = false;
            startToolStripMenuItem.Enabled = false;
            stopToolStripMenuItem.Enabled = false;
            unsortToolStripMenuItem.Enabled = false;

            // Tray icon items
            startSortingToolStripMenuItem.Enabled = false;
            stopAllSortingToolStripMenuItem.Enabled = false;
        }

        private void PopulateCurrentAnchorTree()
        {
            // Validate the current anchor
            if (controller.currentAnchor == null)
            {
                Console.WriteLine("Cannot populate current anchor tree: current anchor is null");
                return;
            }

            // Validate the path
            if (!Directory.Exists(controller.currentAnchor.directory))
            {
                treeCurrentAnchor.Nodes.Clear();
                return;
            }

            // Clear the current tree
            treeCurrentAnchor.Nodes.Clear();

            // Update nodes with current directory
            try
            {
                treeCurrentAnchor.BeginUpdate();
                treeCurrentAnchor.Nodes.AddRange(GetDirectoryNodes(controller.currentAnchor.directory));
            } catch (Exception ex)
            {
                Console.WriteLine("Error occurred during populating current anchor's directory tree: " + ex.Message);
            } finally
            {
                treeCurrentAnchor.EndUpdate();
            }

            // Automatically open the tree
            treeCurrentAnchor.Nodes[0].Expand();
        }

        private TreeNode[] GetDirectoryNodes(string directory, bool includeRoot = true)
        {
            List<TreeNode> nodes = new List<TreeNode>();

            if (includeRoot) nodes.Add(new TreeNode(Path.GetFileName(directory)));

            // Populate with all directories
            int i = 0;
            foreach (string folderPath in Directory.GetDirectories(directory))
            {
                string name = Path.GetFileName(folderPath);
                if (includeRoot) nodes[0].Nodes.Add(name);
                else nodes.Add(new TreeNode(name));

                TreeNode subnode;

                if (includeRoot) subnode = nodes[0].Nodes[i];
                else subnode = nodes[i];

                // Recursively go through the sub-node
                subnode.Nodes.AddRange(GetDirectoryNodes(folderPath, false));
                i++;
            }

            // Populate with all files
            foreach (string filePath in Directory.GetFiles(directory))
            {
                string name = Path.GetFileName(filePath);
                if (includeRoot) nodes[0].Nodes.Add(name);
                else nodes.Add(new TreeNode(name));
            }

            // Return the nodes array
            return nodes.ToArray();
        }

        private void UpdateMenuUI()
        {
            bool isIdle = false;
            bool isActive = false;
            bool isSorted = false;

            if (controller.currentAnchor != null)
            {
                isIdle = controller.currentAnchor.status == AnchorStatus.IDLE;
                isActive = controller.currentAnchor.status == AnchorStatus.ACTIVE;
                isSorted = controller.currentAnchor.sorted;
            }

            addToolStripMenuItem.Enabled = isIdle;
            removeToolStripMenuItem.Enabled = isIdle;
            startToolStripMenuItem.Enabled = isIdle;
            stopToolStripMenuItem.Enabled = isActive;
            startToolStripMenuItem.Text = (isSorted && isIdle) ? "Resort" : "Start sorting";
            unsortToolStripMenuItem.Enabled = isSorted && isIdle;
        }

        private void UpdateTrayUI()
        {
            bool isIdle = false;
            bool isActive = false;
            bool isSorted = false;

            if (controller.currentAnchor != null)
            {
                isIdle = controller.currentAnchor.status == AnchorStatus.IDLE;
                isActive = controller.currentAnchor.status == AnchorStatus.ACTIVE;
                isSorted = controller.currentAnchor.sorted;
            }

            startSortingToolStripMenuItem.Enabled = isIdle;
            stopAllSortingToolStripMenuItem.Enabled = isActive;
        }

        private void UpdateCurrentAnchorUI()
        {
            if (controller.currentAnchor == null) return;

            // Initialize states
            bool isIdle     = controller.currentAnchor.status == AnchorStatus.IDLE;
            bool isActive   = controller.currentAnchor.status == AnchorStatus.ACTIVE;
            bool isSorted   = controller.currentAnchor.sorted;

            // Update Labels
            label_status.Text               = controller.currentAnchor.status.ToString();
            labelSorted.Text                = isSorted ? "SORTED" : "NOT SORTED";

            // Update Buttons
            button_start.Enabled            = isIdle;
            button_stop.Enabled             = isActive;
            button_unsort.Enabled           = isSorted && isIdle;
            button_selectFolder.Enabled     = isIdle;
            button_start.Text               = (isSorted && isIdle) ? "Resort" : "Start";
            buttonResetBlacklist.Enabled    = isIdle;
            buttonOpenDirectory.Enabled     = isIdle;

            // Update dropdowns
            combobox_sortingMethod.Enabled          = isIdle;
            combobox_sortingMethod.SelectedIndex    = (int)controller.currentAnchor.method;

            // Update fields
            textbox_folderDirectory.Text    = controller.currentAnchor.directory;
            textboxAnchorName.Text          = controller.currentAnchor.name;
            textboxAnchorName.Enabled       = isIdle;
            textbox_folderDirectory.Enabled = isIdle;

            // Update list
            listBoxBlacklist.Items.Clear();
            listBoxBlacklist.Items.AddRange(controller.currentAnchor.blacklist.ToArray());

            // Update tree
            PopulateCurrentAnchorTree();
        }

        private void UpdateSettingsUI()
        {
            if (controller.settings == null) return;

            checkboxBackgroundSorting.Checked     = controller.settings.backgroundSorting;
            checkboxAutoSave.Checked        = controller.settings.autoSave;
            checkboxAutorun.Checked         = controller.settings.autorun;
            checkboxDebug.Checked = controller.settings.debug;
        }

        private void UpdateAnchorListUI()
        {
            if (controller.currentAnchor == null) return;
            bool isIdle = controller.currentAnchor.status == AnchorStatus.IDLE;
            listbox_anchors.Enabled = isIdle;
            button_add.Enabled = isIdle;
            button_remove.Enabled = isIdle;
        }

        private void PopulateAnchors()
        {
            listbox_anchors.Items.Clear();
            foreach (Anchor anchor in controller.anchors)
            {
                listbox_anchors.Items.Add((listbox_anchors.Items.Count + 1) + ") " + anchor.name);
            }
        }

        #endregion

        #region Main Window Methods

        

        #endregion

        #region Button Methods
        // Home Page
        private void buttonStart_Click(object sender, EventArgs e)
        {
            StartAnchorSorting();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            StopAnchorSorting();
        }

        private void buttonSelectFolder_Click(object sender, EventArgs e)
        {
            SelectAnchorFolder();
        }

        private void buttonUnsort_Click(object sender, EventArgs e)
        {
            UnsortAnchor();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveAnchors();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            LoadAnchors();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddAnchor();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            RemoveAnchor();
        }

        private void ApplySettings()
        {
            // Set all the states
            controller.settings.backgroundSorting = checkboxBackgroundSorting.Checked;
            controller.settings.autoSave = checkboxAutoSave.Checked;
            controller.settings.autorun = checkboxAutorun.Checked;

            // Change registry value
            if (controller.settings.autorun) controller.regKey.SetValue("AutoSortFolder", Application.ExecutablePath.ToString());
            else controller.regKey.DeleteValue("AutoSortFolder", false);

            SaveSettings();
        }

        private void ResetSettings()
        {
            controller.ResetSettings();
            UpdateSettingsUI();
        }

        // Settings Page
        private void buttonApply_Click(object sender, EventArgs e)
        {
            ApplySettings();
        }

        private void buttonResetToDefault_Click(object sender, EventArgs e)
        {
            DialogResult prompt = MessageBox.Show("Are you sure you want to reset settings?", "Confirm", MessageBoxButtons.YesNo);
            if (prompt == DialogResult.Yes) ResetSettings();
        }
        
        private void buttonOpenDirectory_Click(object sender, EventArgs e)
        {
            if (controller.currentAnchor == null) return;

            string dir = controller.currentAnchor.directory;
            if (Directory.Exists(dir)) Process.Start(dir);
        }

        private void buttonResetBlacklist_Click(object sender, EventArgs e)
        {
            ResetBlacklist();
        }

        private async void buttonCheckForUpdate_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Other Component Methods
        private void dropdownSortingMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (controller.currentAnchor != null) controller.currentAnchor.method = (SortingMethod)combobox_sortingMethod.SelectedIndex;
            if (controller.settings.autoSave) SaveAnchors();
        }

        private void listboxAnchors_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listbox_anchors.SelectedIndex != -1) controller.currentAnchor = controller.anchors[listbox_anchors.SelectedIndex];
                UpdateCurrentAnchorUI();
                UpdateMenuUI();
                UpdateTrayUI();
            } catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }
        }

        private void textboxAnchorName_Leave(object sender, EventArgs e)
        {
            ApplyAnchorName();
        }

        #endregion

        #region Background Worker Methods
        private void sorterWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int anchorRefreshTime = 1000;
            BackgroundWorker worker = sender as BackgroundWorker;

            do
            {
                if (controller.currentAnchor == null) throw new ArgumentNullException("Current anchor doesn't exist"); // Check if the current anchor doesn't exist
                if (!Directory.Exists(controller.currentAnchor.directory)) throw new DirectoryNotFoundException("Anchor directory does not exist"); // Check if the directory doesn't exist
                controller.currentAnchor.Sort(
                    progress =>
                    {
                        worker.ReportProgress(progress);
                    });
                if (controller.settings.backgroundSorting) System.Threading.Thread.Sleep(anchorRefreshTime);
            } while (!worker.CancellationPending && controller.settings.backgroundSorting);

            if (worker.CancellationPending) e.Cancel = true;
        }

        private void sorterWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarSorting.Value = e.ProgressPercentage;
        }

        private void sorterWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled) MessageBox.Show("Sorting was canceled!");
            else if (e.Error != null) MessageBox.Show($"Sorting has stopped due to error: {e.Error.Message}", "Sorting Error");
            else;//MessageBox.Show("Sorting is complete.");

            if (e.Error == null) Console.WriteLine($"Folder Count Match: {AnchorVerifier.FoldersMatch(controller.currentAnchor.directory, testPath, true)}");
            controller.currentAnchor.Deactivate();

            // Update the UI
            UpdateCurrentAnchorUI();
            UpdateMenuUI();
            UpdateTrayUI();
            UpdateAnchorListUI();

            // Save anchor state
            if (controller.settings.autoSave) this.SaveAnchors();
        }
        #endregion

        #region Menubar
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAnchors();
        }

        private void loadAnchorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadAnchors();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddAnchor();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveAnchor();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartAnchorSorting();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopAnchorSorting();
        }

        private void unsortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnsortAnchor();
        }

        private void gitHubRepositoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open the GitHub repo for the controller
            string githubRepoURL = "https://github.com/m-riley04/AutoSortFolder";
            OpenURLInBrowser(githubRepoURL);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitProgram();
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RestartProgram();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowApplicationInfo();
        }

        private void startSortingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartAnchorSorting();
        }
        
        private void stopAllSortingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopAnchorSorting();
        }
        
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ExitProgram();
        }

        #endregion

        private void Window_Activated(object sender, EventArgs e)
        {
            UpdateAnchorListUI();
            UpdateCurrentAnchorUI();
            UpdateSettingsUI();
            UpdateMenuUI();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.Alt) 
            {
                // Toggle menu strip
                menuStrip.Visible = !menuStrip.Visible;


                if (menuStrip.Visible)
                {
                    menuStrip.Focus();
                    menuStrip.Items[0].Select();
                }
                else
                {
                    this.Focus();
                    this.Select();
                }

                Console.WriteLine("User opened top menu.");
            }

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            tabControlPages.SelectedIndex = 0;
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            tabControlPages.SelectedIndex = 1;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (controller.currentAnchor != null && controller.currentAnchor.status == AnchorStatus.ACTIVE)
            {
                switch (MessageBox.Show(this, "Are you sure you want to close?", "Closing", MessageBoxButtons.YesNo))
                {
                    case DialogResult.No:
                        e.Cancel = true;
                        break;
                    default:
                        // Check for any current running threads
                        if (sorterWorker.IsBusy) StopAnchorSorting();
                        break;
                }
            }
        }


    }
}
