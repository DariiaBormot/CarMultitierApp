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
    public class DetailTypeRepository : IDetailTypeRepository
    {
        private readonly string _connectionString;
        public DetailTypeRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        }
        public void Create(DetailType type)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute("spDetailTypes_Insert @name", new { name = type.Name });
                connection.Close();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute("spDetailTypes_Delete @id", new { id });
                connection.Close();
            }
        }

        public IEnumerable<DetailType> GetAll()
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = connection.Query<DetailType>("spDetailTypes_GetAll").ToList();
                connection.Close();

                return result;
            }
        }
        
        public DetailType GetById(int id)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = connection.Query<DetailType>("spDetailTypes_GetById @id", new { id }).ToList();
                connection.Close();

                return result.FirstOrDefault();
            }
        }

        public void Update(DetailType item)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute("spDetailTypes_Update @name, @id", new { name = item.Name, id = item.Id });
                connection.Close();
            }
        }
    }
}
