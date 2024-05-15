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
using System.Diagnostics;
using Microsoft.Win32;

namespace AutoSortFolder
{
    public partial class Window : Form
    {
       
        public App app;
        FileStream filestream;
        StreamWriter writer;
        TextWriter oldWriter = Console.Out;
        public string testPath = @"C:\Users\vex10\Desktop\testOriginal"; // Path for testing/verifying anchor sorting

        public Window()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Create the app
            app = new App();

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
                app.SaveAnchors();
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
                app.LoadAnchors();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }

            PopulateAnchors();
            UpdateAnchorListUI();
        }

        private void SaveSettings()
        {
            try
            {
                app.SaveSettings();
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
                app.LoadSettings();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }

            UpdateSettingsUI();
        }

        private void StartAnchorSorting()
        {
            if (app.currentAnchor == null) return;

            if (app.currentAnchor.method == SortingMethod.NONE)
            {
                MessageBox.Show("Please select a sorting method first!", "Sorting Method");
                return;
            }

            if (!Directory.Exists(app.currentAnchor.directory))
            {
                MessageBox.Show("The anchor directory does not exist. Please choose another directory.", "Error");
                return;
            }

            if (app.currentAnchor.sorted) UnsortAnchor(); // Unsort the folder to re-sort it

            try
            {
                if (!sorterWorker.IsBusy)
                {
                    // Start the asynchronous operation.
                    sorterWorker.RunWorkerAsync();
                    app.ActivateCurrentAnchor();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }

            UpdateCurrentAnchorUI();
            UpdateAnchorListUI();
            UpdateMenuUI();
            UpdateTrayUI();
        }

        private void StopAnchorSorting()
        {
            if (app.currentAnchor == null) return;

            try
            {
                if (sorterWorker.WorkerSupportsCancellation)
                {
                    // Cancel the asynchronous operation.
                    sorterWorker.CancelAsync();
                    app.DeactivateCurrentAnchor();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }

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
                if (app.currentAnchor == null)
                {
                    app.currentAnchor = app.anchors[0];
                }

                if (app.currentAnchor.status != AnchorStatus.IDLE) throw new Exception("Cannot change anchor point folder while sorting is in progress");

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    app.currentAnchor.directory = folderBrowserDialog.SelectedPath;
                    UpdateCurrentAnchorUI();
                    UpdateAnchorListUI();
                    UpdateMenuUI();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }

            if (app.settings.autoSave) SaveAnchors();
        }

        private void UnsortAnchor()
        {
            if (app.currentAnchor == null) return;

            try
            {
                app.currentAnchor.Unsort(progress => { });
                app.currentAnchor.sorted = false;
            }
            catch (Exception err)
            {
                MessageBox.Show($"Error: {err.Message}\nSource: {err.Source}\n Inner: {err.InnerException} \nMethod: {err.TargetSite} \nStack Trace: {err.StackTrace}");
            }

            PopulateCurrentAnchorTree();
            UpdateCurrentAnchorUI();
            UpdateAnchorListUI();
            UpdateMenuUI();
            UpdateTrayUI();

            if (app.settings.autoSave) SaveAnchors();
        }

        private void RemoveAnchor()
        {
            if (app.currentAnchor == null) return;

            try
            {
                int index = listbox_anchors.SelectedIndex;
                if (index != -1)
                {
                    app.anchors.RemoveAt(index);
                }
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

            if (app.settings.autoSave) SaveAnchors();
        }

        private void AddAnchor()
        {
            try
            {
                int index = listbox_anchors.Items.Count + 1;
                Anchor newAnchor = new Anchor(index, "New Anchor " + index, "", SortingMethod.NONE, false, new List<string>());
                app.anchors.Add(newAnchor);
                app.currentAnchor = newAnchor;
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

            if (app.settings.autoSave) SaveAnchors();
        }
        
        private void ResetBlacklist()
        {
            if (app.currentAnchor == null) return;

            app.currentAnchor.blacklist.Clear();

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
                MessageBox.Show($"Error: {ex.Message}");
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
            MessageBox.Show($"AutoSortFolder\nVersion: {app.version}\nCreator: Riley Meyerkorth", "Application Info");
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
            if (app.currentAnchor == null)
            {
                Console.WriteLine("Cannot populate current anchor tree: current anchor is null");
                return;
            }

            // Validate the path
            if (!Directory.Exists(app.currentAnchor.directory))
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
                treeCurrentAnchor.Nodes.AddRange(GetDirectoryNodes(app.currentAnchor.directory));
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

            if (app.currentAnchor != null)
            {
                isIdle = app.currentAnchor.status == AnchorStatus.IDLE;
                isActive = app.currentAnchor.status == AnchorStatus.ACTIVE;
                isSorted = app.currentAnchor.sorted;
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

            if (app.currentAnchor != null)
            {
                isIdle = app.currentAnchor.status == AnchorStatus.IDLE;
                isActive = app.currentAnchor.status == AnchorStatus.ACTIVE;
                isSorted = app.currentAnchor.sorted;
            }

            startSortingToolStripMenuItem.Enabled = isIdle;
            stopAllSortingToolStripMenuItem.Enabled = isActive;
        }

        private void UpdateCurrentAnchorUI()
        {
            if (app.currentAnchor == null) return;

            // Initialize states
            bool isIdle     = app.currentAnchor.status == AnchorStatus.IDLE;
            bool isActive   = app.currentAnchor.status == AnchorStatus.ACTIVE;
            bool isSorted   = app.currentAnchor.sorted;

            // Update Labels
            label_status.Text               = app.currentAnchor.status.ToString();
            labelSortedValue.Text           = isSorted ? "Yes" : "No";

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
            combobox_sortingMethod.SelectedIndex    = (int)app.currentAnchor.method;

            // Update fields
            textbox_folderDirectory.Text    = app.currentAnchor.directory;
            textboxAnchorName.Text          = app.currentAnchor.name;
            textboxAnchorName.Enabled       = isIdle;
            textbox_folderDirectory.Enabled = isIdle;

            // Update list
            listBoxBlacklist.Items.Clear();
            listBoxBlacklist.Items.AddRange(app.currentAnchor.blacklist.ToArray());

            // Update tree
            PopulateCurrentAnchorTree();
        }

        private void UpdateSettingsUI()
        {
            if (app.settings == null) return;

            checkboxBackgroundSorting.Checked     = app.settings.backgroundSorting;
            checkboxAutoSave.Checked        = app.settings.autoSave;
            checkboxAutorun.Checked         = app.settings.autorun;
            checkboxDebug.Checked = app.settings.debug;
        }

        private void UpdateAnchorListUI()
        {
            if (app.currentAnchor == null) return;
            bool isIdle = app.currentAnchor.status == AnchorStatus.IDLE;
            listbox_anchors.Enabled = isIdle;
            button_add.Enabled = isIdle;
            button_remove.Enabled = isIdle;
        }

        private void PopulateAnchors()
        {
            listbox_anchors.Items.Clear();
            foreach (Anchor anchor in app.anchors)
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

        // Settings Page
        private void buttonApply_Click(object sender, EventArgs e)
        {
            // Set all the states
            app.settings.backgroundSorting = checkboxBackgroundSorting.Checked;
            app.settings.autoSave = checkboxAutoSave.Checked;
            app.settings.autorun = checkboxAutorun.Checked;

            // Change registry value
            if (app.settings.autorun) app.regKey.SetValue("AutoSortFolder", Application.ExecutablePath);
            else app.regKey.DeleteValue("AutoSortFolder", false);

            SaveSettings();
        }

        private void buttonResetToDefault_Click(object sender, EventArgs e)
        {
            DialogResult prompt = MessageBox.Show("Are you sure you want to reset settings?", "Confirm", MessageBoxButtons.YesNo);
            if (prompt == DialogResult.Yes)
            {
                app.ResetSettings();
                UpdateSettingsUI();
            }
        }
        
        private void buttonOpenDirectory_Click(object sender, EventArgs e)
        {
            if (app.currentAnchor == null) return;

            string dir = app.currentAnchor.directory;
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
            if (app.currentAnchor != null) app.currentAnchor.method = (SortingMethod)combobox_sortingMethod.SelectedIndex;
            if (app.settings.autoSave) SaveAnchors();
        }

        private void listboxAnchors_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listbox_anchors.SelectedIndex != -1) app.currentAnchor = app.anchors[listbox_anchors.SelectedIndex];
                UpdateCurrentAnchorUI();
                UpdateMenuUI();
                UpdateTrayUI();
            } catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }
        }

        private void textboxAnchorName_TextChanged(object sender, EventArgs e)
        {
            if (app.currentAnchor == null) return;
            app.currentAnchor.name = textboxAnchorName.Text;

            UpdateAnchorListUI();
            PopulateAnchors();
        }
        #endregion

        #region Background Worker Methods
        private void sorterWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int anchorRefreshTime = 1000;
            BackgroundWorker worker = sender as BackgroundWorker;

            do
            {
                app.currentAnchor.Sort(
                    progress =>
                    {
                        worker.ReportProgress(progress);
                    });
                if (app.settings.backgroundSorting) System.Threading.Thread.Sleep(anchorRefreshTime);
            } while (!worker.CancellationPending && app.settings.backgroundSorting);

            if (worker.CancellationPending) e.Cancel = true;
        }

        private void sorterWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarSorting.Value = e.ProgressPercentage;
        }

        private void sorterWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                MessageBox.Show("Sorting was canceled!");
            }
            else if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message, "Sorting Error");
            }
            else
            {
                //MessageBox.Show("Sorting is complete.");
            }

            Console.WriteLine($"Folder Count Match: {AnchorVerifier.FoldersMatch(app.currentAnchor.directory, testPath, true)}");
            app.currentAnchor.Deactivate();
            UpdateCurrentAnchorUI();
            UpdateAnchorListUI();

            if (app.settings.autoSave) this.SaveAnchors();
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
            // Open the GitHub repo for the app
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
        
    }
}
