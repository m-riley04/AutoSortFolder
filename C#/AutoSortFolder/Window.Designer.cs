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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Window));
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
            this.listbox_anchors = new System.Windows.Forms.ListBox();
            this.button_add = new System.Windows.Forms.Button();
            this.button_remove = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.listBoxBlacklist = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.labelSortedValue = new System.Windows.Forms.Label();
            this.labelSorted = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.treeCurrentAnchor = new System.Windows.Forms.TreeView();
            this.progressBarSorting = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.sorterWorker = new System.ComponentModel.BackgroundWorker();
            this.label7 = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anchorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unsortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gitHubRepositoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControlPages = new System.Windows.Forms.TabControl();
            this.pageHome = new System.Windows.Forms.TabPage();
            this.pageSettings = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.checkboxDeepSort = new System.Windows.Forms.CheckBox();
            this.buttonApply = new System.Windows.Forms.Button();
            this.buttonResetToDefault = new System.Windows.Forms.Button();
            this.checkboxAutorun = new System.Windows.Forms.CheckBox();
            this.checkboxAutoSave = new System.Windows.Forms.CheckBox();
            this.checkboxBackgroundSorting = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayIconMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.startSortingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopAllSortingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonOpenDirectory = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.tabControlPages.SuspendLayout();
            this.pageHome.SuspendLayout();
            this.pageSettings.SuspendLayout();
            this.trayIconMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // textbox_folderDirectory
            // 
            this.textbox_folderDirectory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(66)))));
            this.textbox_folderDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textbox_folderDirectory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textbox_folderDirectory.Location = new System.Drawing.Point(80, 7);
            this.textbox_folderDirectory.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textbox_folderDirectory.Name = "textbox_folderDirectory";
            this.textbox_folderDirectory.ReadOnly = true;
            this.textbox_folderDirectory.Size = new System.Drawing.Size(298, 19);
            this.textbox_folderDirectory.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Directory";
            // 
            // button_selectFolder
            // 
            this.button_selectFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(66)))));
            this.button_selectFolder.FlatAppearance.BorderSize = 0;
            this.button_selectFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_selectFolder.Location = new System.Drawing.Point(384, 6);
            this.button_selectFolder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_selectFolder.Name = "button_selectFolder";
            this.button_selectFolder.Size = new System.Drawing.Size(104, 21);
            this.button_selectFolder.TabIndex = 3;
            this.button_selectFolder.Text = "Select Folder";
            this.button_selectFolder.UseVisualStyleBackColor = false;
            this.button_selectFolder.Click += new System.EventHandler(this.buttonSelectFolder_Click);
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.Location = new System.Drawing.Point(129, 287);
            this.label_status.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(33, 12);
            this.label_status.TabIndex = 4;
            this.label_status.Text = "IDLE";
            // 
            // button_start
            // 
            this.button_start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(66)))));
            this.button_start.FlatAppearance.BorderSize = 0;
            this.button_start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_start.Location = new System.Drawing.Point(4, 3);
            this.button_start.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(69, 21);
            this.button_start.TabIndex = 5;
            this.button_start.Text = "Start";
            this.button_start.UseVisualStyleBackColor = false;
            this.button_start.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // button_stop
            // 
            this.button_stop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(66)))));
            this.button_stop.Enabled = false;
            this.button_stop.FlatAppearance.BorderSize = 0;
            this.button_stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_stop.Location = new System.Drawing.Point(79, 3);
            this.button_stop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(69, 21);
            this.button_stop.TabIndex = 6;
            this.button_stop.Text = "Stop";
            this.button_stop.UseVisualStyleBackColor = false;
            this.button_stop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // button_unsort
            // 
            this.button_unsort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(66)))));
            this.button_unsort.FlatAppearance.BorderSize = 0;
            this.button_unsort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_unsort.Location = new System.Drawing.Point(155, 3);
            this.button_unsort.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_unsort.Name = "button_unsort";
            this.button_unsort.Size = new System.Drawing.Size(69, 21);
            this.button_unsort.TabIndex = 7;
            this.button_unsort.Text = "Unsort";
            this.button_unsort.UseVisualStyleBackColor = false;
            this.button_unsort.Click += new System.EventHandler(this.buttonUnsort_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_start);
            this.panel1.Controls.Add(this.button_unsort);
            this.panel1.Controls.Add(this.button_stop);
            this.panel1.Location = new System.Drawing.Point(314, 280);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(230, 29);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonOpenDirectory);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.textbox_folderDirectory);
            this.panel2.Controls.Add(this.button_selectFolder);
            this.panel2.Location = new System.Drawing.Point(9, 21);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(524, 35);
            this.panel2.TabIndex = 9;
            // 
            // combobox_sortingMethod
            // 
            this.combobox_sortingMethod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(66)))));
            this.combobox_sortingMethod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.combobox_sortingMethod.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.combobox_sortingMethod.FormattingEnabled = true;
            this.combobox_sortingMethod.Items.AddRange(new object[] {
            "None",
            "Extension",
            "Alphabetical",
            "Date Created",
            "Date Modified",
            "Date Accessed"});
            this.combobox_sortingMethod.Location = new System.Drawing.Point(12, 90);
            this.combobox_sortingMethod.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.combobox_sortingMethod.Name = "combobox_sortingMethod";
            this.combobox_sortingMethod.Size = new System.Drawing.Size(160, 20);
            this.combobox_sortingMethod.TabIndex = 10;
            this.combobox_sortingMethod.SelectedIndexChanged += new System.EventHandler(this.dropdownSortingMethod_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 75);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sorting Method";
            // 
            // listbox_anchors
            // 
            this.listbox_anchors.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(66)))));
            this.listbox_anchors.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listbox_anchors.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.listbox_anchors.FormattingEnabled = true;
            this.listbox_anchors.ItemHeight = 12;
            this.listbox_anchors.Location = new System.Drawing.Point(4, 9);
            this.listbox_anchors.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.listbox_anchors.Name = "listbox_anchors";
            this.listbox_anchors.Size = new System.Drawing.Size(221, 288);
            this.listbox_anchors.TabIndex = 12;
            this.listbox_anchors.SelectedIndexChanged += new System.EventHandler(this.listboxAnchors_SelectedIndexChanged);
            // 
            // button_add
            // 
            this.button_add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(66)))));
            this.button_add.FlatAppearance.BorderSize = 0;
            this.button_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_add.Location = new System.Drawing.Point(232, 9);
            this.button_add.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(69, 21);
            this.button_add.TabIndex = 13;
            this.button_add.Text = "Add";
            this.button_add.UseVisualStyleBackColor = false;
            this.button_add.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // button_remove
            // 
            this.button_remove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(66)))));
            this.button_remove.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(66)))));
            this.button_remove.FlatAppearance.BorderSize = 0;
            this.button_remove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_remove.Location = new System.Drawing.Point(232, 36);
            this.button_remove.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_remove.Name = "button_remove";
            this.button_remove.Size = new System.Drawing.Size(69, 21);
            this.button_remove.TabIndex = 14;
            this.button_remove.Text = "Remove";
            this.button_remove.UseVisualStyleBackColor = false;
            this.button_remove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(21)))), ((int)(((byte)(36)))));
            this.panel3.Controls.Add(this.button_add);
            this.panel3.Controls.Add(this.listbox_anchors);
            this.panel3.Controls.Add(this.button_remove);
            this.panel3.Location = new System.Drawing.Point(4, 44);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(307, 312);
            this.panel3.TabIndex = 16;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(21)))), ((int)(((byte)(36)))));
            this.panel4.Controls.Add(this.listBoxBlacklist);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.labelSortedValue);
            this.panel4.Controls.Add(this.labelSorted);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.treeCurrentAnchor);
            this.panel4.Controls.Add(this.progressBarSorting);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.combobox_sortingMethod);
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Controls.Add(this.label_status);
            this.panel4.Location = new System.Drawing.Point(371, 44);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(544, 312);
            this.panel4.TabIndex = 17;
            // 
            // listBoxBlacklist
            // 
            this.listBoxBlacklist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(66)))));
            this.listBoxBlacklist.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxBlacklist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.listBoxBlacklist.FormattingEnabled = true;
            this.listBoxBlacklist.ItemHeight = 12;
            this.listBoxBlacklist.Location = new System.Drawing.Point(12, 140);
            this.listBoxBlacklist.Name = "listBoxBlacklist";
            this.listBoxBlacklist.Size = new System.Drawing.Size(157, 96);
            this.listBoxBlacklist.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 125);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 12);
            this.label5.TabIndex = 25;
            this.label5.Text = "Blacklist";
            // 
            // labelSortedValue
            // 
            this.labelSortedValue.AutoSize = true;
            this.labelSortedValue.Location = new System.Drawing.Point(67, 262);
            this.labelSortedValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSortedValue.Name = "labelSortedValue";
            this.labelSortedValue.Size = new System.Drawing.Size(40, 12);
            this.labelSortedValue.TabIndex = 24;
            this.labelSortedValue.Text = "False";
            // 
            // labelSorted
            // 
            this.labelSorted.AutoSize = true;
            this.labelSorted.Location = new System.Drawing.Point(10, 262);
            this.labelSorted.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSorted.Name = "labelSorted";
            this.labelSorted.Size = new System.Drawing.Size(54, 12);
            this.labelSorted.TabIndex = 23;
            this.labelSorted.Text = "SORTED:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(213, 75);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 12);
            this.label6.TabIndex = 22;
            this.label6.Text = "Anchor Preview";
            // 
            // treeCurrentAnchor
            // 
            this.treeCurrentAnchor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(66)))));
            this.treeCurrentAnchor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.treeCurrentAnchor.Indent = 15;
            this.treeCurrentAnchor.Location = new System.Drawing.Point(215, 90);
            this.treeCurrentAnchor.Name = "treeCurrentAnchor";
            this.treeCurrentAnchor.Size = new System.Drawing.Size(310, 184);
            this.treeCurrentAnchor.TabIndex = 19;
            // 
            // progressBarSorting
            // 
            this.progressBarSorting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(66)))));
            this.progressBarSorting.Location = new System.Drawing.Point(9, 283);
            this.progressBarSorting.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.progressBarSorting.Name = "progressBarSorting";
            this.progressBarSorting.Size = new System.Drawing.Size(112, 21);
            this.progressBarSorting.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 5);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 12);
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("OCR A Extended", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(4, 3);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(262, 35);
            this.label7.TabIndex = 18;
            this.label7.Text = "Anchor Points";
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(14)))), ((int)(((byte)(26)))));
            this.menuStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.anchorToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuStrip.Size = new System.Drawing.Size(930, 24);
            this.menuStrip.TabIndex = 19;
            this.menuStrip.Text = "menuStrip1";
            this.menuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.toolStripSeparator2,
            this.restartToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(14)))), ((int)(((byte)(26)))));
            this.saveToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.saveToolStripMenuItem.Text = "Save anchors";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(14)))), ((int)(((byte)(26)))));
            this.loadToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.loadToolStripMenuItem.Text = "Load anchors";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadAnchorsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(14)))), ((int)(((byte)(26)))));
            this.toolStripSeparator2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(182, 6);
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(14)))), ((int)(((byte)(26)))));
            this.restartToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.restartToolStripMenuItem.Text = "Restart";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(14)))), ((int)(((byte)(26)))));
            this.exitToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // anchorToolStripMenuItem
            // 
            this.anchorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.removeToolStripMenuItem,
            this.toolStripSeparator1,
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.unsortToolStripMenuItem});
            this.anchorToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.anchorToolStripMenuItem.Name = "anchorToolStripMenuItem";
            this.anchorToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.anchorToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.anchorToolStripMenuItem.Text = "Anchor";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(14)))), ((int)(((byte)(26)))));
            this.addToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.addToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(14)))), ((int)(((byte)(26)))));
            this.removeToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(14)))), ((int)(((byte)(26)))));
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(135, 6);
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(14)))), ((int)(((byte)(26)))));
            this.startToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.startToolStripMenuItem.Text = "Start sorting";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(14)))), ((int)(((byte)(26)))));
            this.stopToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.stopToolStripMenuItem.Text = "Stop sorting";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // unsortToolStripMenuItem
            // 
            this.unsortToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(14)))), ((int)(((byte)(26)))));
            this.unsortToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.unsortToolStripMenuItem.Name = "unsortToolStripMenuItem";
            this.unsortToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.unsortToolStripMenuItem.Text = "Unsort";
            this.unsortToolStripMenuItem.Click += new System.EventHandler(this.unsortToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.gitHubRepositoryToolStripMenuItem,
            this.checkForUpdateToolStripMenuItem});
            this.helpToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(14)))), ((int)(((byte)(26)))));
            this.aboutToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // gitHubRepositoryToolStripMenuItem
            // 
            this.gitHubRepositoryToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(14)))), ((int)(((byte)(26)))));
            this.gitHubRepositoryToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gitHubRepositoryToolStripMenuItem.Name = "gitHubRepositoryToolStripMenuItem";
            this.gitHubRepositoryToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.gitHubRepositoryToolStripMenuItem.Text = "GitHub Repository";
            this.gitHubRepositoryToolStripMenuItem.Click += new System.EventHandler(this.gitHubRepositoryToolStripMenuItem_Click);
            // 
            // checkForUpdateToolStripMenuItem
            // 
            this.checkForUpdateToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(14)))), ((int)(((byte)(26)))));
            this.checkForUpdateToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.checkForUpdateToolStripMenuItem.Name = "checkForUpdateToolStripMenuItem";
            this.checkForUpdateToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.checkForUpdateToolStripMenuItem.Text = "Check for update";
            // 
            // tabControlPages
            // 
            this.tabControlPages.Controls.Add(this.pageHome);
            this.tabControlPages.Controls.Add(this.pageSettings);
            this.tabControlPages.Location = new System.Drawing.Point(0, 27);
            this.tabControlPages.Name = "tabControlPages";
            this.tabControlPages.SelectedIndex = 0;
            this.tabControlPages.Size = new System.Drawing.Size(931, 395);
            this.tabControlPages.TabIndex = 20;
            this.tabControlPages.TabStop = false;
            this.tabControlPages.SelectedIndexChanged += new System.EventHandler(this.tabControlPages_SelectedIndexChanged);
            // 
            // pageHome
            // 
            this.pageHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(14)))), ((int)(((byte)(26)))));
            this.pageHome.Controls.Add(this.panel3);
            this.pageHome.Controls.Add(this.label7);
            this.pageHome.Controls.Add(this.panel4);
            this.pageHome.Location = new System.Drawing.Point(4, 21);
            this.pageHome.Name = "pageHome";
            this.pageHome.Padding = new System.Windows.Forms.Padding(3);
            this.pageHome.Size = new System.Drawing.Size(923, 370);
            this.pageHome.TabIndex = 0;
            this.pageHome.Text = "Home";
            this.pageHome.Click += new System.EventHandler(this.pageHome_Click);
            // 
            // pageSettings
            // 
            this.pageSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(14)))), ((int)(((byte)(26)))));
            this.pageSettings.Controls.Add(this.label3);
            this.pageSettings.Controls.Add(this.checkboxDeepSort);
            this.pageSettings.Controls.Add(this.buttonApply);
            this.pageSettings.Controls.Add(this.buttonResetToDefault);
            this.pageSettings.Controls.Add(this.checkboxAutorun);
            this.pageSettings.Controls.Add(this.checkboxAutoSave);
            this.pageSettings.Controls.Add(this.checkboxBackgroundSorting);
            this.pageSettings.Controls.Add(this.label8);
            this.pageSettings.Location = new System.Drawing.Point(4, 21);
            this.pageSettings.Name = "pageSettings";
            this.pageSettings.Padding = new System.Windows.Forms.Padding(3);
            this.pageSettings.Size = new System.Drawing.Size(923, 370);
            this.pageSettings.TabIndex = 1;
            this.pageSettings.Text = "Settings";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("OCR A Extended", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(154, 161);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(460, 12);
            this.label3.TabIndex = 25;
            this.label3.Text = "WARNING: This will delete the parent folders of all sorted files.";
            // 
            // checkboxDeepSort
            // 
            this.checkboxDeepSort.AutoSize = true;
            this.checkboxDeepSort.Font = new System.Drawing.Font("OCR A Extended", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkboxDeepSort.Location = new System.Drawing.Point(10, 151);
            this.checkboxDeepSort.Name = "checkboxDeepSort";
            this.checkboxDeepSort.Size = new System.Drawing.Size(137, 27);
            this.checkboxDeepSort.TabIndex = 24;
            this.checkboxDeepSort.Text = "Deep Sort";
            this.checkboxDeepSort.UseVisualStyleBackColor = true;
            // 
            // buttonApply
            // 
            this.buttonApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(66)))));
            this.buttonApply.FlatAppearance.BorderSize = 0;
            this.buttonApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonApply.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonApply.Location = new System.Drawing.Point(844, 328);
            this.buttonApply.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(69, 36);
            this.buttonApply.TabIndex = 23;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = false;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // buttonResetToDefault
            // 
            this.buttonResetToDefault.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(66)))));
            this.buttonResetToDefault.FlatAppearance.BorderSize = 0;
            this.buttonResetToDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonResetToDefault.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonResetToDefault.Location = new System.Drawing.Point(700, 328);
            this.buttonResetToDefault.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonResetToDefault.Name = "buttonResetToDefault";
            this.buttonResetToDefault.Size = new System.Drawing.Size(136, 36);
            this.buttonResetToDefault.TabIndex = 23;
            this.buttonResetToDefault.Text = "Reset to Default";
            this.buttonResetToDefault.UseVisualStyleBackColor = false;
            this.buttonResetToDefault.Click += new System.EventHandler(this.buttonResetToDefault_Click);
            // 
            // checkboxAutorun
            // 
            this.checkboxAutorun.AutoSize = true;
            this.checkboxAutorun.Font = new System.Drawing.Font("OCR A Extended", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkboxAutorun.Location = new System.Drawing.Point(10, 118);
            this.checkboxAutorun.Name = "checkboxAutorun";
            this.checkboxAutorun.Size = new System.Drawing.Size(221, 27);
            this.checkboxAutorun.TabIndex = 22;
            this.checkboxAutorun.Text = "Auto-Run On Boot";
            this.checkboxAutorun.UseVisualStyleBackColor = true;
            // 
            // checkboxAutoSave
            // 
            this.checkboxAutoSave.AutoSize = true;
            this.checkboxAutoSave.Font = new System.Drawing.Font("OCR A Extended", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkboxAutoSave.Location = new System.Drawing.Point(10, 85);
            this.checkboxAutoSave.Name = "checkboxAutoSave";
            this.checkboxAutoSave.Size = new System.Drawing.Size(161, 27);
            this.checkboxAutoSave.TabIndex = 21;
            this.checkboxAutoSave.Text = "Auto Saving";
            this.checkboxAutoSave.UseVisualStyleBackColor = true;
            // 
            // checkboxBackgroundSorting
            // 
            this.checkboxBackgroundSorting.AutoSize = true;
            this.checkboxBackgroundSorting.Font = new System.Drawing.Font("OCR A Extended", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkboxBackgroundSorting.Location = new System.Drawing.Point(10, 52);
            this.checkboxBackgroundSorting.Name = "checkboxBackgroundSorting";
            this.checkboxBackgroundSorting.Size = new System.Drawing.Size(245, 27);
            this.checkboxBackgroundSorting.TabIndex = 20;
            this.checkboxBackgroundSorting.Text = "Background Sorting";
            this.checkboxBackgroundSorting.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("OCR A Extended", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(4, 3);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(167, 35);
            this.label8.TabIndex = 19;
            this.label8.Text = "Settings";
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.trayIconMenuStrip;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "trayIcon";
            this.trayIcon.Visible = true;
            // 
            // trayIconMenuStrip
            // 
            this.trayIconMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startSortingToolStripMenuItem,
            this.stopAllSortingToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem1});
            this.trayIconMenuStrip.Name = "trayIconMenuStrip";
            this.trayIconMenuStrip.Size = new System.Drawing.Size(154, 76);
            // 
            // startSortingToolStripMenuItem
            // 
            this.startSortingToolStripMenuItem.Name = "startSortingToolStripMenuItem";
            this.startSortingToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.startSortingToolStripMenuItem.Text = "Start all sorting";
            this.startSortingToolStripMenuItem.Click += new System.EventHandler(this.startSortingToolStripMenuItem_Click);
            // 
            // stopAllSortingToolStripMenuItem
            // 
            this.stopAllSortingToolStripMenuItem.Name = "stopAllSortingToolStripMenuItem";
            this.stopAllSortingToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.stopAllSortingToolStripMenuItem.Text = "Stop all sorting";
            this.stopAllSortingToolStripMenuItem.Click += new System.EventHandler(this.stopAllSortingToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(150, 6);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(153, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // buttonOpenDirectory
            // 
            this.buttonOpenDirectory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(66)))));
            this.buttonOpenDirectory.FlatAppearance.BorderSize = 0;
            this.buttonOpenDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOpenDirectory.Location = new System.Drawing.Point(491, 6);
            this.buttonOpenDirectory.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonOpenDirectory.Name = "buttonOpenDirectory";
            this.buttonOpenDirectory.Size = new System.Drawing.Size(25, 21);
            this.buttonOpenDirectory.TabIndex = 4;
            this.buttonOpenDirectory.Text = "Open Directory";
            this.buttonOpenDirectory.UseVisualStyleBackColor = false;
            this.buttonOpenDirectory.Click += new System.EventHandler(this.buttonOpenDirectory_Click);
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(14)))), ((int)(((byte)(26)))));
            this.ClientSize = new System.Drawing.Size(930, 415);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.tabControlPages);
            this.Font = new System.Drawing.Font("OCR A Extended", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "Window";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "AutoSortFolder";
            this.Activated += new System.EventHandler(this.Window_Activated);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tabControlPages.ResumeLayout(false);
            this.pageHome.ResumeLayout(false);
            this.pageHome.PerformLayout();
            this.pageSettings.ResumeLayout(false);
            this.pageSettings.PerformLayout();
            this.trayIconMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.ListBox listbox_anchors;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Button button_remove;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.ComponentModel.BackgroundWorker sorterWorker;
        private System.Windows.Forms.ProgressBar progressBarSorting;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TreeView treeCurrentAnchor;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem anchorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unsortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gitHubRepositoryToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControlPages;
        private System.Windows.Forms.TabPage pageHome;
        private System.Windows.Forms.TabPage pageSettings;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkboxBackgroundSorting;
        private System.Windows.Forms.CheckBox checkboxAutorun;
        private System.Windows.Forms.CheckBox checkboxAutoSave;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Button buttonResetToDefault;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.Label labelSorted;
        private System.Windows.Forms.Label labelSortedValue;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip trayIconMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem startSortingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopAllSortingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkboxDeepSort;
        private System.Windows.Forms.ListBox listBoxBlacklist;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonOpenDirectory;
    }
}

