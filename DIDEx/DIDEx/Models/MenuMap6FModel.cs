using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIDEx.Models
{
    public class MenuMap6FModel : BindableBase
    {
        private bool _buttonShow;
        public bool ButtonShow
        {
            get { return _buttonShow; }
            set { SetProperty(ref _buttonShow, value); }
        }
    }
}
