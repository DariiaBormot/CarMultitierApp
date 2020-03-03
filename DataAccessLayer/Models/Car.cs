using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Car
    {
        public Car()
        {
            Details = new List<Detail>();
        }
        public int Id { get; set; }
        public string Name { get; set; }


        public virtual ICollection<Detail> Details { get; set; }

        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

    }
}
