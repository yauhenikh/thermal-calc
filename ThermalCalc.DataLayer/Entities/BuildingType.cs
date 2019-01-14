using System.Collections.Generic;

namespace ThermalCalc.DataLayer
{
    public class BuildingType
    {
        public BuildingType()
        {
            EnclosingStructures = new List<EnclosingStructure>();
        }

        public int BuildingTypeId { get; set; }
        public string TypeName { get; set; }        // тип здания
        public double InternalTemp { get; set; }     // расчетная температура внутреннего воздуха

        // навигационные свойства
        public List<EnclosingStructure> EnclosingStructures { get; set; }
    }
}
