using System.Collections.Generic;

namespace ThermalCalc.DataLayer
{
    public class City
    {
        public City()
        {
            EnclosingStructures = new List<EnclosingStructure>();
        }

        public int CityID { get; set; }
        public string CityName { get; set; }    // название города
        public double OutsideTemp { get; set; }  // расчетная зимняя темература наружного воздуха

        // навигационные свойства
        public List<EnclosingStructure> EnclosingStructures { get; set; }
    }
}
