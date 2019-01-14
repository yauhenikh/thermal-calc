using System;
using ThermalCalc.DataLayer.EFContext;
using ThermalCalc.DataLayer.Interfaces;

namespace ThermalCalc.DataLayer.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        ThermalCalcContext context;
        EnclosingStructuresRepository enclosingStructuresRepository;
        MaterialsRepository materialsRepository;
        EnclosingStructureMaterialsRepository enclosingStructureMaterialsRepository;
        BuildingTypesRepository buildingTypesRepository;
        CitiesRepository citiesRepository;

        public EFUnitOfWork(string name)
        {
            context = new ThermalCalcContext(name);
        }

        public IRepository<EnclosingStructure> EnclosingStructures
        {
            get
            {
                if (enclosingStructuresRepository == null)
                    enclosingStructuresRepository = new EnclosingStructuresRepository(context);
                return enclosingStructuresRepository;
            }
        }

        public IRepository<Material> Materials
        {
            get
            {
                if (materialsRepository == null)
                    materialsRepository = new MaterialsRepository(context);
                return materialsRepository;
            }
        }

        public IRepository<EnclosingStructureMaterial> EnclosingStructureMaterials
        {
            get
            {
                if (enclosingStructureMaterialsRepository == null)
                    enclosingStructureMaterialsRepository = new EnclosingStructureMaterialsRepository(context);
                return enclosingStructureMaterialsRepository;
            }
        }

        public IRepository<BuildingType> BuildingTypes
        {
            get
            {
                if (buildingTypesRepository == null)
                    buildingTypesRepository = new BuildingTypesRepository(context);
                return buildingTypesRepository;
            }
        }

        public IRepository<City> Cities
        {
            get
            {
                if (citiesRepository == null)
                    citiesRepository = new CitiesRepository(context);
                return citiesRepository;
            }
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
