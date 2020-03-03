using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class DetailRepository :IDetailRepository 
    {
        public readonly CarContext _ctx;
        public DetailRepository()
        {
            _ctx = new CarContext();
        }
        public void Create(Detail detail)
        {
            _ctx.Details.Add(detail);
            _ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            var detailToRemove = _ctx.Details.FirstOrDefault(d => d.Id == id);
            _ctx.Details.Remove(detailToRemove);
            _ctx.SaveChanges();
        }

        public IEnumerable<Detail> GetDetails()
        {
            return _ctx.Details.AsNoTracking().ToList();

        }

        public Detail GetDetalById(int id)
        {
            return _ctx.Details.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Detail detail)
        {

            var detailToUpdate = _ctx.Details.FirstOrDefault(d => d.Id == detail.Id);

            detailToUpdate.CarId = detail.CarId;
            detailToUpdate.Name = detail.Name;

            _ctx.SaveChanges();
        }
    }
}
