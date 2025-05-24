using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VaccinationApp.Models
{
    public class VaccinationCenter
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int MaxCapacity { get; set; }

        //Bо рамките на еден вакцинален центар може да се аплицираат повеќе вакцини
        public virtual List<Vaccine> Vaccines { get; set; }
    }
}
