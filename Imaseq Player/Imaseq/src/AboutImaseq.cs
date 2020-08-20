
namespace Imaseq.src {
    class AboutImaseq {

        public static AboutForm AboutFrm { get; set; }


        public static void Open(ImaseqMain imaseq) {

            if (AboutFrm != null)
                return;

            imaseq.HasExtraTask = true;

            AboutFrm = new AboutForm {
                Main = imaseq,
            };
            AboutFrm.ShowDialog();
        }
    }
}
