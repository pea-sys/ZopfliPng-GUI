namespace ZopfliPng_GUI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.compressButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.dropPointLabel = new System.Windows.Forms.Label();
            this.guidanceLabel = new System.Windows.Forms.Label();
            this.beforeSizeTitleLabel = new System.Windows.Forms.Label();
            this.beforeSizeValueLabel = new System.Windows.Forms.Label();
            this.afterSizeValueLabel = new System.Windows.Forms.Label();
            this.afterSizeTitleLabel = new System.Windows.Forms.Label();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.compressCountValuelabel = new System.Windows.Forms.Label();
            this.compressCountTitlelabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // compressButton
            // 
            this.compressButton.Enabled = false;
            this.compressButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.compressButton.FlatAppearance.BorderSize = 3;
            this.compressButton.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.compressButton.Location = new System.Drawing.Point(12, 12);
            this.compressButton.Name = "compressButton";
            this.compressButton.Size = new System.Drawing.Size(106, 32);
            this.compressButton.TabIndex = 0;
            this.compressButton.Text = "Compress";
            this.compressButton.UseVisualStyleBackColor = true;
            this.compressButton.Click += new System.EventHandler(this.compressButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 135);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(239, 15);
            this.progressBar.Step = 1;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 1;
            // 
            // dropPointLabel
            // 
            this.dropPointLabel.AllowDrop = true;
            this.dropPointLabel.Image = ((System.Drawing.Image)(resources.GetObject("dropPointLabel.Image")));
            this.dropPointLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.dropPointLabel.Location = new System.Drawing.Point(3, -2);
            this.dropPointLabel.Name = "dropPointLabel";
            this.dropPointLabel.Size = new System.Drawing.Size(278, 163);
            this.dropPointLabel.TabIndex = 4;
            this.dropPointLabel.DragDrop += new System.Windows.Forms.DragEventHandler(this.dropPointLabel_DragDrop);
            this.dropPointLabel.DragEnter += new System.Windows.Forms.DragEventHandler(this.dropPointLabel_DragEnter);
            // 
            // guidanceLabel
            // 
            this.guidanceLabel.BackColor = System.Drawing.Color.Transparent;
            this.guidanceLabel.Location = new System.Drawing.Point(8, 118);
            this.guidanceLabel.Name = "guidanceLabel";
            this.guidanceLabel.Size = new System.Drawing.Size(173, 23);
            this.guidanceLabel.TabIndex = 5;
            this.guidanceLabel.Text = "1234567890123456789012345678";
            // 
            // beforeSizeTitleLabel
            // 
            this.beforeSizeTitleLabel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.beforeSizeTitleLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.beforeSizeTitleLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.beforeSizeTitleLabel.ForeColor = System.Drawing.Color.Black;
            this.beforeSizeTitleLabel.Location = new System.Drawing.Point(13, 63);
            this.beforeSizeTitleLabel.Name = "beforeSizeTitleLabel";
            this.beforeSizeTitleLabel.Size = new System.Drawing.Size(66, 18);
            this.beforeSizeTitleLabel.TabIndex = 6;
            this.beforeSizeTitleLabel.Text = "BeforeByte";
            // 
            // beforeSizeValueLabel
            // 
            this.beforeSizeValueLabel.BackColor = System.Drawing.Color.White;
            this.beforeSizeValueLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.beforeSizeValueLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.beforeSizeValueLabel.ForeColor = System.Drawing.Color.Black;
            this.beforeSizeValueLabel.Location = new System.Drawing.Point(75, 63);
            this.beforeSizeValueLabel.Name = "beforeSizeValueLabel";
            this.beforeSizeValueLabel.Size = new System.Drawing.Size(70, 18);
            this.beforeSizeValueLabel.TabIndex = 7;
            this.beforeSizeValueLabel.Text = "999999999999";
            this.beforeSizeValueLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // afterSizeValueLabel
            // 
            this.afterSizeValueLabel.BackColor = System.Drawing.Color.White;
            this.afterSizeValueLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.afterSizeValueLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.afterSizeValueLabel.ForeColor = System.Drawing.Color.Black;
            this.afterSizeValueLabel.Location = new System.Drawing.Point(75, 81);
            this.afterSizeValueLabel.Name = "afterSizeValueLabel";
            this.afterSizeValueLabel.Size = new System.Drawing.Size(70, 18);
            this.afterSizeValueLabel.TabIndex = 9;
            this.afterSizeValueLabel.Text = "999999999999";
            this.afterSizeValueLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // afterSizeTitleLabel
            // 
            this.afterSizeTitleLabel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.afterSizeTitleLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.afterSizeTitleLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.afterSizeTitleLabel.ForeColor = System.Drawing.Color.Black;
            this.afterSizeTitleLabel.Location = new System.Drawing.Point(13, 81);
            this.afterSizeTitleLabel.Name = "afterSizeTitleLabel";
            this.afterSizeTitleLabel.Size = new System.Drawing.Size(66, 18);
            this.afterSizeTitleLabel.TabIndex = 8;
            this.afterSizeTitleLabel.Text = "AfterByte";
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // compressCountValuelabel
            // 
            this.compressCountValuelabel.BackColor = System.Drawing.Color.White;
            this.compressCountValuelabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.compressCountValuelabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.compressCountValuelabel.ForeColor = System.Drawing.Color.Black;
            this.compressCountValuelabel.Location = new System.Drawing.Point(75, 47);
            this.compressCountValuelabel.Name = "compressCountValuelabel";
            this.compressCountValuelabel.Size = new System.Drawing.Size(70, 18);
            this.compressCountValuelabel.TabIndex = 11;
            this.compressCountValuelabel.Text = "999999999999";
            this.compressCountValuelabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // compressCountTitlelabel
            // 
            this.compressCountTitlelabel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.compressCountTitlelabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.compressCountTitlelabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.compressCountTitlelabel.ForeColor = System.Drawing.Color.Black;
            this.compressCountTitlelabel.Location = new System.Drawing.Point(13, 47);
            this.compressCountTitlelabel.Name = "compressCountTitlelabel";
            this.compressCountTitlelabel.Size = new System.Drawing.Size(66, 18);
            this.compressCountTitlelabel.TabIndex = 10;
            this.compressCountTitlelabel.Text = "Compress";
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(280, 159);
            this.Controls.Add(this.compressCountValuelabel);
            this.Controls.Add(this.compressCountTitlelabel);
            this.Controls.Add(this.afterSizeValueLabel);
            this.Controls.Add(this.afterSizeTitleLabel);
            this.Controls.Add(this.beforeSizeValueLabel);
            this.Controls.Add(this.beforeSizeTitleLabel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.guidanceLabel);
            this.Controls.Add(this.compressButton);
            this.Controls.Add(this.dropPointLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "ZopfliPNG_GUI";
            this.ResumeLayout(false);

        }

        #endregion

        private Button compressButton;
        private ProgressBar progressBar;
        private Label dropPointLabel;
        private Label guidanceLabel;
        private Label beforeSizeTitleLabel;
        private Label beforeSizeValueLabel;
        private Label afterSizeValueLabel;
        private Label afterSizeTitleLabel;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private Label compressCountValuelabel;
        private Label compressCountTitlelabel;
    }
}