using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerADONET.Models
{
    public class Detail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int CarId { get; set; }
        public int DetailTypeId { get; set; }
        public int ManufacturerId { get; set; }
    }
}
