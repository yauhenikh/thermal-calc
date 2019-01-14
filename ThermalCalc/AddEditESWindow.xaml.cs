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
    /// Interaction logic for AddEditESWindow.xaml
    /// </summary>
    public partial class AddEditESWindow : Window
    {
        IUnitOfWork context;
        ObservableCollection<BuildingType> buildingTypes;
        ObservableCollection<City> cities;
        EnclosingStructure enclosingStructure;

        public AddEditESWindow()
        {
            InitializeComponent();
            context = new EFUnitOfWork("ThermalCalcDbConnection");
            buildingTypes = new ObservableCollection<BuildingType>(context.BuildingTypes.GetAll());
            cities = new ObservableCollection<City>(context.Cities.GetAll());
            cBoxBT.DataContext = buildingTypes;
            cBoxCity.DataContext = cities;
        }

        public AddEditESWindow(EnclosingStructure enclosingStructure) : this()
        {
            this.enclosingStructure = enclosingStructure;
            addEditESGrid.DataContext = enclosingStructure;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            enclosingStructure.CityID = (cBoxCity.SelectedItem as City).CityID;
            enclosingStructure.BuildingTypeId = (cBoxBT.SelectedItem as BuildingType).BuildingTypeId;
            if (cBoxMode.SelectedIndex == 0)
                enclosingStructure.OperatingMode = EnclosingStructure.Mode.A;
            else if (cBoxMode.SelectedIndex == 1)
                enclosingStructure.OperatingMode = EnclosingStructure.Mode.B;
            else
                enclosingStructure.OperatingMode = EnclosingStructure.Mode.A;

            double internalTemp = buildingTypes.Where(b => b.BuildingTypeId == enclosingStructure.BuildingTypeId).Single().InternalTemp;
            double outsideTemp = cities.Where(c => c.CityID == enclosingStructure.CityID).Single().OutsideTemp;

            enclosingStructure.RRequired = (internalTemp - outsideTemp) / (8.7 * 6);
            enclosingStructure.RReduced = 0;
            enclosingStructure.ThermalInertia = 0;
            this.DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
