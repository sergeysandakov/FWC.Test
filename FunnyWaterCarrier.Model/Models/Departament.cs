using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FunnyWaterCarrier.Models.Models
{
    public class Departament
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Employee Leader { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
