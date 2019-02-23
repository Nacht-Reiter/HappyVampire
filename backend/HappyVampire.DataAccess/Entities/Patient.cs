using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HappyVampire.DataAccess.Entities
{
    public class Patient : Entity
    {
        public string FullName { get; set; }
        public string BloodType { get; set; }
        public string Photo { get; set; }
        public string Diagnosis { get; set; }
        public string MotivationLetter { get; set; }

        [ForeignKey("HospitalId")]
        public virtual Hospital Hospital { get; set; }
        public int? HospitalId { get; set; }
    }
}
