using Xamarin.Forms;
#if __ANDROID__
using Xamarin.Forms.Platform.Android;

namespace FAB.Droid
#elif __IOS__
using Xamarin.Forms.Platform.iOS;

namespace FAB.iOS
#elif WINDOWS_PHONE
using Xamarin.Forms.Platform.WinPhone;

namespace FAB.WinPhone
#elif WINDOWS_UWP
using Xamarin.Forms.Platform.UWP;

namespace FAB.UWP
#endif
{
	// see: http://windingroadway.blogspot.com/2014/06/xamarinforms-custom-controls-imagesource.html
	public partial class FloatingActionButtonRenderer
    {
        public static void InitControl ()
        {
            // nothing to do here
        }

        private static IImageSourceHandler GetHandler(ImageSource source)
        {
            IImageSourceHandler returnValue = null;
            if (source is UriImageSource)
            {
                returnValue = new ImageLoaderSourceHandler();
            }
            else if (source is FileImageSource)
            {
                returnValue = new FileImageSourceHandler();
            }
            else if (source is StreamImageSource)
            {
                returnValue = new StreamImagesourceHandler();
            }
            return returnValue;
        }
    }
}