using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    interface ICarRepository
    {
        void Create(Car car);
        void Update(Car car);
        void Delete(int id);
        Car GetById(int id);
        IEnumerable<Car> GetCars();

    }
}
