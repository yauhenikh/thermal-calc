using LiveCharts;
using LiveCharts.Wpf;
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
using ThermalCalc.DataLayer.Interfaces;
using ThermalCalc.DataLayer.Repositories;

namespace ThermalCalc
{
    /// <summary>
    /// Interaction logic for ChartWindow.xaml
    /// </summary>
    public partial class ChartWindow : Window
    {
        IUnitOfWork context;

        public SeriesCollection SeriesCollection { get; set; }
        public List<string> Labels { get; set; }

        public ChartWindow()
        {
            InitializeComponent();
            context = new EFUnitOfWork("ThermalCalcDbConnection");

            Labels = new List<string>();
            List<double> chartValues = new List<double>();
            List<double> chartValues2 = new List<double>();

            var enclosingStructures = context.EnclosingStructures.GetAll();
            foreach(var es in enclosingStructures)
            {
                Labels.Add(es.ESName);
                chartValues.Add(es.RReduced);
                chartValues2.Add(es.RRequired);
            }

            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Rпр., м2*С/Вт",
                    Values = new ChartValues<double>(chartValues)
                }
            };

            SeriesCollection.Add(new ColumnSeries
            {
                Title = "Rтр., м2*С/Вт",
                Values = new ChartValues<double>(chartValues2)
            });

            DataContext = this;
        }
    }
}
