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
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DIDEx.ViewModels
{
    public class AreaMenuViewModel : BindableBase, INavigationAware
    {
        IEventAggregator _ea;
        IRegionManager _regionManager;
        BitmapImage bitmapImage;
        Uri uri;
        private IRegionNavigationService navigationService;
        public DelegateCommand<object> RetrunMenuCommand { get; set; }
        public DelegateCommand<object> InformationMapCommand { get; private set; }
        public ObservableCollection<AreaMenuModel> MenuList { get; set; } = new ObservableCollection<AreaMenuModel>();

        private string _messge = "Message";
        public string Message
        {
            get { return _messge; }
            set { SetProperty(ref _messge, value); }
        }

        private ImageSource _ButtonBack;
        public ImageSource ButtonBack
        {
            get => _ButtonBack; set => SetProperty(ref _ButtonBack, value);
        }

        public AreaMenuViewModel(IRegionManager regionManager, IEventAggregator ea)
        {
            _ea = ea;
            RetrunMenuCommand = new DelegateCommand<object>(RetrunMenuView);
            InformationMapCommand = new DelegateCommand<object>(InformationMapCall);
            _regionManager = regionManager;
        }

        private void RetrunMenuView(object obj)
        {
            //서브메뉴에따른 분기 처리와 서브메뉴 이름 리턴해줘야함.
            var navigationParameters = new NavigationParameters();
            navigationParameters.Add("MenuName", "메뉴C");

            _regionManager.RequestNavigate("MenuRegion", nameof(SubMenu), navigationParameters);
        }

        /// <summary>
        /// 메뉴 지역 선택에따른 맵 전환
        /// </summary>
        /// <param name="obj"></param>
        private void InformationMapCall(object obj)
        {
            try
            {

                var navigationParameters = new NavigationParameters();

                switch (obj.ToString())
                {
                    case "B-0-0"://건축민원
                        navigationParameters.Add("Key", "16");
                        _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap1F), navigationParameters);
                        break;
                    case "B-0-1":
                        navigationParameters.Add("Key", "20");
                        _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap1F), navigationParameters);
                        break;
                    case "B-0-2":
                        navigationParameters.Add("Key", "19");
                        _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap1F), navigationParameters);
                        break;
                    case "B-0-3":
                        navigationParameters.Add("Key", "25");
                        _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap1F), navigationParameters);
                        break;
                    case "B-0-4":
                        navigationParameters.Add("Key", "21");
                        _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap1F), navigationParameters);
                        break;
                    case "B-0-5":
                        navigationParameters.Add("Key", "17");
                        _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap1F), navigationParameters);
                        break;


                    case "B-1-0"://가설건축물 축조신고
                        navigationParameters.Add("Key", "16");
                        _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap1F), navigationParameters);
                        break;
                    case "B-1-1":
                        navigationParameters.Add("Key", "20");
                        _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap1F), navigationParameters);
                        break;
                    case "B-1-2":
                        navigationParameters.Add("Key", "19");
                        _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap1F), navigationParameters);
                        break;
                    case "B-1-3":
                        navigationParameters.Add("Key", "25");
                        _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap1F), navigationParameters);
                        break;
                    case "B-1-4":
                        navigationParameters.Add("Key", "21");
                        _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap1F), navigationParameters);
                        break;
                    case "B-1-5":
                        navigationParameters.Add("Key", "17");
                        _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap1F), navigationParameters);
                        break;


                    case "D-0-0"://토지분할 합병 지목변경 신청
                        navigationParameters.Add("Key", "47");
                        _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap1F), navigationParameters);
                        break;
                    case "D-0-1":
                        navigationParameters.Add("Key", "45");
                        _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap1F), navigationParameters);
                        break;


                    case "K-1-0"://산지전용
                        navigationParameters.Add("Key", "2");
                        _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap6F), navigationParameters);
                        break;
                    case "K-1-1":
                        navigationParameters.Add("Key", "2");
                        _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap6F), navigationParameters);
                        break;


                    case "L-0-0"://개발행위허가
                        navigationParameters.Add("Key", "3");
                        _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap6F), navigationParameters);
                        break;
                    case "L-0-1":
                        navigationParameters.Add("Key", "3");
                        _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap6F), navigationParameters);
                        break;
                    case "L-0-2":
                        navigationParameters.Add("Key", "3");
                        _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap6F), navigationParameters);
                        break;
                    case "L-0-3":
                        navigationParameters.Add("Key", "3");
                        _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap6F), navigationParameters);
                        break;

                }
            }
            catch (Exception e)
            {
                WriteLog.WriteLogger(e.ToString());
            }
        }
        /// <summary>
        /// 메인메뉴에 따라 지역메뉴 바인딩
        /// </summary>
        /// <param name="menuName"></param>
        private void SettingSubMenu(string[] subMenu, string key)
        {
            try
            {
                MenuList.Clear();
                for (int i = 0; i < 6; i++)
                {
                    var menu = new AreaMenuModel();
                    if (i < subMenu.Length)
                    {
                        menu.MenuName = subMenu[i].ToString();
                        menu.ButtonShow = true;
                        menu.Key = key + "-" + i;
                    }
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

        /// <summary>
        /// 메인메뉴에 지역메뉴 할당
        /// </summary>
        /// <param name="menuName"></param>
        private void ChangedSubMenu(string menuName)
        {// L - 0K - 1D - 0B - 1B - 0
            try
            {

                string[] subMenu;

                switch (menuName)
                {
                    case "B-0"://건축민원
                        SettingSubMenu(subMenu = new string[] { "이서ㆍ고산","용진ㆍ비봉","봉동ㆍ운주",
                    "삼례ㆍ소양","구이ㆍ동상","상관ㆍ화산ㆍ경천"}, "B-0");
                        uri = new Uri("pack://application:,,,/Resources\\buttonBlue.png");
                        bitmapImage = new BitmapImage(uri);
                        ButtonBack = bitmapImage;
                        break;

                    case "B-1"://가설건축물 축조신고
                        SettingSubMenu(subMenu = new string[] { "이서ㆍ고산","용진ㆍ비봉","봉동ㆍ운주",
                    "삼례ㆍ소양","구이ㆍ동상","상관ㆍ화산ㆍ경천"}, "B-1");
                        uri = new Uri("pack://application:,,,/Resources\\buttonBlue.png");
                        bitmapImage = new BitmapImage(uri);
                        ButtonBack = bitmapImage;
                        break;

                    case "D-0"://토지분할 합병 지목변경 신청
                        SettingSubMenu(subMenu = new string[] { "삼례ㆍ용진ㆍ상관\n이서ㆍ화산ㆍ동상",
                    "봉동ㆍ소양ㆍ구이ㆍ고산\n     비봉ㆍ운주ㆍ경천"}, "D-0");
                        uri = new Uri("pack://application:,,,/Resources\\buttonBlue.png");
                        bitmapImage = new BitmapImage(uri);
                        ButtonBack = bitmapImage;
                        break;
                    case "K-1"://산지전용
                        SettingSubMenu(subMenu = new string[] { "삼례ㆍ봉동ㆍ용진ㆍ상관\n이서ㆍ소양ㆍ구이ㆍ비봉",
                    "고산ㆍ운주ㆍ화산\n     동상ㆍ경천"}, "K-1");
                        uri = new Uri("pack://application:,,,/Resources\\buttonBrown.png");
                        bitmapImage = new BitmapImage(uri);
                        ButtonBack = bitmapImage;
                        break;
                    case "L-0"://개발행위허가
                        SettingSubMenu(subMenu = new string[] { "삼례ㆍ비봉ㆍ운주","봉동ㆍ용진ㆍ경천",
                    "이서ㆍ고산ㆍ동상ㆍ소양","상관ㆍ구이ㆍ화산"}, "L-0");
                        uri = new Uri("pack://application:,,,/Resources\\buttonBrown.png");
                        bitmapImage = new BitmapImage(uri);
                        ButtonBack = bitmapImage;
                        break;

                }

                VideoTiemerReset();
            }
            catch (Exception e)
            {
                WriteLog.WriteLogger(e.ToString());
            }
        }

        //서브메뉴에서 메뉴 파라미터 받아서 화면 처리
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            navigationService = navigationContext.NavigationService;
            string menuName = navigationContext.Parameters["SubMenuA"].ToString();
            ChangedSubMenu(menuName);
        }

        private void VideoTiemerReset()
        {
            _ea.GetEvent<VideoTimerResetEvent>().Publish(Message);
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
