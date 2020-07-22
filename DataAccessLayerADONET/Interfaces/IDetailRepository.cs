using DataAccessLayerADONET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerADONET.Interfaces
{
    public interface IDetailRepository
    {
        void Create(Detail item);
        void Update(Detail item);
        void Delete(int id);
        Detail GetById(int id);
        IEnumerable<Detail> GetAll();
    }
}
