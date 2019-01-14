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
    /// Interaction logic for ViewMaterialWindow.xaml
    /// </summary>
    public partial class ViewMaterialWindow : Window
    {
        ObservableCollection<Material> materials;
        IUnitOfWork context;

        public ViewMaterialWindow()
        {
            InitializeComponent();
            context = new EFUnitOfWork("ThermalCalcDbConnection");
            materials = new ObservableCollection<Material>(context.Materials.GetAll());
        }

        public ViewMaterialWindow(ObservableCollection<Material> materials) : this()
        {
            this.materials = materials;
            viewMaterialDataGrid.DataContext = materials;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var material = viewMaterialDataGrid.SelectedItem as Material;

            if (material != null)
            {
                AddEditMaterialWindow addEditMaterialWindow = new AddEditMaterialWindow(material);
                var result = addEditMaterialWindow.ShowDialog();
                if (result == true)
                {
                    this.DialogResult = true;
                    context.Save();
                    addEditMaterialWindow.Close();
                }
                else
                {
                    viewMaterialDataGrid.DataContext = null;
                    viewMaterialDataGrid.DataContext = materials;
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Material material = viewMaterialDataGrid.SelectedItem as Material;

            if (material != null)
            {
                var result = MessageBox.Show("Вы уверены?", "Удалить материал", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    context.Materials.Delete(material.MaterialID);
                    materials.Remove(material);
                    context.Save();
                }
            }
        }
    }
}
