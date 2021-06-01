using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FunnyWaterCarrier.Models.Models
{
    public enum Genders
    {
        [Description("Мужской")]
        Male = 1,

        [Description("Женский")]
        Female = 2
    }
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public DateTime BirthDate { get; set; }
        public Genders Gender { get; set; }
        public Departament Departament { get; set; }
        public List<Order> Orders { get; set; }
    }
}
