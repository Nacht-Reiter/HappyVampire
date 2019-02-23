using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HappyVampire.DataAccess.Entities
{
    public class Donation : Entity
    {
        public DateTime Date { get; set; }
        public int Amount { get; set; }

        [ForeignKey("HospitalId")]
        public virtual Hospital Hospital { get; set; }
        public int? HospitalId { get; set; }

        [ForeignKey("DonorId")]
        public virtual Donor Donor { get; set; }
        public int? DonorId { get; set; }
    }
}
