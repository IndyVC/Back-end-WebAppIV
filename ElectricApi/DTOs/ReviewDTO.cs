using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricApi.DTOs {
    public class ReviewDTO {

        [Required]
        public double Rating { get; set; }
        public string Comment { get; set; }
    }
}
