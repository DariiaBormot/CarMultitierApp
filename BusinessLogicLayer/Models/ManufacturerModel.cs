using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Models
{
    public class ManufacturerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<CarModel> Cars { get; set; }
        public IEnumerable<DetailModel> Details { get; set; }

    }
}
