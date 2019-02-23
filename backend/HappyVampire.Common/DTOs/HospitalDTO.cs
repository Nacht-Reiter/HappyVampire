using System;
using System.Collections.Generic;
using System.Text;

namespace HappyVampire.Common.DTOs
{
    public class HospitalDTO : BasicDTO 
    {
        public string Name { get; set; }
        public string Coordinates { get; set; }
        public string Address { get; set; }

        public IEnumerable<PatientDTO> Patients { get; set; }
        public IEnumerable<DonationDTO> Donations { get; set; }

        public UserDTO User { get; set; }

        public HospitalDTO()
        {
            Patients = new List<PatientDTO>();
            Donations = new List<DonationDTO>();
        }
    }
}
