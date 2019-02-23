﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HappyVampire.DataAccess.Entities
{
    public class Donor : Entity
    {
        public string FullName { get; set; }
        public string BloodType { get; set; }
        public string Rating { get; set; }
        public string Photo { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public int? UserId { get; set; }

        public virtual IEnumerable<Donation> Donations { get; set; }

        public Donor()
        {
            Donations = new List<Donation>();
        }
    }
}
