using DataAccessLayerDapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerDapper.Interfaces
{
    public interface IDetailRepository
    {
        void Create(Detail detail);
        void Update(Detail item);
        void Delete(int id);
        Detail GetById(int id);
        IEnumerable<Detail> GetAll();

    }
}
