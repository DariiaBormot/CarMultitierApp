using Dapper;
using DataAccessLayerDapper.Interfaces;
using DataAccessLayerDapper.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccessLayerDapper.Repositories
{
    public class DetailRepository : IDetailRepository
    {
        private readonly string _connectionString;
        public DetailRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        }

        public void Create(Detail detail)
        {
            var sqlQuery = $"INSERT INTO Details (CarId, Name, Price, DetailTypeId, ManufacturerId) VALUES({detail.CarId}, '{detail.Name}', {detail.Price}, {detail.DetailTypeId}, {detail.ManufacturerId})";

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute(sqlQuery, detail);
                connection.Close();
            }
        }

        public void Delete(int id)
        {
            var sqlQuery = $"DELETE FROM Details WHERE Id = '{id}'";

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute(sqlQuery);
                connection.Close();
            }
        }

        public IEnumerable<Detail> GetAll()
        {
            var sqlQuery = "SELECT * FROM Details";

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = connection.Query<Detail>(sqlQuery).ToList();
                connection.Close();
                return result;
            }
        }

        public Detail GetById(int id)
        {
            var sqlQuery = $"SELECT * FROM Details WHERE Id = {id}";

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = connection.Query<Detail>(sqlQuery).FirstOrDefault();
                connection.Close();
                return result;
            }
        }

        public void Update(Detail detail)
        {
            var sqlQuery = $"UPDATE Details SET CarId = {detail.CarId}, Name = '{detail.Name}', Price = {detail.Price}, DetailTypeId = {detail.DetailTypeId}, ManufacturerId = {detail.ManufacturerId}  WHERE Id = '{detail.Id}'";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute(sqlQuery);
                connection.Close();
            }
        }
    }
}
