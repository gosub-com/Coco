namespace CocoDisk
{
    partial class FormCocoCom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCocoCom));
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.textTerminal = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.radio9600 = new System.Windows.Forms.RadioButton();
            this.radio19200 = new System.Windows.Forms.RadioButton();
            this.radio600 = new System.Windows.Forms.RadioButton();
            this.buttonAcceptDisk = new System.Windows.Forms.Button();
            this.buttonClearBuffer = new System.Windows.Forms.Button();
            this.checkRecord = new System.Windows.Forms.CheckBox();
            this.comboComPorts = new System.Windows.Forms.ComboBox();
            this.buttonSaveBinary = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 600;
            this.serialPort1.ReadTimeout = 0;
            // 
            // textTerminal
            // 
            this.textTerminal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textTerminal.BackColor = System.Drawing.SystemColors.Window;
            this.textTerminal.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTerminal.Location = new System.Drawing.Point(12, 60);
            this.textTerminal.Multiline = true;
            this.textTerminal.Name = "textTerminal";
            this.textTerminal.ReadOnly = true;
            this.textTerminal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textTerminal.Size = new System.Drawing.Size(822, 488);
            this.textTerminal.TabIndex = 0;
            this.textTerminal.Text = resources.GetString("textTerminal.Text");
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // radio9600
            // 
            this.radio9600.AutoSize = true;
            this.radio9600.Location = new System.Drawing.Point(101, 8);
            this.radio9600.Name = "radio9600";
            this.radio9600.Size = new System.Drawing.Size(114, 17);
            this.radio9600.TabIndex = 1;
            this.radio9600.Text = "9600: POKE 150,1";
            this.radio9600.UseVisualStyleBackColor = true;
            this.radio9600.CheckedChanged += new System.EventHandler(this.radio9600_CheckedChanged);
            // 
            // radio19200
            // 
            this.radio19200.AutoSize = true;
            this.radio19200.Location = new System.Drawing.Point(221, 8);
            this.radio19200.Name = "radio19200";
            this.radio19200.Size = new System.Drawing.Size(132, 17);
            this.radio19200.TabIndex = 2;
            this.radio19200.Text = "19200: POKE 65497,0";
            this.radio19200.UseVisualStyleBackColor = true;
            this.radio19200.CheckedChanged += new System.EventHandler(this.radio19200_CheckedChanged);
            // 
            // radio600
            // 
            this.radio600.AutoSize = true;
            this.radio600.Checked = true;
            this.radio600.Location = new System.Drawing.Point(12, 8);
            this.radio600.Name = "radio600";
            this.radio600.Size = new System.Drawing.Size(83, 17);
            this.radio600.TabIndex = 3;
            this.radio600.TabStop = true;
            this.radio600.Text = "600 (normal)";
            this.radio600.UseVisualStyleBackColor = true;
            this.radio600.CheckedChanged += new System.EventHandler(this.radio600_CheckedChanged);
            // 
            // buttonAcceptDisk
            // 
            this.buttonAcceptDisk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAcceptDisk.Location = new System.Drawing.Point(745, 8);
            this.buttonAcceptDisk.Name = "buttonAcceptDisk";
            this.buttonAcceptDisk.Size = new System.Drawing.Size(89, 23);
            this.buttonAcceptDisk.TabIndex = 4;
            this.buttonAcceptDisk.Text = "Accept Disk";
            this.buttonAcceptDisk.UseVisualStyleBackColor = true;
            this.buttonAcceptDisk.Click += new System.EventHandler(this.buttonAcceptDisk_Click);
            // 
            // buttonClearBuffer
            // 
            this.buttonClearBuffer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClearBuffer.Location = new System.Drawing.Point(555, 8);
            this.buttonClearBuffer.Name = "buttonClearBuffer";
            this.buttonClearBuffer.Size = new System.Drawing.Size(89, 23);
            this.buttonClearBuffer.TabIndex = 5;
            this.buttonClearBuffer.Text = "Clear Buffer";
            this.buttonClearBuffer.UseVisualStyleBackColor = true;
            this.buttonClearBuffer.Click += new System.EventHandler(this.buttonClearBuffer_Click);
            // 
            // checkRecord
            // 
            this.checkRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkRecord.Location = new System.Drawing.Point(555, 37);
            this.checkRecord.Name = "checkRecord";
            this.checkRecord.Size = new System.Drawing.Size(279, 17);
            this.checkRecord.TabIndex = 6;
            this.checkRecord.Text = "Record Buffer (size=0)";
            this.checkRecord.UseVisualStyleBackColor = true;
            // 
            // comboComPorts
            // 
            this.comboComPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboComPorts.FormattingEnabled = true;
            this.comboComPorts.Location = new System.Drawing.Point(12, 32);
            this.comboComPorts.Name = "comboComPorts";
            this.comboComPorts.Size = new System.Drawing.Size(91, 21);
            this.comboComPorts.TabIndex = 7;
            this.comboComPorts.SelectedIndexChanged += new System.EventHandler(this.comboComPorts_SelectedIndexChanged);
            // 
            // buttonSaveBinary
            // 
            this.buttonSaveBinary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveBinary.Location = new System.Drawing.Point(650, 8);
            this.buttonSaveBinary.Name = "buttonSaveBinary";
            this.buttonSaveBinary.Size = new System.Drawing.Size(89, 23);
            this.buttonSaveBinary.TabIndex = 8;
            this.buttonSaveBinary.Text = "Save Binary...";
            this.buttonSaveBinary.UseVisualStyleBackColor = true;
            this.buttonSaveBinary.Click += new System.EventHandler(this.buttonSaveBinary_Click);
            // 
            // FormCocoCom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 560);
            this.Controls.Add(this.buttonSaveBinary);
            this.Controls.Add(this.comboComPorts);
            this.Controls.Add(this.checkRecord);
            this.Controls.Add(this.buttonClearBuffer);
            this.Controls.Add(this.buttonAcceptDisk);
            this.Controls.Add(this.radio600);
            this.Controls.Add(this.radio19200);
            this.Controls.Add(this.radio9600);
            this.Controls.Add(this.textTerminal);
            this.Name = "FormCocoCom";
            this.Text = "Coco Com";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCocoCom_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Shown += new System.EventHandler(this.FormCocoCom_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.TextBox textTerminal;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RadioButton radio9600;
        private System.Windows.Forms.RadioButton radio19200;
        private System.Windows.Forms.RadioButton radio600;
        private System.Windows.Forms.Button buttonAcceptDisk;
        private System.Windows.Forms.Button buttonClearBuffer;
        private System.Windows.Forms.CheckBox checkRecord;
        private System.Windows.Forms.ComboBox comboComPorts;
        private System.Windows.Forms.Button buttonSaveBinary;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

