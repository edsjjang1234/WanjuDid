using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DIDEx.Models
{
    public class ComplaintsModel : BindableBase
    {
        public static List<ComplaintsListControl> XmlParser()
        {
            List<ComplaintsListControl> depList = new List<ComplaintsListControl>();
            string uri = @"D:\\DIDXML\\Complaints.xml";

            XmlDocument xml = new XmlDocument();
            xml.Load(uri);
            XmlNodeList xmlList = xml.SelectNodes("root/member");
            foreach (XmlNode xn in xmlList)
            {
                var user = new ComplaintsListControl();

                user.Dept = xn["DEPT"].InnerText;
                user.Name = xn["NAME"].InnerText;
                user.Team = xn["TEAM"].InnerText;
                user.Work = xn["WORK"].InnerText;
                user.Tel = xn["TEL"].InnerText;
                user.Visibility = xn["VISIBILITY"].InnerText;
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

    public class ComplaintsListControl
    {
        public string Dept { get; set; }
        public string Name { get; set; }
        public string Team { get; set; }
        public string Work { get; set; }
        public string Tel { get; set; }
        public string Visibility { get; set; }
    }
}
