namespace CocoDisk
{
    partial class FormCocoDisk
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
            this.listFiles = new System.Windows.Forms.ListBox();
            this.textFile = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileSaveDiskAs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileSaveAllFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUtilities = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUtilitiesCocoTerminal = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUtilitiesClearUnusedSectors = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUtilitiesShrinkDisk = new System.Windows.Forms.ToolStripMenuItem();
            this.labelFileName = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // listFiles
            // 
            this.listFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listFiles.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listFiles.FormattingEnabled = true;
            this.listFiles.ItemHeight = 16;
            this.listFiles.Location = new System.Drawing.Point(12, 25);
            this.listFiles.Name = "listFiles";
            this.listFiles.Size = new System.Drawing.Size(215, 516);
            this.listFiles.Sorted = true;
            this.listFiles.TabIndex = 0;
            this.listFiles.SelectedIndexChanged += new System.EventHandler(this.listFiles_SelectedIndexChanged);
            // 
            // textFile
            // 
            this.textFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textFile.BackColor = System.Drawing.SystemColors.Window;
            this.textFile.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textFile.Location = new System.Drawing.Point(233, 25);
            this.textFile.Multiline = true;
            this.textFile.Name = "textFile";
            this.textFile.ReadOnly = true;
            this.textFile.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textFile.Size = new System.Drawing.Size(630, 516);
            this.textFile.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuUtilities});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(875, 24);
            this.mainMenu.TabIndex = 3;
            this.mainMenu.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFileOpen,
            this.menuFileSave,
            this.menuFileSaveDiskAs,
            this.menuFileSaveAllFiles});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(37, 20);
            this.menuFile.Text = "File";
            this.menuFile.DropDownOpening += new System.EventHandler(this.menuFile_DropDownOpening);
            // 
            // menuFileOpen
            // 
            this.menuFileOpen.Name = "menuFileOpen";
            this.menuFileOpen.Size = new System.Drawing.Size(150, 22);
            this.menuFileOpen.Text = "Open";
            this.menuFileOpen.Click += new System.EventHandler(this.menuFileOpen_Click);
            // 
            // menuFileSave
            // 
            this.menuFileSave.Name = "menuFileSave";
            this.menuFileSave.Size = new System.Drawing.Size(150, 22);
            this.menuFileSave.Text = "Save...";
            this.menuFileSave.Click += new System.EventHandler(this.menuFileSave_Click);
            // 
            // menuFileSaveDiskAs
            // 
            this.menuFileSaveDiskAs.Name = "menuFileSaveDiskAs";
            this.menuFileSaveDiskAs.Size = new System.Drawing.Size(150, 22);
            this.menuFileSaveDiskAs.Text = "Save Disk As...";
            this.menuFileSaveDiskAs.Click += new System.EventHandler(this.menuFileSaveDiskAs_Click);
            // 
            // menuFileSaveAllFiles
            // 
            this.menuFileSaveAllFiles.Name = "menuFileSaveAllFiles";
            this.menuFileSaveAllFiles.Size = new System.Drawing.Size(150, 22);
            this.menuFileSaveAllFiles.Text = "Save All Files...";
            this.menuFileSaveAllFiles.Click += new System.EventHandler(this.menuFileSaveAllFiles_Click);
            // 
            // menuUtilities
            // 
            this.menuUtilities.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUtilitiesCocoTerminal,
            this.menuUtilitiesClearUnusedSectors,
            this.menuUtilitiesShrinkDisk});
            this.menuUtilities.Name = "menuUtilities";
            this.menuUtilities.Size = new System.Drawing.Size(58, 20);
            this.menuUtilities.Text = "Utilities";
            // 
            // menuUtilitiesCocoTerminal
            // 
            this.menuUtilitiesCocoTerminal.Name = "menuUtilitiesCocoTerminal";
            this.menuUtilitiesCocoTerminal.Size = new System.Drawing.Size(185, 22);
            this.menuUtilitiesCocoTerminal.Text = "Coco Terminal...";
            this.menuUtilitiesCocoTerminal.Click += new System.EventHandler(this.menuUtilitiesCocoTerminal_Click);
            // 
            // menuUtilitiesClearUnusedSectors
            // 
            this.menuUtilitiesClearUnusedSectors.Name = "menuUtilitiesClearUnusedSectors";
            this.menuUtilitiesClearUnusedSectors.Size = new System.Drawing.Size(185, 22);
            this.menuUtilitiesClearUnusedSectors.Text = "Clear Unused Sectors";
            this.menuUtilitiesClearUnusedSectors.Click += new System.EventHandler(this.menuUtilitiesClearUnusedSectors_Click);
            // 
            // menuUtilitiesShrinkDisk
            // 
            this.menuUtilitiesShrinkDisk.Name = "menuUtilitiesShrinkDisk";
            this.menuUtilitiesShrinkDisk.Size = new System.Drawing.Size(185, 22);
            this.menuUtilitiesShrinkDisk.Text = "Shrink Disk";
            this.menuUtilitiesShrinkDisk.Click += new System.EventHandler(this.menuUtilitiesShrinkDisk_Click);
            // 
            // labelFileName
            // 
            this.labelFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFileName.AutoEllipsis = true;
            this.labelFileName.Location = new System.Drawing.Point(171, 0);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(704, 22);
            this.labelFileName.TabIndex = 4;
            this.labelFileName.Text = "labelFileName";
            this.labelFileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormCocoDisk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 551);
            this.Controls.Add(this.labelFileName);
            this.Controls.Add(this.textFile);
            this.Controls.Add(this.listFiles);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "FormCocoDisk";
            this.Text = "Coco Disk";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCocoDisk_FormClosing);
            this.Load += new System.EventHandler(this.FormCocoDisk_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listFiles;
        private System.Windows.Forms.TextBox textFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuFileOpen;
        private System.Windows.Forms.ToolStripMenuItem menuFileSaveDiskAs;
        private System.Windows.Forms.ToolStripMenuItem menuFileSaveAllFiles;
        private System.Windows.Forms.ToolStripMenuItem menuUtilities;
        private System.Windows.Forms.ToolStripMenuItem menuUtilitiesCocoTerminal;
        private System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem menuUtilitiesClearUnusedSectors;
        private System.Windows.Forms.ToolStripMenuItem menuUtilitiesShrinkDisk;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripMenuItem menuFileSave;
    }
}

