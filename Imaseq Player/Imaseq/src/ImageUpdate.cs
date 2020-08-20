using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace Imaseq {
    class ImageUpdate: UpdateMode {

        private List<Image> images = new List<Image>();


        protected override string SortImages(ImaseqMain imaseq, List<string> imagePaths) {

            bool hasUI = false;
            Stopwatch watch = new Stopwatch();
            watch.Start();

            // Temporary store images in sorted dictionary to sort alpha numeric files
            SortedDictionary<string, Image> sortedImages = new SortedDictionary<string, Image>();
            images.Clear(); // Double sure sprites list is empty

            // Save images from imagePaths to sortedImages with padded name as key
            for (int i = 0; i < imagePaths.Count; i++) {

                if (!imaseq.HasExtraTask)
                    return DisplayInfo.prepCancelled;

                // Create image from path
                Image img = Image.FromFile(imagePaths[i]);

                if (img.IsOverMaxSize(MAX_WIDTH, MAX_HEIGHT))
                    return string.Format(DisplayInfo.maxDimension, Path.GetFileName(imagePaths[i]));
                if (img.IsUnderMinSize(MIN_WIDTH, MIN_HEIGHT))
                    return string.Format(DisplayInfo.minDimension, Path.GetFileName(imagePaths[i]));

                // Add imagepath as tag to remember file location                
                img.Tag = imagePaths[i];
                sortedImages.Add(PadNumbers(Path.GetFileName(imagePaths[i])), img);

                if (!hasUI) {
                    // If the ETA rises to 1 seconds show options and addition UI
                    if (watch.GetETA(i, imagePaths.Count()) > ACCEPTABLE_ETA) {
                        imaseq.ActivateProgressBar(true, imagePaths.Count);
                        CancelOption.Show(imaseq, DisplayInfo.prepImage);
                        hasUI = true;
                    }  
                }

                //Console.WriteLine("{0} time remaining", watch.GetEta(i, imagePaths.Count()));
                //Debug.WriteLine(img.Tag.ToString());
                imaseq.SetProgress(i + 1);
            }

            watch.Stop();
            GC.Collect();

            for (int i = 0; i < sortedImages.Count; i++) { //Loop through sorted images and transfer to images

                if (!imaseq.HasExtraTask)
                    return DisplayInfo.prepCancelled;

                var img = sortedImages.ElementAt(i);
                //Debug.WriteLine(img.Key);
                if (img.Value != null)
                    images.Add(img.Value);
            }

            return string.Empty;
        }


        public override void ClearImageList(PictureBox pictureBox) {

            if (images.Count <= 0)
                return;

            //get the image path of the current image
            string imagePath = images[CurrentIndex].Tag.ToString();
            string tempFileName = "ImaseqTempImg" + Path.GetExtension(imagePath);
            string tempImagePath = Path.Combine(Path.GetTempPath(), tempFileName);

            images.Clear();
            GC.Collect(); // Force garbage collection to get rid of reference from temporary image

            // Attept to save a temporary copy of the current image for display purposes
            for (int i = 0; i < 5; i++) {
                try {
                    // Debug.WriteLine("Attempting to copy and save image");
                    // Copy image to temporary folder
                    File.Copy(imagePath, tempImagePath, true);
                    // Debug.WriteLine("Attempting sucess!!!");
                    break;
                } catch (Exception) {
                    // Update filename since current image with the same filename is in use
                    tempFileName = string.Format("ImaseqTempImg{0}{1}", i, Path.GetExtension(imagePath));
                    tempImagePath = Path.Combine(Path.GetTempPath(), tempFileName);
                }
            }

            Image img = Image.FromFile(tempImagePath);
            pictureBox.Image = img;

            //Do not use will cause the swap to flicker
            //string imagePath = images[currentIndex].Tag.ToString();
            //images.Clear();
            //pictureBox.ImageLocation = imagePath;
            //pictureBox.Image = null;
        }


        public override int GetImageCount() => images.Count;


        public override bool IsEndFrame() => CurrentIndex + 1 == images.Count;


        protected override void AdjustPictureBoxSizeMode(PictureBox pictureBox)
            => SetPictureBoxSizeMode(images[CurrentIndex], pictureBox);
         
        
        protected override void ChangeImage(PictureBox pictureBox)      
            => pictureBox.Image = images[CurrentIndex];


        public override Image GetImageByIndex(int index)
            => images[index.Clamp(images.Count - 1)];
    }
}
