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
    /// Interaction logic for AddEditESMaterialWindow.xaml
    /// </summary>
    public partial class AddEditESMaterialWindow : Window
    {
        IUnitOfWork context;
        ObservableCollection<Material> materials;

        public AddEditESMaterialWindow()
        {
            InitializeComponent();
            context = new EFUnitOfWork("ThermalCalcDbConnection");
            materials = new ObservableCollection<Material>(context.Materials.GetAll());
            cBoxESM.DataContext = materials;
        }

        public int AddMaterialID { get { return (cBoxESM.SelectedItem as Material).MaterialID; } }
        public double AddLayerThickness { get { return double.Parse(tBoxThickness.Text); } }

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
