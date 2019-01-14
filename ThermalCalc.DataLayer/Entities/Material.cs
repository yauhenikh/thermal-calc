using System.Collections.Generic;

namespace ThermalCalc.DataLayer
{
    public class Material
    {
        public Material()
        {
            //EnclosingStructureMaterials = new List<EnclosingStructureMaterial>();
        }

        public int MaterialID { get; set; }
        public string MaterialName { get; set; }   // наименование материала
        public double ThermCoeffA { get; set; }     // коэффициент теплопроводности при режиме эксплуатации A
        public double ThermCoeffB { get; set; }     // коэффициент теплопроводности при режиме эксплуатации B
        public double HeatCoeffA { get; set; }      // коэффициент теплоусвоения при режиме эксплуатации A
        public double HeatCoeffB { get; set; }      // коэффициент теплоусвоения при режиме эксплуатации B 

        // навигационные свойства
        //public List<EnclosingStructureMaterial> EnclosingStructureMaterials { get; set; }
    }
}
