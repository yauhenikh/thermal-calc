using System.Linq;
using System.Windows;
using ThermalCalc.DataLayer.Interfaces;
using ThermalCalc.DataLayer.Repositories;
using static ThermalCalc.DataLayer.EnclosingStructure;

namespace ThermalCalc
{
    public class CalculateService
    {
        IUnitOfWork dataBase;

        public CalculateService(string name)
        {
            dataBase = new EFUnitOfWork(name);
        }

        public void Calculate()
        {
            var enclosingStructureMaterials = dataBase.EnclosingStructureMaterials.GetAll().ToList();
            var enclosingStructures = dataBase.EnclosingStructures.GetAll().ToList();
            var materials = dataBase.Materials.GetAll().ToList();
            var buildingTypes = dataBase.BuildingTypes.GetAll().ToList();
            var cities = dataBase.Cities.GetAll().ToList();

            foreach (var enclosingStructureMaterial in enclosingStructureMaterials)
            {
                var mode = enclosingStructures.Where(e => e.EnclosingStructureId == enclosingStructureMaterial.EnclosingStructureId).Single().OperatingMode;

                double thermCoeff = 0;
                double heatCoeff = 0;

                if (mode == Mode.A)
                {
                    thermCoeff = materials.Where(m => m.MaterialID == enclosingStructureMaterial.MaterialID).Single().ThermCoeffA;
                    heatCoeff = materials.Where(m => m.MaterialID == enclosingStructureMaterial.MaterialID).Single().HeatCoeffA;
                }
                if (mode == Mode.B)
                {
                    thermCoeff = materials.Where(m => m.MaterialID == enclosingStructureMaterial.MaterialID).Single().ThermCoeffB;
                    heatCoeff = materials.Where(m => m.MaterialID == enclosingStructureMaterial.MaterialID).Single().HeatCoeffB;
                }

                enclosingStructureMaterial.RLayer = enclosingStructureMaterial.LayerThickness / thermCoeff;
                enclosingStructureMaterial.ThermalInertiaLayer = enclosingStructureMaterial.RLayer * heatCoeff;
            }

            foreach (var enclosingStructure in enclosingStructures)
            {
                double internalTemp = buildingTypes.Where(b => b.BuildingTypeId == enclosingStructure.BuildingTypeId).Single().InternalTemp;
                double outsideTemp = cities.Where(c => c.CityID == enclosingStructure.CityID).Single().OutsideTemp;

                enclosingStructure.RRequired = (internalTemp - outsideTemp) / (8.7 * 6);
                enclosingStructure.RReduced = 1.0 / 23.0 + 1.0 / 8.7 +
                    enclosingStructureMaterials.Where(e => e.EnclosingStructureId == enclosingStructure.EnclosingStructureId)
                    .Sum(e => e.RLayer);
                enclosingStructure.ThermalInertia = enclosingStructureMaterials.Where(e => e.EnclosingStructureId == enclosingStructure.EnclosingStructureId)
                    .Sum(e => e.ThermalInertiaLayer);
            }



            dataBase.Save();
        }
    }
}
