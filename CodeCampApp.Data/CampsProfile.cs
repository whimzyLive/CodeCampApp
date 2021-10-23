using AutoMapper;
using CodeCampApp.Domain;

namespace CodeCampApp.Data
{
    public class CampsProfile : Profile
    {
        public CampsProfile()
        {
            this.CreateMap<Camp, CampModel>()
                .ForMember(camp => camp.Venue, opt => opt.MapFrom(c => c.Location.VenueName));
            this.CreateMap<Talk, TalkModel>();
        }
    }
}