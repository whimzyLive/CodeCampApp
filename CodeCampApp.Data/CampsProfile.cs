using AutoMapper;
using CodeCampApp.Domain;

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