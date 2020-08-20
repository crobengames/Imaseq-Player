using Imaseq.Properties;
using System;
using System.Windows.Forms;

namespace Imaseq.src {
    public partial class AboutForm : Form {

        public ImaseqMain Main { get; set; }


        public AboutForm() {
            InitializeComponent();
            SetFormPosition();
        }

        private void AboutForm_Load(object sender, EventArgs e) {

            SetFormPosition();

            try {

                richTextBox.Text = Resources.AboutImaseq;

            } catch (Exception) {
                richTextBox.Text = "Failed to load about information. \nPlease re-open this window.";
                richTextBox.SelectAll();
                richTextBox.SelectionAlignment = HorizontalAlignment.Center;
                richTextBox.DeselectAll();
            }
            
        }


        private void SetFormPosition() {
            if (Main != null)
                TopMost = Main.TopMost;

            StartPosition = FormStartPosition.CenterParent;
        }


        private void AboutForm_FormClosing(object sender, FormClosingEventArgs e) {

            AboutImaseq.AboutFrm = null;

            if (Main != null)
                Main.HasExtraTask = false;
        }
    }
}
