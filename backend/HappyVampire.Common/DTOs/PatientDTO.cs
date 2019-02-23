using System;
using System.Collections.Generic;
using System.Text;

namespace HappyVampire.Common.DTOs
{
    public class PatientDTO : BasicDTO
    {
        public string FullName { get; set; }
        public string BloodType { get; set; }
        public string Photo { get; set; }
        public string Diagnosis { get; set; }
        public string MotivationLetter { get; set; }


        public HospitalDTO Hospital { get; set; }

    }
}
