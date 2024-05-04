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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Create the app
            app = new App();

            PopulateAnchors();
            UpdateUI();
        }

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

        private void buttonStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (!sorterWorker.IsBusy)
                {
                    // Start the asynchronous operation.
                    sorterWorker.RunWorkerAsync();
                    app.ActivateCurrentAnchor();
                }
            } catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }

            UpdateUI();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            try
            {
                if (sorterWorker.WorkerSupportsCancellation)
                {
                    // Cancel the asynchronous operation.
                    sorterWorker.CancelAsync();
                    app.DeactivateCurrentAnchor();
                }
            } catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }

            UpdateUI();
        }

        private void buttonSelectFolder_Click(object sender, EventArgs e)
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
            } catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }
        }

        private void buttonUnsort_Click(object sender, EventArgs e)
        {
            try
            {
                app.currentAnchor.Unsort(progress =>
                {
                    
                });
            } catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }

        }

        private void buttonSave_Click(object sender, EventArgs e)
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

        private void buttonLoad_Click(object sender, EventArgs e)
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

        private void buttonAdd_Click(object sender, EventArgs e)
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

        private void buttonRemove_Click(object sender, EventArgs e)
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
            PopulateAnchors();
            UpdateUI();
        }

        private void dropdownSortingMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (app.currentAnchor != null) app.currentAnchor.method = (SortingMethod)combobox_sortingMethod.SelectedIndex;
        }

        private void listboxAnchors_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = listbox_anchors.SelectedIndex;
                if (index != -1 && index != app.anchors.IndexOf(app.currentAnchor)) button_select.Enabled = true;
                else button_select.Enabled = false;
            } catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }
        }

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
    }
}
