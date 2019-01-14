using System.Collections.Generic;
using ThermalCalc.DataLayer.EFContext;
using ThermalCalc.DataLayer.Interfaces;
using System.Data.Entity;
using System;

namespace ThermalCalc.DataLayer.Repositories
{
    class BuildingTypesRepository : IRepository<BuildingType>
    {
        ThermalCalcContext context;
        public BuildingTypesRepository(ThermalCalcContext context)
        {
            this.context = context;
        }

        public void Add(BuildingType t)
        {
            context.BuildingTypes.Add(t);
        }

        public void Delete(int id)
        {
            var buildingType = context.BuildingTypes.Find(id);
            context.BuildingTypes.Remove(buildingType);
        }

        public void Delete(int id1, int id2)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BuildingType> GetAll()
        {
            return context.BuildingTypes.Include(bt => bt.EnclosingStructures);
        }

        public BuildingType GetById(int id)
        {
            return context.BuildingTypes.Find(id);
        }

        public void Update(BuildingType t)
        {
            context.Entry<BuildingType>(t).State = EntityState.Modified;
        }
    }
}
