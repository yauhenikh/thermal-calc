using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;

namespace ThermalCalc.DataLayer.EFContext
{
    class ThermalCalcInitializer : CreateDatabaseIfNotExists<ThermalCalcContext>
    {
        protected override void Seed(ThermalCalcContext context)
        {
            var city1 = new City { CityName = "Витебск", OutsideTemp = -25 };
            var city2 = new City { CityName = "Могилев", OutsideTemp = -25 };
            var city3 = new City { CityName = "Гомель", OutsideTemp = -24 };
            var city4 = new City { CityName = "Брест", OutsideTemp = -21 };
            var city5 = new City { CityName = "Гродно", OutsideTemp = -22 };
            var city6 = new City { CityName = "Минск", OutsideTemp = -24 };
            context.Cities.AddRange(new City[] { city1, city2, city3, city4, city5, city6 });

            var buildingType1 = new BuildingType { TypeName = "Жилые здания", InternalTemp = 18 };
            var buildingType2 = new BuildingType { TypeName = "Общественные здания", InternalTemp = 18 };
            var buildingType3 = new BuildingType { TypeName = "Здания дошкольных учреждений", InternalTemp = 21 };
            context.BuildingTypes.AddRange(new BuildingType[] { buildingType1, buildingType2, buildingType3 });

            var material1 = new Material { MaterialName = "Цементно-песчаный раствор", ThermCoeffA = 0.76, ThermCoeffB = 0.93, HeatCoeffA = 9.6, HeatCoeffB = 11.09 };
            var material2 = new Material { MaterialName = "Железобетон", ThermCoeffA = 1.92, ThermCoeffB = 2.04, HeatCoeffA = 17.98, HeatCoeffB = 19.7 };
            var material3 = new Material { MaterialName = "Плиты из минваты 35", ThermCoeffA = 0.0405, ThermCoeffB = 0.0414, HeatCoeffA = 0.297, HeatCoeffB = 0.304 };
            var material4 = new Material { MaterialName = "Плиты из минваты 105", ThermCoeffA = 0.0417, ThermCoeffB = 0.0426, HeatCoeffA = 0.522, HeatCoeffB = 0.533 };
            var material5 = new Material { MaterialName = "Кирпич керамический 1400", ThermCoeffA = 0.63, ThermCoeffB = 0.78, HeatCoeffA = 7.91, HeatCoeffB = 8.48 };
            context.Materials.AddRange(new Material[] { material1, material2, material3, material4, material5 });

            var enclosingStructure1 = new EnclosingStructure
            {
                ESName = "Восточная стена стоматологической поликлиники №3",
                Year = 1994,
                OperatingMode = EnclosingStructure.Mode.B,
                City = city1,
                BuildingType = buildingType2
            };
            var enclosingStructure2 = new EnclosingStructure
            {
                ESName = "Северная стена дома по адресу Калиновского, 9",
                Year = 2011,
                OperatingMode = EnclosingStructure.Mode.A,
                City = city3,
                BuildingType = buildingType1
            };
            context.EnclosingStructures.AddRange(new EnclosingStructure[] { enclosingStructure1, enclosingStructure2 });

            var enclosingStructureMaterial1 = new EnclosingStructureMaterial
            {
                EnclosingStructure = enclosingStructure1,
                Material = material1,
                LayerThickness = 0.025
            };
            var enclosingStructureMaterial2 = new EnclosingStructureMaterial
            {
                EnclosingStructure = enclosingStructure1,
                Material = material5,
                LayerThickness = 0.51
            };
            var enclosingStructureMaterial3 = new EnclosingStructureMaterial
            {
                EnclosingStructure = enclosingStructure1,
                Material = material4,
                LayerThickness = 0.1
            };
            var enclosingStructureMaterial4 = new EnclosingStructureMaterial
            {
                EnclosingStructure = enclosingStructure2,
                Material = material1,
                LayerThickness = 0.025
            };
            var enclosingStructureMaterial5 = new EnclosingStructureMaterial
            {
                EnclosingStructure = enclosingStructure2,
                Material = material2,
                LayerThickness = 0.16
            };
            var enclosingStructureMaterial6 = new EnclosingStructureMaterial
            {
                EnclosingStructure = enclosingStructure2,
                Material = material3,
                LayerThickness = 0.1
            };
            context.EnclosingStructureMaterials.AddRange(new EnclosingStructureMaterial[] { enclosingStructureMaterial1,
            enclosingStructureMaterial2, enclosingStructureMaterial3, enclosingStructureMaterial4, enclosingStructureMaterial5, enclosingStructureMaterial6});

            context.SaveChanges();
        }
    }
}