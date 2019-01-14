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
    /// Interaction logic for AddEditMaterialWindow.xaml
    /// </summary>
    public partial class AddEditMaterialWindow : Window
    {
        Material material;

        public AddEditMaterialWindow()
        {
            InitializeComponent();
        }

        public AddEditMaterialWindow(Material material) : this()
        {
            this.material = material;
            addEditMaterialGrid.DataContext = material;
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
