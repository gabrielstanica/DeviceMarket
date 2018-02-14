using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMarketName
{
    class Program
    {
        static void Main(string[] args)
        {
            DeviceMarket.MarketName.Initialize();
            var g = DeviceMarket.MarketName.Get("GT-I9300");
        }
    }
}
