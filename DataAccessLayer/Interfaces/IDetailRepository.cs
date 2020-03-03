using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    interface IDetailRepository
    {
        void Create(Detail detail);
        void Update(Detail detail);
        void Delete(int id);
        Detail GetDetalById(int id);
        IEnumerable<Detail> GetDetails();
    }
}
