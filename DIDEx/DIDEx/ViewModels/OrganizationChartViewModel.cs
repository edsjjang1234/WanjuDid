using DIDEx.Models;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DIDEx.ViewModels
{
	public class OrganizationChartViewModel : BindableBase
	{
        //IEventAggregator _ea;
        public List<NameCard> UserList { get; set; } = new List<NameCard>();
        public ICommand SelectCommand { get; private set; }
        public ICommand PopupCloseCommand { get; private set; }
        public ObservableCollection<OrganizationChartModel> VisibilityList { get; set; } = new ObservableCollection<OrganizationChartModel>();
        List<DepListControl> deptList;

        public OrganizationChartViewModel()
        { 
            //_ea = ea;
            deptList = OrganizationChartModel.XmlParser();
 
            var dept = new string[] { "주민", "지적", "인감" };
            var deptIndex = 0;

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

            SetPosition();
        }

        private void SetPosition()
        {
            VisibilityList.Clear();


            for (int i = 0; i < deptList.Count;i++)
            {
                var menu = new OrganizationChartModel();

                menu.ShowVisibility = Convert.ToBoolean(deptList[i].Visibility);


                VisibilityList.Add(menu);
            }
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
         

        //private void GetInformatonImage(string imageName)
        //{
        //    uri = organizationChartModel.GetResourceUri(imageName);
        //    bitmapImage = new BitmapImage(uri);
        //    CurrentImagePath = bitmapImage;
        //}
    }
}
