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

        public Anchor()
        {
            id = 0;
            directory = "";
        }

        public Anchor(int id, string directory)
        {
            this.id = id;
            this.directory = directory;
        }
    }
}
