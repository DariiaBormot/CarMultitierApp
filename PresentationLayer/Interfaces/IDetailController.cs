using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Interfaces
{
    public interface IDetailController
    {
        void Create(DetailViewModel detailVew);
        void Update(DetailViewModel detailVew);
        void Delete(int id);
        DetailViewModel GetById(int id);
        IEnumerable<DetailViewModel> GetDetails();
    }
}
