namespace Radio_Waves_Simulator {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.AntennaShapesDropdown = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CurrentFunctionsDropDown = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.simRegionWidth = new System.Windows.Forms.NumericUpDown();
            this.simRegionHeight = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.timeStep = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.wireElementSize = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pixelSize = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lightSpeed = new System.Windows.Forms.NumericUpDown();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.SimulateButton = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label13 = new System.Windows.Forms.Label();
            this.simulationFrames = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.simRegionWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simRegionHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wireElementSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pixelSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lightSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simulationFrames)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel1.Controls.Add(this.SimulateButton);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1161, 793);
            this.splitContainer1.SplitterDistance = 231;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(226, 749);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.flowLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(218, 721);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Wire";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.AntennaShapesDropdown);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.CurrentFunctionsDropDown);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(212, 715);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Antenna Shape";
            // 
            // AntennaShapesDropdown
            // 
            this.AntennaShapesDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AntennaShapesDropdown.FormattingEnabled = true;
            this.AntennaShapesDropdown.Location = new System.Drawing.Point(3, 28);
            this.AntennaShapesDropdown.Name = "AntennaShapesDropdown";
            this.AntennaShapesDropdown.Size = new System.Drawing.Size(206, 23);
            this.AntennaShapesDropdown.TabIndex = 1;
            this.AntennaShapesDropdown.SelectedIndexChanged += new System.EventHandler(this.AntennaShapesDropdown_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 54);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label2.Size = new System.Drawing.Size(143, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Current vs. Time Function";
            // 
            // CurrentFunctionsDropDown
            // 
            this.CurrentFunctionsDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CurrentFunctionsDropDown.FormattingEnabled = true;
            this.CurrentFunctionsDropDown.Location = new System.Drawing.Point(3, 82);
            this.CurrentFunctionsDropDown.Name = "CurrentFunctionsDropDown";
            this.CurrentFunctionsDropDown.Size = new System.Drawing.Size(206, 23);
            this.CurrentFunctionsDropDown.TabIndex = 3;
            this.CurrentFunctionsDropDown.SelectedIndexChanged += new System.EventHandler(this.CurrentFunctionsDropDown_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.flowLayoutPanel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(218, 721);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Simulation";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label3);
            this.flowLayoutPanel2.Controls.Add(this.label4);
            this.flowLayoutPanel2.Controls.Add(this.simRegionWidth);
            this.flowLayoutPanel2.Controls.Add(this.simRegionHeight);
            this.flowLayoutPanel2.Controls.Add(this.label5);
            this.flowLayoutPanel2.Controls.Add(this.label6);
            this.flowLayoutPanel2.Controls.Add(this.timeStep);
            this.flowLayoutPanel2.Controls.Add(this.label7);
            this.flowLayoutPanel2.Controls.Add(this.label8);
            this.flowLayoutPanel2.Controls.Add(this.wireElementSize);
            this.flowLayoutPanel2.Controls.Add(this.label9);
            this.flowLayoutPanel2.Controls.Add(this.label10);
            this.flowLayoutPanel2.Controls.Add(this.pixelSize);
            this.flowLayoutPanel2.Controls.Add(this.label11);
            this.flowLayoutPanel2.Controls.Add(this.label12);
            this.flowLayoutPanel2.Controls.Add(this.lightSpeed);
            this.flowLayoutPanel2.Controls.Add(this.label13);
            this.flowLayoutPanel2.Controls.Add(this.simulationFrames);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(212, 715);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Simulation Region";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label4.Location = new System.Drawing.Point(3, 25);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.label4.Size = new System.Drawing.Size(145, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "Region to simulate field in";
            // 
            // simRegionWidth
            // 
            this.simRegionWidth.Location = new System.Drawing.Point(3, 53);
            this.simRegionWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.simRegionWidth.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.simRegionWidth.Name = "simRegionWidth";
            this.simRegionWidth.Size = new System.Drawing.Size(120, 23);
            this.simRegionWidth.TabIndex = 2;
            this.simRegionWidth.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // simRegionHeight
            // 
            this.simRegionHeight.Location = new System.Drawing.Point(3, 82);
            this.simRegionHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.simRegionHeight.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.simRegionHeight.Name = "simRegionHeight";
            this.simRegionHeight.Size = new System.Drawing.Size(120, 23);
            this.simRegionHeight.TabIndex = 3;
            this.simRegionHeight.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(3, 108);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.label5.Size = new System.Drawing.Size(64, 30);
            this.label5.TabIndex = 5;
            this.label5.Text = "Time Step";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label6.Location = new System.Drawing.Point(3, 138);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.label6.Size = new System.Drawing.Size(165, 25);
            this.label6.TabIndex = 6;
            this.label6.Text = "Time between each frame (dt)";
            // 
            // timeStep
            // 
            this.timeStep.DecimalPlaces = 4;
            this.timeStep.Location = new System.Drawing.Point(3, 166);
            this.timeStep.Name = "timeStep";
            this.timeStep.Size = new System.Drawing.Size(120, 23);
            this.timeStep.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(3, 192);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.label7.Size = new System.Drawing.Size(109, 30);
            this.label7.TabIndex = 8;
            this.label7.Text = "Wire Element Size";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label8.Location = new System.Drawing.Point(3, 222);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.label8.Size = new System.Drawing.Size(196, 55);
            this.label8.TabIndex = 9;
            this.label8.Text = "Lower values correspond to smaller wire elements and thus a more accurate simulat" +
    "ion (dp)";
            // 
            // wireElementSize
            // 
            this.wireElementSize.DecimalPlaces = 4;
            this.wireElementSize.Location = new System.Drawing.Point(3, 280);
            this.wireElementSize.Name = "wireElementSize";
            this.wireElementSize.Size = new System.Drawing.Size(120, 23);
            this.wireElementSize.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(3, 306);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.label9.Size = new System.Drawing.Size(60, 30);
            this.label9.TabIndex = 11;
            this.label9.Text = "Pixel Size";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label10.Location = new System.Drawing.Point(3, 336);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.label10.Size = new System.Drawing.Size(152, 25);
            this.label10.TabIndex = 12;
            this.label10.Text = "Size of each simulated pixel";
            // 
            // pixelSize
            // 
            this.pixelSize.Location = new System.Drawing.Point(3, 364);
            this.pixelSize.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.pixelSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.pixelSize.Name = "pixelSize";
            this.pixelSize.Size = new System.Drawing.Size(120, 23);
            this.pixelSize.TabIndex = 13;
            this.pixelSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(3, 390);
            this.label11.Name = "label11";
            this.label11.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.label11.Size = new System.Drawing.Size(88, 30);
            this.label11.TabIndex = 14;
            this.label11.Text = "Speed of Light";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label12.Location = new System.Drawing.Point(3, 420);
            this.label12.Name = "label12";
            this.label12.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.label12.Size = new System.Drawing.Size(193, 25);
            this.label12.TabIndex = 15;
            this.label12.Text = "How fast radio waves propagate (c)";
            // 
            // lightSpeed
            // 
            this.lightSpeed.DecimalPlaces = 4;
            this.lightSpeed.Location = new System.Drawing.Point(3, 448);
            this.lightSpeed.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.lightSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.lightSpeed.Name = "lightSpeed";
            this.lightSpeed.Size = new System.Drawing.Size(120, 23);
            this.lightSpeed.TabIndex = 16;
            this.lightSpeed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(218, 721);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Rendering";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // SimulateButton
            // 
            this.SimulateButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SimulateButton.Location = new System.Drawing.Point(15, 758);
            this.SimulateButton.MaximumSize = new System.Drawing.Size(200, 100);
            this.SimulateButton.Name = "SimulateButton";
            this.SimulateButton.Size = new System.Drawing.Size(200, 23);
            this.SimulateButton.TabIndex = 1;
            this.SimulateButton.Text = "Simulate";
            this.SimulateButton.UseVisualStyleBackColor = true;
            this.SimulateButton.Click += new System.EventHandler(this.SimulateButton_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.Black;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.pictureBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.button2);
            this.splitContainer2.Panel2.Controls.Add(this.trackBar1);
            this.splitContainer2.Size = new System.Drawing.Size(926, 793);
            this.splitContainer2.SplitterDistance = 742;
            this.splitContainer2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(926, 742);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::Radio_Waves_Simulator.Properties.Resources.PlayIcon;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(9, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(37, 37);
            this.button2.TabIndex = 1;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar1.BackColor = System.Drawing.Color.Black;
            this.trackBar1.Enabled = false;
            this.trackBar1.Location = new System.Drawing.Point(48, 3);
            this.trackBar1.Maximum = 0;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(875, 45);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(3, 474);
            this.label13.Name = "label13";
            this.label13.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.label13.Size = new System.Drawing.Size(109, 30);
            this.label13.TabIndex = 17;
            this.label13.Text = "Simulation Frames";
            // 
            // simulationFrames
            // 
            this.simulationFrames.Location = new System.Drawing.Point(3, 507);
            this.simulationFrames.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.simulationFrames.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.simulationFrames.Name = "simulationFrames";
            this.simulationFrames.Size = new System.Drawing.Size(120, 23);
            this.simulationFrames.TabIndex = 18;
            this.simulationFrames.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 793);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Radio Waves Simulator";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.simRegionWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simRegionHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wireElementSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pixelSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lightSpeed)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simulationFrames)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer splitContainer1;
        private Button SimulateButton;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label1;
        private ComboBox AntennaShapesDropdown;
        private Label label2;
        private ComboBox CurrentFunctionsDropDown;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private SplitContainer splitContainer2;
        private PictureBox pictureBox1;
        private TrackBar trackBar1;
        private Button button2;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label label3;
        private NumericUpDown simRegionWidth;
        private NumericUpDown simRegionHeight;
        private Label label4;
        private Label label5;
        private Label label6;
        private NumericUpDown timeStep;
        private Label label7;
        private Label label8;
        private NumericUpDown wireElementSize;
        private Label label9;
        private Label label10;
        private NumericUpDown pixelSize;
        private Label label11;
        private Label label12;
        private NumericUpDown lightSpeed;
        private Label label13;
        private NumericUpDown simulationFrames;
    }
}