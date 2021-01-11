using DIDEx.Models;
using DIDEx.Views;
using LogLib;
using Prism;
using Prism.Commands;
using Prism.Events;
using Prism.Interactivity.InteractionRequest;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Xml;
using WeatherApiLib;
using static NativeLib.NativeMethods;

namespace DIDEx
{
    public class MainWindowViewModel : BindableBase, INavigationAware
    {
        IContainerExtension _container;
        IRegionManager _regionManager;
        IRegion _region;
        IDialogService _dialogService;
        DispatcherTimer _videoTimer;
        Uri uri;
        BitmapImage bitmapImage;
        MainWindowModel mainWindowModel;
        int AppCloseCheckCnt = 0;
        public DelegateCommand<object> MenuSelectCommand { get; private set; }
        public DelegateCommand<object> LoadedCommand { get; private set; }
        public DelegateCommand<object> CloseWindowCommand { get; private set; }
        public DelegateCommand<object> AppClosedCommand { get; private set; }
        public DelegateCommand<object> VidioPopupCommand { get; private set; }
        //public DelegateCommand CustomPopupCommand { get; set; }

        private string _Week = string.Empty;
        public string Week
        {
            get => _Week; set => SetProperty(ref _Week, value);
        }
        
        private string _Watch = string.Empty;
        public string Watch
        {
            get => _Watch; set => SetProperty(ref _Watch, value);
        }

        private string _Temperature = string.Empty;
        public string Temperature
        {
            get => _Temperature; set => SetProperty(ref _Temperature, value);
        }

        private ObservableCollection<string> _message = new ObservableCollection<string>();
        public ObservableCollection<string> Message
        {
            get => _message; set => SetProperty(ref _message, value);
        }

        private ImageSource _WeatherImageSource;
        public ImageSource WeatherImageSource
        {
            get => _WeatherImageSource; set => SetProperty(ref _WeatherImageSource, value);
        }

        private bool _RadioCheckedCommand;
        public bool RadioCheckedCommand
        {
            get => _RadioCheckedCommand; set => SetProperty(ref _RadioCheckedCommand, value);
        }

        public MainWindowViewModel(IContainerExtension container, IRegionManager regionManager,IEventAggregator ea, IDialogService dialogService)
        {
            RadioCheckedCommand = true;
            ea.GetEvent<VideoTimerResetEvent>().Subscribe(MessageReceived);
            ea.GetEvent<HomeViewRetrunEvent>().Subscribe(HomeRetrun);

            MenuSelectCommand = new DelegateCommand<object>(MenuDisplay);
            LoadedCommand = new DelegateCommand<object>(MainWindow_Loaded);
            CloseWindowCommand = new DelegateCommand<object>(MainWindow_Closed);
            AppClosedCommand = new DelegateCommand<object>(ApplicationClosed);
            VidioPopupCommand = new DelegateCommand<object>(VideoViewPopup);
            mainWindowModel = new MainWindowModel();
            //CustomPopupCommand = new DelegateCommand(ShowVideosPopup);  
            _container = container;
            _regionManager = regionManager;
            _dialogService = dialogService;
        }  
         
        private void MainWindow_Loaded(object obj)
        {
            _region = _regionManager.Regions["MainWindowRegion"];
            _regionManager.RequestNavigate(_region.Name, nameof(MenuFrame));

            WeatherAndWatch(); 
        }

        private void ApplicationClosed (object obj)
        {
            
            if(AppCloseCheckCnt == 2)
                Application.Current.Shutdown();

            AppCloseCheckCnt++;
        }

        private void MainWindow_Closed(object obj)
        {
            ShowDeskTop();
            ShowTaskBar();
        }

        /// <summary>
        /// 작업표시줄을 숨김
        /// </summary>
        public static void HideTaskBar()
        {              
            int hwnd = FindTrayWindow();
            if (hwnd != 0)
                ShowWindow(new IntPtr(hwnd), ShowWindowCommands.SW_HIDE);

            hwnd = FindStartButton();
            if (hwnd != 0) // 시작 버튼은 있을 수도 있고 없을수도 있다.      
                ShowWindow(new IntPtr(hwnd), ShowWindowCommands.SW_HIDE);
        }

        /// <summary>
        /// 작업표시줄을 보이게 설정
        /// </summary>
        public static void ShowTaskBar()
        {
            int hwnd = FindTrayWindow();
            if (hwnd != 0)
                ShowWindow(new IntPtr(hwnd), ShowWindowCommands.SW_SHOW);

            hwnd = FindStartButton();
            if (hwnd != 0) // 시작 버튼은 있을 수도 있고 없을수도 있다.      
                ShowWindow(new IntPtr(hwnd), ShowWindowCommands.SW_SHOW);
        }

        /// <summary>
        /// 바탕화면을 숨김
        /// </summary>
        public static void HideDeskTop()
        {
            int hwnd = FindDesktop();

            if (hwnd != 0)
                ShowWindow(new IntPtr(hwnd), ShowWindowCommands.SW_HIDE);
        }

