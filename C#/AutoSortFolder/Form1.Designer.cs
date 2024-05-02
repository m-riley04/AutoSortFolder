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
            this.SuspendLayout();
            // 
            // textbox_folderDirectory
            // 
            this.textbox_folderDirectory.Location = new System.Drawing.Point(150, 49);
            this.textbox_folderDirectory.Name = "textbox_folderDirectory";
            this.textbox_folderDirectory.Size = new System.Drawing.Size(275, 20);
            this.textbox_folderDirectory.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sorting Folder Directory";
            // 
            // button_selectFolder
            // 
            this.button_selectFolder.Location = new System.Drawing.Point(432, 45);
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
            this.label_status.Location = new System.Drawing.Point(27, 507);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(23, 13);
            this.label_status.TabIndex = 4;
            this.label_status.Text = "idle";
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(30, 79);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(59, 23);
            this.button_start.TabIndex = 5;
            this.button_start.Text = "Start";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // button_stop
            // 
            this.button_stop.Location = new System.Drawing.Point(95, 79);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(59, 23);
            this.button_stop.TabIndex = 6;
            this.button_stop.Text = "Stop";
            this.button_stop.UseVisualStyleBackColor = true;
            this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
            // 
            // button_unsort
            // 
            this.button_unsort.Location = new System.Drawing.Point(160, 79);
            this.button_unsort.Name = "button_unsort";
            this.button_unsort.Size = new System.Drawing.Size(59, 23);
            this.button_unsort.TabIndex = 7;
            this.button_unsort.Text = "Unsort";
            this.button_unsort.UseVisualStyleBackColor = true;
            this.button_unsort.Click += new System.EventHandler(this.button_unsort_Click);
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 542);
            this.Controls.Add(this.button_unsort);
            this.Controls.Add(this.button_stop);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.button_selectFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textbox_folderDirectory);
            this.Name = "Window";
            this.Text = "AutoSortFolder";
            this.Load += new System.EventHandler(this.Form1_Load);
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
    }
}

