using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class CarRepository : ICarRepository
    {
        public readonly CarContext _ctx;
        public CarRepository()
        {
            _ctx = new CarContext();
        }

        public void Create(Car car)
        {
            if (IsLessThanTwoSpaces(car.Name) && IsUniqueName(car))
            {
                _ctx.Cars.Add(car);
                _ctx.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var carToRemove = _ctx.Cars.FirstOrDefault(c => c.Id == id);
            _ctx.Cars.Remove(carToRemove);
            _ctx.SaveChanges();
        }


        public Car GetById(int id)
        {
            return _ctx.Cars.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Car> GetAll()
        {
            return _ctx.Cars.Include(x => x.Details).AsNoTracking().ToList();
        }

        public void Update(Car car)
        {
            if (IsLessThanTwoSpaces(car.Name) && IsUniqueName(car))
            {
                var carToUpdate = _ctx.Cars.Include(x => x.Details).FirstOrDefault(x => x.Id == car.Id);

                carToUpdate.Manufacturer = car.Manufacturer;
                carToUpdate.Name = car.Name;
                carToUpdate.ManufacturerId = car.ManufacturerId;
                carToUpdate.Details = car.Details.Select(x => new Detail { Name = x.Name, DetailType = x.DetailType, Price = x.Price }).ToList();

                _ctx.SaveChanges();
            }
        }

        public Car GetMostExpenciveCarByManufacturerId(int id)
        {
            var mostExpenciveCar = _ctx.Cars.Where(x => x.ManufacturerId == id)
                                       .OrderByDescending(x => x.Details.Sum(y => y.Price))
                                       .FirstOrDefault();

            return mostExpenciveCar;

        }

        private string RemoveMultiplyWhiteSpaces(string str)
        {
            var wordsArray = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string resultedString = string.Join(" ", wordsArray);
            return resultedString;
        }

        private bool IsLessThanTwoSpaces(string str)
        {
            char c = ' ';
            var result = str.Count(x => x == c) <= 2;
            return result;
        }

        private bool IsUniqueName(Car model)
        {
            var cars = _ctx.Cars.Include(x => x.Details).AsNoTracking().ToList();
            var result = cars.All(x => x.Name != model.Name);
            return result;
        }
    }
}
