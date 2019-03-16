using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricApi.Models {
    public class Review {
        public int id { get; set; }
        public DateTime DatePosted { get; set; }
        public string Comment { get; set; }
        public double Rating { get; set; }
        public int CarId { get; set; }
        public Customer Customer { get; set; }
    }
}
