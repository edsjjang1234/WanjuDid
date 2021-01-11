using CommonServiceLocator;
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
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static System.Net.Mime.MediaTypeNames;

namespace DIDEx.ViewModels
{
	public class SubMenuViewModel : BindableBase , INavigationAware, IRegionNavigationJournal
    {
        IEventAggregator _ea;
        IContainerExtension _container;
        IRegionManager _regionManager;
        IRegion _region;
        BitmapImage bitmapImage;
        Uri uri;
        SubMenuModel Sm;
        public DelegateCommand<object> LoadedCommand { get; private set; }
        public DelegateCommand<object> ReturnMenu { get; private set; }
        public DelegateCommand<object> InformationMapCommand { get; private set; }
        public ObservableCollection<SubMenuModel> MenuList { get; set; } = new ObservableCollection<SubMenuModel>();

        bool IRegionNavigationJournal.CanGoBack => true;
        public bool CanGoForward => true;
        public IRegionNavigationJournalEntry CurrentEntry => throw new NotImplementedException();
        public INavigateAsync NavigationTarget { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private IRegionNavigationService navigationService;

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
        public SubMenuViewModel(IContainerExtension container, IRegionManager regionManager, IEventAggregator ea)
        {
            _ea = ea;
            LoadedCommand = new DelegateCommand<object>(SubMenuView_Loaded);
            ReturnMenu = new DelegateCommand<object>(ReturnMenuView);
            InformationMapCommand = new DelegateCommand<object>(InformationMapCall);
            _container = container;
            _regionManager = regionManager;
            Sm = new SubMenuModel();
        }

        private void SubMenuView_Loaded(object obj)
        { 
            _region = _regionManager.Regions["SubMenuRegion"]; 
        }

        /// <summary>
        /// 서브메뉴에 따라 안내 지도 화면 전환
        /// </summary>
        /// <param name="obj"></param>
        private void InformationMapCall(object obj)
        {
            try
            {
                string[] nemu = obj.ToString().Split('-');

                var navigationParameters = new NavigationParameters();
                //navigationParameters.Add("SubMenuA", "메뉴A");

                //_regionManager.RequestNavigate("MenuRegion", nameof(AreaMenu), navigationParameters);

                switch (nemu[0])
                {
                    case "A"://민원접수 및 증명발급
                        if (obj.ToString() == "A-0")
                        {
                            navigationParameters.Add("Key", "75");
                            _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap1F), navigationParameters);
                        }
                        else if (obj.ToString() == "A-1")
                        {
                            navigationParameters.Add("Key", "0");
                            _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap4F), navigationParameters);
                        }


