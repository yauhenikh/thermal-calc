using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using ThermalCalc.DataLayer.Interfaces;
using ThermalCalc.DataLayer.Repositories;

namespace ThermalCalc
{
    /// <summary>
    /// Interaction logic for ViewBuildingType.xaml
    /// </summary>
    public partial class ViewBuildingTypeWindow : Window
    {
        ObservableCollection<BuildingType> buildingTypes;
        IUnitOfWork context;
        

        public ViewBuildingTypeWindow()
        {
            InitializeComponent();
            context = new EFUnitOfWork("ThermalCalcDbConnection");
            buildingTypes = new ObservableCollection<BuildingType>(context.BuildingTypes.GetAll());
            
        }

        public ViewBuildingTypeWindow(ObservableCollection<BuildingType> buildingTypes) : this()
        {
            this.buildingTypes = buildingTypes;
            viewBuildingTypeDataGrid.DataContext = buildingTypes;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var bType = viewBuildingTypeDataGrid.SelectedItem as BuildingType;

            if (bType != null)
            {
                AddEditBuildingTypeWindow addEditBuildingTypeWindow = new AddEditBuildingTypeWindow(bType);
                var result = addEditBuildingTypeWindow.ShowDialog();
                if (result == true)
                {
                    this.DialogResult = true;
                    context.Save();
                    addEditBuildingTypeWindow.Close();
                }
                else
                {
                    viewBuildingTypeDataGrid.DataContext = null;
                    viewBuildingTypeDataGrid.DataContext = buildingTypes;
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            BuildingType bType = viewBuildingTypeDataGrid.SelectedItem as BuildingType;

            if (bType != null)
            {
                var result = MessageBox.Show("Вы уверены?", "Удалить тип здания", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    context.BuildingTypes.Delete(bType.BuildingTypeId);
                    buildingTypes.Remove(bType);
                    context.Save();
                }
            }
        }
    }
}
