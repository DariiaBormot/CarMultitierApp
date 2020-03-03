using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Models
{
    public class ManufacturerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<CarViewModel> Cars { get; set; }
        public IEnumerable<DetailViewModel> Details { get; set; }
    }
}
