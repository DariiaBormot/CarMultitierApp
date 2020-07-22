using BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IDetailService
    {
        void Create(DetailModel detailModel);
        void Update(DetailModel detailModel);
        void Delete(int id);
        DetailModel GetById(int id);
        IEnumerable<DetailModel> GetDetails();
    }
}
