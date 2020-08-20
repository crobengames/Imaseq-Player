using System;
using System.Windows.Forms;

namespace Imaseq {

    public partial class ImaseqMsgBox : Form {

        public ImaseqMain Main { get; set; }
        public string Message { get; set; }
        public int DesktopX { get; set; }
        public int DesktopY { get; set; }
        public bool IsTop { get; set; }


        public ImaseqMsgBox() {
    
            InitializeComponent();
            ControlBox = false;
            TopMost = IsTop;   
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {

            if (keyData == Keys.Escape) {
                btnCancel.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void btnCancel_Click(object sender, EventArgs e) {

            TopMost = false;

            try {

                if (Main != null)
                    Main.HasExtraTask = false;

            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

            CancelOption.MsgBox = null;
            Close();
        }

        private void ImaseqMsgBox_Load(object sender, EventArgs e) {

            TopMost = IsTop;

            try {

                lblMsg.Text = Message;
                SetDesktopLocation(DesktopX, DesktopY);

            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
