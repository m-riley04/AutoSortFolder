using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            
        }

        private void button_stop_Click(object sender, EventArgs e)
        {

        }

        private void button_selectFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                app.currentAnchor.directory = folderBrowserDialog.SelectedPath;
                textbox_folderDirectory.Text = folderBrowserDialog.SelectedPath;
            }
        }
    }

    public class App
    {
        public Anchor currentAnchor;
        public App()
        {
            currentAnchor = new Anchor();
        }
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
