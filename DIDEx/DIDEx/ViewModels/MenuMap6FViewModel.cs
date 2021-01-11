using DIDEx.Models;
using DIDEx.Views;
using LogLib;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DIDEx.ViewModels
{
	public class MenuMap6FViewModel : BindableBase, INavigationAware
    {
        IEventAggregator _ea;
        public ObservableCollection<MenuMap6FModel> MenuList { get; set; } = new ObservableCollection<MenuMap6FModel>();
        private IRegionNavigationService navigationService;
        IRegionManager _regionManager;
        public DelegateCommand<object> RetrunViewCommand { get; set; }

        private string _messge = "Message";
        public string Message
        {
            get { return _messge; }
            set { SetProperty(ref _messge, value); }
        }

        public MenuMap6FViewModel(IRegionManager regionManager, IEventAggregator ea)
        {
            _ea = ea;
            _regionManager = regionManager;
            RetrunViewCommand = new DelegateCommand<object>(RetrunView);
        }

        private void RetrunView(object obj)
        {

            var navigationParameters = new NavigationParameters();
            navigationParameters.Add("MenuName", "메뉴C");

            _regionManager.RequestNavigate("MenuRegion", nameof(SubMenu), navigationParameters);

            // _regionManager.RequestNavigate("MenuRegion", nameof(SubMenu));
            VideoTiemerReset();
        }

        private void VideoTiemerReset()
        {
            _ea.GetEvent<VideoTimerResetEvent>().Publish(Message);
        }

        private void SetArea(string key)
        {
            try
            {
                MenuList.Clear();
                for (int i = 0; i < 5; i++)
                {
                    var menu = new MenuMap6FModel();
                    if (Convert.ToString(i) == key)
                        menu.ButtonShow = true;
                    else
                        menu.ButtonShow = false;

                    MenuList.Add(menu);
                }
            }
            catch (Exception e)
            {
                WriteLog.WriteLogger(e.ToString());
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            navigationService = navigationContext.NavigationService;
            string key = navigationContext.Parameters["Key"].ToString();
            SetArea(key);
        }
    }
}
