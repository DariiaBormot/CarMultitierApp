using DataAccessLayerDapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerDapper.Interfaces
{
    public interface ICarRepository
    {
        void Create(Car car);
        void Update(Car item);
        void Delete(int id);
        Car GetById(int id);
        IEnumerable<Car> GetAll();

    }
}
