using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Imaseq {


    class GifMaker {

        private const int MAX_GIF_IMAGES = 100;


        public static void AttemptGifCreation(ImaseqMain imaseq, UpdateMode mode) {

            if (mode.GetImageCount() > MAX_GIF_IMAGES) {
    
                imaseq.SetCurrentStatusText(string.Format(DisplayInfo.gifExceeded1, MAX_GIF_IMAGES));
                using (new CenterWinDialog(imaseq)) {
                    DialogResult dr = MessageBox.Show(
                        string.Format(DisplayInfo.gifExceeded2, mode.GetImageCount()),
                        "Imaseq",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Warning);

                    if (dr == DialogResult.Cancel) {
                        imaseq.SetCurrentStatusText(DisplayInfo.gifCancelled);
                        return;
                    }
                }
            }

            //Console.WriteLine("Saving as gif");
            SaveAsGif(imaseq, mode);
        }

        private static void SaveAsGif(ImaseqMain imaseq, UpdateMode mode) {
            // Displays a SaveFileDialog so the gif
            SaveFileDialog saveFileDialog = new SaveFileDialog {
                Filter = "Gif Image|*.gif",
                Title = "Save images as gif"
            };

            imaseq.SetCurrentStatusText(DisplayInfo.savingGif);

            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                // If the file name is not an empty string open it for saving.
                if (saveFileDialog.FileName != "") {

                    //bool isTop = imaseq.TopMost; //Store TopMost setting                   
                    // Saves the Image via a FileStream created by the OpenFile method.
                    FileStream stream = null;

                    try {
                        //Try catch error when overriting
                        stream = (FileStream)saveFileDialog.OpenFile();

                    } catch (Exception) {
                        imaseq.SetCurrentStatusText(DisplayInfo.fileInUse);
                        using (new CenterWinDialog(imaseq)) {
                            MessageBox.Show(
                                string.Format(DisplayInfo.fileInUse),
                                "Imaseq",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);                            
                        }
                        return;
                    }

                    imaseq.HasExtraTask = true;
                    CreateGif(stream, imaseq, mode);

                    imaseq.SetCurrentStatusText(imaseq.HasExtraTask ? DisplayInfo.gifSaved :DisplayInfo.gifCancelled);
                    imaseq.ActivateProgressBar(false);
                    stream.Close();
                    GC.Collect();
                    //SendKeys.Send("{ESC}");
                    imaseq.HasExtraTask = false;
                    //imaseq.TopMost = isTop; //Reset to TopMost setting
                    CancelOption.CloseMsgBox();
                }
            } else {
                imaseq.SetCurrentStatusText(DisplayInfo.gifCancelled);
            }
        }


        private static void CreateGif(FileStream stream, ImaseqMain imaseq, UpdateMode mode) {

            GifWriter gifWriter = new GifWriter(stream, imaseq.GetClockInterval(), (imaseq.IsLooping) ? 0 : -1);
            Stopwatch watch = new Stopwatch();
            watch.Start();
            bool hasOption = false;
            int counterGoal = mode.GetImageCount();
            imaseq.ActivateProgressBar(true, counterGoal);

            try {
                for (int i = 0; i < counterGoal; i++) {

                    if (!imaseq.HasExtraTask)
                        break;

                    gifWriter.WriteFrame(mode.GetImageByIndex(i), imaseq.GetClockInterval());
                    imaseq.IncrementProgress();

                    if (!hasOption && watch.GetETA(i, counterGoal) > 1000) {
                        hasOption = true;
                        CancelOption.Show(imaseq, DisplayInfo.savingGif);
                    }
                }
            } catch (Exception) {
                imaseq.ShowMessageBoxAndStatus(DisplayInfo.gifFailed);
            }

            gifWriter.Dispose();
            watch.Stop();
        }
    }
}
