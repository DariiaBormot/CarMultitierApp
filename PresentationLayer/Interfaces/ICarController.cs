using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Interfaces
{
    public interface ICarController
    {
        void Create(CarViewModel carView);
        void Update(CarViewModel carView);
        void Delete(int id);
        CarViewModel GetById(int id);
        IEnumerable<CarViewModel> GetCars();
        CarViewModel GetMostExpensiveCarByManufacturerId(int id);
    }
}
