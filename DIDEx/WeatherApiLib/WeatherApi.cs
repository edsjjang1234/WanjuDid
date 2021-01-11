using LogLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WeatherApiLib
{
    public class WeatherApi
    {
        public static string ReadWeather()
        {

            string url = @"http://www.kma.go.kr/wid/queryDFS.jsp?gridx=65&gridy=93";
            string temp = string.Empty;
            string wfkof = string.Empty;
            try
            {

                XmlDocument xml = new XmlDocument();
                xml.Load(url);

                XmlNode node = xml.SelectSingleNode("/wid/body/data[@seq='0']");
                temp = node.SelectSingleNode("temp").InnerText;
                wfkof = node.SelectSingleNode("wfKor").InnerText;
            }
            catch (Exception e)
            {
                WriteLog.WriteLogger(e.ToString());
            }
             
            return wfkof + "," + temp + "℃";
        }
    }
}
