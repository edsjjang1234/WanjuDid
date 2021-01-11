using DIDEx.Model;
using LogLib;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace DIDEx.ViewModels
{
    public class PhotoGalleryViewModel : BindableBase
    {
        IEventAggregator _ea;
        PhotoGalleryModel pgModel;
        List<string> ImageNameLsit;
        List<PhotoContent> PhotoContent;
        List<string> PhotoContentList;
        private List<BitmapImage> bitmapImageList = new List<BitmapImage>();
        int currentIndex = 0;
        public DelegateCommand<object> LeftImageCommand { get; private set; }
        public DelegateCommand<object> RightImageCommand { get; private set; }

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

        private string _messge = "Message";
        public string Message
        {
            get { return _messge; }
            set { SetProperty(ref _messge, value); }
        }

        public PhotoGalleryViewModel(IEventAggregator ea)
        {
            _ea = ea;
            LeftImageCommand = new DelegateCommand<object>(LeftImageChanged);
            RightImageCommand = new DelegateCommand<object>(RightImageChanged);
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 5);
            timer.Tick += Timer_Tick;
            timer.Start();

            SetBitmapImageList();
        } 
        
        public void RightImageChanged(object obj)
        {
            try
            {

                if (this.currentIndex == this.bitmapImageList.Count - 1)
                {
                    this.currentIndex = 0;
                }
                else
                {
                    this.currentIndex++;
                }
                CurrentImagePath = this.bitmapImageList[this.currentIndex];
                Photocontent = PhotoContentList[currentIndex];
            }
            catch (Exception e)
            {
                WriteLog.WriteLogger(e.ToString());
            }
            _ea.GetEvent<VideoTimerResetEvent>().Publish(Message);//화면 터치시 Video Timer 리셋 이벤트
        }

        private void LeftImageChanged(object obj)
        {
            try
            {
                if (this.currentIndex == 0)
                {
                    this.currentIndex = this.bitmapImageList.Count - 1;
                }
                else
                {
                    this.currentIndex--;
                }
                CurrentImagePath = this.bitmapImageList[this.currentIndex];
                Photocontent = PhotoContentList[currentIndex];
            }
            catch (Exception e)
            {
                WriteLog.WriteLogger(e.ToString());
            }
            _ea.GetEvent<VideoTimerResetEvent>().Publish(Message);//화면 터치시 Video Timer 리셋 이벤트
        }

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
                pgModel = new PhotoGalleryModel();
                ImageNameLsit = new List<string>();
                ImageNameLsit = pgModel.ImageFileSetting();

                PhotoContentList = new List<string>();

                this.bitmapImageList.Clear();

                foreach (string resourcePath in ImageNameLsit)
                {
                    BitmapImage bitmapImage = new BitmapImage(new Uri("D:\\Image\\" + resourcePath, UriKind.Absolute));
                    this.bitmapImageList.Add(bitmapImage);

                    pathArray = resourcePath.Split('.');
                    PhotoContent = PhotoGalleryModel.XmlParser(pathArray[0]);
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
    }
}