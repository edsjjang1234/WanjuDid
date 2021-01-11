using DIDEx.ViewModels;
using DIDEx.Views;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DIDEx
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //containerRegistry.RegisterForNavigation(typeof(MainWindow), "MainWindow");

            containerRegistry.RegisterForNavigation<MainWindow>();

            containerRegistry.RegisterForNavigation<MenuFrame>();
            containerRegistry.RegisterForNavigation<MainMenu>();
            containerRegistry.RegisterForNavigation<SubMenu>();

            containerRegistry.RegisterForNavigation<OrganizationChart>();
            containerRegistry.RegisterForNavigation<OrganizationMenu>();
            containerRegistry.RegisterForNavigation<Construct>();
            containerRegistry.RegisterForNavigation<Complaints>();
            containerRegistry.RegisterForNavigation<BuildingInformation>();
            containerRegistry.RegisterForNavigation<Views.PhotoGalleryView>();

            containerRegistry.RegisterForNavigation<Views.Videos>();
            containerRegistry.RegisterForNavigation<Views.AreaMenu>();
            containerRegistry.RegisterForNavigation<AutomaticDispenser>();
            containerRegistry.RegisterForNavigation<MenuMap1F>();
            containerRegistry.RegisterForNavigation<MenuMap3F>();
            containerRegistry.RegisterForNavigation<MenuMap4F>();
            containerRegistry.RegisterForNavigation<MenuMap5F>();
            containerRegistry.RegisterForNavigation<MenuMap6F>();
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            // type / type
            //ViewModelLocationProvider.Register(typeof(MainWindow).ToString(), typeof(CustomViewModel));

            // type / factory
            //ViewModelLocationProvider.Register(typeof(MainWindow).ToString(), () => Container.Resolve<CustomViewModel>());

            // generic factory
            //ViewModelLocationProvider.Register<MainWindow>(() => Container.Resolve<CustomViewModel>());

            // generic type
            //ViewModelLocationProvider.Register<PhotoGalleryView, PhotoGalleryViewModel>();

            
        }

    }
}
