using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIDEx.Models
{
    public class MainWindowModel
    {
        public Uri GetResourceUri(string resourcePath)
        {
            return new Uri(string.Format("pack://application:,,,/Resources\\{0}", resourcePath));
        }
    }
}
