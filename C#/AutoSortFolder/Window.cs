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
            try
            {
                app.currentAnchor.Activate();
            } catch (Exception err)
            {
                var popup = new ErrorPopup(err.Message);
            }

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

}