        /// <summary>
        /// 바탕화면을 보이게함
        /// </summary>
        public static void ShowDeskTop()
        {
            int hwnd = FindDesktop();

            if (hwnd != 0)
                ShowWindow(new IntPtr(hwnd), ShowWindowCommands.SW_SHOW);
        }

        private static int FindTrayWindow()
        {
            return FindWindow("Shell_TrayWnd", null);
        }

        private static int FindStartButton()
        {
            int hwnd = FindWindow("Button", "시작");

            if (hwnd == 0)
                hwnd = FindWindow("Start", "시작"); //윈도우10은 Class가 Start이다.

            return hwnd;
        }

        private static int FindDesktop()
        {
            int hwnd = FindWindow("MainWindowViewModel", "MainWindow");

            if (hwnd == 0)
                hwnd = FindWindowEx(IntPtr.Zero, IntPtr.Zero, "Progman", null);

            return hwnd;
        }
        
        private void VideoViewPopup(object obj)
        {
            ShowVideosPopup();
        }
        private void ShowVideosPopup()
        { 
            _dialogService.ShowDialog("Videos", new DialogParameters(""), r =>
            {
                
            });

            _regionManager.RequestNavigate("MenuRegion", nameof(MainMenu));
            _regionManager.RequestNavigate("MainWindowRegion", nameof(MenuFrame));//Video 팝업창 닫으면 MainMenu로 전환시켜줌
            RadioCheckedCommand = true;
        }
         
        /// <summary>
        /// 메뉴 선택에 따른 화면 분기 처리
        /// </summary>
        /// <param name="obj"></param>
        private void MenuDisplay(object obj)
        { 
            switch (obj.ToString())
            {
                case "민원안내": 
                    _regionManager.RequestNavigate("MainWindowRegion", nameof(MenuFrame));
                    MessageReceived("");
                    break;
                case "조직도":
                    //_regionManager.RequestNavigate("MainWindowRegion", nameof(OrganizationChart));
                    _regionManager.RequestNavigate("MainWindowRegion", nameof(OrganizationMenu));
                    MessageReceived("");
                    break;
                case "청사소개":
                    _regionManager.RequestNavigate("MainWindowRegion", nameof(BuildingInformation));
                    MessageReceived("");
                    break;
                case "포토갤러리":
                    _regionManager.RequestNavigate("MainWindowRegion", nameof(PhotoGalleryView));
                    MessageReceived("");
                    break; 
            }
        } 

        /// <summary>
        /// 시간 및 날씨 연동하기 위한 Timer
        /// </summary>
        private void WeatherAndWatch()
        {
            WeatherUpdate();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;              
            timer.Start();

            DispatcherTimer weatherTimer = new DispatcherTimer();
            weatherTimer.Interval = new TimeSpan(0, 30, 0);
            weatherTimer.Tick += WeatherUpdateTick;
            weatherTimer.Start();

            //터치 없을때 홍보영상 활성화하기 위한 타이머
            _videoTimer = new DispatcherTimer();
            _videoTimer.Interval = new TimeSpan(0, 0, 30);
            _videoTimer.Tick += VideoViewStart;
            _videoTimer.Start();
        }

        private void VideoViewStart(object obj, EventArgs e)
        {
            ShowVideosPopup();
        }

        private void MessageReceived(string parameter)
        {
            _videoTimer.Stop();
            _videoTimer.Start(); 
        }

        public void HomeRetrun(string parameter)
        {
            RadioCheckedCommand = true;
        }
        /// <summary>
        /// 시간 업데이트하고 1시간 마다 날씨 업데이트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {            
            Watch = DateTime.Now.ToString("HH  :  mm");
            Week = DateTime.Now.ToString("yyyy-MM-dd[ddd]");
        }

        private void WeatherUpdateTick(object sender, EventArgs e)
        {
            WeatherUpdate();
        }

        private void WeatherUpdate()
        {
            try
            {

                string weather = WeatherApi.ReadWeather();
                string[] weatherArray = weather.Split(',');

                Temperature = weatherArray[1];

                switch (weatherArray[0])
                {
                    case "맑음":
                        GetInformatonImage("sunny.png");
                        break;
                    case "구름 많음":
                        GetInformatonImage("nebilousness.png");
                        break;
                    case "흐림":
                        GetInformatonImage("cloudy.png");
                        break;
                    case "비":
                        GetInformatonImage("rain.png");
                        break;
                    case "비/눈":
                        GetInformatonImage("snowandrain.png");
                        break;
                    case "눈":
                        GetInformatonImage("snow.png");
                        break;
                    case "소나기":
                        GetInformatonImage("shower.png");
                        break;
                }
            }
            catch (Exception e)
            {
                WriteLog.WriteLogger(e.ToString());
            }
        }

        private void GetInformatonImage(string imageName)
        {
            try
            {

                uri = mainWindowModel.GetResourceUri(imageName);
                bitmapImage = new BitmapImage(uri);
                WeatherImageSource = bitmapImage;
            }
            catch (Exception e)
            {
                WriteLog.WriteLogger(e.ToString());
            }
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
    }
}
