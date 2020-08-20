using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Imaseq {
    abstract class UpdateMode {

        public int CurrentIndex { get; protected set; }
        protected const int ACCEPTABLE_ETA = 1000; //In Milliseconds
        // Remove or comment parts of the code that uses this field to speed up image loading.
        protected const int MAX_IMAGE = 1000; //Total images   
        protected const int MAX_WIDTH = 1920; //In pixels
        protected const int MAX_HEIGHT = 1080; //In pixels 
        protected const int MIN_WIDTH = 8; //In pixels
        protected const int MIN_HEIGHT = 8; //In pixels


        public virtual string SetUp(ImaseqMain imaseq, PictureBox pictureBox, string path, string[] imageFormats) {

            CurrentIndex = 0;
            List<string> imagePaths = new List<string>();
            //bool isTop = imaseq.TopMost;

            try { //Try to catch error due to bad directory

                for (int i = 0; i < imageFormats.Length; i++) { //Loop through supported formats

                    string[] paths = Directory.GetFiles(path, imageFormats[i]);

                    if (paths.Length > 0) //Append formats that are valid
                        imagePaths.AddRange(paths.ToList());
                }

            } catch {
                //Handle error cause by invalid directory                
                return (DisplayInfo.invalidDir);
            }

            if (imagePaths.Count < 2) //Make sure their is atleast 2 image in the directory
                return DisplayInfo.minImage;

            if (imagePaths.Count > MAX_IMAGE) //Limits the total images to be sequenced
                return string.Format(DisplayInfo.imageLimit, imagePaths.Count, MAX_IMAGE);

            string error = SortImages(imaseq, imagePaths);

            if (!string.IsNullOrEmpty(error)) {
                CancelOption.CloseMsgBox(); //Close MsgBox if Any
                //SendKeys.Send("{ESC}"); //Close Custom MsgBox
                GC.Collect();
                return error;
            }

            //SendKeys.Send("{ESC}"); //Close Custom MsgBox
            CancelOption.CloseMsgBox(); //Close MsgBox if Any
            AdjustPictureBoxSizeMode(pictureBox);
            ChangeImage(pictureBox);

            return string.Empty;
        }


        //Main Update
        public virtual void Update(PictureBox pictureBox, int increment = 1) {

            CurrentIndex = (CurrentIndex + increment) % GetImageCount();

            if (CurrentIndex < 0)
                CurrentIndex = GetImageCount() - 1;

            ChangeImage(pictureBox);
        }


        //Use for frame slider
        public virtual void Update(int newIndex, PictureBox pictureBox) {
            //Clam index value since
            if (newIndex < 0)
                CurrentIndex = 0;
            else if (newIndex > GetImageCount() - 1)
                CurrentIndex = GetImageCount() - 1;
            else
                CurrentIndex = newIndex;

            ChangeImage(pictureBox);
        }


        protected void SetPictureBoxSizeMode(Image img, PictureBox pictureBox) {
            //Fit image to the size of picturebox
            if (img.Width > pictureBox.Width || img.Height > pictureBox.Height)
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            else
                pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
        }


        //Code from https://stackoverflow.com/questions/5093842/alphanumeric-sorting-using-linq#5093939
        //Credits to Nathan & Joey Adams
        //Pad numbers by padding amount to sort properly
        protected string PadNumbers(string input, int padding = 5)
            => Regex.Replace(input, "[0-9]+", match => match.Value.PadLeft(padding, '0'));


        protected abstract string SortImages(ImaseqMain imaseq, List<string> imagePaths);


        protected abstract void AdjustPictureBoxSizeMode(PictureBox pictureBox);


        protected abstract void ChangeImage(PictureBox pictureBox);


        public abstract void ClearImageList(PictureBox pictureBox);


        public abstract int GetImageCount();


        public abstract bool IsEndFrame();


        public abstract Image GetImageByIndex(int index);

    }
}
