using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Models
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalPrice { get; set; }
        public IEnumerable<DetailModel> Details { get; set; }
        public int ManufacturerId { get; set; }
    }
}
