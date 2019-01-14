using System.Collections.Generic;

namespace ThermalCalc.DataLayer.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T t);
        void Update(T t);
        void Delete(int id);
        void Delete(int id1, int id2);
    }
}
