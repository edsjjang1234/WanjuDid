using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIDEx.Models
{
    public class AreaMenuModel : BindableBase
    {
        public AreaMenuModel()
        {

        }

        private bool _buttonShow;
        public bool ButtonShow
        {
            get { return _buttonShow; }
            set { SetProperty(ref _buttonShow, value); }
        }

        private string _MenuName;
        public string MenuName
        {
            get => _MenuName;
            set => base.SetProperty(ref _MenuName, value);
        }

        private string _Key;
        public string Key
        {
            get => _Key;
            set => base.SetProperty(ref _Key, value);
        }
    }
}
