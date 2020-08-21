namespace Imaseq {
    partial class ImaseqMain {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImaseqMain));
            this.clock = new System.Windows.Forms.Timer(this.components);
            this.txtBoxPath = new System.Windows.Forms.TextBox();
            this.lblCurrentStatus = new System.Windows.Forms.Label();
            this.LblStatusTitle = new System.Windows.Forms.Label();
            this.imaseqToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.frameSlider = new System.Windows.Forms.TrackBar();
            this.aboutButton = new System.Windows.Forms.Button();
            this.saveGifButton = new System.Windows.Forms.Button();
            this.alwaysTopButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.loopButton = new System.Windows.Forms.Button();
            this.browseDirButton = new System.Windows.Forms.Button();
            this.previousButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.pausePlayButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.speedSlider = new System.Windows.Forms.TrackBar();
            this.lblFrameSlider = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.lblFPS = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.frameSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.SuspendLayout();
            // 
            // clock
            // 
            this.clock.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // txtBoxPath
            // 
            this.txtBoxPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxPath.Location = new System.Drawing.Point(7, 8);
            this.txtBoxPath.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtBoxPath.Name = "txtBoxPath";
            this.txtBoxPath.Size = new System.Drawing.Size(440, 24);
            this.txtBoxPath.TabIndex = 1;
            this.txtBoxPath.Text = "Folder Path e.g.  C:\\Users\\Name\\Pictures";
            this.imaseqToolTip.SetToolTip(this.txtBoxPath, "Image(s) Directory");
            this.txtBoxPath.Enter += new System.EventHandler(this.txtBoxPath_Enter);
            this.txtBoxPath.Leave += new System.EventHandler(this.txtBoxPath_Leave);
            // 
            // lblCurrentStatus
            // 
            this.lblCurrentStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCurrentStatus.AutoSize = true;
            this.lblCurrentStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentStatus.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblCurrentStatus.Location = new System.Drawing.Point(51, 591);
            this.lblCurrentStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCurrentStatus.Name = "lblCurrentStatus";
            this.lblCurrentStatus.Size = new System.Drawing.Size(53, 18);
            this.lblCurrentStatus.TabIndex = 4;
            this.lblCurrentStatus.Text = "Ready!";
            // 
            // LblStatusTitle
            // 
            this.LblStatusTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LblStatusTitle.AutoSize = true;
            this.LblStatusTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblStatusTitle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LblStatusTitle.Location = new System.Drawing.Point(2, 591);
            this.LblStatusTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblStatusTitle.Name = "LblStatusTitle";
            this.LblStatusTitle.Size = new System.Drawing.Size(54, 18);
            this.LblStatusTitle.TabIndex = 5;
            this.LblStatusTitle.Text = "Status:";
            // 
            // frameSlider
            // 
            this.frameSlider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.frameSlider.Enabled = false;
            this.frameSlider.Location = new System.Drawing.Point(158, 55);
            this.frameSlider.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.frameSlider.Maximum = 60;
            this.frameSlider.Minimum = 1;
            this.frameSlider.Name = "frameSlider";
            this.frameSlider.Size = new System.Drawing.Size(180, 45);
            this.frameSlider.TabIndex = 8;
            this.frameSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.imaseqToolTip.SetToolTip(this.frameSlider, "Seek");
            this.frameSlider.Value = 1;
            this.frameSlider.Scroll += new System.EventHandler(this.frameBar_Scroll);
            // 
            // aboutButton
            // 
            this.aboutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.aboutButton.BackColor = System.Drawing.Color.Transparent;
            this.aboutButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.aboutButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.aboutButton.FlatAppearance.BorderSize = 0;
            this.aboutButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.aboutButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.aboutButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.aboutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aboutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutButton.Image = global::Imaseq.Properties.Resources.about;
            this.aboutButton.Location = new System.Drawing.Point(486, 587);
            this.aboutButton.Margin = new System.Windows.Forms.Padding(0);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Padding = new System.Windows.Forms.Padding(0, 0, 2, 2);
            this.aboutButton.Size = new System.Drawing.Size(20, 20);
            this.aboutButton.TabIndex = 13;
            this.imaseqToolTip.SetToolTip(this.aboutButton, "About");
            this.aboutButton.UseVisualStyleBackColor = false;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            this.aboutButton.MouseEnter += new System.EventHandler(this.aboutButton_MouseEnter);
            this.aboutButton.MouseLeave += new System.EventHandler(this.aboutButton_MouseLeave);
            // 
            // saveGifButton
            // 
            this.saveGifButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveGifButton.BackColor = System.Drawing.Color.Transparent;
            this.saveGifButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.saveGifButton.FlatAppearance.BorderSize = 0;
            this.saveGifButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.saveGifButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.saveGifButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.saveGifButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveGifButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveGifButton.Image = global::Imaseq.Properties.Resources.savedisabled;
            this.saveGifButton.Location = new System.Drawing.Point(482, 8);
            this.saveGifButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.saveGifButton.Name = "saveGifButton";
            this.saveGifButton.Padding = new System.Windows.Forms.Padding(0, 0, 2, 2);
            this.saveGifButton.Size = new System.Drawing.Size(24, 24);
            this.saveGifButton.TabIndex = 3;
            this.imaseqToolTip.SetToolTip(this.saveGifButton, "Save As Gif (Ctrl + S)");
            this.saveGifButton.UseVisualStyleBackColor = false;
            this.saveGifButton.Click += new System.EventHandler(this.saveGifButton_Click);
            this.saveGifButton.MouseEnter += new System.EventHandler(this.saveGifButton_MouseEnter);
            this.saveGifButton.MouseLeave += new System.EventHandler(this.saveGifButton_MouseLeave);
            // 
            // alwaysTopButton
            // 
            this.alwaysTopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.alwaysTopButton.BackColor = System.Drawing.Color.Transparent;
            this.alwaysTopButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.alwaysTopButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.alwaysTopButton.FlatAppearance.BorderSize = 0;
            this.alwaysTopButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.alwaysTopButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.alwaysTopButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.alwaysTopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.alwaysTopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alwaysTopButton.Image = global::Imaseq.Properties.Resources.nottop;
            this.alwaysTopButton.Location = new System.Drawing.Point(408, 587);
            this.alwaysTopButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.alwaysTopButton.Name = "alwaysTopButton";
            this.alwaysTopButton.Padding = new System.Windows.Forms.Padding(0, 0, 2, 2);
            this.alwaysTopButton.Size = new System.Drawing.Size(20, 20);
            this.alwaysTopButton.TabIndex = 10;
            this.imaseqToolTip.SetToolTip(this.alwaysTopButton, "Always On Top (T)");
            this.alwaysTopButton.UseVisualStyleBackColor = false;
            this.alwaysTopButton.Click += new System.EventHandler(this.alwaysTopButton_Click);
            this.alwaysTopButton.MouseEnter += new System.EventHandler(this.alwaysTopButton_MouseEnter);
            this.alwaysTopButton.MouseLeave += new System.EventHandler(this.alwaysTopButton_MouseLeave);
            // 
            // editButton
            // 
            this.editButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.editButton.BackColor = System.Drawing.Color.Transparent;
            this.editButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.editButton.FlatAppearance.BorderSize = 0;
            this.editButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.editButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.editButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.editButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editButton.Image = global::Imaseq.Properties.Resources.edit;
            this.editButton.Location = new System.Drawing.Point(434, 587);
            this.editButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.editButton.Name = "editButton";
            this.editButton.Padding = new System.Windows.Forms.Padding(0, 0, 2, 2);
            this.editButton.Size = new System.Drawing.Size(20, 20);
            this.editButton.TabIndex = 11;
            this.imaseqToolTip.SetToolTip(this.editButton, "Edit While Playing (E). Caution! If enabled it can cause high CPU usage. If disab" +
        "led memory will be use.");
            this.editButton.UseVisualStyleBackColor = false;
            this.editButton.Click += new System.EventHandler(this.updateModeButton_Click);
            this.editButton.MouseEnter += new System.EventHandler(this.updateModeButton_MouseEnter);
            this.editButton.MouseLeave += new System.EventHandler(this.updateModeButton_MouseLeave);
            // 
            // loopButton
            // 
            this.loopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.loopButton.BackColor = System.Drawing.Color.Transparent;
            this.loopButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.loopButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.loopButton.FlatAppearance.BorderSize = 0;
            this.loopButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.loopButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.loopButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.loopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loopButton.Image = global::Imaseq.Properties.Resources.loop;
            this.loopButton.Location = new System.Drawing.Point(460, 587);
            this.loopButton.Margin = new System.Windows.Forms.Padding(0);
            this.loopButton.Name = "loopButton";
            this.loopButton.Padding = new System.Windows.Forms.Padding(0, 0, 2, 2);
            this.loopButton.Size = new System.Drawing.Size(20, 20);
            this.loopButton.TabIndex = 12;
            this.imaseqToolTip.SetToolTip(this.loopButton, "Loop (L)");
            this.loopButton.UseVisualStyleBackColor = false;
            this.loopButton.Click += new System.EventHandler(this.loopButton_Click);
            this.loopButton.MouseEnter += new System.EventHandler(this.loopButton_MouseEnter);
            this.loopButton.MouseLeave += new System.EventHandler(this.loopButton_MouseLeave);
            // 
            // browseDirButton
            // 
            this.browseDirButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseDirButton.BackColor = System.Drawing.Color.Transparent;
            this.browseDirButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.browseDirButton.FlatAppearance.BorderSize = 0;
            this.browseDirButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.browseDirButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.browseDirButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browseDirButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browseDirButton.Image = global::Imaseq.Properties.Resources.folder;
            this.browseDirButton.Location = new System.Drawing.Point(446, 8);
            this.browseDirButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.browseDirButton.Name = "browseDirButton";
            this.browseDirButton.Padding = new System.Windows.Forms.Padding(0, 1, 2, 0);
            this.browseDirButton.Size = new System.Drawing.Size(32, 24);
            this.browseDirButton.TabIndex = 2;
            this.imaseqToolTip.SetToolTip(this.browseDirButton, "Browse Folder (B)");
            this.browseDirButton.UseVisualStyleBackColor = false;
            this.browseDirButton.Click += new System.EventHandler(this.browseDirButton_Click);
            this.browseDirButton.MouseEnter += new System.EventHandler(this.browseDirButton_MouseEnter);
            this.browseDirButton.MouseLeave += new System.EventHandler(this.browseDirButton_MouseLeave);
            // 
            // previousButton
            // 
            this.previousButton.BackColor = System.Drawing.Color.Transparent;
            this.previousButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.previousButton.FlatAppearance.BorderSize = 0;
            this.previousButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.previousButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.previousButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.previousButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.previousButton.Image = global::Imaseq.Properties.Resources.backwarddisabled;
            this.previousButton.Location = new System.Drawing.Point(83, 38);
            this.previousButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.previousButton.Name = "previousButton";
            this.previousButton.Padding = new System.Windows.Forms.Padding(0, 0, 2, 2);
            this.previousButton.Size = new System.Drawing.Size(32, 32);
            this.previousButton.TabIndex = 6;
            this.imaseqToolTip.SetToolTip(this.previousButton, "Previous Frame (A)");
            this.previousButton.UseVisualStyleBackColor = false;
            this.previousButton.Click += new System.EventHandler(this.backwardButton_Click);
            this.previousButton.MouseEnter += new System.EventHandler(this.backwardButton_MouseEnter);
            this.previousButton.MouseLeave += new System.EventHandler(this.backwardButton_MouseLeave);
            // 
            // nextButton
            // 
            this.nextButton.BackColor = System.Drawing.Color.Transparent;
            this.nextButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.nextButton.FlatAppearance.BorderSize = 0;
            this.nextButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.nextButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.nextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextButton.Image = global::Imaseq.Properties.Resources.forwarddisabled;
            this.nextButton.Location = new System.Drawing.Point(121, 38);
            this.nextButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.nextButton.Name = "nextButton";
            this.nextButton.Padding = new System.Windows.Forms.Padding(0, 0, 2, 2);
            this.nextButton.Size = new System.Drawing.Size(32, 32);
            this.nextButton.TabIndex = 7;
            this.imaseqToolTip.SetToolTip(this.nextButton, "Next Frame (D)");
            this.nextButton.UseVisualStyleBackColor = false;
            this.nextButton.Click += new System.EventHandler(this.forwardButton_Click);
            this.nextButton.MouseEnter += new System.EventHandler(this.forwardButton_MouseEnter);
            this.nextButton.MouseLeave += new System.EventHandler(this.forwardButton_MouseLeave);
            // 
            // pausePlayButton
            // 
            this.pausePlayButton.BackColor = System.Drawing.Color.Transparent;
            this.pausePlayButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.pausePlayButton.FlatAppearance.BorderSize = 0;
            this.pausePlayButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.pausePlayButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.pausePlayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pausePlayButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pausePlayButton.Image = global::Imaseq.Properties.Resources.play;
            this.pausePlayButton.Location = new System.Drawing.Point(7, 38);
            this.pausePlayButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pausePlayButton.Name = "pausePlayButton";
            this.pausePlayButton.Padding = new System.Windows.Forms.Padding(0, 0, 2, 2);
            this.pausePlayButton.Size = new System.Drawing.Size(32, 32);
            this.pausePlayButton.TabIndex = 4;
            this.imaseqToolTip.SetToolTip(this.pausePlayButton, "Play (Space)");
            this.pausePlayButton.UseVisualStyleBackColor = false;
            this.pausePlayButton.Click += new System.EventHandler(this.pausePlay_ButtonClick);
            this.pausePlayButton.MouseEnter += new System.EventHandler(this.pausePlayButton_MouseEnter);
            this.pausePlayButton.MouseLeave += new System.EventHandler(this.pausePlayButton_MouseLeave);
            // 
            // stopButton
            // 
            this.stopButton.BackColor = System.Drawing.Color.Transparent;
            this.stopButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.stopButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.stopButton.FlatAppearance.BorderSize = 0;
            this.stopButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.stopButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.stopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopButton.Image = global::Imaseq.Properties.Resources.stopdisabled;
            this.stopButton.Location = new System.Drawing.Point(44, 38);
            this.stopButton.Margin = new System.Windows.Forms.Padding(0);
            this.stopButton.Name = "stopButton";
            this.stopButton.Padding = new System.Windows.Forms.Padding(0, 0, 2, 2);
            this.stopButton.Size = new System.Drawing.Size(32, 32);
            this.stopButton.TabIndex = 5;
            this.imaseqToolTip.SetToolTip(this.stopButton, "Stop (S)");
            this.stopButton.UseVisualStyleBackColor = false;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            this.stopButton.MouseEnter += new System.EventHandler(this.stopButton_MouseEnter);
            this.stopButton.MouseLeave += new System.EventHandler(this.stopButton_MouseLeave);
            // 
            // speedSlider
            // 
            this.speedSlider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.speedSlider.Location = new System.Drawing.Point(332, 55);
            this.speedSlider.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.speedSlider.Maximum = 60;
            this.speedSlider.Minimum = 1;
            this.speedSlider.Name = "speedSlider";
            this.speedSlider.Size = new System.Drawing.Size(180, 45);
            this.speedSlider.TabIndex = 9;
            this.speedSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.imaseqToolTip.SetToolTip(this.speedSlider, "Speed");
            this.speedSlider.Value = 10;
            this.speedSlider.Scroll += new System.EventHandler(this.speedBar_Scroll);
            // 
            // lblFrameSlider
            // 
            this.lblFrameSlider.AutoSize = true;
            this.lblFrameSlider.BackColor = System.Drawing.Color.Transparent;
            this.lblFrameSlider.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrameSlider.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblFrameSlider.Location = new System.Drawing.Point(166, 35);
            this.lblFrameSlider.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFrameSlider.Name = "lblFrameSlider";
            this.lblFrameSlider.Size = new System.Drawing.Size(63, 18);
            this.lblFrameSlider.TabIndex = 11;
            this.lblFrameSlider.Text = "Frame 1";
            this.lblFrameSlider.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(0, 563);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(512, 23);
            this.progressBar.TabIndex = 13;
            this.progressBar.Value = 100;
            // 
            // picBox
            // 
            this.picBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBox.BackColor = System.Drawing.Color.Gray;
            this.picBox.Image = global::Imaseq.Properties.Resources.InitialImage;
            this.picBox.Location = new System.Drawing.Point(1, 79);
            this.picBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(512, 512);
            this.picBox.TabIndex = 0;
            this.picBox.TabStop = false;
            // 
            // lblFPS
            // 
            this.lblFPS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFPS.AutoSize = true;
            this.lblFPS.BackColor = System.Drawing.Color.Transparent;
            this.lblFPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFPS.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblFPS.Location = new System.Drawing.Point(340, 35);
            this.lblFPS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFPS.Name = "lblFPS";
            this.lblFPS.Size = new System.Drawing.Size(61, 18);
            this.lblFPS.TabIndex = 7;
            this.lblFPS.Text = "FPS: 10";
            this.lblFPS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ImaseqMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(512, 611);
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.saveGifButton);
            this.Controls.Add(this.alwaysTopButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.loopButton);
            this.Controls.Add(this.lblCurrentStatus);
            this.Controls.Add(this.picBox);
            this.Controls.Add(this.LblStatusTitle);
            this.Controls.Add(this.browseDirButton);
            this.Controls.Add(this.txtBoxPath);
            this.Controls.Add(this.speedSlider);
            this.Controls.Add(this.previousButton);
            this.Controls.Add(this.lblFrameSlider);
            this.Controls.Add(this.frameSlider);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.lblFPS);
            this.Controls.Add(this.pausePlayButton);
            this.Controls.Add(this.stopButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(528, 650);
            this.Name = "ImaseqMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imaseq Player 1.0.0";
            ((System.ComponentModel.ISupportInitialize)(this.frameSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.Timer clock;
        private System.Windows.Forms.TextBox txtBoxPath;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Label lblCurrentStatus;
        private System.Windows.Forms.Label LblStatusTitle;
        private System.Windows.Forms.Button pausePlayButton;
        private System.Windows.Forms.Button previousButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.ToolTip imaseqToolTip;
        private System.Windows.Forms.TrackBar frameSlider;
        private System.Windows.Forms.Label lblFrameSlider;
        private System.Windows.Forms.Button browseDirButton;
        private System.Windows.Forms.Button loopButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button alwaysTopButton;
        private System.Windows.Forms.Button saveGifButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.Label lblFPS;
        private System.Windows.Forms.TrackBar speedSlider;
    }
}

