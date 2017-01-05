using GalaSoft.MvvmLight;
using System.Windows.Media.Imaging;
using System.IO;
using QRCoder;

namespace MvvmLightTest.ViewModel
{
    public class LoyaltyCardDirectorViewModel : ViewModelBase
    {
        private string url;
        public string Url
        {
            get
            {
                return url;
            }
            private set
            {
                if (value != url)
                {
                    url = value;
                    RaisePropertyChanged("Url");
                    this.UrlQrCode = GenerateQRCode(value);
                }
            }
        }

        private BitmapImage urlQrCode;
        public BitmapImage UrlQrCode {
            get
            {
                return urlQrCode;
            }
            private set
            {
                if(value != urlQrCode)
                {
                    urlQrCode = value;
                    RaisePropertyChanged("UrlQrCode");
                }
            }
        }

        /// <summary>
        /// Constructor for LoyaltyCardDirectorViewModel VM
        /// </summary>
        /// <todo>
        /// Load URL from settings
        /// </todo>
        public LoyaltyCardDirectorViewModel()
        {
            this.Url = "https://www.premiermarketcards.com";
        }

        public BitmapImage GenerateQRCode(string text)
        {

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);

            BitmapByteQRCode qrCode = new BitmapByteQRCode(qrCodeData);
            byte[] bm = qrCode.GetGraphic(20);
            
            using (MemoryStream memory = new MemoryStream(bm))
            {
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }
        }
    }
}
