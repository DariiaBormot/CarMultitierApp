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
            _ctx.Cars.Add(car);
            _ctx.SaveChanges();
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

        public IEnumerable<Car> GetCars()
        {
            return _ctx.Cars.Include(x => x.Details).AsNoTracking().ToList();
        }

        public void Update(Car car)
        {
            var carToUpdate = _ctx.Cars.Include(x => x.Details).FirstOrDefault(x => x.Id == car.Id);

            carToUpdate.Manufacturer = car.Manufacturer;
            carToUpdate.Name = car.Name;

            carToUpdate.Details = car.Details.Select(x=> new Detail { Name = x.Name}).ToList();

            _ctx.SaveChanges();
        }
    }
}
