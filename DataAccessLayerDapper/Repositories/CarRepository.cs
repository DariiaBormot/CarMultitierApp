using DataAccessLayerDapper.Interfaces;
using DataAccessLayerDapper.Models;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Dapper;
using System.Data;

namespace DataAccessLayerDapper.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly string _connectionString;

        public CarRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        }
        public void Create(Car car)
        {

            var sqlQuery = $"INSERT INTO Cars (ManufacturerId, Name) VALUES({car.ManufacturerId}, '{car.Name}')";

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute(sqlQuery);
                connection.Close();
            }
        }

        public void Delete(int id)
        {
            var sqlQuery = $"DELETE FROM Cars WHERE Id = '{id}'";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute(sqlQuery);
                connection.Close();
            }
        }

        public IEnumerable<Car> GetAll()
        {
            var sqlQuery = $"SELECT* FROM Cars C LEFT JOIN Details D on C.Id = D.CarId WHERE C.Id = D.CarId";

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var carDictionary = new Dictionary<int, Car>();

                var result = connection.Query<Car, Detail, Car>(
                    sqlQuery,

                    (car, detail) =>
                    {
                        Car carEntry;

                        if (!carDictionary.TryGetValue(car.Id, out carEntry))
                        {
                            carEntry = car;
                            carEntry.Details = new List<Detail>();
                            carDictionary.Add(car.Id, carEntry);
                        }

                        carEntry.Details.Add(detail);

                        return carEntry;
                    },
                    new { },
                    splitOn: "Id");

                connection.Close();
                return result;

            };
        }

        public Car GetById(int id)
        {
            var sqlQuery = $"SELECT* FROM Cars c LEFT JOIN Details d on c.Id = d.CarId WHERE c.Id = {id}";

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = new List<Car>();
                var queryResult = connection.Query<Car, Detail, Car>(sqlQuery, (car, detail) =>
                {
                    var existingCar = result.FirstOrDefault(x => x.Id == car.Id);
                    if (existingCar == null)
                    {
                        result.Add(car);
                        existingCar = car;
                    }
                    existingCar.Details.Add(detail);
                    return car;
                });

                connection.Close();
                return result.FirstOrDefault();
            };
        }

        public void Update(Car car)
        {
            var sqlQuery = $"UPDATE Cars SET Name = '{car.Name}', ManufacturerId = {car.ManufacturerId} WHERE Id = {car.Id}";

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute(sqlQuery);
                connection.Close();
            }
        }
    }
}
