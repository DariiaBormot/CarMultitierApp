using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Models
{
    public class DetailModel
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int DetailTypeId { get; set; }
        public int ManufacturerId { get; set; }

    }
}
