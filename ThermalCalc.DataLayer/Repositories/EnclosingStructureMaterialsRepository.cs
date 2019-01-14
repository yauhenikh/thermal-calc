using System.Collections.Generic;
using ThermalCalc.DataLayer.EFContext;
using ThermalCalc.DataLayer.Interfaces;
using System.Data.Entity;
using System.Linq;

namespace ThermalCalc.DataLayer.Repositories
{
    class EnclosingStructureMaterialsRepository : IRepository<EnclosingStructureMaterial>
    {
        ThermalCalcContext context;
        public EnclosingStructureMaterialsRepository(ThermalCalcContext context)
        {
            this.context = context;
        }

        public void Add(EnclosingStructureMaterial t)
        {
            context.EnclosingStructureMaterials.Add(t);
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int esId, int matId)
        {
            var enclosingStructureMaterial = context.EnclosingStructureMaterials.Find(esId, matId);
            context.EnclosingStructureMaterials.Remove(enclosingStructureMaterial);
        }

        public IEnumerable<EnclosingStructureMaterial> GetAll()
        {
            return context.EnclosingStructureMaterials;
        }

        public EnclosingStructureMaterial GetById(int esId, int matId)
        {
            return context.EnclosingStructureMaterials.Find(esId, matId);
        }

        public void Update(EnclosingStructureMaterial t)
        {
            context.Entry<EnclosingStructureMaterial>(t).State = EntityState.Modified;
        }

        EnclosingStructureMaterial IRepository<EnclosingStructureMaterial>.GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
