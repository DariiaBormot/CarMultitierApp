using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        public readonly CarContext _ctx;
        public ManufacturerRepository()
        {
            _ctx = new CarContext();
        }
        public IEnumerable<Manufacturer> GetAll()
        {

            return _ctx.Manufacturers.Include(x => x.Cars)
                                     .Include(c => c.Details).AsNoTracking().ToList();

        }

    }
}
