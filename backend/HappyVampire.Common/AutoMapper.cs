using AutoMapper;
using HappyVampire.Common.DTOs;
using HappyVampire.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HappyVampire.Common
{
    public class AutoMapper
    {
        public static IMapper GetDefaultMapper()
        {
            return new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<DonationDTO, Donation>()
                    .ForMember(e => e.Donor, opt => opt.MapFrom(dto => dto.Donor))
                    .ForMember(e => e.Hospital, opt => opt.MapFrom(dto => dto.Hospital));
                cfg.CreateMap<Donation, DonationDTO>()
                    .ForMember(dto => dto.Donor, opt => opt.MapFrom(e => e.Donor))
                    .ForMember(dto => dto.Hospital, opt => opt.MapFrom(e => e.Hospital));

                cfg.CreateMap<DonorDTO, Donor>()
                    .ForMember(e => e.User, opt => opt.MapFrom(dto => dto.User))
                    .ForMember(e => e.Donations, opt => opt.MapFrom(dto => dto.Donations));
                cfg.CreateMap<Donor, DonorDTO>()
                    .ForMember(dto => dto.User, opt => opt.MapFrom(e => e.User))
                    .ForMember(dto => dto.Donations, opt => opt.MapFrom(e => e.Donations));

                cfg.CreateMap<PatientDTO, Patient>()
                    .ForMember(e => e.Hospital, opt => opt.MapFrom(dto => dto.Hospital));
                cfg.CreateMap<Patient, PatientDTO>()
                    .ForMember(dto => dto.Hospital, opt => opt.MapFrom(e => e.Hospital));

                cfg.CreateMap<UserDTO, User>();
                cfg.CreateMap<User, UserDTO>();

                cfg.CreateMap<HospitalDTO, Hospital>()
                    .ForMember(dto => dto.User, opt => opt.MapFrom(e => e.User))
                    .ForMember(dto => dto.Patients, opt => opt.MapFrom(e => e.Patients))
                    .ForMember(dto => dto.Donations, opt => opt.MapFrom(e => e.Donations));
                cfg.CreateMap<Hospital, HospitalDTO>()
                    .ForMember(dto => dto.User, opt => opt.MapFrom(e => e.User))
                    .ForMember(dto => dto.Patients, opt => opt.MapFrom(e => e.Patients))
                    .ForMember(dto => dto.Donations, opt => opt.MapFrom(e => e.Donations));


            }).CreateMapper();
        }
    }
}
