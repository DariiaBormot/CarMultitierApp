using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly IManufacturerRepository _repository;

        public ManufacturerService()
        {
            _repository = new ManufacturerRepository();
        }
        public IEnumerable<ManufacturerModel> GetAll()
        {
            var manufacturers = _repository.GetAll();

            var manufacturerModels = manufacturers.Select(manuf => new ManufacturerModel()
            {
                Id = manuf.Id,
                Name = manuf.Name,
                Cars = manuf.Cars?.Select(car => new CarModel()
                {
                    Id = car.Id,
                    Name = car.Name,
                    ManufacturerId = car.ManufacturerId,
                    Details = car.Details?.Select(detail => new DetailModel()
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
