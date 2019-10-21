using System;
using System.Text;
using Foundation;
using UIKit;

namespace FoodAppClient.iOS.Helpers
{
    public class ImageStringConverter
    {
        public ImageStringConverter()
        {

        }
        public UIImage ConvertToUIImage(string bytesString)
        {
            if (bytesString == null)
                return null;

            return new UIImage(NSData.FromArray(Convert.FromBase64String(bytesString)));
        }

        public string ConvertToSrtring(UIImage image)
        {
            return image.AsPNG()?.GetBase64EncodedString(NSDataBase64EncodingOptions.None);
        }
    }
}
