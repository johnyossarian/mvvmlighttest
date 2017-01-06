using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MTSCRANET;


namespace MvvmLightTest.Devices.MagStripeReader
{
    public class MagTek
    {
        MTSCRANET.MTSCRA reader { get; set; }

        public MagTek()
        {

        }

        public void InitializeMagStripeReader()
        {
            reader = new MTSCRA();
            reader.setConnectionType(MTLIB.MTConnectionType.USB);
            //reader.OnDataReceived += Reader_OnDataReceived;
            reader.openDevice();
        }
    }
}
