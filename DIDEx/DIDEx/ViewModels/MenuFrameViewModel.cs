using DIDEx.Views;
using Prism;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace DIDEx.ViewModels
{
	public class MenuFrameViewModel : BindableBase,IActiveAware, INavigationAware
    {
        IRegionManager _regionManager;
         
        public event EventHandler IsActiveChanged;

        public DelegateCommand<object> LoadedCommand { get; private set; }
        
        private bool _IsActive;
        public bool IsActive
        {
            get
            {
                return _IsActive;
            }

            set
            {
                _IsActive = value;
                if (_IsActive)
                    OnActive();
            }
        }
        
        private void OnActive()
        {
        }

        public MenuFrameViewModel(IContainerExtension container, IRegionManager regionManager)
        {
            LoadedCommand = new DelegateCommand<object>(MenuFrame_Loaded);
            
            _regionManager = regionManager;
        }
        
        private void MenuFrame_Loaded(object obj)
        {
            _regionManager.RequestNavigate("MenuRegion", "MainMenu");
            return;
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            ;
        }
    }
}
