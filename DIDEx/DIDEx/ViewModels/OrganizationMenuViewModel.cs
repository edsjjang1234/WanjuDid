using DIDEx.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DIDEx.ViewModels
{
    public class OrganizationMenuViewModel : BindableBase
    {
        IRegionManager _regionManager;
        public DelegateCommand<object> ArchitectureDepartmentCommand { get;set; }
        public DelegateCommand<object> CivilAffairsDivisionCommand { get; set; }
        public OrganizationMenuViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            ArchitectureDepartmentCommand = new DelegateCommand<object>(ArchitectureDepartmentCommand_Click);
            CivilAffairsDivisionCommand = new DelegateCommand<object>(CivilAffairsDivisionCommand_Click);
        }

        private void ArchitectureDepartmentCommand_Click(object obj)
        {
            _regionManager.RequestNavigate("MainWindowRegion", nameof(Construct));
        }

        private void CivilAffairsDivisionCommand_Click(object obj)
        {
            _regionManager.RequestNavigate("MainWindowRegion", nameof(Complaints));
        }
    }
}
