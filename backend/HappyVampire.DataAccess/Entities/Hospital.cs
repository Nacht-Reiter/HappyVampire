using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HappyVampire.DataAccess.Entities
{
    public class Hospital : Entity
    {
        public string Name { get; set; }
        public string Coordinates { get; set; }
        public string Address { get; set; }

        public virtual List<Patient> Patients { get; set; }
        public virtual IEnumerable<Donation> Donations { get; set; }


        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public int? UserId { get; set; }

        public Hospital()
        {
            Patients = new List<Patient>();
            Donations = new List<Donation>();
        }
    }
}
