using Dapper;
using DataAccessLayerDapper.Interfaces;
using DataAccessLayerDapper.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerDapper.Repositories
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        private readonly string _connectionString;
        public ManufacturerRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        }
        public void Create(Manufacturer entity)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute("spManufacturers_Insert @name", new { name = entity.Name });
                connection.Close();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute("spManufacturers_Delete @id", new { id });
                connection.Close();
            }
        }

        public IEnumerable<Manufacturer> GetAll()
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = connection.Query<Manufacturer>("spManufacturers_GetAll").ToList();
                connection.Close();

                return result;
            }
        }

        public Manufacturer GetById(int id)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = connection.Query<Manufacturer>("spManufacturers_GetById @id", new { id }).ToList();
                connection.Close();

                return result.FirstOrDefault();
            }
        }

        public void Update(Manufacturer entity)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute("spManufacturers_Update @name, @id", new { name = entity.Name, id = entity.Id });
                connection.Close();
            }
        }
    }
}
