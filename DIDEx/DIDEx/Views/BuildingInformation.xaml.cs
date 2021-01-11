using System.Windows.Controls;

namespace DIDEx.Views
{
    /// <summary>
    /// Interaction logic for BuildingInformation
    /// </summary>
    public partial class BuildingInformation : UserControl
    {
        public BuildingInformation()
        {
            InitializeComponent();
            upStairsRadio.IsChecked = true;
        }
    }
}
