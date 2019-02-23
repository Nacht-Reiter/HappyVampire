using System;
using System.Collections.Generic;
using System.Text;

namespace HappyVampire.DataAccess.Entities
{
    public class User : Entity
    {
        public string Uid { get; set; }
        public bool IsDonor { get; set; }
        public int AccountId { get; set; }
    }
}
