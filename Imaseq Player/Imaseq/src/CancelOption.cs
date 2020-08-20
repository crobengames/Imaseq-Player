using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Imaseq {
    class CancelOption {

        public static Form MsgBox { get; set; }


        public static void Show(ImaseqMain imaseq, string msg) {

            if (MsgBox != null) {
                //Console.WriteLine("A Message Box Already Exits");
                return;
            }

            try {

                Task.Factory.StartNew(() => {

                    ImaseqMsgBox msgBox = new ImaseqMsgBox {
                        Message = msg,
                        Main = imaseq, 
                        IsTop = imaseq.TopMost
                    };

                    msgBox.DesktopX = imaseq.DesktopBounds.Left + (imaseq.Width - msgBox.Width) / 2;
                    msgBox.DesktopY = imaseq.DesktopBounds.Top + (imaseq.Height - msgBox.Height) / 2;
                    MsgBox = msgBox;
                    msgBox.ShowDialog();
                });

            } catch (Exception ex) {

                MsgBox = null;
                MessageBox.Show(ex.Message);
            }
        }


        public static void CloseMsgBox() {

            if (MsgBox == null) return;

            try {

                MsgBox.Invoke((MethodInvoker)delegate
                {
                    // close the form on the forms thread
                    MsgBox.Close();
                });

            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            
            MsgBox = null;
        }
    }
}
