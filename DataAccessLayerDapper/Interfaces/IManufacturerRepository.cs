using DataAccessLayerDapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerDapper.Interfaces
{
    interface IManufacturerRepository
    {
        void Create(Manufacturer item);
        void Update(Manufacturer item);
        void Delete(int id);
        Manufacturer GetById(int id);
        IEnumerable<Manufacturer> GetAll();

    }
}
