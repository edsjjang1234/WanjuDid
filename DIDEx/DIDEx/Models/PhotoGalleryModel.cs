using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace DIDEx.Model
{
    public class PhotoGalleryModel
    {
        public List<string> ImageFileSetting()
        {

            List<string> imageList = new List<string>();
            string Path = @"D:\\Image";

            if (System.IO.Directory.Exists(Path))
            {
                //DirectoryInfo 객체 생성
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(Path);

                //해당 폴더에 있는 파일이름을 출력
                foreach (var item in di.GetFiles())
                {
                    if (Regex.IsMatch(item.Name, @".jpg|.png|.bmp|.JPG|.PNG|.BMP|.JPEG|.jpeg$"))
                    {
                        imageList.Add(item.Name);
                    }
                }

            }

            return imageList;
        }

        public static List<PhotoContent> XmlParser(string fileName)
        {
            List<PhotoContent> depList = new List<PhotoContent>();
            string uri = @"D:\\Image\\" + fileName+".xml";

            XmlDocument xml = new XmlDocument();
            xml.Load(uri);
            XmlNodeList xmlList = xml.SelectNodes("root/content");
            foreach (XmlNode xn in xmlList)
            {
                var user = new PhotoContent();

                user.Content = xn["TEXT"].InnerText;
                 
                depList.Add(user);
            }

            return depList;
        }
    }

    public class PhotoContent
    { 
        public string Content { get; set; }
    }
}
