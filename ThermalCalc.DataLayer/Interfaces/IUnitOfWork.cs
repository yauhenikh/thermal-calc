using System;

namespace ThermalCalc.DataLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<EnclosingStructure> EnclosingStructures { get; }
        IRepository<Material> Materials { get; }
        IRepository<EnclosingStructureMaterial> EnclosingStructureMaterials { get; }
        IRepository<BuildingType> BuildingTypes { get; }
        IRepository<City> Cities { get; }
        void Save();
    }
}
