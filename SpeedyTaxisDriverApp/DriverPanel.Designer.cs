namespace SpeedyTaxisDriverApp
{
    partial class DriverPanel
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
            this.AllTabs = new System.Windows.Forms.TabControl();
            this.LogTab = new System.Windows.Forms.TabPage();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.Log_ProcessStatus = new System.Windows.Forms.Label();
            this.Log_EndJourneyNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Log_StartJourneyNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Log_EndWorkNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Log_StartWorkNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Log_TotalWorkHoursLabel = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.Log_JourneyDurationLabel = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.Log_ProcessLogButton = new System.Windows.Forms.Button();
            this.label37 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.AllTabs.SuspendLayout();
            this.LogTab.SuspendLayout();
            this.groupBox19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Log_EndJourneyNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Log_StartJourneyNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Log_EndWorkNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Log_StartWorkNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // AllTabs
            // 
            this.AllTabs.Controls.Add(this.LogTab);
            this.AllTabs.Font = new System.Drawing.Font("Microsoft JhengHei Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AllTabs.Location = new System.Drawing.Point(36, 87);
            this.AllTabs.Name = "AllTabs";
            this.AllTabs.SelectedIndex = 0;
            this.AllTabs.Size = new System.Drawing.Size(887, 448);
            this.AllTabs.TabIndex = 2;
            // 
            // LogTab
            // 
            this.LogTab.BackColor = System.Drawing.Color.Transparent;
            this.LogTab.Controls.Add(this.groupBox19);
            this.LogTab.Location = new System.Drawing.Point(4, 24);
            this.LogTab.Name = "LogTab";
            this.LogTab.Padding = new System.Windows.Forms.Padding(3);
            this.LogTab.Size = new System.Drawing.Size(879, 420);
            this.LogTab.TabIndex = 7;
            this.LogTab.Text = "Log Work Hours";
            // 
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.Log_ProcessStatus);
            this.groupBox19.Controls.Add(this.Log_EndJourneyNumericUpDown);
            this.groupBox19.Controls.Add(this.Log_StartJourneyNumericUpDown);
            this.groupBox19.Controls.Add(this.Log_EndWorkNumericUpDown);
            this.groupBox19.Controls.Add(this.Log_StartWorkNumericUpDown);
            this.groupBox19.Controls.Add(this.Log_TotalWorkHoursLabel);
            this.groupBox19.Controls.Add(this.label40);
            this.groupBox19.Controls.Add(this.Log_JourneyDurationLabel);
            this.groupBox19.Controls.Add(this.label38);
            this.groupBox19.Controls.Add(this.Log_ProcessLogButton);
            this.groupBox19.Controls.Add(this.label37);
            this.groupBox19.Controls.Add(this.label36);
            this.groupBox19.Controls.Add(this.label35);
            this.groupBox19.Controls.Add(this.label34);
            this.groupBox19.Location = new System.Drawing.Point(19, 17);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(841, 386);
            this.groupBox19.TabIndex = 0;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "Add to Work log";
            // 
            // Log_ProcessStatus
            // 
            this.Log_ProcessStatus.AutoSize = true;
            this.Log_ProcessStatus.Location = new System.Drawing.Point(12, 263);
            this.Log_ProcessStatus.Name = "Log_ProcessStatus";
            this.Log_ProcessStatus.Size = new System.Drawing.Size(0, 15);
            this.Log_ProcessStatus.TabIndex = 17;
            // 
            // Log_EndJourneyNumericUpDown
            // 
            this.Log_EndJourneyNumericUpDown.Location = new System.Drawing.Point(81, 145);
            this.Log_EndJourneyNumericUpDown.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.Log_EndJourneyNumericUpDown.Name = "Log_EndJourneyNumericUpDown";
            this.Log_EndJourneyNumericUpDown.Size = new System.Drawing.Size(120, 22);
            this.Log_EndJourneyNumericUpDown.TabIndex = 16;
            this.Log_EndJourneyNumericUpDown.ValueChanged += new System.EventHandler(this.Log_EndJourneyNumericUpDown_ValueChanged);
            // 
            // Log_StartJourneyNumericUpDown
            // 
            this.Log_StartJourneyNumericUpDown.Location = new System.Drawing.Point(82, 109);
            this.Log_StartJourneyNumericUpDown.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.Log_StartJourneyNumericUpDown.Name = "Log_StartJourneyNumericUpDown";
            this.Log_StartJourneyNumericUpDown.Size = new System.Drawing.Size(120, 22);
            this.Log_StartJourneyNumericUpDown.TabIndex = 15;
            this.Log_StartJourneyNumericUpDown.ValueChanged += new System.EventHandler(this.Log_StartJourneyNumericUpDown_ValueChanged);
            // 
            // Log_EndWorkNumericUpDown
            // 
            this.Log_EndWorkNumericUpDown.Location = new System.Drawing.Point(82, 73);
            this.Log_EndWorkNumericUpDown.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.Log_EndWorkNumericUpDown.Name = "Log_EndWorkNumericUpDown";
            this.Log_EndWorkNumericUpDown.Size = new System.Drawing.Size(120, 22);
            this.Log_EndWorkNumericUpDown.TabIndex = 14;
            this.Log_EndWorkNumericUpDown.ValueChanged += new System.EventHandler(this.Log_EndWorkNumericUpDown_ValueChanged);
            // 
            // Log_StartWorkNumericUpDown
            // 
            this.Log_StartWorkNumericUpDown.Location = new System.Drawing.Point(82, 36);
            this.Log_StartWorkNumericUpDown.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.Log_StartWorkNumericUpDown.Name = "Log_StartWorkNumericUpDown";
            this.Log_StartWorkNumericUpDown.Size = new System.Drawing.Size(120, 22);
            this.Log_StartWorkNumericUpDown.TabIndex = 13;
            this.Log_StartWorkNumericUpDown.ValueChanged += new System.EventHandler(this.Log_StartWorkNumericUpDown_ValueChanged);
            // 
            // Log_TotalWorkHoursLabel
            // 
            this.Log_TotalWorkHoursLabel.AutoSize = true;
            this.Log_TotalWorkHoursLabel.Location = new System.Drawing.Point(110, 223);
            this.Log_TotalWorkHoursLabel.Name = "Log_TotalWorkHoursLabel";
            this.Log_TotalWorkHoursLabel.Size = new System.Drawing.Size(23, 15);
            this.Log_TotalWorkHoursLabel.TabIndex = 12;
            this.Log_TotalWorkHoursLabel.Text = "null";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(13, 223);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(97, 15);
            this.label40.TabIndex = 11;
            this.label40.Text = "Total Work Hours:";
            // 
            // Log_JourneyDurationLabel
            // 
            this.Log_JourneyDurationLabel.AutoSize = true;
            this.Log_JourneyDurationLabel.Location = new System.Drawing.Point(110, 194);
            this.Log_JourneyDurationLabel.Name = "Log_JourneyDurationLabel";
            this.Log_JourneyDurationLabel.Size = new System.Drawing.Size(23, 15);
            this.Log_JourneyDurationLabel.TabIndex = 10;
            this.Log_JourneyDurationLabel.Text = "null";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(15, 194);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(94, 15);
            this.label38.TabIndex = 9;
            this.label38.Text = "Journey Duration:";
            // 
            // Log_ProcessLogButton
            // 
            this.Log_ProcessLogButton.Location = new System.Drawing.Point(81, 319);
            this.Log_ProcessLogButton.Name = "Log_ProcessLogButton";
            this.Log_ProcessLogButton.Size = new System.Drawing.Size(75, 23);
            this.Log_ProcessLogButton.TabIndex = 8;
            this.Log_ProcessLogButton.Text = "Process";
            this.Log_ProcessLogButton.UseVisualStyleBackColor = true;
            this.Log_ProcessLogButton.Click += new System.EventHandler(this.Log_ProcessLogButton_Click);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(9, 147);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(67, 15);
            this.label37.TabIndex = 7;
            this.label37.Text = "End Journey";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(7, 111);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(72, 15);
            this.label36.TabIndex = 6;
            this.label36.Text = "Start Journey";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(20, 75);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(56, 15);
            this.label35.TabIndex = 5;
            this.label35.Text = "End Work";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(15, 38);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(61, 15);
            this.label34.TabIndex = 4;
            this.label34.Text = "Start Work";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(876, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 31);
            this.button1.TabIndex = 3;
            this.button1.Text = "Log Out";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.LogOut_Click);
            // 
            // DriverPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 560);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.AllTabs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DriverPanel";
            this.Text = "DriverPanel";
            this.AllTabs.ResumeLayout(false);
            this.LogTab.ResumeLayout(false);
            this.groupBox19.ResumeLayout(false);
            this.groupBox19.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Log_EndJourneyNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Log_StartJourneyNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Log_EndWorkNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Log_StartWorkNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl AllTabs;
        private System.Windows.Forms.TabPage LogTab;
        private System.Windows.Forms.GroupBox groupBox19;
        private System.Windows.Forms.Label Log_ProcessStatus;
        private System.Windows.Forms.NumericUpDown Log_EndJourneyNumericUpDown;
        private System.Windows.Forms.NumericUpDown Log_StartJourneyNumericUpDown;
        private System.Windows.Forms.NumericUpDown Log_EndWorkNumericUpDown;
        private System.Windows.Forms.NumericUpDown Log_StartWorkNumericUpDown;
        private System.Windows.Forms.Label Log_TotalWorkHoursLabel;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label Log_JourneyDurationLabel;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Button Log_ProcessLogButton;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Button button1;
    }
}