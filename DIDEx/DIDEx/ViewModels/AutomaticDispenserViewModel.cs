using DIDEx.Views;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DIDEx.ViewModels
{
	public class AutomaticDispenserViewModel : BindableBase
	{
        IRegionManager _regionManager;
        IEventAggregator _ea;

        public DelegateCommand<object> RetrunCommand { get; private set; }

        private string _messge = "Message";
        public string Message
        {
            get { return _messge; }
            set { SetProperty(ref _messge, value); }
        }

        public AutomaticDispenserViewModel(IRegionManager regionManager, IEventAggregator ea)
        {
            RetrunCommand = new DelegateCommand<object>(RetrunView);
            _ea = ea;
            _regionManager = regionManager;
        }

        private void RetrunView(object obj)
        {
            var navigationParameters = new NavigationParameters();
            navigationParameters.Add("MenuName", "14");
            _regionManager.RequestNavigate("MenuRegion", nameof(SubMenu), navigationParameters);
            VideoTiemerReset();
        }


        private void VideoTiemerReset()
        {
            _ea.GetEvent<VideoTimerResetEvent>().Publish(Message);
        }

    }
}
