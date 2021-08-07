using AutoMapper;
using BuildProperties.CrossCutting.ApiModel;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Business.Profiles
{
    public class AdminProfile: Profile
    {
        public AdminProfile()
        {
            CreateMap<Owner, OwnerAM>().ReverseMap();
            CreateMap<Property, PropertyAM>().ReverseMap();
            CreateMap<PropertyImage, PropertyImageAM>().ReverseMap();
            CreateMap<PropertyTrace, PropertyTraceAM>().ReverseMap();
        }
    }
}
