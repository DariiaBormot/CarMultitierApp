using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerDapper.Models
{
    public class Car
    {
        public Car()
        {
            Details = new List<Detail>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int ManufacturerId { get; set; }

        public ICollection<Detail> Details { get; set; }

    }
}
