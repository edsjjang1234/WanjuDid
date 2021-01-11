using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WeatherApi
{
    public class Weather
    {
        public string ReadWeather()
        {
            string url = @"http://www.kma.go.kr/wid/queryDFS.jsp?gridx=65&gridy=93";

            XmlDocument xml = new XmlDocument();
            xml.Load(url);

            XmlNode node = xml.SelectSingleNode("/wid/body/data[@seq='0']");

            string temp = node.SelectSingleNode("temp").InnerText;
            string wfkof = node.SelectSingleNode("wfKor").InnerText;


            return wfkof + " " + temp + "℃";
        }
    }
}
