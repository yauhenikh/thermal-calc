using System.Collections.Generic;

namespace ThermalCalc.DataLayer
{
    public class EnclosingStructure
    {
        public enum Mode
        {
            A,
            B
        }

        public EnclosingStructure()
        {
            EnclosingStructureMaterials = new List<EnclosingStructureMaterial>();
        }

        public int EnclosingStructureId { get; set; }
        public string ESName { get; set; }              // наименование ограждающей конструкции
        public int Year { get; set; }                   // год постройки
        public Mode OperatingMode { get; set; }         // режим эксплуатации
        public double RRequired { get; set; }            // требуемое сопротивление теплопередаче
        public double RReduced { get; set; }             // приведенное сопротивление теплопередаче
        public double ThermalInertia { get; set; }       // тепловая инерция

        // навигационные свойства
        public int CityID { get; set; }
        public City City { get; set; }

        public int BuildingTypeId { get; set; }
        public BuildingType BuildingType { get; set; }

        public List<EnclosingStructureMaterial> EnclosingStructureMaterials { get; set; }
    }
}
