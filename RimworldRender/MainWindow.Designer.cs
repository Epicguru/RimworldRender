using System.Windows.Forms;

namespace RimworldRender
{
    partial class MainWindow
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
            this.startRenderButton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.OutputFormatCombo = new System.Windows.Forms.ComboBox();
            this.EstimatedTime = new System.Windows.Forms.Label();
            this.settingsGroup = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SamplingComboBox = new System.Windows.Forms.ComboBox();
            this.IPSWarning = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ResolutionY = new System.Windows.Forms.NumericUpDown();
            this.ResolutionX = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.ImagesPerSecondInput = new System.Windows.Forms.NumericUpDown();
            this.imagesPerSecondLabel = new System.Windows.Forms.Label();
            this.FramerateInput = new System.Windows.Forms.NumericUpDown();
            this.frameratelabel = new System.Windows.Forms.Label();
            this.BitrateInput = new System.Windows.Forms.NumericUpDown();
            this.bitrateLabel = new System.Windows.Forms.Label();
            this.BitrateComboBox = new System.Windows.Forms.ComboBox();
            this.codecLabel = new System.Windows.Forms.Label();
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.RenderPreviewCheckbox = new System.Windows.Forms.CheckBox();
            this.settingsGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResolutionY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResolutionX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImagesPerSecondInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FramerateInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BitrateInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // startRenderButton
            // 
            this.startRenderButton.Enabled = false;
            this.startRenderButton.Location = new System.Drawing.Point(263, 68);
            this.startRenderButton.Name = "startRenderButton";
            this.startRenderButton.Size = new System.Drawing.Size(118, 49);
            this.startRenderButton.TabIndex = 0;
            this.startRenderButton.Text = "Start Render";
            this.startRenderButton.UseVisualStyleBackColor = true;
            this.startRenderButton.Click += new System.EventHandler(this.UponStartButtonPressed);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(260, 9);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(96, 13);
            this.statusLabel.TabIndex = 1;
            this.statusLabel.Text = "Waiting for folder...";
            // 
            // ProgressBar
            // 
            this.ProgressBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ProgressBar.Location = new System.Drawing.Point(263, 39);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(439, 23);
            this.ProgressBar.Step = 1;
            this.ProgressBar.TabIndex = 2;
            // 
            // OutputFormatCombo
            // 
            this.OutputFormatCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OutputFormatCombo.FormattingEnabled = true;
            this.OutputFormatCombo.Location = new System.Drawing.Point(53, 84);
            this.OutputFormatCombo.MaxDropDownItems = 16;
            this.OutputFormatCombo.Name = "OutputFormatCombo";
            this.OutputFormatCombo.Size = new System.Drawing.Size(183, 21);
            this.OutputFormatCombo.TabIndex = 3;
            this.OutputFormatCombo.SelectedIndexChanged += new System.EventHandler(this.UponComboValueChanged);
            // 
            // EstimatedTime
            // 
            this.EstimatedTime.AutoSize = true;
            this.EstimatedTime.Location = new System.Drawing.Point(260, 143);
            this.EstimatedTime.Name = "EstimatedTime";
            this.EstimatedTime.Size = new System.Drawing.Size(62, 13);
            this.EstimatedTime.TabIndex = 4;
            this.EstimatedTime.Text = "Est. time: ---";
            // 
            // settingsGroup
            // 
            this.settingsGroup.AutoSize = true;
            this.settingsGroup.BackColor = System.Drawing.SystemColors.ControlLight;
            this.settingsGroup.Controls.Add(this.label3);
            this.settingsGroup.Controls.Add(this.SamplingComboBox);
            this.settingsGroup.Controls.Add(this.IPSWarning);
            this.settingsGroup.Controls.Add(this.label2);
            this.settingsGroup.Controls.Add(this.ResolutionY);
            this.settingsGroup.Controls.Add(this.ResolutionX);
            this.settingsGroup.Controls.Add(this.label1);
            this.settingsGroup.Controls.Add(this.ImagesPerSecondInput);
            this.settingsGroup.Controls.Add(this.imagesPerSecondLabel);
            this.settingsGroup.Controls.Add(this.FramerateInput);
            this.settingsGroup.Controls.Add(this.frameratelabel);
            this.settingsGroup.Controls.Add(this.BitrateInput);
            this.settingsGroup.Controls.Add(this.bitrateLabel);
            this.settingsGroup.Controls.Add(this.BitrateComboBox);
            this.settingsGroup.Controls.Add(this.codecLabel);
            this.settingsGroup.Controls.Add(this.OutputFormatCombo);
            this.settingsGroup.Location = new System.Drawing.Point(12, 12);
            this.settingsGroup.Name = "settingsGroup";
            this.settingsGroup.Size = new System.Drawing.Size(242, 254);
            this.settingsGroup.TabIndex = 5;
            this.settingsGroup.TabStop = false;
            this.settingsGroup.Text = "Output Settings";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Sampling:";
            // 
            // SamplingComboBox
            // 
            this.SamplingComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SamplingComboBox.FormattingEnabled = true;
            this.SamplingComboBox.Location = new System.Drawing.Point(64, 51);
            this.SamplingComboBox.MaxDropDownItems = 16;
            this.SamplingComboBox.Name = "SamplingComboBox";
            this.SamplingComboBox.Size = new System.Drawing.Size(171, 21);
            this.SamplingComboBox.TabIndex = 17;
            // 
            // IPSWarning
            // 
            this.IPSWarning.AutoSize = true;
            this.IPSWarning.Location = new System.Drawing.Point(6, 225);
            this.IPSWarning.Name = "IPSWarning";
            this.IPSWarning.Size = new System.Drawing.Size(29, 13);
            this.IPSWarning.TabIndex = 16;
            this.IPSWarning.Text = "ASD";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(147, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "x";
            // 
            // ResolutionY
            // 
            this.ResolutionY.Location = new System.Drawing.Point(163, 25);
            this.ResolutionY.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.ResolutionY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ResolutionY.Name = "ResolutionY";
            this.ResolutionY.Size = new System.Drawing.Size(73, 20);
            this.ResolutionY.TabIndex = 14;
            this.ResolutionY.Value = new decimal(new int[] {
            1080,
            0,
            0,
            0});
            // 
            // ResolutionX
            // 
            this.ResolutionX.Location = new System.Drawing.Point(72, 25);
            this.ResolutionX.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.ResolutionX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ResolutionX.Name = "ResolutionX";
            this.ResolutionX.Size = new System.Drawing.Size(72, 20);
            this.ResolutionX.TabIndex = 13;
            this.ResolutionX.Value = new decimal(new int[] {
            1920,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Resolution:";
            // 
            // ImagesPerSecondInput
            // 
            this.ImagesPerSecondInput.Location = new System.Drawing.Point(109, 197);
            this.ImagesPerSecondInput.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.ImagesPerSecondInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ImagesPerSecondInput.Name = "ImagesPerSecondInput";
            this.ImagesPerSecondInput.Size = new System.Drawing.Size(127, 20);
            this.ImagesPerSecondInput.TabIndex = 11;
            this.ImagesPerSecondInput.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.ImagesPerSecondInput.ValueChanged += new System.EventHandler(this.UponImagesPerSecondChange);
            // 
            // imagesPerSecondLabel
            // 
            this.imagesPerSecondLabel.AutoSize = true;
            this.imagesPerSecondLabel.Location = new System.Drawing.Point(6, 199);
            this.imagesPerSecondLabel.Name = "imagesPerSecondLabel";
            this.imagesPerSecondLabel.Size = new System.Drawing.Size(100, 13);
            this.imagesPerSecondLabel.TabIndex = 10;
            this.imagesPerSecondLabel.Text = "Images per second:";
            // 
            // FramerateInput
            // 
            this.FramerateInput.Location = new System.Drawing.Point(66, 161);
            this.FramerateInput.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.FramerateInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.FramerateInput.Name = "FramerateInput";
            this.FramerateInput.Size = new System.Drawing.Size(170, 20);
            this.FramerateInput.TabIndex = 9;
            this.FramerateInput.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.FramerateInput.ValueChanged += new System.EventHandler(this.UponFramerateChange);
            // 
            // frameratelabel
            // 
            this.frameratelabel.AutoSize = true;
            this.frameratelabel.Location = new System.Drawing.Point(6, 163);
            this.frameratelabel.Name = "frameratelabel";
            this.frameratelabel.Size = new System.Drawing.Size(57, 13);
            this.frameratelabel.TabIndex = 8;
            this.frameratelabel.Text = "Framerate:";
            // 
            // BitrateInput
            // 
            this.BitrateInput.DecimalPlaces = 2;
            this.BitrateInput.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.BitrateInput.Location = new System.Drawing.Point(52, 122);
            this.BitrateInput.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.BitrateInput.Name = "BitrateInput";
            this.BitrateInput.Size = new System.Drawing.Size(92, 20);
            this.BitrateInput.TabIndex = 7;
            this.BitrateInput.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // bitrateLabel
            // 
            this.bitrateLabel.AutoSize = true;
            this.bitrateLabel.Location = new System.Drawing.Point(6, 124);
            this.bitrateLabel.Name = "bitrateLabel";
            this.bitrateLabel.Size = new System.Drawing.Size(40, 13);
            this.bitrateLabel.TabIndex = 6;
            this.bitrateLabel.Text = "Bitrate:";
            // 
            // BitrateComboBox
            // 
            this.BitrateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BitrateComboBox.FormattingEnabled = true;
            this.BitrateComboBox.Items.AddRange(new object[] {
            "bps",
            "kbps",
            "mbps"});
            this.BitrateComboBox.Location = new System.Drawing.Point(150, 121);
            this.BitrateComboBox.MaxDropDownItems = 16;
            this.BitrateComboBox.Name = "BitrateComboBox";
            this.BitrateComboBox.Size = new System.Drawing.Size(86, 21);
            this.BitrateComboBox.TabIndex = 5;
            this.BitrateComboBox.SelectedIndexChanged += new System.EventHandler(this.UponBitrateComboChange);
            // 
            // codecLabel
            // 
            this.codecLabel.AutoSize = true;
            this.codecLabel.Location = new System.Drawing.Point(6, 87);
            this.codecLabel.Name = "codecLabel";
            this.codecLabel.Size = new System.Drawing.Size(41, 13);
            this.codecLabel.TabIndex = 4;
            this.codecLabel.Text = "Codec:";
            // 
            // PictureBox
            // 
            this.PictureBox.Location = new System.Drawing.Point(387, 68);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(323, 198);
            this.PictureBox.TabIndex = 6;
            this.PictureBox.TabStop = false;
            // 
            // RenderPreviewCheckbox
            // 
            this.RenderPreviewCheckbox.AutoSize = true;
            this.RenderPreviewCheckbox.Checked = true;
            this.RenderPreviewCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RenderPreviewCheckbox.Location = new System.Drawing.Point(263, 123);
            this.RenderPreviewCheckbox.Name = "RenderPreviewCheckbox";
            this.RenderPreviewCheckbox.Size = new System.Drawing.Size(106, 17);
            this.RenderPreviewCheckbox.TabIndex = 7;
            this.RenderPreviewCheckbox.Text = "Render pewview";
            this.RenderPreviewCheckbox.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 277);
            this.Controls.Add(this.RenderPreviewCheckbox);
            this.Controls.Add(this.PictureBox);
            this.Controls.Add(this.settingsGroup);
            this.Controls.Add(this.EstimatedTime);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.startRenderButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rimworld Render";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.UponDragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.UponDragEnter);
            this.settingsGroup.ResumeLayout(false);
            this.settingsGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResolutionY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResolutionX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImagesPerSecondInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FramerateInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BitrateInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }        

        #endregion

        private System.Windows.Forms.Button startRenderButton;
        public System.Windows.Forms.Label statusLabel;
        private ComboBox OutputFormatCombo;
        public ProgressBar ProgressBar;
        public Label EstimatedTime;
        private GroupBox settingsGroup;
        private Label codecLabel;
        private Label bitrateLabel;
        public NumericUpDown BitrateInput;
        public ComboBox BitrateComboBox;
        public NumericUpDown FramerateInput;
        private Label frameratelabel;
        public NumericUpDown ImagesPerSecondInput;
        private Label imagesPerSecondLabel;
        private Label label2;
        public NumericUpDown ResolutionY;
        public NumericUpDown ResolutionX;
        private Label label1;
        private Label IPSWarning;
        private Label label3;
        public ComboBox SamplingComboBox;
        public PictureBox PictureBox;
        private CheckBox RenderPreviewCheckbox;
    }
}

