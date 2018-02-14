using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DeviceMarket
{
    public class MarketName
    {
        public static string CSVFile { get; set; }

        public static void Initialize(string csvPath = "")
        {
            if (csvPath.Equals(String.Empty))
            {
                CSVFile = Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().ToString(), "supported_devices.csv");
            }
            else
            {
                CSVFile = csvPath;
            }
        }
        public static  string Get(string deviceModel)
        {
            var csvFile = File.ReadAllLines(CSVFile);
            string realName = SearchForDevice(csvFile, deviceModel);
            return realName;
        }

        private string OnlineCSV(string deviceModel)
        {
            WebClient s = new WebClient();
            var data = s.DownloadString("http://storage.googleapis.com/play_public/supported_devices.csv");
            string[] stringSeparators = new string[] { "\r\n" };
            var lineData = data.Split(stringSeparators, StringSplitOptions.None);
            string realName = SearchForDevice(lineData, deviceModel);

            return realName;

        }

        private static string SearchForDevice(string[] data, string deviceModel)
        {
            string realName = String.Empty;
            foreach (var line in data)
            {
                if (line.Contains(deviceModel))
                {
                    var allDevices = line.Split(',');
                    realName = String.Format("{0} {1}", allDevices[0], allDevices[1]);
                }
            }

            if (realName.Equals(String.Empty))
            {
                realName = "No device found";
            }

            return realName;
        }
    }
}