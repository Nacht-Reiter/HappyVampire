using System;
using System.Collections.Generic;
using System.Text;

namespace HappyVampire.Common.DTOs
{
    public class UserDTO : BasicDTO
    {
        public string Uid { get; set; }
        public bool IsDonor { get; set; }
        public int AccountId { get; set; }
    }
}