                        break;
                    case "B"://건축민원
                        if (obj.ToString() == "B-0")
                        {
                            //지역화면 전환
                            navigationParameters.Add("SubMenuA", "B-0");
                            _regionManager.RequestNavigate("MenuRegion", nameof(AreaMenu), navigationParameters);
                        }
                        else if (obj.ToString() == "B-1")
                        {
                            //지역화면 전환
                            navigationParameters.Add("SubMenuA", "B-1");
                            _regionManager.RequestNavigate("MenuRegion", nameof(AreaMenu), navigationParameters);
                        }
                        else if (obj.ToString() == "B-2")
                        {
                            navigationParameters.Add("Key", "10");
                            _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap1F), navigationParameters);
                        }
                        else if (obj.ToString() == "B-3")
                        {
                            navigationParameters.Add("Key", "3");
                            _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap1F), navigationParameters);
                        }
                        break;
                    case "C"://여권 국제운전면허증
                        if (obj.ToString() == "C-0")
                        {
                            navigationParameters.Add("Key", "63");
                            _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap1F), navigationParameters);
                        }
                        else if (obj.ToString() == "C-1")
                        {
                            navigationParameters.Add("Key", "62");
                            _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap1F), navigationParameters);
                        }
                        break;
                    case "D"://지역토지
                        if (obj.ToString() == "D-0")
                        {
                            //지역화면 전환
                            navigationParameters.Add("SubMenuA", "D-0");
                            _regionManager.RequestNavigate("MenuRegion", nameof(AreaMenu), navigationParameters);
                        }
                        else if (obj.ToString() == "D-1" || obj.ToString() == "D-4")
                        {
                            navigationParameters.Add("Key", "48");
                            _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap1F), navigationParameters);
                        }
                        else if (obj.ToString() == "D-2")
                        {
                            navigationParameters.Add("Key", "38");
                            _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap1F), navigationParameters);
                        }
                        else if (obj.ToString() == "D-3")
                        {
                            navigationParameters.Add("Key", "71");
                            _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap1F), navigationParameters);
                        }
                        else if (obj.ToString() == "D-5")
                        {
                            navigationParameters.Add("Key", "45");
                            _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap1F), navigationParameters);
                        }
                        else if (obj.ToString() == "D-6")
                        {
                            navigationParameters.Add("Key", "37");
                            _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap1F), navigationParameters);
                        }
                        else if (obj.ToString() == "D-7")
                        {
                            navigationParameters.Add("Key", "54");
                            _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap1F), navigationParameters);
                        }
                        else if (obj.ToString() == "D-8")
                        {
                            navigationParameters.Add("Key", "51");
                            _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap1F), navigationParameters);
                        }
                        else if (obj.ToString() == "D-9")
                        {
                            navigationParameters.Add("Key", "58");
                            _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap1F), navigationParameters);
                        }
                        break;
                    case "E"://지방세
                        if (obj.ToString() == "E-0")
                        {
                            navigationParameters.Add("Key", "69");
                            _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap1F), navigationParameters);
                        }
                        else if (obj.ToString() == "E-1" || obj.ToString() == "E-6" || obj.ToString() == "E-7"
                            || obj.ToString() == "E-8")
                        {
                            navigationParameters.Add("Key", "68");
                            _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap1F), navigationParameters);
                        }
                        else if (obj.ToString() == "E-2" || obj.ToString() == "E-3" || obj.ToString() == "E-4"
                            || obj.ToString() == "E-5" || obj.ToString() == "E-9" || obj.ToString() == "E-10")
                        {
                            navigationParameters.Add("Key", "0");
                            _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap3F), navigationParameters);
                        }

                        break;
                    case "F"://사회복지
                        if (obj.ToString() == "F-0" || obj.ToString() == "F-1" || obj.ToString() == "F-2"
                            || obj.ToString() == "F-3")
                        {
                            navigationParameters.Add("Key", "1");
                            _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap3F), navigationParameters);
                        }
                        else if (obj.ToString() == "F-4" || obj.ToString() == "F-5" || obj.ToString() == "F-6" ||
                            obj.ToString() == "F-7" || obj.ToString() == "F-8" || obj.ToString() == "F-9" ||
                            obj.ToString() == "F-10" || obj.ToString() == "F-11" || obj.ToString() == "F-12")
                        {
                            navigationParameters.Add("Key", "0");
                            _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap5F), navigationParameters);
                        }
                        break;
                    case "G"://환경
                        navigationParameters.Add("Key", "0");
                        _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap6F), navigationParameters);
                        break;
                    case "H"://도로교통
                        if (obj.ToString() == "H-0" || obj.ToString() == "H-3"
                            || obj.ToString() == "H-4")
                        {
                            navigationParameters.Add("Key", "65");
                            _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap1F), navigationParameters);
                        }
                        else if (obj.ToString() == "H-1" || obj.ToString() == "H-2")
                        {
                            navigationParameters.Add("Key", "64");
                            _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap1F), navigationParameters);
                        }
                        else if (obj.ToString() == "H-5")
                        {
                            navigationParameters.Add("Key", "66");
                            _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap1F), navigationParameters);
                        }
                        else if (obj.ToString() == "H-6" || obj.ToString() == "H-7" || obj.ToString() == "H-8"
                            || obj.ToString() == "H-9")
                        {
                            navigationParameters.Add("Key", "1");
                            _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap5F), navigationParameters);
                        }
                        break;
                    case "I"://일자리경제
                        navigationParameters.Add("Key", "2");
                        _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap3F), navigationParameters);
                        break;
                    case "J"://식품위생
                        navigationParameters.Add("Key", "1");
                        _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap6F), navigationParameters);
                        break;
                    case "K"://농지전용산지업무
                        if (obj.ToString() == "K-0")
                        {
                            navigationParameters.Add("Key", "2");
                            _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap5F), navigationParameters);
                        }
                        else if (obj.ToString() == "K-1")
                        {
                            //지역화면 전환
                            navigationParameters.Add("SubMenuA", "K-1");
                            _regionManager.RequestNavigate("MenuRegion", nameof(AreaMenu), navigationParameters);
                        }
                        else if (obj.ToString() == "K-2" || obj.ToString() == "K-3")
                        {
                            navigationParameters.Add("Key", "2");
                            _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap6F), navigationParameters);
                        }

                        break;
                    case "L"://개발행위허가
                        if (obj.ToString() == "L-0")
                        {
                            //지역화면 전환
                            navigationParameters.Add("SubMenuA", "L-0");
                            _regionManager.RequestNavigate("MenuRegion", nameof(AreaMenu), navigationParameters);
                        }
                        else if (obj.ToString() == "L-1")
                        {
                            navigationParameters.Add("Key", "3");
                            _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap6F), navigationParameters);
                        }
                        else if (obj.ToString() == "L-2")
                        {
                            navigationParameters.Add("Key", "3");
                            _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap6F), navigationParameters);
                        }
                        break;
                    case "M"://귀농귀촌
                        navigationParameters.Add("Key", "2");
                        _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap5F), navigationParameters);
                        break;
                    case "N"://기타
                        if (obj.ToString() == "N-0" || obj.ToString() == "N-1")
                        {
                            navigationParameters.Add("Key", "1");
                            _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap4F), navigationParameters);
                        }
                        else if (obj.ToString() == "N-2")
                        {

                        }
                        else if (obj.ToString() == "N-3")
                        {
                            navigationParameters.Add("Key", "4");
                            _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap6F), navigationParameters);
                        }
                        break;
                    case "O":
                        if (obj.ToString() == "O-0" || obj.ToString() == "O-1")
                        {
                            navigationParameters.Add("Key", "74");
                            _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap1F), navigationParameters);
                        }
                        else if (obj.ToString() == "O-2" || obj.ToString() == "O-3" || obj.ToString() == "O-4")
                        {
                            navigationParameters.Add("Key", "73");
                            _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap1F), navigationParameters);
                        }
                        else if (obj.ToString() == "O-5" || obj.ToString() == "O-6")
                        {
                            navigationParameters.Add("Key", "68");
                            _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap1F), navigationParameters);
                        }
                        else if (obj.ToString() == "O-7")
                        {
                            navigationParameters.Add("Key", "65");
                            _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap1F), navigationParameters);
                        }
                        else if (obj.ToString() == "O-8" || obj.ToString() == "O-9" || obj.ToString() == "O-10")
                        {
                            _regionManager.RequestNavigate("MenuRegion", nameof(AutomaticDispenser), navigationParameters);
                        }
                        else if (obj.ToString() == "O-11" || obj.ToString() == "O-12" || obj.ToString() == "O-13" || obj.ToString() == "O-14"
                            || obj.ToString() == "O-15" || obj.ToString() == "O-16" || obj.ToString() == "O-17")
                        {
                            navigationParameters.Add("Key", "76");
                            _regionManager.RequestNavigate("MenuRegion", nameof(MenuMap1F), navigationParameters);
                        }
                        break;
                }
                _ea.GetEvent<VideoTimerResetEvent>().Publish(Message);//화면 터치시 Video Timer 리셋 이벤트

            }
            catch(Exception e)
            {
                WriteLog.WriteLogger(e.ToString());
            }
            
        }

        /// <summary>
        /// 메인메뉴에 따라 서브메뉴 바인딩
        /// </summary>
        /// <param name="menuName"></param>
        private void SettingSubMenu(string[] subMenu, string key)
        {
            try
            {
                MenuList.Clear();
                for (int i = 0; i < 20; i++)
                {
                    var menu = new SubMenuModel();
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
        /// 메인메뉴에 서브메뉴 할당
        /// </summary>
        /// <param name="menuName"></param>
        private void ChangedSubMenu(string menuName)
        {
            try
            {
                string[] subMenu;

                switch (menuName)
                {
                    case "0":
                        SettingSubMenu(subMenu = new string[] { "민원서류 접수", "정보공개신청" }, "A");

                        uri = new Uri("pack://application:,,,/Resources\\buttonBlue.png");
                        bitmapImage = new BitmapImage(uri);
                        ButtonBack = bitmapImage;
                        break;
                    case "1":
                        SettingSubMenu(subMenu = new string[] { "건축민원", "가설건축물 축조신고", "옥외광고물 표시 신고", "임대사업자 등록" }, "B");
                        uri = new Uri("pack://application:,,,/Resources\\buttonBlue.png");
                        bitmapImage = new BitmapImage(uri);
                        ButtonBack = bitmapImage;
                        break;
                    case "2":
                        SettingSubMenu(subMenu = new string[] { "여권 발급", "국제운전면허증 발급" }, "C");
                        uri = new Uri("pack://application:,,,/Resources\\buttonBlue.png");
                        bitmapImage = new BitmapImage(uri);
                        ButtonBack = bitmapImage;
                        break;
                    case "3":
                        SettingSubMenu(subMenu = new string[] { "토지분할ㆍ합병ㆍ지목변경\n신청", "부동산 등기 특별조치법",
                        "실거래신고ㆍ검인", "지적측량", "조상땅찾기", "부동산 등기용\n등록번호 부여신청",
                        "도로명주소 신청","개별공시지가 확인","개별주택가격 확인","지적재조사 사업"}, "D");
                        uri = new Uri("pack://application:,,,/Resources\\buttonBlue.png");
                        bitmapImage = new BitmapImage(uri);
                        ButtonBack = bitmapImage;
                        break;
                    case "4":
                        SettingSubMenu(subMenu = new string[] { "취득세(부동산)", "취득세(차량)", "재산세(주택)", "재산세(토지)",
                        "자동차세", "주민세","등록면허세","세목별 과세증명서","지방세 완납증명서","지방세 체납",
                        "세외수입 체납"}, "E");
                        uri = new Uri("pack://application:,,,/Resources\\buttonBlue.png");
                        bitmapImage = new BitmapImage(uri);
                        ButtonBack = bitmapImage;
                        break;
                    case "5":
                        SettingSubMenu(subMenu = new string[] { "국민기초생활수급자 업무", "장애인업무",
                        "기초연금", "지역사회서비스 투자사업\n서비스 신청", "보육료 및 양육수당\n(어린이집)",
                        "아동수당","초등학생 방과후 돌봄\n서비스 신청","한부모가정","청소년증 발급",
                        "아동학대 신고","보육시설 종사자\n경력증명서","전입장려지원금","결혼축하금"}, "F");
                        uri = new Uri("pack://application:,,,/Resources\\buttonGreen.png");
                        bitmapImage = new BitmapImage(uri);
                        ButtonBack = bitmapImage;
                        break;
                    case "6":
                        SettingSubMenu(subMenu = new string[] { "노후경유차 조기폐차", "환경개선부담금",
                        "폐기물재활용시설\n설치신고", "음식물류 폐기물 수수료", "사업장 폐기물 배출자신고",
                        "건설폐기물 처리계획서\n제출","가족분뇨 배출시설허가\n신고",
                        "대기배출시설ㆍ폐수배출\n시설 설치허가ㆍ신고","비산먼지 및 특정공사\n사전신고",
                        "정화조 및 오수처리시설\n설치신고"}, "G");
                        uri = new Uri("pack://application:,,,/Resources\\buttonGreen.png");
                        bitmapImage = new BitmapImage(uri);
                        ButtonBack = bitmapImage;
                        break;
                    case "7":
                        SettingSubMenu(subMenu = new string[] { "차량 등록ㆍ이전ㆍ말소", "건설기계(지게차,굴착기\n등) 등록ㆍ이전ㆍ말소",
                        "건설기계 면허증 발급", "자동차 등록원부 발급", "자동차 임시운행 허가",
                        "운행정지ㆍ차량초과ㆍ\n멸실인정서","도로점용허가","여객자동차 운수사업",
                    "화물자동차 운수사업","건설업 등록신청"}, "H");
                        uri = new Uri("pack://application:,,,/Resources\\buttonGreen.png");
                        bitmapImage = new BitmapImage(uri);
                        ButtonBack = bitmapImage;
                        break;
                    case "8":
                        SettingSubMenu(subMenu = new string[] { "통신ㆍ방문판매업", "전기사업허가(태양광)",
                        "소상공인 지원", "기업투자유치", "공장등록"}, "I");
                        uri = new Uri("pack://application:,,,/Resources\\buttonGreen.png");
                        bitmapImage = new BitmapImage(uri);
                        ButtonBack = bitmapImage;
                        break;
                    case "9":
                        SettingSubMenu(subMenu = new string[] { "식품위생업 (음식점 등)", "공중위생업\n(숙박ㆍ목욕장ㆍ이미용 등)" }, "J");

                        uri = new Uri("pack://application:,,,/Resources\\buttonGreen.png");
                        bitmapImage = new BitmapImage(uri);
                        ButtonBack = bitmapImage;
                        break;
                    case "10":
                        SettingSubMenu(subMenu = new string[] { "농지전용", "산지전용", "입목벌채 허가", "산림관련 불법행위 신고" }, "K");

                        uri = new Uri("pack://application:,,,/Resources\\buttonBrown.png");
                        bitmapImage = new BitmapImage(uri);
                        ButtonBack = bitmapImage;
                        break;
                    case "11":
                        SettingSubMenu(subMenu = new string[] { "개발행위허가", "장기미집행 도시계획시설\n보상", "도시계획도로개설 보상" }, "L");

                        uri = new Uri("pack://application:,,,/Resources\\buttonBrown.png");
                        bitmapImage = new BitmapImage(uri);
                        ButtonBack = bitmapImage;
                        break;
                    case "12":
                        SettingSubMenu(subMenu = new string[] { "귀농귀촌 상담" }, "M");
                        uri = new Uri("pack://application:,,,/Resources\\buttonBrown.png");
                        bitmapImage = new BitmapImage(uri);
                        ButtonBack = bitmapImage;
                        break;
                    case "13":
                        SettingSubMenu(subMenu = new string[] { "주민참여예산", "공무원 불법행위 등\n감사청구", "문화예술 단체지원", "체육ㆍ공원 시설관리" }, "N");
                        uri = new Uri("pack://application:,,,/Resources\\buttonBrown.png");
                        bitmapImage = new BitmapImage(uri);
                        ButtonBack = bitmapImage;
                        break;
                    case "14":
                        SettingSubMenu(subMenu = new string[] { "등ㆍ초본 발급", "인감증명서 발급","지적도ㆍ토지대장 발급",
                            "건축물대장 발급","토지이용계획서확인원\n발급","세목별 과세증명서",
                            "지방세 완납증명서","자동차 등록원부 발급","가족관계증명서류 발급\n(본인)",
                            "부동산 등기부등본","건강보험 자격관련 서류","소득금액 증명",
                            "사업자등록 증명","농지원부","농업경영체 등록 확인서",
                            "초중고등학교 증명\n(졸업ㆍ성적ㆍ생활기록부)","부가가치세 과세표준 증명",
                            "병적증명서"}, "O");
                        uri = new Uri("pack://application:,,,/Resources\\buttonBlue.png");
                        bitmapImage = new BitmapImage(uri);
                        ButtonBack = bitmapImage;
                        break;
                        //case "14":
                        //    SettingSubMenu(subMenu = new string[] { "등ㆍ초본 발급",
                        //"인감증명서 발급","지적도ㆍ토지대장\n           발급","건축물대장 발급","토지이용계획서확인원\n               발급",
                        //"세목별 과세증명서","지방세 완납증명서","자동차 등록원부\n         발급","가족관계증명서류\n      발급(본인)",
                        //"부동산 등기부등본","건강보험 자격관리\n           서류","소득금액 증명","사업자등록 증명",
                        //"농지원부","농업경영체 등록\n        확인서","        초중고등학교\n (졸업ㆍ성적ㆍ생활기\n록부)",
                        //"부가가치세 과세표준\n              증명","병적증명서"}, "O");
                        //    uri = new Uri("pack://application:,,,/Resources\\buttonBlue.png");
                        //    bitmapImage = new BitmapImage(uri);
                        //    ButtonBack = bitmapImage;
                        //    break;
                }

                VideoTiemerReset();
            }
            catch (Exception e)
            {
                WriteLog.WriteLogger(e.ToString());
            }
        }

        private void ReturnMenuView(object obj)
        {
            _regionManager.RequestNavigate("MenuRegion", nameof(MainMenu));
            VideoTiemerReset();
        }

        private void VideoTiemerReset()
        {
            _ea.GetEvent<VideoTimerResetEvent>().Publish(Message);
        }

        private void aaa(NavigationResult obj)
        {
            ;
        }
        /// <summary>
        /// 메인 메뉴에서 넘어오는 파라미터 값 받음
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            navigationService = navigationContext.NavigationService;
            string menuName = navigationContext.Parameters["MenuName"].ToString();
            ChangedSubMenu(menuName);            
        } 
         
        private bool CanGoBack(object commandArg)
        {
            return navigationService.Journal.CanGoBack;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }

        public void GoBack()
        {
            
        }

        public void GoForward()
        {
             
        }

        public void RecordNavigation(IRegionNavigationJournalEntry entry, bool persistInHistory)
        {
            
        }

        public void Clear()
        {
             
        }
    }
}
