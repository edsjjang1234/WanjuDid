using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DIDEx.Models
{
    public class MenuMap1FModel : BindableBase
    {
        public Uri GetResourceUri(string resourcePath)
        {
            return new Uri(string.Format("pack://application:,,,/Resources\\{0}", resourcePath));
        }

        public static List<MenuMapList> XmlParser()
        {
            List<MenuMapList> depList = new List<MenuMapList>();
            string uri = @"D:\\DIDXML\\organizationchart.xml";

            XmlDocument xml = new XmlDocument();
            xml.Load(uri);
            XmlNodeList xmlList = xml.SelectNodes("root/member");
            foreach (XmlNode xn in xmlList)
            {
                var user = new MenuMapList();

                user.Dept = xn["DEPT"].InnerText;
                user.Name = xn["NAME"].InnerText;
                user.Team = xn["TEAM"].InnerText;
                //user.Work = xn["WORK"].InnerText;
                //user.Tel = xn["TEL"].InnerText;

                depList.Add(user);
            }

            return depList;
        }

        private bool _ShowVisibility;
        public bool ShowVisibility
        {
            get { return _ShowVisibility; }
            set { SetProperty(ref _ShowVisibility, value); }
        }

    }

    public class MenuMapList
    {
        public string Dept { get; set; }
        public string Name { get; set; }
        public string Team { get; set; }
        public string Work { get; set; }
        public string Tel { get; set; }
    }  
}
