using System;

namespace HappyVampire.Common.DTOs
{
    public class DonationDTO : BasicDTO
    {
        public DateTime Date { get; set; }
        public int Amount { get; set; }


        public HospitalDTO Hospital { get; set; }

        public DonorDTO Donor { get; set; }

    }
}
