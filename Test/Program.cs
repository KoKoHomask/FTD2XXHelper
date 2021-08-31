using System;
using FTD2XXHelper;
using static FTD2XXHelper.FTDI;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            FTDI fTDI = new FTDI();
            var infolst = new FT_DEVICE_INFO_NODE[100];
            var res = fTDI.GetDeviceList(infolst);
            if (infolst[0] == null) return;
            uint id = infolst[0].ID;
            var openStatus = fTDI.OpenByIndex(0);
            var baudStatus = fTDI.SetBaudRate(3000000);
            var dtr = fTDI.SetDTR(true);
            var rts = fTDI.SetRTS(true);
            bool isOpen = fTDI.IsOpen;
            var closeSattus = fTDI.Close();
            Console.WriteLine("Hello World!");
            Console.WriteLine(res);
            Console.WriteLine(openStatus);
            Console.WriteLine(baudStatus);
            Console.WriteLine(closeSattus);
            Console.WriteLine(dtr);
            Console.WriteLine(rts);
            ;
        }
    }
}
