using Imaseq.src;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.IO;
using System.Windows.Forms;


namespace Imaseq {
    public partial class ImaseqMain : Form {

        private bool isPlaying = false;
        private bool isPaused = false;
        private bool canEditWhilePlaying = true; 
        private UpdateMode mode;
        private readonly string[] imageFormats = { "*.PNG", "*.JPG", "*.JPEG" };
        public bool IsLooping { get; private set; }
        public bool HasExtraTask { get; set; } //Task other than displaying the images


        //TODO: Alow Resize
        public ImaseqMain() {
            InitializeComponent();
            mode = new PropertyUpdate();
            StartPosition = FormStartPosition.CenterScreen;
            IsLooping = true;
            progressBar.Visible = false;
            HasExtraTask = true;

            try {
                txtBoxPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            } catch (Exception) {
                //throw;
            }
        }


        //Handle shortcuts
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {

            if (!HasExtraTask) { 

                switch (keyData) {
                    case Keys.Space:
                        PlayPause(true);
                        return true;
                    case Keys.S:
                        stopButton.PerformClick();
                        return true;
                    case Keys.Left:
                    case Keys.A:
                        previousButton.PerformClick();
                        return true;
                    case Keys.Right:
                    case Keys.D:
                        nextButton.PerformClick();
                        return true;
                    case Keys.L:
                        LoopButtonClicked(true);
                        return true;
                    case Keys.B:
                        browseDirButton.PerformClick();
                        return true;
                    case Keys.E:
                        ChangeUpdateMode(true);
                        return true;
                    case Keys.T:
                        SetAppToTop(true);
                        return true;
                    case (Keys.Control | Keys.S):
                        AttemptGifCreation();
                        return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }


        //Display picture box images & returns true if success and false if a failure or error occurs
        private bool InitPicBox() {

            UpdateCurrentStatusText(DisplayInfo.looking);

            HasExtraTask = true;
            string msg = mode.SetUp(this, picBox, txtBoxPath.Text.Trim(), imageFormats);
            ActivateProgressBar(false);
            HasExtraTask = false;

            if (!string.IsNullOrEmpty(msg)) {
                ShowMessageBoxAndStatus(msg);
                return false;
            }

            SetCurrentStatusText(string.Format(DisplayInfo.played, mode.GetImageCount()));
            //1000 = 1 minute, speedBar.value = frames per minute
            SetTimerInterval();
            clock.Start();
            SeTextBoxPath(false);            
            return true;
        }


        private void UpdateSpriteDisplay(int increment = 1) {

            mode.Update(picBox, increment);
            UpdateFrameSliderValue();

            if (!IsLooping && mode.IsEndFrame())
                pausePlayButton.PerformClick();
        }


        #region Status & MsgBox

        public void SetCurrentStatusText(string message)  => lblCurrentStatus.Text = message;
  

        public void UpdateCurrentStatusText(string message) {
            SetCurrentStatusText(message);
            lblCurrentStatus.Update();
        }


        public Label GetStatusLabel() => lblCurrentStatus;


        public void ShowMessageBoxAndStatus(string message) {
            SetCurrentStatusText(message);
            ShowMessageBox(message);
        }


        private void ShowMessageBox(string message) {
            using (new CenterWinDialog(this)) {
                MessageBox.Show(message, "Imaseq", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        #endregion /Status & MsgBox


        #region Path or Directory TextBox

        private void txtBoxPath_Enter(object sender, EventArgs e) {
            //Debug.WriteLine("Text Box Focus Must Not Accept Shortcuts");
            HasExtraTask = true;
        }


        private void txtBoxPath_Leave(object sender, EventArgs e) {
            //Debug.WriteLine("Text Box Not In Focus Now Accepts Shortcuts");
            HasExtraTask = false;
        }


        private void SeTextBoxPath(bool pathActive) {
            txtBoxPath.Enabled = pathActive;

            if (pathActive)
                ChangeBrowseButtonImage(BtnState.Active);
            else
                ChangeBrowseButtonImage(BtnState.Disabled);
        }

        #endregion /Path or Directory TextBox


        #region Browse Directory Button

        private void browseDirButton_Click(object sender, EventArgs e) {

            if (isPlaying) return;

            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            //Set Initial Directory to txtBoxPath if directory is valid else use C users
            dialog.InitialDirectory = (Directory.Exists(txtBoxPath.Text.Trim())) ? txtBoxPath.Text.Trim() : "C:\\Users";
            dialog.IsFolderPicker = true;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok) {
                //MessageBox.Show("You selected: " + dialog.FileName);
                txtBoxPath.Text = dialog.FileName;
            }
        }


        private void browseDirButton_MouseEnter(object sender, EventArgs e) {

            if (isPlaying) return;

            ChangeBrowseButtonImage(BtnState.Hovered);
        }


        private void browseDirButton_MouseLeave(object sender, EventArgs e) {

            if (isPlaying) return;

            ChangeBrowseButtonImage(BtnState.Active);
        }


        private void ChangeBrowseButtonImage(BtnState state)
            => ImaseqButton.UpdateButtonImage(browseDirButton, BtnType.Browse, state);

        #endregion /Browse Directory Button


        #region Sliders

        private void speedBar_Scroll(object sender, EventArgs e) {
            SetTimerInterval();
            lblFPS.Text = string.Format("FPS: {0}", speedSlider.Value);
        }


        private void frameBar_Scroll(object sender, EventArgs e) {

            int frameIndex = frameSlider.Value;

            mode.Update(frameIndex - 1, picBox);
            lblFrameSlider.Text = string.Format("Frame {0}", frameIndex);
            SetStatusPauseText();
        }


        private void SetFrameSlider() => frameSlider.Enabled = isPaused;


        private void UpdateFrameSliderValue() {
            frameSlider.Value = mode.CurrentIndex + 1;
            lblFrameSlider.Text = string.Format("Frame {0}", mode.CurrentIndex + 1);
        }

        #endregion /Sliders


        #region Timer
        //Timer event that occurs 
        private void timer_Tick(object sender, EventArgs e) {

            if (isPaused) return;

            UpdateSpriteDisplay();
        }


        private void SetTimerInterval()
            => clock.Interval = 1000 / speedSlider.Value;


        public int GetClockInterval() => clock.Interval;

        #endregion /Timer


        #region Stop Button

        private void stopButton_Click(object sender, EventArgs e) {

            if (!isPlaying || HasExtraTask) return;

            mode.ClearImageList(picBox);
            ChangeStopButtonImage(BtnState.Disabled);
            ChangeSaveGifButtonImage(BtnState.Disabled);
            isPaused = false;
            isPlaying = false;
            SeTextBoxPath(true);
            clock.Stop();
            SetPauseButton(true); //Consider pressing from stop button as shortcut for correct effect
            SetFrameSlider();
            ChangeFrameStepButtonImage(BtnState.Disabled);
            SetCurrentStatusText(DisplayInfo.stopped);
            GC.Collect(); //For Garbage Collection to get rid of unused references and allow editing of images not shown in picbox
        }


        private void stopButton_MouseEnter(object sender, EventArgs e)
            => ChangeStopButtonImage(BtnState.Hovered);


        private void stopButton_MouseLeave(object sender, EventArgs e)
            => ChangeStopButtonImage(BtnState.Active);


        private void ChangeStopButtonImage(BtnState state) {

            if (!isPlaying) return;

            ImaseqButton.UpdateButtonImage(stopButton, BtnType.Stop, state);
        }

        #endregion /Stop Button


        #region Pause or Play Button

        private void pausePlay_ButtonClick(object sender, EventArgs e) => PlayPause(false);


        private void pausePlayButton_MouseEnter(object sender, EventArgs e) 
            => ChangePlayPauseButtonImage(BtnState.Hovered, isPaused || !isPlaying);


        private void pausePlayButton_MouseLeave(object sender, EventArgs e) 
            => ChangePlayPauseButtonImage(BtnState.Active, isPaused || !isPlaying);


        private void PlayPause(bool isShortcut) {

            if (HasExtraTask) return;

            if (!isPlaying) {

                if (!InitPicBox()) return;
                //Order is important! Becareful when rearranging.
                isPaused = false;
                isPlaying = true;
                ChangeStopButtonImage(BtnState.Active);
                ChangeSaveGifButtonImage(BtnState.Active);
                ChangePlayPauseButtonImage((isShortcut) ? BtnState.Active : BtnState.Hovered, false);
                SetPauseButton(isShortcut);
                frameSlider.Maximum = mode.GetImageCount();
                SetFrameSlider();
                return;
            }

            isPaused = !isPaused;
            SetPauseButton(isShortcut);
            SetFrameSlider();
            
        }


        private void SetPauseButton(bool isShortcut) {

            if (isPaused || !isPlaying) {
                imaseqToolTip.SetToolTip(pausePlayButton, "Play (Space)");
                ChangePlayPauseButtonImage((isShortcut) ? BtnState.Active : BtnState.Hovered, true);
                SetStatusPauseText();
                ChangeFrameStepButtonImage(BtnState.Active);
                
            } else {
                imaseqToolTip.SetToolTip(pausePlayButton, "Pause (Space)");
                ChangePlayPauseButtonImage((isShortcut) ? BtnState.Active : BtnState.Hovered, false);
                ChangeFrameStepButtonImage(BtnState.Disabled);
                if (isPlaying)
                    SetCurrentStatusText(string.Format(DisplayInfo.played, mode.GetImageCount()));
            }
        }


        private void SetStatusPauseText() {
            SetCurrentStatusText(string.Format(DisplayInfo.paused, mode.CurrentIndex + 1, mode.GetImageCount()));
        }


        private void ChangePlayPauseButtonImage(BtnState state, bool isPlay) 
            => ImaseqButton.UpdateButtonImage(pausePlayButton, (isPlay) ? BtnType.Play : BtnType.Pause, state);

        #endregion /Pause or Play Button


        #region Frame Step Buttons

        private void forwardButton_Click(object sender, EventArgs e) {

            if (!isPaused || HasExtraTask) return;

            UpdateSpriteDisplay(1);
            SetStatusPauseText();
        }


        private void backwardButton_Click(object sender, EventArgs e) {

            if (!isPaused || HasExtraTask) return;

            UpdateSpriteDisplay(-1);
            SetStatusPauseText();
        }


        private void forwardButton_MouseEnter(object sender, EventArgs e) {
            if (!isPaused) return;

            ChangeNextFrameImage(BtnState.Hovered);
        }


        private void forwardButton_MouseLeave(object sender, EventArgs e) {
            if (!isPaused) return;

            ChangeNextFrameImage(BtnState.Active);
        }


        private void backwardButton_MouseEnter(object sender, EventArgs e) {
            if (!isPaused) return;

            ChangePrevFrameImage(BtnState.Hovered);
        }


        private void backwardButton_MouseLeave(object sender, EventArgs e) {
            if (!isPaused) return;

            ChangePrevFrameImage(BtnState.Active);
        }


        private void ChangeFrameStepButtonImage(BtnState state) {
            ChangeNextFrameImage(state);
            ChangePrevFrameImage(state);
        }


        private void ChangeNextFrameImage(BtnState state)
            => ImaseqButton.UpdateButtonImage(nextButton, BtnType.NextFrame, state);


        private void ChangePrevFrameImage(BtnState state)
            => ImaseqButton.UpdateButtonImage(previousButton, BtnType.PrevFrame, state);

        #endregion /Frame Step Buttons


        #region Loop Button

        private void loopButton_Click(object sender, EventArgs e) => LoopButtonClicked(false);


        private void loopButton_MouseEnter(object sender, EventArgs e) 
            => ChangeLoopButtonImage(BtnState.Hovered, IsLooping);


        private void loopButton_MouseLeave(object sender, EventArgs e)
            => ChangeLoopButtonImage(BtnState.Active, IsLooping);



        private void LoopButtonClicked(bool isShortcut) {

            if (HasExtraTask) return;

            IsLooping = !IsLooping;

            ChangeLoopButtonImage((isShortcut) ? BtnState.Active : BtnState.Hovered, IsLooping);
        }


        private void ChangeLoopButtonImage(BtnState state, bool isLoop)
            => ImaseqButton.UpdateButtonImage(loopButton, (isLoop) ? BtnType.Loop : BtnType.NoLoop, state);

        #endregion /Loop Button


        #region Update Mode Button

        private void updateModeButton_Click(object sender, EventArgs e) => ChangeUpdateMode(false);


        private void updateModeButton_MouseEnter(object sender, EventArgs e) 
            => ChangeEditButtonImage(BtnState.Hovered, canEditWhilePlaying);


        private void updateModeButton_MouseLeave(object sender, EventArgs e) 
            => ChangeEditButtonImage(BtnState.Active, canEditWhilePlaying);


        private void ChangeUpdateMode(bool isShortcut) {

            if (HasExtraTask) return;

            canEditWhilePlaying = !canEditWhilePlaying;

            if (isPlaying)
                stopButton.PerformClick();

            ChangeEditButtonImage((isShortcut) ? BtnState.Active: BtnState.Hovered, canEditWhilePlaying);

            if (canEditWhilePlaying)
                mode = new PropertyUpdate();
            else 
                mode = new ImageUpdate();
        }


        private void ChangeEditButtonImage(BtnState state, bool isEdit)
            => ImaseqButton.UpdateButtonImage(editButton, (isEdit) ? BtnType.Edit : BtnType.NoEdit, state);

        #endregion /Update Mode Button


        #region Always Top Button

        private void alwaysTopButton_Click(object sender, EventArgs e) => SetAppToTop(false);


        private void alwaysTopButton_MouseEnter(object sender, EventArgs e)
            => ChangeAlwaysTopButtonImage(BtnState.Hovered);


        private void alwaysTopButton_MouseLeave(object sender, EventArgs e)
            => ChangeAlwaysTopButtonImage(BtnState.Active);


        private void SetAppToTop(bool isShortcut) {

            if (HasExtraTask) return;

            TopMost = !TopMost;

            ChangeAlwaysTopButtonImage((isShortcut) ? BtnState.Active : BtnState.Hovered);
        }


        private void ChangeAlwaysTopButtonImage(BtnState state )
            => ImaseqButton.UpdateButtonImage(alwaysTopButton, (TopMost)? BtnType.AlwaysTop : BtnType.NotTop, state);

        #endregion /Always Top Button


        #region  Save Gif Button

        private void saveGifButton_Click(object sender, EventArgs e) => AttemptGifCreation();


        private void saveGifButton_MouseEnter(object sender, EventArgs e) {

            if (!isPlaying) return;
            ChangeSaveGifButtonImage(BtnState.Hovered);
        }


        private void saveGifButton_MouseLeave(object sender, EventArgs e) {
            if (!isPlaying) return;

            ChangeSaveGifButtonImage(BtnState.Active);
        }


        private void AttemptGifCreation() {

            if (!isPlaying || HasExtraTask) return;

            if (!isPaused)
                PlayPause(true);

            GifMaker.AttemptGifCreation(this, mode);
        }


        private void ChangeSaveGifButtonImage(BtnState state)
            => ImaseqButton.UpdateButtonImage(saveGifButton, BtnType.SaveGif, state);


        #endregion /Save Gif Button


        #region ProgressBar

        public void ActivateProgressBar(bool activate, int maxValue = 100, int cur_value = 0) {
            progressBar.Visible = activate;
            progressBar.Maximum = maxValue;
            progressBar.Value = cur_value;
        }


        public void SetProgress(int value) {

            if (value > progressBar.Maximum)
                value = progressBar.Maximum;

            progressBar.Value = value;
            //progressBar.Value = Math.Max(Math.Min(value, progressBar.Maximum), progressBar.Minimum);
        }

        public void IncrementProgress(int value = 1) {

            int newVal = progressBar.Value + value;
            SetProgress(newVal);
            //progressBar.Value = Math.Max(Math.Min(newVal, progressBar.Maximum), progressBar.Minimum);
        }


        public int GetMaxProgress() => progressBar.Maximum;


        public int GetProgress() => progressBar.Value;

        #endregion /ProgressBar


        #region About Button

        private void aboutButton_Click(object sender, EventArgs e) {
            
            if (!isPaused && isPlaying)
                PlayPause(true);

            AboutImaseq.Open(this);
        }


        private void aboutButton_MouseLeave(object sender, EventArgs e)
             => ChangeAboutButtonImage(BtnState.Active);

        private void aboutButton_MouseEnter(object sender, EventArgs e)
            => ChangeAboutButtonImage(BtnState.Hovered);


        private void ChangeAboutButtonImage(BtnState state)
            => ImaseqButton.UpdateButtonImage(aboutButton, BtnType.About, state);


        #endregion /About Button

    }
}
