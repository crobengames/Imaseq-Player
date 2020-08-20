using System.Drawing;
using System.Windows.Forms;


namespace Imaseq {


    public enum BtnState {
        Disabled,
        Active,
        Hovered
    }

    public enum BtnType {
        Play,
        Pause,
        Stop,
        NextFrame,
        PrevFrame,
        Browse,
        Loop,
        NoLoop,
        Edit,
        NoEdit,
        AlwaysTop,
        NotTop,
        SaveGif,
        About
    }


    class ImaseqButton {


        public static void UpdateButtonImage(Button button, BtnType type, BtnState state) {

            switch (state) {
                default:
                case BtnState.Active:
                    SetButtonImage(button, GetActiveImage(type));
                    break;
                case BtnState.Disabled:
                    SetButtonImage(button, GetDisabledImage(type));
                    break;
                case BtnState.Hovered:
                    SetButtonImage(button, GetHoveredImage(type));
                    break;
            }
        }


        private static void SetButtonImage(Button button, Image image) => button.Image = image;


        private static Image GetHoveredImage(BtnType type) {

            switch (type) {
                case BtnType.Play:
                    return Properties.Resources.playhovered;
                case BtnType.Pause:
                    return Properties.Resources.pausehovered;
                case BtnType.Stop:
                    return Properties.Resources.stophovered;
                case BtnType.NextFrame:
                    return Properties.Resources.forwardhovered;
                case BtnType.PrevFrame:
                    return Properties.Resources.backwardhovered;
                case BtnType.Browse:
                    return Properties.Resources.folderhovered;
                case BtnType.Loop:
                    return Properties.Resources.loophovered;
                case BtnType.Edit:
                    return Properties.Resources.edithovered;      
                case BtnType.NoLoop:
                    return Properties.Resources.noloophovered;
                case BtnType.NoEdit:
                    return Properties.Resources.noedithovered;
                case BtnType.AlwaysTop:
                    return Properties.Resources.alwaystophovered;
                case BtnType.NotTop:
                    return Properties.Resources.nottophovered;
                case BtnType.SaveGif:
                    return Properties.Resources.savehovered;
                case BtnType.About:
                    return Properties.Resources.abouthovered;
            }

            return null;
        }


        private static Image GetActiveImage(BtnType type) {
            switch (type) {
                case BtnType.Play:
                    return Properties.Resources.play;
                case BtnType.Pause:
                    return Properties.Resources.pause;
                case BtnType.Stop:
                    return Properties.Resources.stop;
                case BtnType.NextFrame:
                    return Properties.Resources.forward;
                case BtnType.PrevFrame:
                    return Properties.Resources.backward;
                case BtnType.Browse:
                    return Properties.Resources.folder;
                case BtnType.Loop:
                    return Properties.Resources.loop;
                case BtnType.Edit:
                    return Properties.Resources.edit;     
                case BtnType.NoLoop:
                    return Properties.Resources.noloop;
                case BtnType.NoEdit:
                    return Properties.Resources.noedit;
                case BtnType.AlwaysTop:
                    return Properties.Resources.alwaystop;
                case BtnType.NotTop:
                    return Properties.Resources.nottop;
                case BtnType.SaveGif:
                    return Properties.Resources.save;
                case BtnType.About:
                    return Properties.Resources.about;
            }

            return null;
        }


        private static Image GetDisabledImage(BtnType type) {
            switch (type) {
                case BtnType.Play:
                    return Properties.Resources.play;
                case BtnType.Pause:
                    return Properties.Resources.pause;
                case BtnType.Stop:
                    return Properties.Resources.stopdisabled;
                case BtnType.NextFrame:
                    return Properties.Resources.forwarddisabled;
                case BtnType.PrevFrame:
                    return Properties.Resources.backwarddisabled;
                case BtnType.Browse:
                    return Properties.Resources.folderdisabled;
                case BtnType.Loop:
                    return Properties.Resources.loop;
                case BtnType.Edit:
                    return Properties.Resources.edit;
                case BtnType.NoLoop:
                    return Properties.Resources.noloop;
                case BtnType.NoEdit:
                    return Properties.Resources.noedit;
                case BtnType.AlwaysTop:
                    return Properties.Resources.alwaystop;
                case BtnType.NotTop:
                    return Properties.Resources.nottop;
                case BtnType.SaveGif:
                    return Properties.Resources.savedisabled;
                case BtnType.About:
                    return Properties.Resources.about;
            }

            return null;
        }
    }
}
