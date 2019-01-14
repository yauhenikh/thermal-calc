using System.Collections.Generic;
using ThermalCalc.DataLayer.EFContext;
using ThermalCalc.DataLayer.Interfaces;
using System.Data.Entity;
using System;

namespace ThermalCalc.DataLayer.Repositories
{
    class EnclosingStructuresRepository : IRepository<EnclosingStructure>
    {
        ThermalCalcContext context;
        public EnclosingStructuresRepository(ThermalCalcContext context)
        {
            this.context = context;
        }

        public void Add(EnclosingStructure t)
        {
            context.EnclosingStructures.Add(t);
        }

        public void Delete(int id)
        {
            var enclosingStructure = context.EnclosingStructures.Find(id);
            context.EnclosingStructures.Remove(enclosingStructure);
        }

        public void Delete(int id1, int id2)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EnclosingStructure> GetAll()
        {
            return context.EnclosingStructures.Include(es => es.EnclosingStructureMaterials);
        }

        public EnclosingStructure GetById(int id)
        {
            return context.EnclosingStructures.Find(id);
        }

        public void Update(EnclosingStructure t)
        {
            context.Entry<EnclosingStructure>(t).State = EntityState.Modified;
        }
    }
}
