using System;
using System.ComponentModel.DataAnnotations;

namespace FunnyWaterCarrier.Models.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int Number { get; set; }
        public string Partner { get; set; }
        public Employee Worker { get; set; }
    }
}
