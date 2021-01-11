using DIDEx.Models;
using DIDEx.Views;
using LogLib;
using Prism.Commands;
using Prism.Events;
using Prism.Interactivity.InteractionRequest;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace DIDEx.ViewModels
{
    public class VideosViewModel : BindableBase,  INavigationAware, IDialogAware
    {
        IContainerExtension _container;
        IRegionManager _regionManager;
        IEventAggregator _ea;
        VideosModel videosModel;
        public Action FinishInteraction { get; set; }
        public DelegateCommand <object> CloseDialogCommand { get; private set; }
        public DelegateCommand<object> LoadedCommand { get; private set; }
        private List<BitmapImage> bitmapImageList = new List<BitmapImage>();
        List<PhotoContent> PhotoContent;
        List<string> PhotoContentList;
        List<string> ImageNameLsit;
        List<Uri> videoUriList;
        int currentIndex = 0;
        int videoIndex = 0;

        private Uri _UriSource;
        public Uri UriSource
        {
            get => _UriSource; set => SetProperty(ref _UriSource, value);
        }


        private string _messge = "Message";
        public string Message
        {
            get { return _messge; }
            set { SetProperty(ref _messge, value); }
        }

        private ImageSource _CurrentImagePath;
        public ImageSource CurrentImagePath
        {
            get => _CurrentImagePath; set => SetProperty(ref _CurrentImagePath, value);
        }

        private string _Photocontent;
        public string Photocontent
        {
            get => _Photocontent; set => SetProperty(ref _Photocontent, value);
        }

        public VideosViewModel(IContainerExtension container, IRegionManager regionManager, IEventAggregator ea)
        {
            _ea = ea;
            videosModel = new VideosModel();
            videoUriList = new List<Uri>();
            videoUriList= videosModel.GetVidioFilePath(); 
            UriSource = videoUriList[videoIndex];
            videoIndex++;
            //UriSource = videosModel.GetVidioFilePath();
            CloseDialogCommand = new DelegateCommand<object>(PopupClose);
            LoadedCommand = new DelegateCommand<object>(UserControl_Loaded);
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 5);
            timer.Tick += Timer_Tick;
            timer.Start();

            SetBitmapImageList();
            _container = container;
            _regionManager = regionManager;
        }

        
        public event Action<IDialogResult> RequestClose;

        private void UserControl_Loaded(object sender)
        { 
        }

        private void PopupClose(object obj)
        {
            RaiseRequestClose(new DialogResult()); 
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
             
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
             
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
             
        }
        public virtual void RaiseRequestClose(IDialogResult dialogResult)
        {
            RequestClose?.Invoke(dialogResult);
        }

        public ICommand MediaEndedCommand
        {
            get
            {
                return new DelegateCommand<object>((sender) =>
                {
                    if (videoUriList.Count > videoIndex)
                    {
                        UriSource = videoUriList[videoIndex];
                    }
                    else
                    {
                        videoIndex = 0;
                        UriSource = videoUriList[videoIndex];
                    }
                    
                    MediaElement media = (MediaElement)sender;
                    media.LoadedBehavior = MediaState.Manual;
                    media.Position = TimeSpan.FromMilliseconds(1);
                    media.Play();
                    videoIndex++;
                });
            }

        }

        public string Title => "";

        private void Timer_Tick(Object sender, EventArgs e)
        {
            try
            {
                this.currentIndex++;

                if (this.currentIndex > this.bitmapImageList.Count - 1)
                {
                    this.currentIndex = 0;
                }

                CurrentImagePath = this.bitmapImageList[this.currentIndex];
                Photocontent = PhotoContentList[currentIndex];
            }
            catch (Exception ex)
            {
                WriteLog.WriteLogger(ex.ToString());
            }
            
        }

        private void SetBitmapImageList()
        {
            try
            {

                string[] pathArray;
               // videosModel = new VideosModel();
                ImageNameLsit = new List<string>();
                ImageNameLsit = videosModel.ImageFileSetting();

                PhotoContentList = new List<string>();

                this.bitmapImageList.Clear();

                foreach (string resourcePath in ImageNameLsit)
                {
                    BitmapImage bitmapImage = new BitmapImage(new Uri("D:\\Image\\" + resourcePath, UriKind.Absolute));
                    this.bitmapImageList.Add(bitmapImage);

                    pathArray = resourcePath.Split('.');
                    PhotoContent = VideosModel.XmlParser(pathArray[0]);
                    PhotoContentList.Add(PhotoContent[0].Content);
                    PhotoContent.Clear();
                }
                CurrentImagePath = this.bitmapImageList[this.currentIndex];
                Photocontent = PhotoContentList[currentIndex];
            }
            catch (Exception e)
            {
                WriteLog.WriteLogger(e.ToString());
            }

        }

        //public INotification Notification { get; set; }

        //public string Title => throw new NotImplementedException();
    }
}
