using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class CarService : ICarService
    {
        private readonly CarRepository carRepository;

        public CarService()
        {
            carRepository = new CarRepository();
        }
        public void Create(CarModel carModel)
        {
            var car = new Car
            {
                Id = carModel.Id,
                Name = carModel.Name,
                ManufacturerId = carModel.ManufacturerId,
                Details = carModel.Details?.Select(x => new Detail
                {
                    Id = x.Id,
                    CarId = x.CarId,
                    Name = x.Name,
                    Price = x.Price,
                    DetailTypeId = x.DetailTypeId,
                    ManufacturerId = x.ManufacturerId

                }).ToList()
            };
            carRepository.Create(car);
        }

        public void Delete(int id)
        {
            carRepository.Delete(id);
        }

        public CarModel GetById(int id)
        {
            var car = carRepository.GetById(id);
            var carModel = new CarModel
            {
                Id = car.Id,
                Name = car.Name,
                ManufacturerId = car.ManufacturerId,
                TotalPrice = car.Details.Sum(x => x.Price),
                Details = car.Details.Select(x => new DetailModel
                {
                    Id = x.Id,
                    CarId = x.CarId,
                    Name = x.Name,
                    Price = x.Price,
                    ManufacturerId = x.ManufacturerId,
                    DetailTypeId = x.DetailTypeId

                }).ToList()
            };
            return carModel;
        }

        public IEnumerable<CarModel> GetCars()
        {
            var cars = carRepository.GetCars();
            var carModels = cars.Select(car => new CarModel()
            {
                Id = car.Id,
                Name = car.Name,
                ManufacturerId = car.ManufacturerId,
                TotalPrice = car.Details.Sum(x => x.Price),
                Details = car.Details.Select(detail => new DetailModel()
                {
                    Id = detail.Id,
                    CarId = detail.CarId,
                    Name = detail.Name,
                    Price = detail.Price,
                    ManufacturerId = detail.ManufacturerId,
                    DetailTypeId = detail.DetailTypeId
                })

            });
            return carModels;
        }

        public void Update(CarModel carModel)
        {
            var car = new Car()
            {
                Id = carModel.Id,
                Name = carModel.Name,
                ManufacturerId = carModel.ManufacturerId,
                Details = carModel.Details?.Select(x => new Detail
                {
                    Name = x.Name,
                    Price = x.Price,
                    CarId = x.CarId,
                    DetailTypeId = x.DetailTypeId,
                    ManufacturerId = x.ManufacturerId

                }).ToList()

            };
            carRepository.Update(car);
        }

        public IEnumerable<CarModel> GetMostExpensiveCars()
        {
            var cars = carRepository.GetCars();
            var carsViews = cars.Select(car => new CarModel()
            {
                Id = car.Id,
                Name = car.Name,
                TotalPrice = car.Details.Sum(x => x.Price),
                ManufacturerId = car.ManufacturerId,
                Details = car.Details.Select(detail => new DetailModel()
                {
                    Id = detail.Id,
                    CarId = detail.CarId,
                    Name = detail.Name,
                    Price = detail.Price,
                    DetailTypeId = detail.DetailTypeId,
                    ManufacturerId = detail.ManufacturerId
                })
            });

            var result = carsViews.GroupBy(x => x.ManufacturerId)
                            .Select(c => c.OrderByDescending(y => y.TotalPrice).First());

            return result;
        }

    }

}
