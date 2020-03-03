using BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    interface ICarService
    {
        void Create(CarModel carModel);
        void Update(CarModel carModel);
        void Delete(int id);
        CarModel GetById(int id);
        IEnumerable<CarModel> GetCars();
        IEnumerable<CarModel> GetMostExpensiveCars();
    }
}
