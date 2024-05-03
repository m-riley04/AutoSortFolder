namespace AutoSortFolder
{
    partial class Window
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textbox_folderDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_selectFolder = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.label_status = new System.Windows.Forms.Label();
            this.button_start = new System.Windows.Forms.Button();
            this.button_stop = new System.Windows.Forms.Button();
            this.button_unsort = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.combobox_sortingMethod = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_save = new System.Windows.Forms.Button();
            this.button_load = new System.Windows.Forms.Button();
            this.listbox_anchors = new System.Windows.Forms.ListBox();
            this.button_add = new System.Windows.Forms.Button();
            this.button_remove = new System.Windows.Forms.Button();
            this.button_select = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.progressBarSorting = new System.Windows.Forms.ProgressBar();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sorterWorker = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // textbox_folderDirectory
            // 
            this.textbox_folderDirectory.Location = new System.Drawing.Point(58, 8);
            this.textbox_folderDirectory.Name = "textbox_folderDirectory";
            this.textbox_folderDirectory.ReadOnly = true;
            this.textbox_folderDirectory.Size = new System.Drawing.Size(275, 20);
            this.textbox_folderDirectory.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Directory";
            // 
            // button_selectFolder
            // 
            this.button_selectFolder.Location = new System.Drawing.Point(339, 7);
            this.button_selectFolder.Name = "button_selectFolder";
            this.button_selectFolder.Size = new System.Drawing.Size(103, 23);
            this.button_selectFolder.TabIndex = 3;
            this.button_selectFolder.Text = "Select Folder";
            this.button_selectFolder.UseVisualStyleBackColor = true;
            this.button_selectFolder.Click += new System.EventHandler(this.button_selectFolder_Click);
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.Location = new System.Drawing.Point(11, 150);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(23, 13);
            this.label_status.TabIndex = 4;
            this.label_status.Text = "idle";
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(3, 3);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(59, 23);
            this.button_start.TabIndex = 5;
            this.button_start.Text = "Start";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // button_stop
            // 
            this.button_stop.Enabled = false;
            this.button_stop.Location = new System.Drawing.Point(68, 3);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(59, 23);
            this.button_stop.TabIndex = 6;
            this.button_stop.Text = "Stop";
            this.button_stop.UseVisualStyleBackColor = true;
            this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
            // 
            // button_unsort
            // 
            this.button_unsort.Location = new System.Drawing.Point(133, 3);
            this.button_unsort.Name = "button_unsort";
            this.button_unsort.Size = new System.Drawing.Size(59, 23);
            this.button_unsort.TabIndex = 7;
            this.button_unsort.Text = "Unsort";
            this.button_unsort.UseVisualStyleBackColor = true;
            this.button_unsort.Click += new System.EventHandler(this.button_unsort_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_start);
            this.panel1.Controls.Add(this.button_unsort);
            this.panel1.Controls.Add(this.button_stop);
            this.panel1.Location = new System.Drawing.Point(266, 217);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(197, 31);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.textbox_folderDirectory);
            this.panel2.Controls.Add(this.button_selectFolder);
            this.panel2.Location = new System.Drawing.Point(8, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(449, 38);
            this.panel2.TabIndex = 9;
            // 
            // combobox_sortingMethod
            // 
            this.combobox_sortingMethod.FormattingEnabled = true;
            this.combobox_sortingMethod.Items.AddRange(new object[] {
            "None",
            "Extension",
            "Alphabetical",
            "Date Created",
            "Date Modified",
            "Date Accessed"});
            this.combobox_sortingMethod.Location = new System.Drawing.Point(11, 97);
            this.combobox_sortingMethod.Name = "combobox_sortingMethod";
            this.combobox_sortingMethod.Size = new System.Drawing.Size(315, 21);
            this.combobox_sortingMethod.TabIndex = 10;
            this.combobox_sortingMethod.SelectedIndexChanged += new System.EventHandler(this.combobox_sortingMethod_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sorting Method";
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(245, 196);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(59, 23);
            this.button_save.TabIndex = 8;
            this.button_save.Text = "Save";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // button_load
            // 
            this.button_load.Location = new System.Drawing.Point(245, 225);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(59, 23);
            this.button_load.TabIndex = 11;
            this.button_load.Text = "Load";
            this.button_load.UseVisualStyleBackColor = true;
            this.button_load.Click += new System.EventHandler(this.button_load_Click);
            // 
            // listbox_anchors
            // 
            this.listbox_anchors.FormattingEnabled = true;
            this.listbox_anchors.Location = new System.Drawing.Point(3, 23);
            this.listbox_anchors.Name = "listbox_anchors";
            this.listbox_anchors.Size = new System.Drawing.Size(236, 225);
            this.listbox_anchors.TabIndex = 12;
            this.listbox_anchors.SelectedIndexChanged += new System.EventHandler(this.listbox_anchors_SelectedIndexChanged);
            // 
            // button_add
            // 
            this.button_add.Location = new System.Drawing.Point(245, 23);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(59, 23);
            this.button_add.TabIndex = 13;
            this.button_add.Text = "Add";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // button_remove
            // 
            this.button_remove.Location = new System.Drawing.Point(245, 52);
            this.button_remove.Name = "button_remove";
            this.button_remove.Size = new System.Drawing.Size(59, 23);
            this.button_remove.TabIndex = 14;
            this.button_remove.Text = "Remove";
            this.button_remove.UseVisualStyleBackColor = true;
            this.button_remove.Click += new System.EventHandler(this.button_remove_Click);
            // 
            // button_select
            // 
            this.button_select.Location = new System.Drawing.Point(245, 81);
            this.button_select.Name = "button_select";
            this.button_select.Size = new System.Drawing.Size(59, 23);
            this.button_select.TabIndex = 15;
            this.button_select.Text = "Select";
            this.button_select.UseVisualStyleBackColor = true;
            this.button_select.Click += new System.EventHandler(this.button_select_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.button_add);
            this.panel3.Controls.Add(this.button_load);
            this.panel3.Controls.Add(this.button_select);
            this.panel3.Controls.Add(this.button_save);
            this.panel3.Controls.Add(this.listbox_anchors);
            this.panel3.Controls.Add(this.button_remove);
            this.panel3.Location = new System.Drawing.Point(12, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(309, 251);
            this.panel3.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Anchor Points";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.progressBarSorting);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.combobox_sortingMethod);
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Controls.Add(this.label_status);
            this.panel4.Location = new System.Drawing.Point(322, 12);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(466, 251);
            this.panel4.TabIndex = 17;
            // 
            // progressBarSorting
            // 
            this.progressBarSorting.Location = new System.Drawing.Point(14, 220);
            this.progressBarSorting.Name = "progressBarSorting";
            this.progressBarSorting.Size = new System.Drawing.Size(96, 23);
            this.progressBarSorting.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 201);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Progress";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Status";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Current Anchor Point";
            // 
            // sorterWorker
            // 
            this.sorterWorker.WorkerReportsProgress = true;
            this.sorterWorker.WorkerSupportsCancellation = true;
            this.sorterWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.sorterWorker_DoWork);
            this.sorterWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.sorterWorker_ProgressChanged);
            this.sorterWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.sorterWorker_RunWorkerCompleted);
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 270);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Window";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "AutoSortFolder";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textbox_folderDirectory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_selectFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Button button_stop;
        private System.Windows.Forms.Button button_unsort;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox combobox_sortingMethod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Button button_load;
        private System.Windows.Forms.ListBox listbox_anchors;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Button button_remove;
        private System.Windows.Forms.Button button_select;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.ComponentModel.BackgroundWorker sorterWorker;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ProgressBar progressBarSorting;
    }
}

