using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imaseq {

    static class ImaseqExtensions {


        /// <summary>
        /// Clamp an interger value.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="maximum"></param>
        /// <param name="minimum"></param>
        /// <returns></returns>
        public static int Clamp(this int value, int maximum, int minimum = 0) 
            => Math.Max(Math.Min(value, maximum), minimum);
        

        /// <summary>
        /// Returns true if the given width or height is greater than the image dimension.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="maxWidth"></param>
        /// <param name="maxHeight"></param>
        /// <returns></returns>
        public static bool IsOverMaxSize(this Image image, int maxWidth, int maxHeight) {

            if (image.Width > maxWidth || image.Height > maxHeight)
                return true;

            return false;
        }


        /// <summary>
        /// Returns true if the given width or height is lower than the image dimension.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="minWidth"></param>
        /// <param name="minHeight"></param>
        /// <returns></returns>
        public static bool IsUnderMinSize(this Image image, int minWidth, int minHeight) {

            if (image.Width < minWidth || image.Height < minHeight)
                return true;

            return false;
        }



        // Code from https://stackoverflow.com/questions/473355/calculate-time-remaining#6822458
        // Modified to return long instead  of timespan
        // Credits to Chad Carisch
        /// <summary>
        /// Returns the estimated time of compleation in milliseconds
        /// </summary>
        /// <param name="watch"></param>
        /// <param name="counter"></param>
        /// <param name="counterGoal"></param>
        /// <returns></returns>
        public static long GetETA(this Stopwatch watch, int counter, int counterGoal) {

            if (counter == 0)
                return 0;

            return (watch.ElapsedMilliseconds / counter) * (counterGoal - counter);
        }
    }
}
