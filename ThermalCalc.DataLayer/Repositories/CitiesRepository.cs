using System.Collections.Generic;
using ThermalCalc.DataLayer.EFContext;
using ThermalCalc.DataLayer.Interfaces;
using System.Data.Entity;
using System;

namespace ThermalCalc.DataLayer.Repositories
{
    class CitiesRepository : IRepository<City>
    {
        ThermalCalcContext context;
        public CitiesRepository(ThermalCalcContext context)
        {
            this.context = context;
        }

        public void Add(City t)
        {
            context.Cities.Add(t);
        }

        public void Delete(int id)
        {
            var city = context.Cities.Find(id);
            context.Cities.Remove(city);
        }

        public void Delete(int id1, int id2)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<City> GetAll()
        {
            return context.Cities.Include(c => c.EnclosingStructures);
        }

        public City GetById(int id)
        {
            return context.Cities.Find(id);
        }

        public void Update(City t)
        {
            context.Entry<City>(t).State = EntityState.Modified;
        }
    }
}
