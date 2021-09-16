namespace AVR_Programmer
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBoxFlash = new System.Windows.Forms.GroupBox();
            this.checkBoxInterfaceCheck = new System.Windows.Forms.CheckBox();
            this.rtbEventLog = new System.Windows.Forms.RichTextBox();
            this.radioButtonEep = new System.Windows.Forms.RadioButton();
            this.radioButtonFlash = new System.Windows.Forms.RadioButton();
            this.buttonRead = new System.Windows.Forms.Button();
            this.checkBoxVerify = new System.Windows.Forms.CheckBox();
            this.checkBoxWrite = new System.Windows.Forms.CheckBox();
            this.checkBoxErase = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.buttonProgram = new System.Windows.Forms.Button();
            this.checkBoxInfoCheck = new System.Windows.Forms.CheckBox();
            this.buttonCheck = new System.Windows.Forms.Button();
            this.comboBoxClock = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxIface = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxFTool = new System.Windows.Forms.ComboBox();
            this.comboBoxMcu = new System.Windows.Forms.ComboBox();
            this.groupBoxParam = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxFirmwareFile = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.groupBoxFlash.SuspendLayout();
            this.groupBoxParam.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxFlash
            // 
            this.groupBoxFlash.Controls.Add(this.checkBoxInterfaceCheck);
            this.groupBoxFlash.Controls.Add(this.rtbEventLog);
            this.groupBoxFlash.Controls.Add(this.radioButtonEep);
            this.groupBoxFlash.Controls.Add(this.radioButtonFlash);
            this.groupBoxFlash.Controls.Add(this.buttonRead);
            this.groupBoxFlash.Controls.Add(this.checkBoxVerify);
            this.groupBoxFlash.Controls.Add(this.checkBoxWrite);
            this.groupBoxFlash.Controls.Add(this.checkBoxErase);
            this.groupBoxFlash.Controls.Add(this.progressBar1);
            this.groupBoxFlash.Controls.Add(this.buttonProgram);
            this.groupBoxFlash.Location = new System.Drawing.Point(12, 120);
            this.groupBoxFlash.Name = "groupBoxFlash";
            this.groupBoxFlash.Size = new System.Drawing.Size(444, 339);
            this.groupBoxFlash.TabIndex = 1;
            this.groupBoxFlash.TabStop = false;
            this.groupBoxFlash.Text = "Memory";
            // 
            // checkBoxInterfaceCheck
            // 
            this.checkBoxInterfaceCheck.AutoSize = true;
            this.checkBoxInterfaceCheck.Checked = true;
            this.checkBoxInterfaceCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxInterfaceCheck.Location = new System.Drawing.Point(97, 71);
            this.checkBoxInterfaceCheck.Name = "checkBoxInterfaceCheck";
            this.checkBoxInterfaceCheck.Size = new System.Drawing.Size(57, 17);
            this.checkBoxInterfaceCheck.TabIndex = 4;
            this.checkBoxInterfaceCheck.Text = "Check";
            this.checkBoxInterfaceCheck.UseVisualStyleBackColor = true;
            // 
            // rtbEventLog
            // 
            this.rtbEventLog.Location = new System.Drawing.Point(11, 118);
            this.rtbEventLog.Name = "rtbEventLog";
            this.rtbEventLog.ReadOnly = true;
            this.rtbEventLog.Size = new System.Drawing.Size(424, 210);
            this.rtbEventLog.TabIndex = 9;
            this.rtbEventLog.Text = "";
            this.rtbEventLog.WordWrap = false;
            // 
            // radioButtonEep
            // 
            this.radioButtonEep.AutoSize = true;
            this.radioButtonEep.Location = new System.Drawing.Point(11, 51);
            this.radioButtonEep.Name = "radioButtonEep";
            this.radioButtonEep.Size = new System.Drawing.Size(71, 17);
            this.radioButtonEep.TabIndex = 1;
            this.radioButtonEep.Text = "EEPROM";
            this.radioButtonEep.UseVisualStyleBackColor = true;
            // 
            // radioButtonFlash
            // 
            this.radioButtonFlash.AutoSize = true;
            this.radioButtonFlash.Checked = true;
            this.radioButtonFlash.Location = new System.Drawing.Point(11, 28);
            this.radioButtonFlash.Name = "radioButtonFlash";
            this.radioButtonFlash.Size = new System.Drawing.Size(59, 17);
            this.radioButtonFlash.TabIndex = 0;
            this.radioButtonFlash.TabStop = true;
            this.radioButtonFlash.Text = "FLASH";
            this.radioButtonFlash.UseVisualStyleBackColor = true;
            // 
            // buttonRead
            // 
            this.buttonRead.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRead.Location = new System.Drawing.Point(97, 19);
            this.buttonRead.Name = "buttonRead";
            this.buttonRead.Size = new System.Drawing.Size(120, 46);
            this.buttonRead.TabIndex = 2;
            this.buttonRead.Text = "Read";
            this.buttonRead.UseVisualStyleBackColor = true;
            this.buttonRead.Click += new System.EventHandler(this.ButtonRead_Click);
            // 
            // checkBoxVerify
            // 
            this.checkBoxVerify.AutoSize = true;
            this.checkBoxVerify.Checked = true;
            this.checkBoxVerify.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxVerify.Location = new System.Drawing.Point(369, 71);
            this.checkBoxVerify.Name = "checkBoxVerify";
            this.checkBoxVerify.Size = new System.Drawing.Size(52, 17);
            this.checkBoxVerify.TabIndex = 7;
            this.checkBoxVerify.Text = "Verify";
            this.checkBoxVerify.UseVisualStyleBackColor = true;
            // 
            // checkBoxWrite
            // 
            this.checkBoxWrite.AutoSize = true;
            this.checkBoxWrite.Checked = true;
            this.checkBoxWrite.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxWrite.Location = new System.Drawing.Point(301, 71);
            this.checkBoxWrite.Name = "checkBoxWrite";
            this.checkBoxWrite.Size = new System.Drawing.Size(51, 17);
            this.checkBoxWrite.TabIndex = 6;
            this.checkBoxWrite.Text = "Write";
            this.checkBoxWrite.UseVisualStyleBackColor = true;
            // 
            // checkBoxErase
            // 
            this.checkBoxErase.AutoSize = true;
            this.checkBoxErase.Checked = true;
            this.checkBoxErase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxErase.Location = new System.Drawing.Point(241, 71);
            this.checkBoxErase.Name = "checkBoxErase";
            this.checkBoxErase.Size = new System.Drawing.Size(53, 17);
            this.checkBoxErase.TabIndex = 5;
            this.checkBoxErase.Text = "Erase";
            this.checkBoxErase.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(11, 97);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(424, 15);
            this.progressBar1.TabIndex = 8;
            // 
            // buttonProgram
            // 
            this.buttonProgram.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonProgram.Location = new System.Drawing.Point(241, 19);
            this.buttonProgram.Name = "buttonProgram";
            this.buttonProgram.Size = new System.Drawing.Size(180, 46);
            this.buttonProgram.TabIndex = 3;
            this.buttonProgram.Text = "Program";
            this.buttonProgram.UseVisualStyleBackColor = true;
            this.buttonProgram.Click += new System.EventHandler(this.ButtonProgram_Click);
            // 
            // checkBoxInfoCheck
            // 
            this.checkBoxInfoCheck.AutoSize = true;
            this.checkBoxInfoCheck.Location = new System.Drawing.Point(358, 15);
            this.checkBoxInfoCheck.Name = "checkBoxInfoCheck";
            this.checkBoxInfoCheck.Size = new System.Drawing.Size(78, 17);
            this.checkBoxInfoCheck.TabIndex = 4;
            this.checkBoxInfoCheck.Text = "Check Info";
            this.checkBoxInfoCheck.UseVisualStyleBackColor = true;
            // 
            // buttonCheck
            // 
            this.buttonCheck.Location = new System.Drawing.Point(358, 38);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(75, 23);
            this.buttonCheck.TabIndex = 9;
            this.buttonCheck.Text = "Check";
            this.buttonCheck.UseVisualStyleBackColor = true;
            this.buttonCheck.Click += new System.EventHandler(this.ButtonCheck_Click);
            // 
            // comboBoxClock
            // 
            this.comboBoxClock.FormattingEnabled = true;
            this.comboBoxClock.Location = new System.Drawing.Point(241, 40);
            this.comboBoxClock.Name = "comboBoxClock";
            this.comboBoxClock.Size = new System.Drawing.Size(111, 21);
            this.comboBoxClock.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(197, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Speed";
            // 
            // comboBoxIface
            // 
            this.comboBoxIface.FormattingEnabled = true;
            this.comboBoxIface.Location = new System.Drawing.Point(61, 40);
            this.comboBoxIface.Name = "comboBoxIface";
            this.comboBoxIface.Size = new System.Drawing.Size(111, 21);
            this.comboBoxIface.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Interface";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(181, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Debugger";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Controller";
            // 
            // comboBoxFTool
            // 
            this.comboBoxFTool.FormattingEnabled = true;
            this.comboBoxFTool.Location = new System.Drawing.Point(241, 13);
            this.comboBoxFTool.Name = "comboBoxFTool";
            this.comboBoxFTool.Size = new System.Drawing.Size(111, 21);
            this.comboBoxFTool.TabIndex = 3;
            // 
            // comboBoxMcu
            // 
            this.comboBoxMcu.FormattingEnabled = true;
            this.comboBoxMcu.Location = new System.Drawing.Point(61, 13);
            this.comboBoxMcu.Name = "comboBoxMcu";
            this.comboBoxMcu.Size = new System.Drawing.Size(111, 21);
            this.comboBoxMcu.TabIndex = 1;
            // 
            // groupBoxParam
            // 
            this.groupBoxParam.Controls.Add(this.label3);
            this.groupBoxParam.Controls.Add(this.checkBoxInfoCheck);
            this.groupBoxParam.Controls.Add(this.textBoxFirmwareFile);
            this.groupBoxParam.Controls.Add(this.buttonBrowse);
            this.groupBoxParam.Controls.Add(this.buttonCheck);
            this.groupBoxParam.Controls.Add(this.comboBoxMcu);
            this.groupBoxParam.Controls.Add(this.comboBoxFTool);
            this.groupBoxParam.Controls.Add(this.label4);
            this.groupBoxParam.Controls.Add(this.label5);
            this.groupBoxParam.Controls.Add(this.label6);
            this.groupBoxParam.Controls.Add(this.comboBoxIface);
            this.groupBoxParam.Controls.Add(this.comboBoxClock);
            this.groupBoxParam.Controls.Add(this.label7);
            this.groupBoxParam.Location = new System.Drawing.Point(12, 12);
            this.groupBoxParam.Name = "groupBoxParam";
            this.groupBoxParam.Size = new System.Drawing.Size(444, 102);
            this.groupBoxParam.TabIndex = 0;
            this.groupBoxParam.TabStop = false;
            this.groupBoxParam.Text = "Parameter";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Firmware";
            // 
            // textBoxFirmwareFile
            // 
            this.textBoxFirmwareFile.Location = new System.Drawing.Point(61, 67);
            this.textBoxFirmwareFile.Name = "textBoxFirmwareFile";
            this.textBoxFirmwareFile.Size = new System.Drawing.Size(291, 20);
            this.textBoxFirmwareFile.TabIndex = 11;
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(358, 65);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowse.TabIndex = 12;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.ButtonBrowse_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 470);
            this.Controls.Add(this.groupBoxParam);
            this.Controls.Add(this.groupBoxFlash);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "AVR Programmer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.groupBoxFlash.ResumeLayout(false);
            this.groupBoxFlash.PerformLayout();
            this.groupBoxParam.ResumeLayout(false);
            this.groupBoxParam.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxFlash;
        private System.Windows.Forms.Button buttonProgram;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBoxParam;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxFirmwareFile;
        private System.Windows.Forms.ComboBox comboBoxFTool;
        private System.Windows.Forms.ComboBox comboBoxMcu;
        private System.Windows.Forms.ComboBox comboBoxIface;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxClock;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBoxWrite;
        private System.Windows.Forms.CheckBox checkBoxErase;
        private System.Windows.Forms.CheckBox checkBoxVerify;
        private System.Windows.Forms.Button buttonCheck;
        private System.Windows.Forms.Button buttonRead;
        private System.Windows.Forms.RadioButton radioButtonEep;
        private System.Windows.Forms.RadioButton radioButtonFlash;
        private System.Windows.Forms.CheckBox checkBoxInfoCheck;
        private System.Windows.Forms.RichTextBox rtbEventLog;
        private System.Windows.Forms.CheckBox checkBoxInterfaceCheck;
    }
}

