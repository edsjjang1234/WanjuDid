using System;
using BlankApp1.Views;
using Module1.Views;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;

namespace BlankApp1.ViewModels
{
    public class MainWindowViewModel : BindableBase         
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        IContainerExtension _container;
        IRegionManager _regionManager;
        IRegion _region;

        public DelegateCommand<object> LoadedCommand { get; private set; }

        PrismUserControl1 _pohtoView;
        ViewA _viewA;

        public MainWindowViewModel(IContainerExtension container, IRegionManager regionManager)
        {
            LoadedCommand = new DelegateCommand<object>(MainWindow_Loaded);
            _container = container;
            _regionManager = regionManager;

        }

        private void MainWindow_Loaded(object obj)
        {
            _pohtoView = _container.Resolve<PrismUserControl1>();
            _viewA = _container.Resolve<ViewA>();

            _region = _regionManager.Regions["ContentRegion"];

            _region.Add(_pohtoView);
            _region.Add(_viewA);

            //_region.Activate(_pohtoView);
            _regionManager.RequestNavigate(_region.Name,
                        _viewA.Name, NavigationCompleted);
        }

        private void NavigationCompleted(NavigationResult obj)
        {
            ;
        }
    }
}
