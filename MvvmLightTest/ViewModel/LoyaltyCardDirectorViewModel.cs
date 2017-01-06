using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Media.Imaging;
using System;
using System.IO;
using System.Windows.Input;
using QRCoder;
using MvvmLightTest.Model;

namespace MvvmLightTest.ViewModel
{
    public class LoyaltyCardDirectorViewModel : ViewModelBase
    {
        public ICommand CreateNewLoyaltyCardAccountCommand { get; private set; }

        public ICommand DialogueWindowCommand { get; private set; }

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
            DialogueWindowCommand = new RelayCommand<object>(DialogueWindow);
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

        public void DialogueWindow(object obj)
        {
            MessengerInstance.Send<NotificationMessage<DialogueWindowMessage>>(new NotificationMessage<DialogueWindowMessage>(new DialogueWindowMessage { UserControlType = (Type)obj }, "SwitchDialogueWindow"));
        }
    }
}
