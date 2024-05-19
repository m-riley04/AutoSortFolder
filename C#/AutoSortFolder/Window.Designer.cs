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
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.label_status = new System.Windows.Forms.Label();
            this.button_start = new System.Windows.Forms.Button();
            this.button_stop = new System.Windows.Forms.Button();
            this.button_unsort = new System.Windows.Forms.Button();
            this.combobox_sortingMethod = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listbox_anchors = new System.Windows.Forms.ListBox();
            this.button_add = new System.Windows.Forms.Button();
            this.button_remove = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.progressBarSorting = new System.Windows.Forms.ProgressBar();
            this.labelSorted = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonOpenDirectory = new System.Windows.Forms.Button();
            this.textboxAnchorName = new System.Windows.Forms.TextBox();
            this.listBoxBlacklist = new System.Windows.Forms.ListBox();
            this.button_selectFolder = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.treeCurrentAnchor = new System.Windows.Forms.TreeView();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonResetBlacklist = new System.Windows.Forms.Button();
            this.sorterWorker = new System.ComponentModel.BackgroundWorker();
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pageSettings = new System.Windows.Forms.TabPage();
            this.checkboxSortRepositories = new System.Windows.Forms.CheckBox();
            this.checkboxSortHidden = new System.Windows.Forms.CheckBox();
            this.checkboxDebug = new System.Windows.Forms.CheckBox();
            this.checkboxAutorun = new System.Windows.Forms.CheckBox();
            this.checkboxAutoSave = new System.Windows.Forms.CheckBox();
            this.checkboxBackgroundSorting = new System.Windows.Forms.CheckBox();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayIconMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.startSortingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopAllSortingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSystemWatcher = new System.IO.FileSystemWatcher();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonResetToDefault = new System.Windows.Forms.Button();
            this.buttonCheckForUpdate = new System.Windows.Forms.Button();
            this.buttonApply = new System.Windows.Forms.Button();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.tabControlPages.SuspendLayout();
            this.pageHome.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.pageSettings.SuspendLayout();
            this.trayIconMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // textbox_folderDirectory
            // 
            this.textbox_folderDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textbox_folderDirectory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(66)))));
            this.textbox_folderDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textbox_folderDirectory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textbox_folderDirectory.Location = new System.Drawing.Point(140, 43);
            this.textbox_folderDirectory.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textbox_folderDirectory.Name = "textbox_folderDirectory";
            this.textbox_folderDirectory.ReadOnly = true;
            this.textbox_folderDirectory.Size = new System.Drawing.Size(264, 19);
            this.textbox_folderDirectory.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Directory";
            // 
            // label_status
            // 
            this.label_status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label_status.AutoSize = true;
            this.label_status.Location = new System.Drawing.Point(112, 27);
            this.label_status.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(123, 12);
            this.label_status.TabIndex = 4;
            this.label_status.Text = "IDLE";
            // 
            // button_start
            // 
            this.button_start.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(66)))));
            this.button_start.FlatAppearance.BorderSize = 0;
            this.button_start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_start.Location = new System.Drawing.Point(4, 7);
            this.button_start.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(68, 21);
            this.button_start.TabIndex = 7;
            this.button_start.Text = "Start";
            this.button_start.UseVisualStyleBackColor = false;
            this.button_start.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // button_stop
            // 
            this.button_stop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_stop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(66)))));
            this.button_stop.Enabled = false;
            this.button_stop.FlatAppearance.BorderSize = 0;
            this.button_stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_stop.Location = new System.Drawing.Point(80, 7);
            this.button_stop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(68, 21);
            this.button_stop.TabIndex = 8;
            this.button_stop.Text = "Stop";
            this.button_stop.UseVisualStyleBackColor = false;
            this.button_stop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // button_unsort
            // 
            this.button_unsort.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_unsort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(66)))));
            this.button_unsort.FlatAppearance.BorderSize = 0;
            this.button_unsort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_unsort.Location = new System.Drawing.Point(156, 7);
            this.button_unsort.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_unsort.Name = "button_unsort";
            this.button_unsort.Size = new System.Drawing.Size(69, 21);
            this.button_unsort.TabIndex = 9;
            this.button_unsort.Text = "Unsort";
            this.button_unsort.UseVisualStyleBackColor = false;
            this.button_unsort.Click += new System.EventHandler(this.buttonUnsort_Click);
            // 
            // combobox_sortingMethod
            // 
            this.combobox_sortingMethod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
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
            this.combobox_sortingMethod.Location = new System.Drawing.Point(4, 95);
            this.combobox_sortingMethod.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.combobox_sortingMethod.Name = "combobox_sortingMethod";
            this.combobox_sortingMethod.Size = new System.Drawing.Size(128, 20);
            this.combobox_sortingMethod.TabIndex = 4;
            this.combobox_sortingMethod.SelectedIndexChanged += new System.EventHandler(this.dropdownSortingMethod_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 74);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sorting Method";
            // 
            // listbox_anchors
            // 
            this.listbox_anchors.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(66)))));
            this.listbox_anchors.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listbox_anchors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listbox_anchors.Font = new System.Drawing.Font("OCR A Extended", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listbox_anchors.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.listbox_anchors.FormattingEnabled = true;
            this.listbox_anchors.Location = new System.Drawing.Point(4, 3);
            this.listbox_anchors.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.listbox_anchors.Name = "listbox_anchors";
            this.tableLayoutPanel2.SetRowSpan(this.listbox_anchors, 3);
            this.listbox_anchors.Size = new System.Drawing.Size(283, 435);
            this.listbox_anchors.TabIndex = 0;
            this.listbox_anchors.SelectedIndexChanged += new System.EventHandler(this.listboxAnchors_SelectedIndexChanged);
            // 
            // button_add
            // 
            this.button_add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(66)))));
            this.button_add.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_add.FlatAppearance.BorderSize = 0;
            this.button_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_add.Location = new System.Drawing.Point(295, 3);
            this.button_add.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(70, 66);
            this.button_add.TabIndex = 1;
            this.button_add.Text = "Add";
            this.button_add.UseVisualStyleBackColor = false;
            this.button_add.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // button_remove
            // 
            this.button_remove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(66)))));
            this.button_remove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_remove.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(66)))));
            this.button_remove.FlatAppearance.BorderSize = 0;
            this.button_remove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_remove.Location = new System.Drawing.Point(295, 75);
            this.button_remove.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_remove.Name = "button_remove";
            this.button_remove.Size = new System.Drawing.Size(70, 72);
            this.button_remove.TabIndex = 2;
            this.button_remove.Text = "Remove";
            this.button_remove.UseVisualStyleBackColor = false;
            this.button_remove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(21)))), ((int)(((byte)(36)))));
            this.panel4.Controls.Add(this.tableLayoutPanel6);
            this.panel4.Controls.Add(this.tableLayoutPanel4);
            this.panel4.Controls.Add(this.tableLayoutPanel3);
            this.panel4.Controls.Add(this.buttonResetBlacklist);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(407, 3);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(599, 441);
            this.panel4.TabIndex = 1;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.18829F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.81171F));
            this.tableLayoutPanel6.Controls.Add(this.progressBarSorting, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.label_status, 1, 1);
            this.tableLayoutPanel6.Controls.Add(this.labelSorted, 0, 0);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 391);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.6087F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.3913F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(239, 50);
            this.tableLayoutPanel6.TabIndex = 27;
            // 
            // progressBarSorting
            // 
            this.progressBarSorting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(66)))));
            this.progressBarSorting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBarSorting.Location = new System.Drawing.Point(4, 19);
            this.progressBarSorting.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.progressBarSorting.Name = "progressBarSorting";
            this.progressBarSorting.Size = new System.Drawing.Size(100, 28);
            this.progressBarSorting.TabIndex = 21;
            // 
            // labelSorted
            // 
            this.labelSorted.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSorted.AutoSize = true;
            this.labelSorted.Location = new System.Drawing.Point(4, 2);
            this.labelSorted.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSorted.Name = "labelSorted";
            this.labelSorted.Size = new System.Drawing.Size(100, 12);
            this.labelSorted.TabIndex = 23;
            this.labelSorted.Text = "NOT SORTED";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.Controls.Add(this.button_unsort, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.button_stop, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.button_start, 0, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(370, 406);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(229, 35);
            this.tableLayoutPanel4.TabIndex = 26;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.84073F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.4271F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.0393F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.69287F));
            this.tableLayoutPanel3.Controls.Add(this.buttonOpenDirectory, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.textboxAnchorName, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.listBoxBlacklist, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.button_selectFolder, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.textbox_folderDirectory, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.treeCurrentAnchor, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.label6, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.combobox_sortingMethod, 0, 3);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 6;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.863013F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.863013F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.753425F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.041096F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.027397F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.54795F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(599, 365);
            this.tableLayoutPanel3.TabIndex = 20;
            // 
            // buttonOpenDirectory
            // 
            this.buttonOpenDirectory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonOpenDirectory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(66)))));
            this.buttonOpenDirectory.FlatAppearance.BorderSize = 0;
            this.buttonOpenDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOpenDirectory.Location = new System.Drawing.Point(530, 41);
            this.buttonOpenDirectory.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonOpenDirectory.Name = "buttonOpenDirectory";
            this.buttonOpenDirectory.Size = new System.Drawing.Size(60, 23);
            this.buttonOpenDirectory.TabIndex = 3;
            this.buttonOpenDirectory.Text = "Open Directory";
            this.buttonOpenDirectory.UseVisualStyleBackColor = false;
            this.buttonOpenDirectory.Click += new System.EventHandler(this.buttonOpenDirectory_Click);
            // 
            // textboxAnchorName
            // 
            this.textboxAnchorName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textboxAnchorName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(66)))));
            this.textboxAnchorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel3.SetColumnSpan(this.textboxAnchorName, 3);
            this.textboxAnchorName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textboxAnchorName.Location = new System.Drawing.Point(140, 8);
            this.textboxAnchorName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textboxAnchorName.Name = "textboxAnchorName";
            this.textboxAnchorName.Size = new System.Drawing.Size(455, 19);
            this.textboxAnchorName.TabIndex = 0;
            this.textboxAnchorName.TextChanged += new System.EventHandler(this.textboxAnchorName_TextChanged);
            // 
            // listBoxBlacklist
            // 
            this.listBoxBlacklist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(66)))));
            this.listBoxBlacklist.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxBlacklist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxBlacklist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.listBoxBlacklist.FormattingEnabled = true;
            this.listBoxBlacklist.ItemHeight = 12;
            this.listBoxBlacklist.Location = new System.Drawing.Point(3, 146);
            this.listBoxBlacklist.Name = "listBoxBlacklist";
            this.listBoxBlacklist.Size = new System.Drawing.Size(130, 216);
            this.listBoxBlacklist.TabIndex = 26;
            // 
            // button_selectFolder
            // 
            this.button_selectFolder.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_selectFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(66)))));
            this.button_selectFolder.FlatAppearance.BorderSize = 0;
            this.button_selectFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_selectFolder.Location = new System.Drawing.Point(412, 41);
            this.button_selectFolder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_selectFolder.Name = "button_selectFolder";
            this.button_selectFolder.Size = new System.Drawing.Size(106, 23);
            this.button_selectFolder.TabIndex = 2;
            this.button_selectFolder.Text = "Select Folder";
            this.button_selectFolder.UseVisualStyleBackColor = false;
            this.button_selectFolder.Click += new System.EventHandler(this.buttonSelectFolder_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 126);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 12);
            this.label5.TabIndex = 25;
            this.label5.Text = "Blacklist";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "Name";
            // 
            // treeCurrentAnchor
            // 
            this.treeCurrentAnchor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(66)))));
            this.treeCurrentAnchor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableLayoutPanel3.SetColumnSpan(this.treeCurrentAnchor, 3);
            this.treeCurrentAnchor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeCurrentAnchor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.treeCurrentAnchor.Indent = 15;
            this.treeCurrentAnchor.Location = new System.Drawing.Point(139, 93);
            this.treeCurrentAnchor.Name = "treeCurrentAnchor";
            this.tableLayoutPanel3.SetRowSpan(this.treeCurrentAnchor, 3);
            this.treeCurrentAnchor.Size = new System.Drawing.Size(457, 269);
            this.treeCurrentAnchor.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(140, 74);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(264, 12);
            this.label6.TabIndex = 22;
            this.label6.Text = "Anchor Preview";
            // 
            // buttonResetBlacklist
            // 
            this.buttonResetBlacklist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(66)))));
            this.buttonResetBlacklist.FlatAppearance.BorderSize = 0;
            this.buttonResetBlacklist.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonResetBlacklist.Location = new System.Drawing.Point(122, 179);
            this.buttonResetBlacklist.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonResetBlacklist.Name = "buttonResetBlacklist";
            this.buttonResetBlacklist.Size = new System.Drawing.Size(51, 21);
            this.buttonResetBlacklist.TabIndex = 6;
            this.buttonResetBlacklist.Text = "Reset Blacklist";
            this.buttonResetBlacklist.UseVisualStyleBackColor = false;
            this.buttonResetBlacklist.Click += new System.EventHandler(this.buttonResetBlacklist_Click);
            // 
            // sorterWorker
            // 
            this.sorterWorker.WorkerReportsProgress = true;
            this.sorterWorker.WorkerSupportsCancellation = true;
            this.sorterWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.sorterWorker_DoWork);
            this.sorterWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.sorterWorker_ProgressChanged);
            this.sorterWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.sorterWorker_RunWorkerCompleted);
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
            this.menuStrip.ShowItemToolTips = true;
            this.menuStrip.Size = new System.Drawing.Size(982, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            this.menuStrip.Visible = false;
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
            this.tabControlPages.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControlPages.Controls.Add(this.pageHome);
            this.tabControlPages.Controls.Add(this.pageSettings);
            this.tabControlPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPages.ItemSize = new System.Drawing.Size(100, 25);
            this.tabControlPages.Location = new System.Drawing.Point(0, 0);
            this.tabControlPages.Multiline = true;
            this.tabControlPages.Name = "tabControlPages";
            this.tabControlPages.Padding = new System.Drawing.Point(0, 0);
            this.tabControlPages.SelectedIndex = 0;
            this.tabControlPages.Size = new System.Drawing.Size(1017, 480);
            this.tabControlPages.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlPages.TabIndex = 1;
            this.tabControlPages.TabStop = false;
            // 
            // pageHome
            // 
            this.pageHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(14)))), ((int)(((byte)(26)))));
            this.pageHome.Controls.Add(this.tableLayoutPanel2);
            this.pageHome.Controls.Add(this.panel4);
            this.pageHome.Location = new System.Drawing.Point(4, 29);
            this.pageHome.Name = "pageHome";
            this.pageHome.Padding = new System.Windows.Forms.Padding(3);
            this.pageHome.Size = new System.Drawing.Size(1009, 447);
            this.pageHome.TabIndex = 0;
            this.pageHome.Text = "Anchors";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.89447F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.10553F));
            this.tableLayoutPanel2.Controls.Add(this.button_remove, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.button_add, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.listbox_anchors, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.10126F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.89874F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 290F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(369, 441);
            this.tableLayoutPanel2.TabIndex = 19;
            // 
            // pageSettings
            // 
            this.pageSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(14)))), ((int)(((byte)(26)))));
            this.pageSettings.Controls.Add(this.tableLayoutPanel1);
            this.pageSettings.Controls.Add(this.tableLayoutPanel5);
            this.pageSettings.Location = new System.Drawing.Point(4, 29);
            this.pageSettings.Name = "pageSettings";
            this.pageSettings.Padding = new System.Windows.Forms.Padding(3);
            this.pageSettings.Size = new System.Drawing.Size(1009, 447);
            this.pageSettings.TabIndex = 1;
            this.pageSettings.Text = "Settings";
            // 
            // checkboxSortRepositories
            // 
            this.checkboxSortRepositories.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.checkboxSortRepositories.AutoSize = true;
            this.checkboxSortRepositories.Font = new System.Drawing.Font("OCR A Extended", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkboxSortRepositories.Location = new System.Drawing.Point(311, 149);
            this.checkboxSortRepositories.Name = "checkboxSortRepositories";
            this.checkboxSortRepositories.Size = new System.Drawing.Size(354, 24);
            this.checkboxSortRepositories.TabIndex = 23;
            this.checkboxSortRepositories.Text = "Sort Repositories";
            this.checkboxSortRepositories.UseVisualStyleBackColor = true;
            // 
            // checkboxSortHidden
            // 
            this.checkboxSortHidden.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.checkboxSortHidden.AutoSize = true;
            this.checkboxSortHidden.Font = new System.Drawing.Font("OCR A Extended", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkboxSortHidden.Location = new System.Drawing.Point(311, 103);
            this.checkboxSortHidden.Name = "checkboxSortHidden";
            this.checkboxSortHidden.Size = new System.Drawing.Size(354, 24);
            this.checkboxSortHidden.TabIndex = 22;
            this.checkboxSortHidden.Text = "Sort Hidden";
            this.checkboxSortHidden.UseVisualStyleBackColor = true;
            // 
            // checkboxDebug
            // 
            this.checkboxDebug.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.checkboxDebug.AutoSize = true;
            this.checkboxDebug.Font = new System.Drawing.Font("OCR A Extended", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkboxDebug.Location = new System.Drawing.Point(3, 149);
            this.checkboxDebug.Name = "checkboxDebug";
            this.checkboxDebug.Size = new System.Drawing.Size(302, 24);
            this.checkboxDebug.TabIndex = 18;
            this.checkboxDebug.Text = "Debug";
            this.checkboxDebug.UseVisualStyleBackColor = true;
            // 
            // checkboxAutorun
            // 
            this.checkboxAutorun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.checkboxAutorun.AutoSize = true;
            this.checkboxAutorun.Font = new System.Drawing.Font("OCR A Extended", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkboxAutorun.Location = new System.Drawing.Point(3, 103);
            this.checkboxAutorun.Name = "checkboxAutorun";
            this.checkboxAutorun.Size = new System.Drawing.Size(302, 24);
            this.checkboxAutorun.TabIndex = 17;
            this.checkboxAutorun.Text = "Auto-Run On Boot";
            this.checkboxAutorun.UseVisualStyleBackColor = true;
            // 
            // checkboxAutoSave
            // 
            this.checkboxAutoSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.checkboxAutoSave.AutoSize = true;
            this.checkboxAutoSave.Font = new System.Drawing.Font("OCR A Extended", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkboxAutoSave.Location = new System.Drawing.Point(3, 57);
            this.checkboxAutoSave.Name = "checkboxAutoSave";
            this.checkboxAutoSave.Size = new System.Drawing.Size(302, 24);
            this.checkboxAutoSave.TabIndex = 16;
            this.checkboxAutoSave.Text = "Auto Saving";
            this.checkboxAutoSave.UseVisualStyleBackColor = true;
            // 
            // checkboxBackgroundSorting
            // 
            this.checkboxBackgroundSorting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.checkboxBackgroundSorting.AutoSize = true;
            this.checkboxBackgroundSorting.Font = new System.Drawing.Font("OCR A Extended", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkboxBackgroundSorting.Location = new System.Drawing.Point(311, 57);
            this.checkboxBackgroundSorting.Name = "checkboxBackgroundSorting";
            this.checkboxBackgroundSorting.Size = new System.Drawing.Size(354, 24);
            this.checkboxBackgroundSorting.TabIndex = 15;
            this.checkboxBackgroundSorting.Text = "Background Sorting";
            this.checkboxBackgroundSorting.UseVisualStyleBackColor = true;
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
            // fileSystemWatcher
            // 
            this.fileSystemWatcher.EnableRaisingEvents = true;
            this.fileSystemWatcher.SynchronizingObject = this;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.70788F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.89232F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.label7, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkboxSortRepositories, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.checkboxSortHidden, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.checkboxBackgroundSorting, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.checkboxAutoSave, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.checkboxAutorun, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.checkboxDebug, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1003, 323);
            this.tableLayoutPanel1.TabIndex = 24;
            // 
            // buttonResetToDefault
            // 
            this.buttonResetToDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonResetToDefault.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(66)))));
            this.buttonResetToDefault.FlatAppearance.BorderSize = 0;
            this.buttonResetToDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonResetToDefault.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonResetToDefault.Location = new System.Drawing.Point(124, 3);
            this.buttonResetToDefault.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonResetToDefault.Name = "buttonResetToDefault";
            this.buttonResetToDefault.Size = new System.Drawing.Size(112, 35);
            this.buttonResetToDefault.TabIndex = 19;
            this.buttonResetToDefault.Text = "Reset to Default";
            this.buttonResetToDefault.UseVisualStyleBackColor = false;
            this.buttonResetToDefault.Click += new System.EventHandler(this.buttonResetToDefault_Click);
            // 
            // buttonCheckForUpdate
            // 
            this.buttonCheckForUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCheckForUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(66)))));
            this.buttonCheckForUpdate.FlatAppearance.BorderSize = 0;
            this.buttonCheckForUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCheckForUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCheckForUpdate.Location = new System.Drawing.Point(4, 3);
            this.buttonCheckForUpdate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonCheckForUpdate.Name = "buttonCheckForUpdate";
            this.buttonCheckForUpdate.Size = new System.Drawing.Size(112, 35);
            this.buttonCheckForUpdate.TabIndex = 21;
            this.buttonCheckForUpdate.Text = "Check for Updates";
            this.buttonCheckForUpdate.UseVisualStyleBackColor = false;
            this.buttonCheckForUpdate.Click += new System.EventHandler(this.buttonCheckForUpdate_Click);
            // 
            // buttonApply
            // 
            this.buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(66)))));
            this.buttonApply.FlatAppearance.BorderSize = 0;
            this.buttonApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonApply.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonApply.Location = new System.Drawing.Point(244, 3);
            this.buttonApply.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(114, 35);
            this.buttonApply.TabIndex = 20;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = false;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel5.Controls.Add(this.buttonApply, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.buttonCheckForUpdate, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.buttonResetToDefault, 1, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(643, 398);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(362, 41);
            this.tableLayoutPanel5.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("OCR A Extended", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(302, 29);
            this.label4.TabIndex = 24;
            this.label4.Text = "Application";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("OCR A Extended", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(311, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(354, 29);
            this.label7.TabIndex = 25;
            this.label7.Text = "Sorting";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(14)))), ((int)(((byte)(26)))));
            this.ClientSize = new System.Drawing.Size(1017, 480);
            this.Controls.Add(this.tabControlPages);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("OCR A Extended", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "Window";
            this.Text = "AutoSortFolder";
            this.Activated += new System.EventHandler(this.Window_Activated);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Window_KeyDown);
            this.panel4.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tabControlPages.ResumeLayout(false);
            this.pageHome.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.pageSettings.ResumeLayout(false);
            this.trayIconMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textbox_folderDirectory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Button button_stop;
        private System.Windows.Forms.Button button_unsort;
        private System.Windows.Forms.ComboBox combobox_sortingMethod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listbox_anchors;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Button button_remove;
        private System.Windows.Forms.Panel panel4;
        private System.ComponentModel.BackgroundWorker sorterWorker;
        private System.Windows.Forms.ProgressBar progressBarSorting;
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkboxBackgroundSorting;
        private System.Windows.Forms.CheckBox checkboxAutorun;
        private System.Windows.Forms.CheckBox checkboxAutoSave;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.Label labelSorted;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip trayIconMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem startSortingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopAllSortingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ListBox listBoxBlacklist;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkboxDebug;
        private System.Windows.Forms.Button buttonResetBlacklist;
        private System.IO.FileSystemWatcher fileSystemWatcher;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textboxAnchorName;
        private System.Windows.Forms.CheckBox checkboxSortHidden;
        private System.Windows.Forms.CheckBox checkboxSortRepositories;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button buttonOpenDirectory;
        private System.Windows.Forms.Button button_selectFolder;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Button buttonCheckForUpdate;
        private System.Windows.Forms.Button buttonResetToDefault;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
    }
}

