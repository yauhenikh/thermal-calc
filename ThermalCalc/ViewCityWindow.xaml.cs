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
    /// Interaction logic for ViewCityWindow.xaml
    /// </summary>
    public partial class ViewCityWindow : Window
    {
        ObservableCollection<City> cities;
        IUnitOfWork context;

        public ViewCityWindow()
        {
            InitializeComponent();
            context = new EFUnitOfWork("ThermalCalcDbConnection");
            cities = new ObservableCollection<City>(context.Cities.GetAll());
        }

        public ViewCityWindow(ObservableCollection<City> cities) : this()
        {
            this.cities = cities;
            viewCityDataGrid.DataContext = cities;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var city = viewCityDataGrid.SelectedItem as City;

            if (city != null)
            {
                AddEditCityWindow addEditCityWindow = new AddEditCityWindow(city);
                var result = addEditCityWindow.ShowDialog();
                if (result == true)
                {
                    this.DialogResult = true;
                    context.Save();
                    addEditCityWindow.Close();
                }
                else
                {
                    viewCityDataGrid.DataContext = null;
                    viewCityDataGrid.DataContext = cities;
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            City city = viewCityDataGrid.SelectedItem as City;

            if (city != null)
            {
                var result = MessageBox.Show("Вы уверены?", "Удалить город", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    context.Cities.Delete(city.CityID);
                    cities.Remove(city);
                    context.Save();
                }
            }
        }
    }
}
