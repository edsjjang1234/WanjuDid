using DIDEx.Models;
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
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DIDEx.ViewModels
{
    public class BuildingInformationViewModel : BindableBase
    {
        IEventAggregator _ea;
        IRegionManager _regionManager;
        BuildingInformationModel BuildingModel;
        BitmapImage bitmapImage;
        Uri uri;
        
        public DelegateCommand<object> Upstairs { get; private set; }
        public DelegateCommand<object> RetrunViewCommand { get; private set; }

        private ImageSource _BuildingImagePath;
        public ImageSource BuildingImagePath
        {
            get => _BuildingImagePath; set => SetProperty(ref _BuildingImagePath, value);
        }
        //
        private string _messge = "Message";
        public string Message
        {
            get { return _messge; }
            set { SetProperty(ref _messge, value); }
        }
        //
        
        public BuildingInformationViewModel(IContainerExtension container, IRegionManager regionManager, IEventAggregator ea)
        {
            _regionManager = regionManager;
            _ea = ea;
            Upstairs = new DelegateCommand<object>(ChangeBuildingImage);
            RetrunViewCommand = new DelegateCommand<object>(RetrunView);
            BuildingModel = new BuildingInformationModel();
            //SendMessageCommand = new DelegateCommand<object>(ChangeBuildingImage,SendMessage);
            GetInformatonImage("office_f1.png"); 
        }
 
        private void GetInformatonImage(string imageName)
        {
            uri = BuildingModel.GetResourceUri(imageName);
            bitmapImage = new BitmapImage(uri);
            BuildingImagePath = bitmapImage;
        }

        private void RetrunView(object obj)
        {
            var navigationParameters = new NavigationParameters();
            navigationParameters.Add("MenuName", "BuildingRetrun");
            
            _regionManager.RequestNavigate("MenuRegion", nameof(MainMenu), navigationParameters);
            _regionManager.RequestNavigate("MainWindowRegion", nameof(MenuFrame));
            _ea.GetEvent<HomeViewRetrunEvent>().Publish("");
        }

        private void ChangeBuildingImage(object obj)
        {
            try
            {

                switch (obj.ToString())
                {
                    case "1층":
                        GetInformatonImage("office_f1.png");
                        break;
                    case "2층":
                        GetInformatonImage("office_f2.png");
                        break;
                    case "3층":
                        GetInformatonImage("office_f3.png");
                        break;
                    case "4층":
                        GetInformatonImage("office_f4.png");
                        break;
                    case "5층":
                        GetInformatonImage("office_f5.png");
                        break;
                    case "6층":
                        GetInformatonImage("office_f6.png");
                        break;
                }
                _ea.GetEvent<VideoTimerResetEvent>().Publish(Message);
            }
            catch (Exception e)
            {
                WriteLog.WriteLogger(e.ToString());
            }

        } 
    }
}