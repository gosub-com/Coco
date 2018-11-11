using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;

namespace CocoDisk
{
    partial class FormCocoCom : Form
    {
        byte[] mReadBuffer = new byte[256];
        byte[] mNullBuffer = new byte[256];
        List<byte> mRecordBuffer = new List<byte>();
        bool mTextTerminalEverChanged;

        /// <summary>
        /// Null if there was no data or an error occured.
        /// </summary>
        public CocoDisk Disk;

        public FormCocoCom()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                var ports = SerialPort.GetPortNames();
                if (ports.Length == 0)
                {
                    MessageBox.Show(this, "No COM ports were detected.  Plug in a USB COM port and try again.", FormCocoDisk.APP_NAME);
                    Close();
                    return;
                }
                foreach (var port in ports)
                    comboComPorts.Items.Add(port);
                comboComPorts.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error: " + ex.Message, FormCocoDisk.APP_NAME);
                Close();
            }
        }

        private void FormCocoCom_Shown(object sender, EventArgs e)
        {
            textTerminal.SelectionLength = 0;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            bool recording = checkRecord.Checked;
            textTerminal.ReadOnly = recording;
            comboComPorts.Enabled = !recording;
            radio600.Enabled = !recording;
            radio9600.Enabled = !recording;
            radio19200.Enabled = !recording;
            buttonClearBuffer.Enabled = !recording && mRecordBuffer.Count != 0;
            buttonSaveBinary.Enabled = !recording && mRecordBuffer.Count != 0;
            buttonAcceptDisk.Enabled = !recording && mRecordBuffer.Count != 0;
            checkRecord.Text = "Record Buffer (size=" + mRecordBuffer.Count + ")";

            if (!serialPort1.IsOpen)
                return;

            // Send 0's in the background to make the coco send data
            if (serialPort1.BytesToWrite < 1024)
                serialPort1.BaseStream.WriteAsync(mNullBuffer, 0, mNullBuffer.Length);

            if (serialPort1.BytesToRead == 0)
                return;

            // Clear instructions on first data bytes
            if (!mTextTerminalEverChanged)
            {
                mTextTerminalEverChanged = true;
                textTerminal.Text = "";
            }

            // Copy or record data
            var count = serialPort1.Read(mReadBuffer, 0, Math.Min(serialPort1.BytesToRead, mReadBuffer.Length));
            if (!checkRecord.Checked)
            {
                // Send to text box
                var s = Encoding.UTF8.GetString(mReadBuffer, 0, count);
                s = s.Replace("\r", "\r\n");
                textTerminal.AppendText(s);
            }
            else
            {
                // Record in buffer
                for (int i = 0; i < count; i++)
                    mRecordBuffer.Add(mReadBuffer[i]);
            }
        }

        private void radio600_CheckedChanged(object sender, EventArgs e)
        {
            serialPort1.BaudRate = 600;
        }

        private void radio9600_CheckedChanged(object sender, EventArgs e)
        {
            serialPort1.BaudRate = 9600;
        }

        private void radio19200_CheckedChanged(object sender, EventArgs e)
        {
            serialPort1.BaudRate = 19200;
        }

        private void buttonClearBuffer_Click(object sender, EventArgs e)
        {
            mRecordBuffer.Clear();
        }

        private void buttonSaveBinary_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog(this) == DialogResult.Cancel || saveFileDialog1.FileName == "")
                return;

            try
            {
                File.WriteAllBytes(saveFileDialog1.FileName, mRecordBuffer.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void buttonAcceptDisk_Click(object sender, EventArgs e)
        {
            if (mRecordBuffer.Count == 0)
            {
                MessageBox.Show("There is no data in the buffer");
                return;
            }
            try
            {
                Disk = new CocoDisk(mRecordBuffer.ToArray());
                mRecordBuffer.Clear();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "ERROR: " + ex.Message, FormCocoDisk.APP_NAME);
            }
        }

        private void comboComPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.Close();
            if (comboComPorts.SelectedIndex < 0)
                return;

            serialPort1.PortName = comboComPorts.Items[comboComPorts.SelectedIndex].ToString(); ;
            serialPort1.Open();
        }

        private void FormCocoCom_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mRecordBuffer.Count != 0 
                && MessageBox.Show(this, "Are you sure you want to discard the record buffer?", 
                        FormCocoDisk.APP_NAME, MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                serialPort1.Close();
            }
        }

    }
}
