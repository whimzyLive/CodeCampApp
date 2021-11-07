using AutoMapper;
using CodeCampApp.Domain;

namespace CodeCampApp.Data
{
    public class CampsProfile : Profile
    {
        public CampsProfile()
        {
            CreateMap<Camp, CampModel>()
                .ForMember(camp => camp.Venue, opt => opt.MapFrom(c => c.Location.VenueName))
                .ReverseMap();
            CreateMap<Talk, TalkModel>()
                .ReverseMap();
            CreateMap<Speaker, SpeakerModel>()
                .ReverseMap();
        }
    }
}