using BusinessLogicLayer.Models;
using BusinessLogicLayer.Services;
using PresentationLayer.Interfaces;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    public  class DetailController : IDetailController
    {
        private DetailService detailService;
        public DetailController()
        {
            detailService = new DetailService();
        }
        public void Create(DetailViewModel detailView)
        {
            var detail = new DetailModel()
            {
                Id = detailView.Id,
                CarId = detailView.CarId,
                Name = detailView.Name,
                Price = detailView.Price,
                DetailTypeId = detailView.DetailTypeId,
                ManufacturerId = detailView.ManufacturerId
            };
            detailService.Create(detail);
        }

        public void Delete(int id)
        {
            detailService.Delete(id);
        }

        public DetailViewModel GetById(int id)
        {
            var detail = detailService.GetById(id);
            var detailView = new DetailViewModel()
            {
                Id = detail.Id,
                CarId = detail.CarId,
                Name = detail.Name,
                Price = detail.Price,
                DetailTypeId = detail.DetailTypeId,
                ManufacturerId = detail.ManufacturerId
            };
            return detailView;
        }

        public IEnumerable<DetailViewModel> GetDetails()
        {
            var details = detailService.GetDetails();
            var detailsView = details.Select(d => new DetailViewModel
            {
                Id = d.Id,
                CarId = d.CarId,
                Name = d.Name,
                Price = d.Price,
                DetailTypeId = d.DetailTypeId,
                ManufacturerId = d.ManufacturerId
            });
            return detailsView;
        }

        public void Update(DetailViewModel detailView)
        {
            var detailToUpdate = new DetailModel()
            {
                Id = detailView.Id,
                CarId = detailView.CarId,
                Name = detailView.Name,
                Price = detailView.Price,
                DetailTypeId = detailView.DetailTypeId,
                ManufacturerId = detailView.ManufacturerId
            };
            detailService.Update(detailToUpdate);
        }
    }
}
