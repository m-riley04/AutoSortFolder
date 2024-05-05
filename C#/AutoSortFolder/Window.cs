﻿using System;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AutoSortFolder
{
    public partial class Window : Form
    {
        public App app;

        public Window()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Create the app
            app = new App();

            PopulateAnchors();
            UpdateUI();
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
            UpdateUI();
        }

        private void StartAnchorSorting()
        {
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

            UpdateUI();
        }

        private void StopAnchorSorting()
        {
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

            UpdateUI();
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
                    UpdateUI();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }
        }

        private void UnsortAnchor()
        {
            try
            {
                app.currentAnchor.Unsort(progress => { });
                app.currentAnchor.sorted = false;
            }
            catch (Exception err)
            {
                MessageBox.Show($"Error: {err.Message}");
            }

            PopulateCurrentAnchorTree();
            UpdateCurrentAnchorUI();
        }

        private void RemoveAnchor()
        {
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
            UpdateUI();
        }

        private void AddAnchor()
        {
            try
            {
                Anchor newAnchor = new Anchor(listbox_anchors.Items.Count + 1, "...", SortingMethod.NONE);
                app.anchors.Add(newAnchor);
                app.currentAnchor = newAnchor;
                listbox_anchors.Items.Add((listbox_anchors.Items.Count + 1) + ") " + newAnchor.directory);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }

            this.UpdateUI();
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

        #endregion

        #region UI Update Methods

        private void PopulateCurrentAnchorTree()
        {
            if (app.currentAnchor == null) return;

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
            treeCurrentAnchor.ExpandAll();
        }

        private TreeNode[] GetDirectoryNodes(string directory, bool includeRoot = true)
        {
            List<TreeNode> nodes = new List<TreeNode>();

            if (includeRoot) nodes.Add(new TreeNode(Path.GetFileName(directory)));

            // Populate with all directories
            int i = 0;
            foreach (string folderPath in Directory.GetDirectories(directory))
            {
                Console.WriteLine(folderPath);
                string name = Path.GetFileName(folderPath);
                if (includeRoot) nodes[0].Nodes.Add(name);
                else nodes.Add(new TreeNode(name));

                TreeNode subnode;

                if (includeRoot) subnode = nodes[0].Nodes[i];
                else subnode = nodes[i];

                Console.WriteLine(folderPath);
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

        private void UpdateUI()
        {
            if (app.currentAnchor == null)
            {
                ResetUI();
                return;
            }

            UpdateCurrentAnchorUI();
        }

        private void UpdateCurrentAnchorUI()
        {
            if (app.currentAnchor == null)
            {
                //ResetUI();
                return;
            }

            bool isIdle = app.currentAnchor.status == AnchorStatus.IDLE;
            bool isActive = app.currentAnchor.status == AnchorStatus.ACTIVE;
            bool isSorted = app.currentAnchor.sorted;

            // Update Labels
            label_status.Text = app.currentAnchor.status.ToString();

            // Update Buttons
            button_start.Enabled = isIdle;
            button_stop.Enabled = isActive;
            button_unsort.Enabled = isSorted;
            button_selectFolder.Enabled = isIdle;
            //button_select.Enabled = (listbox_anchors.SelectedIndex != -1 && listbox_anchors.SelectedIndex != app.anchors.IndexOf(app.currentAnchor));

            // Update dropdowns
            combobox_sortingMethod.Enabled = isIdle;
            combobox_sortingMethod.SelectedIndex = (int)app.currentAnchor.method;

            // Update fields
            textbox_folderDirectory.Text = app.currentAnchor.directory;

            // Update tree
            PopulateCurrentAnchorTree();

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

        #endregion

        #region Button Methods
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

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            try
            {
                if (listbox_anchors.SelectedIndex != -1) app.currentAnchor = app.anchors[listbox_anchors.SelectedIndex];
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }
            UpdateCurrentAnchorUI();
        }

        #endregion

        #region Other Component Methods
        private void dropdownSortingMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (app.currentAnchor != null) app.currentAnchor.method = (SortingMethod)combobox_sortingMethod.SelectedIndex;
        }

        private void listboxAnchors_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listbox_anchors.SelectedIndex != -1) app.currentAnchor = app.anchors[listbox_anchors.SelectedIndex];
                UpdateCurrentAnchorUI();
            } catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }
        }
        #endregion

        #region Background Worker Methods
        private void sorterWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            while (!worker.CancellationPending)
            {
                app.currentAnchor.Sort(
                    progress =>
                    {
                        worker.ReportProgress(progress);
                    });
                System.Threading.Thread.Sleep(1000);
            }

            if (worker.CancellationPending)
            {
                e.Cancel = true;
            }
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
                MessageBox.Show("Sorting is complete.");
            }
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
        #endregion
    }
}
