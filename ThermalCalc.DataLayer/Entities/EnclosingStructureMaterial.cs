using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThermalCalc.DataLayer
{
    public class EnclosingStructureMaterial
    {
        public double LayerThickness { get; set; }        // толщина слоя
        public double RLayer { get; set; }                // сопротивление теплопередаче слоя
        public double ThermalInertiaLayer { get; set; }   // тепловая инерция слоя

        // навигационные свойства
        [Key, Column(Order = 0)]
        public int EnclosingStructureId { get; set; }
        [Key, Column(Order = 1)]
        public int MaterialID { get; set; }

        public EnclosingStructure EnclosingStructure { get; set; }
        public Material Material { get; set; }
    }
}
