using System.Windows.Media.Imaging;

namespace VideoTagPlayer.Main.model
{
    public class PreviewImage
    {
        public System.Windows.Media.Imaging.BitmapSource Visual { get; set; }

        public PreviewImage()
        {
        }

        public PreviewImage(BitmapSource visual)
        {
            Visual = visual;
        }
    }
}
