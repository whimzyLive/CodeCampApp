using AutoMapper;
using CodeCampApp.Domain;
using System;

namespace CodeCampApp.Data
{
    public class CampsProfile : Profile
    {
        public CampsProfile()
        {
            this.CreateMap<Camp, CampModel>();
        }
    }
}