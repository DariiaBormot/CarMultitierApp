using DataAccessLayerADONET.Interfaces;
using DataAccessLayerADONET.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace DataAccessLayerADONET.Repositories
{
    public class DetailRepository : IDetailRepository
    {
        private readonly string _connectionString;
        public DetailRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        }

        public void Create(Detail item)
        {
            var sqlQuery = $"INSERT INTO Details (Name, Price, CarId, DetailTypeId, ManufacturerId) VALUES ( @name, @price, @carId, @detailTypeId, @manufacturerId )";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add(new SqlParameter("@name", item.Name));
                command.Parameters.Add(new SqlParameter("@price", item.Price));
                command.Parameters.Add(new SqlParameter("@carId", item.CarId));
                command.Parameters.Add(new SqlParameter("@detailTypeId", item.DetailTypeId));
                command.Parameters.Add(new SqlParameter("@manufacturerId", item.ManufacturerId));

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
            var sqlQuery = $"DELETE  FROM Details WHERE Id = {id}";

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

        public IEnumerable<Detail> GetAll()
        {
            var sqlQuery = "SELECT * FROM Details";

            var details = new List<Detail>();

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
                            details.Add(MapToDetail(reader));
                        }
                    }

                    connection.Close();
                    return details;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
        }

        public Detail GetById(int id)
        {
            var sqlQuery = $"SELECT * FROM Details WHERE Id = {id}";

            Detail detail = null;

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
                            detail = MapToDetail(reader);
                        }
                    }

                    connection.Close();
                    return detail;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
        }

        private Detail MapToDetail(SqlDataReader reader)
        {
            return new Detail()
            {
                Id = (int)reader["Id"],
                Name = (string)reader["Name"],
                ManufacturerId = (int)reader["ManufacturerId"],
                CarId = (int)reader["CarId"],
                DetailTypeId = (int)reader["DetailTypeId"],
                Price = (int)reader["Price"]
            };
        }
        public void Update(Detail item)
        {
            var sqlQuery = "UPDATE Details SET Name = @name, Price = @price, CarId = @carId, DetailTypeId = @detailTypeId, ManufacturerId = @manufacturerId WHERE Id = @id";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add(new SqlParameter("@name", item.Name));
                command.Parameters.Add(new SqlParameter("@price", item.Price));
                command.Parameters.Add(new SqlParameter("@carId", item.CarId));
                command.Parameters.Add(new SqlParameter("@detailTypeId", item.DetailTypeId));
                command.Parameters.Add(new SqlParameter("@manufacturerId", item.ManufacturerId));
                command.Parameters.Add(new SqlParameter("@id", item.Id));

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
    }
}
