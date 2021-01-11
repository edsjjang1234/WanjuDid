using DIDEx.Models;
using DIDEx.Views;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace DIDEx.ViewModels
{
	public class MenuMap1FViewModel : BindableBase, INavigationAware
    {
        IRegionManager _regionManager;
        IEventAggregator _ea;
        private IRegionNavigationService navigationService;
        public List<NameCard> UserList { get; set; } = new List<NameCard>();
        public ICommand SelectCommand { get; private set; }
        public ICommand PopupCloseCommand { get; private set; }
        public ObservableCollection<MenuMap1FModel> VisibilityList { get; set; } = new ObservableCollection<MenuMap1FModel>();
        public DelegateCommand<object> RetrunViewCommand { get; private set; }

        private string _messge = "Message";
        public string Message
        {
            get { return _messge; }
            set { SetProperty(ref _messge, value); }
        }

        public MenuMap1FViewModel(IRegionManager regionManager, IEventAggregator ea)
        {
            _ea = ea;
            _regionManager = regionManager;
            RetrunViewCommand = new DelegateCommand<object>(RetrunView);
            List<DepListControl> deptList = OrganizationChartModel.XmlParser();

            var dept = new string[] { "주민", "지적", "인감" };
             
            for (int i = 0; i < deptList.Count; i++)
            {
                var user = new NameCard();
                user.Name = deptList[i].Name;
                user.Team = deptList[i].Team;
                user.Work = deptList[i].Work;
                user.Tel = deptList[i].Tel;

                user.ImagePath = System.IO.Path.GetFullPath($"D:\\images\\{i}.jpg");

                user.DeptIndex = i;
                user.Dept = deptList[i].Dept;

                user.OnClick += User_OnClick;
                UserList.Add(user);
            }

            SelectCommand = new DelegateCommand<string>(x =>
            {
                //_ea.GetEvent<VideoTimerResetEvent>().Publish(Message);

                var n = int.Parse(x);
                foreach (var item in UserList)
                {
                    item.IsSelected = item.DeptIndex == n;
                }
            });

            PopupCloseCommand = new DelegateCommand(() =>
            {
                //_ea.GetEvent<VideoTimerResetEvent>().Publish(Message);

                ShowPopup = Visibility.Collapsed;
                SelectedItem = null;
            });
        }

        private void User_OnClick(object sender, EventArgs e)
        {
            if (sender is NameCard nc)
            {
                SelectedItem = nc;
                ShowPopup = Visibility.Visible;
            }
            //_ea.GetEvent<VideoTimerResetEvent>().Publish(Message);
        }

        public NameCard SelectedItem
        {
            get => _IsSelected;
            set => base.SetProperty(ref _IsSelected, value);
        }
        private NameCard _IsSelected = null;

        public Visibility ShowPopup
        {
            get => _ShowPopup;
            set => base.SetProperty(ref _ShowPopup, value);
        }
        private Visibility _ShowPopup = Visibility.Collapsed;

        private void PositionSet(string key)
        {
            VisibilityList.Clear();
           

            for (int i = 0; i < 82; i++)
            {
                var menu = new MenuMap1FModel();
                if (Convert.ToString(i) == key)
                    menu.ShowVisibility = true;
                else
                    menu.ShowVisibility = false;

                VisibilityList.Add(menu);
            }
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
            PositionSet(key);
        }
    }
}  
 