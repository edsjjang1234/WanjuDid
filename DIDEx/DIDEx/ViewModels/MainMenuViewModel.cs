using DIDEx.Views;
using LogLib;
using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DIDEx.ViewModels
{
    public class MainMenuViewModel : BindableBase, INavigationAware
    {
        IEventAggregator _ea;
        IRegionManager _regionManager;
        public DelegateCommand<object> MenuCommand { get; private set; }

        private string _messge = "Message";
        public string Message
        {
            get { return _messge; }
            set { SetProperty(ref _messge, value); }
        }

        public MainMenuViewModel(IContainerExtension container, IRegionManager regionManager, IEventAggregator ea)
        {
            _ea = ea;
            MenuCommand = new DelegateCommand<object>(SelectSubManu);
            
            _regionManager = regionManager;
        }
         
        private void SelectSubManu(object obj)
        {
            try
            {

                var navigationParameters = new NavigationParameters();
                switch (obj.ToString())
                {
                    case "0":
                        navigationParameters.Add("MenuName", "0");
                        break;
                    case "1":
                        navigationParameters.Add("MenuName", "1");
                        break;
                    case "2":
                        navigationParameters.Add("MenuName", "2");
                        break;
                    case "3":
                        navigationParameters.Add("MenuName", "3");
                        break;
                    case "4":
                        navigationParameters.Add("MenuName", "4");
                        break;
                    case "5":
                        navigationParameters.Add("MenuName", "5");
                        break;
                    case "6":
                        navigationParameters.Add("MenuName", "6");
                        break;
                    case "7":
                        navigationParameters.Add("MenuName", "7");
                        break;
                    case "8":
                        navigationParameters.Add("MenuName", "8");
                        break;
                    case "9":
                        navigationParameters.Add("MenuName", "9");
                        break;
                    case "10":
                        navigationParameters.Add("MenuName", "10");
                        break;
                    case "11":
                        navigationParameters.Add("MenuName", "11");
                        break;
                    case "12":
                        navigationParameters.Add("MenuName", "12");
                        break;
                    case "13":
                        navigationParameters.Add("MenuName", "13");
                        break;
                    case "14":
                        navigationParameters.Add("MenuName", "14");
                        break;
                }
                _ea.GetEvent<VideoTimerResetEvent>().Publish(Message);//화면 터치시 Video Timer 리셋 이벤트
                _regionManager.RequestNavigate("MenuRegion", nameof(SubMenu), navigationParameters);
            }
            catch (Exception e)
            {
                WriteLog.WriteLogger(e.ToString());
            }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            ;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
    }
}
