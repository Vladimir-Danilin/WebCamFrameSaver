namespace WebСamFrameSaver
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboboxCameraDevices = new System.Windows.Forms.ComboBox();
            this.videoSourcePlayer = new AForge.Controls.VideoSourcePlayer();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelResolution = new System.Windows.Forms.Label();
            this.labelFps = new System.Windows.Forms.Label();
            this.buttonChangeDirectory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboboxCameraDevices
            // 
            this.comboboxCameraDevices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboboxCameraDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboboxCameraDevices.FormattingEnabled = true;
            this.comboboxCameraDevices.Location = new System.Drawing.Point(652, 27);
            this.comboboxCameraDevices.Name = "comboboxCameraDevices";
            this.comboboxCameraDevices.Size = new System.Drawing.Size(120, 21);
            this.comboboxCameraDevices.TabIndex = 1;
            this.comboboxCameraDevices.SelectedIndexChanged += new System.EventHandler(this.comboboxCameraDevices_SelectedIndexChanged);
            // 
            // videoSourcePlayer
            // 
            this.videoSourcePlayer.BackColor = System.Drawing.SystemColors.Control;
            this.videoSourcePlayer.Location = new System.Drawing.Point(12, 27);
            this.videoSourcePlayer.Name = "videoSourcePlayer";
            this.videoSourcePlayer.Size = new System.Drawing.Size(634, 422);
            this.videoSourcePlayer.TabIndex = 2;
            this.videoSourcePlayer.Text = "videoSourcePlayer";
            this.videoSourcePlayer.VideoSource = null;
            this.videoSourcePlayer.NewFrame += new AForge.Controls.VideoSourcePlayer.NewFrameHandler(this.videoSourcePlayer_NewFrame);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPlay.Location = new System.Drawing.Point(652, 368);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(120, 23);
            this.buttonPlay.TabIndex = 3;
            this.buttonPlay.Text = "Play";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(652, 397);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(120, 23);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelResolution
            // 
            this.labelResolution.AutoSize = true;
            this.labelResolution.BackColor = System.Drawing.Color.Transparent;
            this.labelResolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelResolution.Location = new System.Drawing.Point(12, 9);
            this.labelResolution.Name = "labelResolution";
            this.labelResolution.Size = new System.Drawing.Size(93, 15);
            this.labelResolution.TabIndex = 5;
            this.labelResolution.Text = "labelResolution";
            // 
            // labelFps
            // 
            this.labelFps.AutoSize = true;
            this.labelFps.BackColor = System.Drawing.Color.Transparent;
            this.labelFps.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFps.Location = new System.Drawing.Point(171, 9);
            this.labelFps.Name = "labelFps";
            this.labelFps.Size = new System.Drawing.Size(57, 15);
            this.labelFps.TabIndex = 6;
            this.labelFps.Text = "labelFPS";
            // 
            // buttonChangeDirectory
            // 
            this.buttonChangeDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonChangeDirectory.Location = new System.Drawing.Point(652, 426);
            this.buttonChangeDirectory.Name = "buttonChangeDirectory";
            this.buttonChangeDirectory.Size = new System.Drawing.Size(120, 23);
            this.buttonChangeDirectory.TabIndex = 7;
            this.buttonChangeDirectory.Text = "Change directory";
            this.buttonChangeDirectory.UseVisualStyleBackColor = true;
            this.buttonChangeDirectory.Click += new System.EventHandler(this.buttonChangeDirectory_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.buttonChangeDirectory);
            this.Controls.Add(this.labelFps);
            this.Controls.Add(this.labelResolution);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.videoSourcePlayer);
            this.Controls.Add(this.comboboxCameraDevices);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimumSize = new System.Drawing.Size(410, 200);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrameSaver";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboboxCameraDevices;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayer;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelResolution;
        private System.Windows.Forms.Label labelFps;
        private System.Windows.Forms.Button buttonChangeDirectory;
    }
}

