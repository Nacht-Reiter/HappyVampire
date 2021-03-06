﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HappyVampire.Common.DTOs
{
    public class DonorDTO : BasicDTO
    {
        public string FullName { get; set; }
        public string BloodType { get; set; }
        public int Rating { get; set; }

        public UserDTO User { get; set; }

        public IEnumerable<DonationDTO> Donations { get; set; }

        public DonorDTO()
        {
            Donations = new List<DonationDTO>();
        }
    }
}
