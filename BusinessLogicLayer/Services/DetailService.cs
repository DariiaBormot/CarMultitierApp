using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class DetailService : IDetailService
    {
        private readonly DetailRepository detailRepository;

        public DetailService()
        {
            detailRepository = new DetailRepository();
        }
        public void Create(DetailModel detailModel)
        {
            var detail = new Detail
            {
                Id = detailModel.Id,
                CarId = detailModel.CarId,
                Name = detailModel.Name,
                Price = detailModel.Price,
                DetailTypeId = detailModel.DetailTypeId,
                ManufacturerId = detailModel.ManufacturerId
            };
            detailRepository.Create(detail);
        }

        public void Delete(int id)
        {
            detailRepository.Delete(id);
        }

        public DetailModel GetById(int id)
        {
            var detail = detailRepository.GetDetalById(id);

            var detailModel = new DetailModel()
            {
                Id = detail.Id,
                CarId = detail.CarId,
                Name = detail.Name,
                Price = detail.Price,
                DetailTypeId = detail.DetailTypeId,
                ManufacturerId = detail.ManufacturerId
            };
            return detailModel;
        }

        public IEnumerable<DetailModel> GetDetails()
        {
            var details = detailRepository.GetAll();
            var detailModels = details.Select(d => new DetailModel
            {
                Id = d.Id,
                CarId = d.CarId,
                Name = d.Name,
                Price = d.Price,
                DetailTypeId = d.DetailTypeId,
                ManufacturerId = d.ManufacturerId
            });
            return detailModels;
        }

        public void Update(DetailModel detailModel)
        {
            var detail = new Detail()
            {
                Id = detailModel.Id,
                CarId = detailModel.CarId,
                Name = detailModel.Name,
                Price = detailModel.Price,
                DetailTypeId = detailModel.DetailTypeId,
                ManufacturerId = detailModel.ManufacturerId
            };
            detailRepository.Update(detail);
        }
    }
}
