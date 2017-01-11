using MTSCRANET;
using MTLIB;
using GalaSoft.MvvmLight.Messaging;


namespace MvvmLightTest.Devices
{
    public class MagTek
    {
        MTSCRANET.MTSCRA reader { get; set; }

        public MagTek()
        {
            InitializeMagStripeReader();
        }

        public void InitializeMagStripeReader()
        {
            reader = new MTSCRA();
            reader.setConnectionType(MTLIB.MTConnectionType.USB);
            reader.OnDataReceived += Reader_OnDataReceived;
            reader.openDevice();
        }

        public void Reader_OnDataReceived(object sender, IMTCardData cardData)
        {
            // send message
        }
    }
}
