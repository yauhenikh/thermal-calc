using System.Collections.Generic;
using ThermalCalc.DataLayer.EFContext;
using ThermalCalc.DataLayer.Interfaces;
using System.Data.Entity;
using System;

namespace ThermalCalc.DataLayer.Repositories
{
    class MaterialsRepository : IRepository<Material>
    {
        ThermalCalcContext context;
        public MaterialsRepository(ThermalCalcContext context)
        {
            this.context = context;
        }

        public void Add(Material t)
        {
            context.Materials.Add(t);
        }

        public void Delete(int id)
        {
            var material = context.Materials.Find(id);
            context.Materials.Remove(material);
        }

        public void Delete(int id1, int id2)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Material> GetAll()
        {
            return context.Materials
                //.Include(m => m.EnclosingStructureMaterials)
                ;
        }

        public Material GetById(int id)
        {
            return context.Materials.Find(id);
        }

        public void Update(Material t)
        {
            context.Entry<Material>(t).State = EntityState.Modified;
        }
    }
}
