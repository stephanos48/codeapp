using System.Linq;
using AutoMapper;
using codeapp.API.Dtos;
using codeapp.API.Models;

namespace codeapp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
                .ForMember(dest => dest.PhotoUrl, opt => {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                })                
                .ForMember(dest => dest.Age, opt => {
                    opt.MapFrom(d => d.DateOfBirth.CalculateAge());
            });
            CreateMap<User, UserForDetailedDto>()
                .ForMember(dest => dest.PhotoUrl, opt => {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                })
                .ForMember(dest => dest.Age, opt => {
                    opt.MapFrom(d => d.DateOfBirth.CalculateAge());
            });
            CreateMap<Photo, PhotosForDetailedDto>();
            CreateMap<UserForUpdateDto, User>();
            CreateMap<Photo, PhotoForReturnDto>();
            CreateMap<PhotoForCreationDto, Photo>();
            CreateMap<UserForRegisterDto, User>();
            CreateMap<MessageForCreationDto, Message>().ReverseMap();
            CreateMap<Message, MessageToReturnDto>()
                .ForMember(m => m.SenderPhotoUrl, opt => opt
                    .MapFrom(u => u.Sender.Photos.FirstOrDefault(p => p.IsMain).Url))
                .ForMember(m => m.RecipientPhotoUrl, opt => opt
                    .MapFrom(u => u.Recipient.Photos.FirstOrDefault(p => p.IsMain).Url));
            CreateMap<CustomerForCreationDto, Customer>();
            CreateMap<CustomerForReturnDto, Customer>().ReverseMap();
            CreateMap<CustomerForUpdateDto, Customer>();
            CreateMap<ScrumForCreationDto, Scrum>();
            CreateMap<ScrumForReturnDto, Scrum>().ReverseMap();
            CreateMap<ScrumForListDto, Scrum>().ReverseMap();
            CreateMap<ScrumForUpdateDto, Scrum>();
            CreateMap<ResponsibleForReturnDto, Responsible>().ReverseMap();
            CreateMap<AuditForCreationDto, Audit>();
            CreateMap<AuditForReturnDto, Audit>().ReverseMap();
            CreateMap<Audit, AuditForListDto>()
                .ForMember(dest => dest.PhotoAuditUrl, opt => opt
                    .MapFrom(src => src.PhotoAudits.FirstOrDefault(p => p.IsMain).Url));
            CreateMap<Audit, AuditForDetailDto>()
                .ForMember(dest => dest.PhotoAuditUrl, opt => opt
                    .MapFrom(src => src.PhotoAudits.FirstOrDefault(p => p.IsMain).Url));  
            CreateMap<PhotoAudit, PhotoAuditsForDetailedDto>();
            CreateMap<PhotoAudit, PhotoAuditForReturnDto>();
            CreateMap<PhotoAuditForCreationDto, PhotoAudit>();     
            CreateMap<AuditForUpdateDto, Audit>();
            CreateMap<FindingForCreationDto, Finding>();
            CreateMap<FindingForReturnDto, Finding>().ReverseMap();
            CreateMap<FindingForUpdateDto, Finding>();

        }
    }
}