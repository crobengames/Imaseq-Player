using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Imaseq {
    class PropertyUpdate : UpdateMode {

        private List<string> imagePaths = new List<string>();

        
        protected override string SortImages(ImaseqMain imaseq, List<string> imagePaths) {

            SortedDictionary<string, string> sorthPaths = new SortedDictionary<string, string>();
            this.imagePaths.Clear();

            //int counterGoal = imagePaths.Count * 2; // Multiple by 2 if sorting will be check for ETA as well
            bool hasUI = false;
            Stopwatch watch = new Stopwatch();
            watch.Start();

            // Save images from imagePaths to sortedPathss with padded name as key
            for (int i = 0; i < imagePaths.Count; i++) {

                if (!imaseq.HasExtraTask)
                    return DisplayInfo.prepCancelled;

                Image img = Image.FromFile(imagePaths[i]);
                if (img.IsOverMaxSize(MAX_WIDTH, MAX_HEIGHT))
                    return string.Format(DisplayInfo.maxDimension, Path.GetFileName(imagePaths[i]));
                if (img.IsUnderMinSize(MIN_WIDTH, MIN_HEIGHT))
                    return string.Format(DisplayInfo.minDimension, Path.GetFileName(imagePaths[i]));

                sorthPaths.Add(PadNumbers(Path.GetFileName(imagePaths[i])), imagePaths[i]);

                if (!hasUI) {
                    // If the ETA rises to 1 seconds show options and addition UI
                    if (watch.GetETA(i, imagePaths.Count()) > ACCEPTABLE_ETA) {
                        imaseq.ActivateProgressBar(true, imagePaths.Count);
                        CancelOption.Show(imaseq, DisplayInfo.prepImage);
                        hasUI = true;
                    }
                }

                //if (!hasUI)
                //    CheckIfShowUI(i);

                imaseq.IncrementProgress();
            }

            watch.Stop();
            GC.Collect();

            for (int i = 0; i < sorthPaths.Count; i++) { // Loop through sorted paths and transfr to image paths

                if (!imaseq.HasExtraTask)
                    return DisplayInfo.prepCancelled;

                var img = sorthPaths.ElementAt(i);
                //Debug.WriteLine(img.Key);
                if (img.Value != null)
                    this.imagePaths.Add(img.Value);

                //if (!hasUI)
                //    CheckIfShowUI(i + sorthPaths.Count);

                //imaseq.IncrementProgress();
            }
       
            return string.Empty;

            //Just incase the process may took more than 1 seconds
            //void CheckIfShowUI(int counter) {
            //    // If the ETA rises to 1 seconds show options and addition UI
            //    if (watch.GetETA(counter, counterGoal) > ACCEPTABLE_ETA) {
            //        //imaseq.TopMost = false;
            //        imaseq.ActivateProgressBar(true, counterGoal);
            //        CancelOption.Show(imaseq, DisplayInfo.prepImage);
            //        imaseq.SetProgress(counter + 1);
            //        hasUI = true;
            //    }
            //}
        }


        public override void ClearImageList(PictureBox pictureBox) => imagePaths.Clear();


        public override int GetImageCount() => imagePaths.Count();


        public override bool IsEndFrame() => CurrentIndex + 1 == imagePaths.Count;


        protected override void AdjustPictureBoxSizeMode(PictureBox pictureBox) {
            //DO NOT USE!!! Will lead to a flicker at start
            //if (pictureBox.Image != null)
            //    pictureBox.Image = null;

            Image img = Image.FromFile(imagePaths[CurrentIndex]);
            SetPictureBoxSizeMode(img, pictureBox);
        }


        protected override void ChangeImage(PictureBox pictureBox)
            => pictureBox.ImageLocation = imagePaths[CurrentIndex];


        public override Image GetImageByIndex(int index) 
            => Image.FromFile(imagePaths[index.Clamp(imagePaths.Count - 1)]);

    }
}
