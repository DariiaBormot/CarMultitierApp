using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using PresentationLayer.Interfaces;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    public class ManufacturerController : IManufacturerController
    {

        public IManufacturerService manufacturerService;

        public ManufacturerController()
        {
            manufacturerService = new ManufacturerService();
        }
        public IEnumerable<ManufacturerViewModel> GetAll()
        {
            var manufacturers = manufacturerService.GetAll();

            var manufacturerModels = manufacturers.Select(manuf => new ManufacturerViewModel()
            {
                Id = manuf.Id,
                Name = manuf.Name,
                Cars = manuf.Cars?.Select(car => new CarViewModel()
                {
                    Id = car.Id,
                    Name = car.Name,
                    TotalPrice = car.Details.Sum(x => x.Price),
                    ManufacturerId = car.ManufacturerId,
                    Details = car.Details?.Select(detail => new DetailViewModel()
                    {
                        Id = detail.Id,
                        Name = detail.Name,
                        Price = detail.Price,
                        CarId = detail.CarId,
                        DetailTypeId = detail.DetailTypeId,
                        ManufacturerId = detail.ManufacturerId
                    })
                })
            });
            return manufacturerModels;
        }

       
    }
}
