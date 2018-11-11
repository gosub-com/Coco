using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CocoDisk
{
    partial class FormCocoDisk : Form
    {
        public const string APP_NAME = "Coco Disk";

        CocoDisk mDisk = new CocoDisk();
        bool mFileModified;

        public FormCocoDisk()
        {
            InitializeComponent();
        }

        private void FormCocoDisk_Load(object sender, EventArgs e)
        {
            labelFileName.Text = "";
        }

        private void listFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listFiles.SelectedIndex < 0)
            {
                textFile.Text = "";
                return;
            }
            textFile.Text = ((CocoFile)listFiles.Items[listFiles.SelectedIndex]).GetText("\r\n");
        }

        private void menuFileOpen_Click(object sender, EventArgs e)
        {
            if (mFileModified)
                if (MessageBox.Show(this, "You have unsaved changes.  Do you want to save them first?", APP_NAME, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    return;

            if (openFileDialog1.ShowDialog(this) == DialogResult.Cancel || openFileDialog1.FileName == "")
                return;

            try
            {
                mDisk = new CocoDisk(File.ReadAllBytes(openFileDialog1.FileName));
                mFileModified = false;
                labelFileName.Text = openFileDialog1.FileName;
                UpdateFilesAndShowErrors();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error: " + ex.Message, APP_NAME);
                return;
            }
        }

        private void menuUtilitiesCocoTerminal_Click(object sender, EventArgs e)
        {
            if (mFileModified)
                if (MessageBox.Show(this, "You have unsaved changes.  Do you want to save them first?", APP_NAME, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    return;

            var form = new FormCocoCom();
            form.ShowDialog(this);    
            if (form.Disk != null)
            {
                mDisk = form.Disk;
                mFileModified = true;
                labelFileName.Text = "";
                UpdateFilesAndShowErrors();
            }
        }

        void UpdateFilesAndShowErrors()
        {
            listFiles.Items.Clear();
            textFile.Text = "";
            foreach (var file in mDisk.Files)
                listFiles.Items.Add(file);

            if (mDisk.ErrorsOnDisk != 0)
                MessageBox.Show(this, "There were " + mDisk.ErrorsOnDisk + " errors on the disk, "
                    + "and " + mDisk.ErrorsInFiles + " of them were in files.  Files that have "
                    + "errors in them are marked with an 'X'.", APP_NAME);
        }

        private void menuFile_DropDownOpening(object sender, EventArgs e)
        {
            menuFileSave.Enabled = mDisk.Disk.Length != 0 && mFileModified && labelFileName.Text != ""; ;
            menuFileSaveDiskAs.Enabled = mDisk.Disk.Length != 0; ;
            menuFileSaveAllFiles.Enabled = listFiles.Items.Count != 0;
        }

        private void menuFileSave_Click(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllBytes(labelFileName.Text, mDisk.Disk);
                mFileModified = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error: " + ex.Message, APP_NAME);
            }
        }

        private void menuFileSaveDiskAs_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog(this) == DialogResult.Cancel || saveFileDialog1.FileName == "")
                return;

            try
            {
                File.WriteAllBytes(saveFileDialog1.FileName, mDisk.Disk);
                mFileModified = false;
                labelFileName.Text = saveFileDialog1.FileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error: " + ex.Message, APP_NAME);
            }
        }

        private void menuUtilitiesClearUnusedSectors_Click(object sender, EventArgs e)
        {
            int clearedSectors = mDisk.ClearUnusedSectors();
            MessageBox.Show(this, "" + clearedSectors + " unused sectors were cleared.", APP_NAME);

            if (clearedSectors != 0)
                mFileModified = true;

            UpdateFilesAndShowErrors();
        }

        private void menuUtilitiesShrinkDisk_Click(object sender, EventArgs e)
        {
            int sizeBefore = mDisk.Disk.Length;
            mDisk.ShrinkDisk();
            int clearedSectors = mDisk.ClearUnusedSectors();
            int sizeAfter = mDisk.Disk.Length;

            MessageBox.Show(this, "The disk was shrunk by " + (sizeBefore-sizeAfter) + " bytes.  "
                + clearedSectors + " unused sectors were cleared.", APP_NAME);

            if (sizeAfter != sizeBefore || clearedSectors != 0)
                mFileModified = true;

            UpdateFilesAndShowErrors();       }


        private void FormCocoDisk_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mFileModified
                && MessageBox.Show(this, "The disk has not been saved.  Are you sure you want to discard the changes?",
                        FormCocoDisk.APP_NAME, MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void menuFileSaveAllFiles_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.FileName != "")
                folderBrowserDialog1.SelectedPath = Path.GetDirectoryName(openFileDialog1.FileName);
            if (folderBrowserDialog1.ShowDialog(this) == DialogResult.Cancel || folderBrowserDialog1.SelectedPath == "")
                return;

            var dir = folderBrowserDialog1.SelectedPath;
            try
            {
                // Warn user about overwriting files
                int overwrites = 0; ;
                foreach (var file in mDisk.Files)
                    if (File.Exists(Path.Combine(dir, file.Name)))
                        overwrites++;
                if (overwrites != 0)
                {
                    if (MessageBox.Show(this, "Are you sure you want to overwrite " + overwrites + " files?", 
                                                APP_NAME, MessageBoxButtons.YesNo) != DialogResult.Yes)
                        return;
                }

                // Save all files
                foreach (var file in mDisk.Files)
                {
                    byte[] data;
                    if (file.Type == CocoFileType.Basic || file.Type == CocoFileType.Ascii)
                        data = Encoding.UTF8.GetBytes(file.GetText("\r\n"));
                    else
                        data = file.Data;

                    var fileName = Path.Combine(dir, file.Name);
                    if (File.Exists(fileName))
                        File.Delete(fileName);
                    File.WriteAllBytes(fileName, data);
                }

                MessageBox.Show(this, "" + mDisk.Files.Length + " files saved.", APP_NAME);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error: " + ex.Message, APP_NAME);
            }

        }

    }
}
