using LogLib;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
 
namespace DIDEx
{
    public class NameCard : BindableBase
    {
        public event EventHandler OnClick;

        public NameCard()
        {
            try
            {
                ClickCommand = new DelegateCommand(() =>
                {
                    OnClick?.Invoke(this, EventArgs.Empty);
                //if (IsSelected)
                //    OnClick?.Invoke(this, EventArgs.Empty);
                //else
                //    IsSelected = true;
            });
            }
            catch(Exception e)
            {
                WriteLog.WriteLogger(e.ToString());
            }
        }

        public bool IsSelected
        {
            get => _IsSelected;
            set => base.SetProperty(ref _IsSelected, value);
        }
        private bool _IsSelected = false;

        public int DeptIndex { get; set; }
        
        public string Dept
        {
            get => _Dept;
            set => base.SetProperty(ref _Dept, value);
        }
        private string _Dept;

       public string Team
        {
            get => _Team;
            set => base.SetProperty(ref _Team, value);
        }
        private string _Team;

        public string Name
        {
            get => _Name;
            set => base.SetProperty(ref _Name, value);
        }
        private string _Name;

        public string Work
        {
            get => _Work;
            set => base.SetProperty(ref _Work, value);
        }
        private string _Work;

        public string Tel
        {
            get => _Tel;
            set => base.SetProperty(ref _Tel, value);
        }
        private string _Tel;

        public string ImagePath
        {
            get => _ImagePath;
            set => base.SetProperty(ref _ImagePath, value);
        }
        private string _ImagePath;



        public ICommand ClickCommand { get; }
    }
}
