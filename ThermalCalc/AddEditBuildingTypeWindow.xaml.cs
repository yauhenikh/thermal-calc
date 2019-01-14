using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ThermalCalc.DataLayer;

namespace ThermalCalc
{
    /// <summary>
    /// Interaction logic for AddEditBuildingType.xaml
    /// </summary>
    public partial class AddEditBuildingTypeWindow : Window
    {
        BuildingType buildingType;

        public AddEditBuildingTypeWindow()
        {
            InitializeComponent();
        }

        public AddEditBuildingTypeWindow(BuildingType buildingType) : this()
        {
            this.buildingType = buildingType;
            addEditBuildingTypeGrid.DataContext = buildingType;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
