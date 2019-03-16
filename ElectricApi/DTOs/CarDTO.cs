using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricApi.DTOs {
    public class CarDTO {
        [Required]
        public string Model { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public double MaxSpeed { get; set; }
        [Required]
        public double MaxRange { get; set; }
        [Required]
        public double ChargeTime { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public byte[] Image { get; set; }
    }
}
