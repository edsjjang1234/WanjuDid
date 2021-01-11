using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Windows.Input;

namespace DIDEx.Models
{
    public class SubMenuModel : BindableBase
    {
       
        public SubMenuModel()
        { 
        }

        public Uri GetResourceUri(string resourcePath)
        {
            return new Uri(string.Format("pack://application:,,,/Resources\\{0}", resourcePath));
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
