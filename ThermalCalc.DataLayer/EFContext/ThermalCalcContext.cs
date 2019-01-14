using System.Data.Entity;

namespace ThermalCalc.DataLayer.EFContext
{
    public class ThermalCalcContext : DbContext
    {
        public ThermalCalcContext(string name) : base(name)
        {
            Database.SetInitializer(new ThermalCalcInitializer());
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<BuildingType> BuildingTypes { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<EnclosingStructure> EnclosingStructures { get; set; }
        public DbSet<EnclosingStructureMaterial> EnclosingStructureMaterials { get; set; }
    }
}
