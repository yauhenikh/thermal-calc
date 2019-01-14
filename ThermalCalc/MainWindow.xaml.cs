using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using ThermalCalc.DataLayer;
using ThermalCalc.DataLayer.Interfaces;
using ThermalCalc.DataLayer.Repositories;
using static ThermalCalc.DataLayer.EnclosingStructure;

namespace ThermalCalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IUnitOfWork context;

        ObservableCollection<EnclosingStructure> enclosingStructures;
        ObservableCollection<EnclosingStructureMaterial> enclosingStructureMaterials;
        ObservableCollection<Material> materials;
        ObservableCollection<BuildingType> buildingTypes;
        ObservableCollection<City> cities;

        CalculateService calculateService;

        public MainWindow()
        {
            InitializeComponent();

            context = new EFUnitOfWork("ThermalCalcDbConnection");

            calculateService = new CalculateService("ThermalCalcDbConnection");
            calculateService.Calculate();

            enclosingStructures = new ObservableCollection<EnclosingStructure>(context.EnclosingStructures.GetAll());
            buildingTypes = new ObservableCollection<BuildingType>(context.BuildingTypes.GetAll());
            cities = new ObservableCollection<City>(context.Cities.GetAll());
            materials = new ObservableCollection<Material>(context.Materials.GetAll());

            cBoxES.DataContext = enclosingStructures;
        }

        private void addBuildingType(object sender, RoutedEventArgs e)
        {
            var bType = new BuildingType();
            AddEditBuildingTypeWindow addEditBuildingTypeWindow = new AddEditBuildingTypeWindow(bType);
            var result = addEditBuildingTypeWindow.ShowDialog();
            if (result == true)
            {
                context.BuildingTypes.Add(bType);
                buildingTypes.Add(bType);
                context.Save();
                addEditBuildingTypeWindow.Close();
            }
        }

        private void editBuildingType(object sender, RoutedEventArgs e)
        {
            ViewBuildingTypeWindow viewBuildingTypeWindow = new ViewBuildingTypeWindow(buildingTypes);
            var result = viewBuildingTypeWindow.ShowDialog();
            if (result == true)
            {
                context.Save();
                context = new EFUnitOfWork("ThermalCalcDbConnection");

                calculateService = new CalculateService("ThermalCalcDbConnection");
                calculateService.Calculate();

                enclosingStructures = new ObservableCollection<EnclosingStructure>(context.EnclosingStructures.GetAll());
                buildingTypes = new ObservableCollection<BuildingType>(context.BuildingTypes.GetAll());
                cities = new ObservableCollection<City>(context.Cities.GetAll());
                materials = new ObservableCollection<Material>(context.Materials.GetAll());

                cBoxES.DataContext = enclosingStructures;
                cBoxES.SelectedIndex = 0;      
            }
        }

        private void addCity(object sender, RoutedEventArgs e)
        {
            var city = new City();
            AddEditCityWindow addEditCityWindow = new AddEditCityWindow(city);
            var result = addEditCityWindow.ShowDialog();
            if (result == true)
            {
                context.Cities.Add(city);
                cities.Add(city);
                context.Save();
                addEditCityWindow.Close();
            }
        }

        private void editCity(object sender, RoutedEventArgs e)
        {
            ViewCityWindow viewCityWindow = new ViewCityWindow(cities);
            var result = viewCityWindow.ShowDialog();
            if (result == true)
            {
                context.Save();
                context = new EFUnitOfWork("ThermalCalcDbConnection");

                calculateService = new CalculateService("ThermalCalcDbConnection");
                calculateService.Calculate();

                enclosingStructures = new ObservableCollection<EnclosingStructure>(context.EnclosingStructures.GetAll());
                buildingTypes = new ObservableCollection<BuildingType>(context.BuildingTypes.GetAll());
                cities = new ObservableCollection<City>(context.Cities.GetAll());
                materials = new ObservableCollection<Material>(context.Materials.GetAll());

                cBoxES.DataContext = enclosingStructures;
                cBoxES.SelectedIndex = 0;
            }
        }

        private void addMaterial(object sender, RoutedEventArgs e)
        {
            var material = new Material();
            AddEditMaterialWindow addEditMaterialWindow = new AddEditMaterialWindow(material);
            var result = addEditMaterialWindow.ShowDialog();
            if (result == true)
            {
                context.Materials.Add(material);
                materials.Add(material);
                context.Save();
                addEditMaterialWindow.Close();
            }
        }

        private void editMaterial(object sender, RoutedEventArgs e)
        {
            ViewMaterialWindow viewMaterialWindow = new ViewMaterialWindow(materials);
            var result = viewMaterialWindow.ShowDialog();
            if (result == true)
            {
                context.Save();
                context = new EFUnitOfWork("ThermalCalcDbConnection");

                calculateService = new CalculateService("ThermalCalcDbConnection");
                calculateService.Calculate();

                enclosingStructures = new ObservableCollection<EnclosingStructure>(context.EnclosingStructures.GetAll());
                buildingTypes = new ObservableCollection<BuildingType>(context.BuildingTypes.GetAll());
                cities = new ObservableCollection<City>(context.Cities.GetAll());
                materials = new ObservableCollection<Material>(context.Materials.GetAll());

                cBoxES.DataContext = enclosingStructures;
                cBoxES.SelectedIndex = 0;
            }
        }

        private void addES(object sender, RoutedEventArgs e)
        {
            var enclosingStructure = new EnclosingStructure();
            AddEditESWindow addEditESWindow = new AddEditESWindow(enclosingStructure);
            var result = addEditESWindow.ShowDialog();
            if (result == true)
            {
                context.EnclosingStructures.Add(enclosingStructure);
                enclosingStructures.Add(enclosingStructure);
                context.Save();
                context = new EFUnitOfWork("ThermalCalcDbConnection");

                enclosingStructures = new ObservableCollection<EnclosingStructure>(context.EnclosingStructures.GetAll());
                buildingTypes = new ObservableCollection<BuildingType>(context.BuildingTypes.GetAll());
                cities = new ObservableCollection<City>(context.Cities.GetAll());
                materials = new ObservableCollection<Material>(context.Materials.GetAll());

                cBoxES.DataContext = enclosingStructures;
                cBoxES.SelectedIndex = cBoxES.Items.Count - 1;
                addEditESWindow.Close();
            }
        }

        private void editES(object sender, RoutedEventArgs e)
        {
            var enclosingStructure = cBoxES.SelectedItem as EnclosingStructure;
            int index = cBoxES.SelectedIndex;

            if (enclosingStructure != null)
            {
                AddEditESWindow addEditESWindow = new AddEditESWindow(enclosingStructure);
                var result = addEditESWindow.ShowDialog();
                if (result == true)
                {
                    context.Save();
                    context = new EFUnitOfWork("ThermalCalcDbConnection");

                    calculateService = new CalculateService("ThermalCalcDbConnection");
                    calculateService.Calculate();

                    enclosingStructures = new ObservableCollection<EnclosingStructure>(context.EnclosingStructures.GetAll());
                    buildingTypes = new ObservableCollection<BuildingType>(context.BuildingTypes.GetAll());
                    cities = new ObservableCollection<City>(context.Cities.GetAll());
                    materials = new ObservableCollection<Material>(context.Materials.GetAll());

                    cBoxES.DataContext = enclosingStructures;
                    cBoxES.SelectedIndex = index;
                    addEditESWindow.Close();
                }
            }
        }

        private void deleteES(object sender, RoutedEventArgs e)
        {
            EnclosingStructure es = cBoxES.SelectedItem as EnclosingStructure;

            if (es != null)
            {
                var result = MessageBox.Show("Вы уверены?", "Удалить ограждающую конструкцию", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    context.EnclosingStructures.Delete(es.EnclosingStructureId);
                    enclosingStructures.Remove(es);
                    context.Save();
                    cBoxES.SelectedIndex = 0;
                }
            }
        }

        private void saveToXML(object sender, RoutedEventArgs e)
        {
            XDocument doc = new XDocument(new XElement("Root",
                from bt in context.BuildingTypes.GetAll().AsEnumerable()
                select new XElement("BuildingType",
                    new XElement("BuildingTypeId", bt.BuildingTypeId),
                    new XElement("TypeName", bt.TypeName),
                    new XElement("InternalTemp", bt.InternalTemp)),
                from c in context.Cities.GetAll().AsEnumerable()
                select new XElement("City",
                    new XElement("CityID", c.CityID),
                    new XElement("CityName", c.CityName),
                    new XElement("OutsideTemp", c.OutsideTemp)),
                from m in context.Materials.GetAll().AsEnumerable()
                select new XElement("Material",
                    new XElement("MaterialID", m.MaterialID),
                    new XElement("MaterialName", m.MaterialName),
                    new XElement("ThermCoeffA", m.ThermCoeffA),
                    new XElement("ThermCoeffB", m.ThermCoeffB),
                    new XElement("HeatCoeffA", m.HeatCoeffA),
                    new XElement("HeatCoeffB", m.HeatCoeffB)),
                from es in context.EnclosingStructures.GetAll().AsEnumerable()
                select new XElement("EnclosingStructure",
                    new XElement("EnclosingStructureId", es.EnclosingStructureId),
                    new XElement("ESName", es.ESName),
                    new XElement("Year", es.Year),
                    new XElement("OperatingMode", es.OperatingMode),
                    new XElement("RRequired", es.RRequired),
                    new XElement("RReduced", es.RReduced),
                    new XElement("ThermalInertia", es.ThermalInertia),
                    new XElement("BuildingTypeId", es.BuildingTypeId),
                    new XElement("CityID", es.CityID)),
                from esm in context.EnclosingStructureMaterials.GetAll().AsEnumerable()
                select new XElement("EnclosingStructureMaterial",
                    new XElement("EnclosingStructureId", esm.EnclosingStructureId),
                    new XElement("MaterialID", esm.MaterialID),
                    new XElement("LayerThickness", esm.LayerThickness),
                    new XElement("RLayer", esm.RLayer),
                    new XElement("ThermalInertiaLayer", esm.ThermalInertiaLayer))));

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML (*.xml)|*.xml";
            saveFileDialog.Title = "Сохранить в XML";
            if (saveFileDialog.ShowDialog() == true)
            {
                doc.Save(saveFileDialog.FileName);
            }
        }

        //private void openFromXML(object sender, RoutedEventArgs e)
        //{
        //    foreach (var item in context.BuildingTypes.GetAll())
        //    {
        //        context.BuildingTypes.Delete(item.BuildingTypeId);
        //    }
        //    foreach (var item in context.Cities.GetAll())
        //    {
        //        context.Cities.Delete(item.CityID);
        //    }
        //    foreach (var item in context.Materials.GetAll())
        //    {
        //        context.Materials.Delete(item.MaterialID);
        //    }
        //    foreach (var item in context.EnclosingStructures.GetAll())
        //    {
        //        context.EnclosingStructures.Delete(item.EnclosingStructureId);
        //    }
        //    foreach (var item in context.EnclosingStructureMaterials.GetAll())
        //    {
        //        context.EnclosingStructureMaterials.Delete(item.EnclosingStructureId, item.MaterialID);
        //    }

        //    string fileName = null;
        //    OpenFileDialog openFileDialog = new OpenFileDialog();
        //    openFileDialog.Filter = "XML (*.xml)|*.xml";
        //    openFileDialog.Title = "Открыть XML";

        //    if (openFileDialog.ShowDialog() == true)
        //    {
        //        fileName = openFileDialog.FileName;
        //    }

        //    XDocument doc = XDocument.Load(fileName);

        //    context = new EFUnitOfWork("ThermalCalcDbConnection");

        //    var bTypes = from bt in doc.Descendants("BuildingType")
        //                        select new BuildingType()
        //                        {
        //                            TypeName = bt.Element("TypeName").Value,
        //                            InternalTemp = double.Parse(bt.Element("InternalTemp").Value)
        //                        };
        //    foreach(var bt in bTypes)
        //    {
        //        context.BuildingTypes.Add(bt);
        //    }
        //    context.Save();

        //    var cs = from c in doc.Descendants("City")
        //                 select new City()
        //                 {
        //                     CityName = c.Element("CityName").Value,
        //                     OutsideTemp = double.Parse(c.Element("OutsideTemp").Value)
        //                 };
        //    foreach (var c in cs)
        //    {
        //        context.Cities.Add(c);
        //    }
        //    context.Save();

        //    var ms = from m in doc.Descendants("Material")
        //                    select new Material()
        //                    {
        //                        MaterialName = m.Element("MaterialName").Value,
        //                        ThermCoeffA = double.Parse(m.Element("ThermCoeffA").Value),
        //                        ThermCoeffB = double.Parse(m.Element("ThermCoeffB").Value),
        //                        HeatCoeffA = double.Parse(m.Element("HeatCoeffA").Value),
        //                        HeatCoeffB = double.Parse(m.Element("HeatCoeffB").Value)
        //                    };
        //    foreach (var m in ms)
        //    {
        //        context.Materials.Add(m);
        //    }
        //    context.Save();

        //    var eStrucs = from es in doc.Descendants("EnclosingStructure")
        //                              select new EnclosingStructure()
        //                              {
        //                                  ESName = es.Element("ESName").Value,
        //                                  Year = int.Parse(es.Element("Year").Value),
        //                                  OperatingMode = es.Element("OperatingMode").Value == "A" ? Mode.A : Mode.B,
        //                                  RRequired = double.Parse(es.Element("RRequired").Value),
        //                                  RReduced = double.Parse(es.Element("RReduced").Value),
        //                                  ThermalInertia = double.Parse(es.Element("ThermalInertia").Value),
        //                                  BuildingTypeId = int.Parse(es.Element("BuildingTypeId").Value),
        //                                  CityID = int.Parse(es.Element("CityID").Value)
        //                              };
        //    foreach (var es in eStrucs)
        //    {
        //        context.EnclosingStructures.Add(es);
        //    }
        //    context.Save();

        //    var enclosingStructureMaterials = from esm in doc.Descendants("EnclosingStructureMaterial")
        //                                      select new EnclosingStructureMaterial()
        //                                      {
        //                                          EnclosingStructureId = int.Parse(esm.Element("EnclosingStructureId").Value),
        //                                          MaterialID = int.Parse(esm.Element("MaterialID").Value),
        //                                          LayerThickness = double.Parse(esm.Element("LayerThickness").Value),
        //                                          RLayer = double.Parse(esm.Element("RLayer").Value),
        //                                          ThermalInertiaLayer = double.Parse(esm.Element("ThermalInertiaLayer").Value)
        //                                      };

        //    foreach (var item in context.EnclosingStructureMaterials.GetAll())
        //    {
        //        context.EnclosingStructureMaterials.Delete(item.EnclosingStructureId, item.MaterialID);
        //    }
        //    foreach (var esm in enclosingStructureMaterials)
        //    {
        //        context.EnclosingStructureMaterials.Add(esm);
        //    }

        //    context.Save();

        //    enclosingStructures = new ObservableCollection<EnclosingStructure>(context.EnclosingStructures.GetAll());
        //    buildingTypes = new ObservableCollection<BuildingType>(context.BuildingTypes.GetAll());
        //    cities = new ObservableCollection<City>(context.Cities.GetAll());
        //    materials = new ObservableCollection<Material>(context.Materials.GetAll());
        //}

        private void addChart(object sender, RoutedEventArgs e)
        {
            ChartWindow chart = new ChartWindow();
            if (chart.ShowDialog() == true)
            {

            }
        }

        private void addLayer(object sender, RoutedEventArgs e)
        {
            EnclosingStructure es = cBoxES.SelectedItem as EnclosingStructure;
            int index = cBoxES.SelectedIndex;
            var esm = new EnclosingStructureMaterial { EnclosingStructure = es };
            AddEditESMaterialWindow addEditESMaterialWindow = new AddEditESMaterialWindow();
            var result = addEditESMaterialWindow.ShowDialog();
            if (result == true)
            {
                esm.MaterialID = addEditESMaterialWindow.AddMaterialID;
                esm.LayerThickness = addEditESMaterialWindow.AddLayerThickness;
                context.EnclosingStructureMaterials.Add(esm);
                es.EnclosingStructureMaterials.Add(esm);
                context.Save();
                context = new EFUnitOfWork("ThermalCalcDbConnection");

                calculateService = new CalculateService("ThermalCalcDbConnection");
                calculateService.Calculate();

                enclosingStructures = new ObservableCollection<EnclosingStructure>(context.EnclosingStructures.GetAll());
                buildingTypes = new ObservableCollection<BuildingType>(context.BuildingTypes.GetAll());
                cities = new ObservableCollection<City>(context.Cities.GetAll());
                materials = new ObservableCollection<Material>(context.Materials.GetAll());

                cBoxES.DataContext = enclosingStructures;
                cBoxES.SelectedIndex = index;
                addEditESMaterialWindow.Close();
            }
        }

        private void editLayer(object sender, RoutedEventArgs e)
        {
            EnclosingStructureMaterial esm = esmDataGrid.SelectedItem as EnclosingStructureMaterial;
            EnclosingStructure es = cBoxES.SelectedItem as EnclosingStructure;
            int index = cBoxES.SelectedIndex;

            if (esm != null)
            {
                AddEditESMaterialWindow addEditESMaterialWindow = new AddEditESMaterialWindow();
                var result = addEditESMaterialWindow.ShowDialog();

                if (result == true)
                {
                    esm.MaterialID = addEditESMaterialWindow.AddMaterialID;
                    esm.LayerThickness = addEditESMaterialWindow.AddLayerThickness;
                    context.Save();
                    context = new EFUnitOfWork("ThermalCalcDbConnection");

                    calculateService = new CalculateService("ThermalCalcDbConnection");
                    calculateService.Calculate();

                    enclosingStructures = new ObservableCollection<EnclosingStructure>(context.EnclosingStructures.GetAll());
                    buildingTypes = new ObservableCollection<BuildingType>(context.BuildingTypes.GetAll());
                    cities = new ObservableCollection<City>(context.Cities.GetAll());
                    materials = new ObservableCollection<Material>(context.Materials.GetAll());

                    cBoxES.DataContext = enclosingStructures;
                    cBoxES.SelectedIndex = index;
                    addEditESMaterialWindow.Close();
                }
            }
        }

        private void deleteLayer(object sender, RoutedEventArgs e)
        {
            EnclosingStructureMaterial esm = esmDataGrid.SelectedItem as EnclosingStructureMaterial;
            EnclosingStructure es = cBoxES.SelectedItem as EnclosingStructure;
            int index = cBoxES.SelectedIndex;

            if (esm != null)
            {
                var result = MessageBox.Show("Вы уверены?", "Удалить слой", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    context.EnclosingStructureMaterials.Delete(esm.EnclosingStructureId, esm.MaterialID);
                    es.EnclosingStructureMaterials.Remove(esm);
                    context.Save();
                    context = new EFUnitOfWork("ThermalCalcDbConnection");

                    calculateService = new CalculateService("ThermalCalcDbConnection");
                    calculateService.Calculate();

                    enclosingStructures = new ObservableCollection<EnclosingStructure>(context.EnclosingStructures.GetAll());
                    buildingTypes = new ObservableCollection<BuildingType>(context.BuildingTypes.GetAll());
                    cities = new ObservableCollection<City>(context.Cities.GetAll());
                    materials = new ObservableCollection<Material>(context.Materials.GetAll());

                    cBoxES.DataContext = enclosingStructures;
                    cBoxES.SelectedIndex = index;
                }
            }
        }
    }
}
