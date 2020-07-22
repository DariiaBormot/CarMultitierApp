using DataAccessLayerADONET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerADONET.Interfaces
{
    public interface IDetailTypeRepository
    {
        void Create(DetailType item);
        void Update(DetailType item);
        void Delete(int id);
        DetailType GetById(int id);
        IEnumerable<DetailType> GetAll();

    }
}
