using DataAccessLayerADONET.Interfaces;
using DataAccessLayerADONET.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayerADONET.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly string _connectionString;

        public CarRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        }

        public void Create(Car item)
        {
            var sqlQuery = $"INSERT INTO Cars(Name, ManufacturerId) VALUES('{item.Name}', {item.ManufacturerId})";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

        }

        public void Delete(int id)
        {
            var sqlQuery = $"DELETE  FROM Cars WHERE Id = {id}";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public IEnumerable<Car> GetAll()
        {

            var sqlQuery = "SELECT * FROM Cars";

            var cars = new List<Car>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            cars.Add(MapToCar(reader));
                        }
                    }

                    connection.Close();
                    return cars;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
        }

        private Car MapToCar(SqlDataReader reader)
        {
            return new Car()
            {
                Id = (int)reader["Id"],
                Name = (string)reader["Name"],
                ManufacturerId = (int)reader["ManufacturerId"]

            };
        }

        public Car GetById(int id)
        {
            var sqlQuery = $"SELECT * FROM Cars WHERE Id = {id}";

            Car car = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            car = MapToCar(reader);
                        }
                    }

                    connection.Close();
                    return car;

                } catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }

        }

        public void Update(Car item)
        {
            var sqlQuery = $"UPDATE Cars SET Name = '{item.Name}', ManufacturerId = {item.ManufacturerId} WHERE Id = {item.Id}";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                } catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
    }
}
