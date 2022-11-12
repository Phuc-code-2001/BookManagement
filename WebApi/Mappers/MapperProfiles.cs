using AutoMapper;
using DataLayer.Domain;
using WebApi.DTOs;
using WebApi.Models.Authors;
using WebApi.Models.Books;
using WebApi.Models.Users;

namespace WebApi.Mappers
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            // AppUser Create Update
            CreateMap<CreateAppUser, AppUser>();
            CreateMap<UpdateAppUser, AppUser>()
                .ForMember(des => des.RoleId, act =>
                {
                    act.Condition(src => src.RoleId != null);
                    act.MapFrom(src => src.RoleId.Value);
                })
                .ForMember(des => des.PublisherId, act =>
                {
                    act.Condition(src => src.PublisherId != null);
                    act.MapFrom(src => src.PublisherId.Value);
                })
                .ForAllMembers(opts => opts.Condition((src, des, member) => member != null));


            // AppUser DTOs
            CreateMap<AppUser, AppUserDTO>()
                .ForMember(des => des.HireDate, act => act.MapFrom(src => src.HireDate.Value.ToString("yyyy-MM-dd")));
            CreateMap<Publisher, PublisherDTO>();


            // Author Create Update
            CreateMap<CreateAuthor, Author>();
            CreateMap<UpdateAuthor, Author>()
                .ForAllMembers(opts => opts.Condition((src, des, member) => member != null));


            //  Author DTO
            CreateMap<Author, AuthorDTO>();

            // Book Create Update
            CreateMap<CreateBook, Book>();
            CreateMap<UpdateBook, Book>()
                .ForAllMembers(opts => opts.Condition((src, des, member) => member != null));

            // Book DTO
            CreateMap<Book, BookDTO>()
                .ForMember(des => des.PublishedDate, act => act.MapFrom(src => src.PublishedDate.ToString("yyyy-MM-dd")));

            // Enum -> TypeResponse
            CreateMap<BookType, TypeResponse>()
                .ForMember(des => des.Id, act => act.MapFrom(src => src))
                .ForMember(des => des.Name, act => act.MapFrom(src => src.ToString()));

            CreateMap<City, TypeResponse>()
                .ForMember(des => des.Id, act => act.MapFrom(src => src))
                .ForMember(des => des.Name, act => act.MapFrom(src => src.ToString()));

            CreateMap<State, TypeResponse>()
                .ForMember(des => des.Id, act => act.MapFrom(src => src))
                .ForMember(des => des.Name, act => act.MapFrom(src => src.ToString()));

            CreateMap<Country, TypeResponse>()
                .ForMember(des => des.Id, act => act.MapFrom(src => src))
                .ForMember(des => des.Name, act => act.MapFrom(src => src.ToString()));

            CreateMap<Publisher, TypeResponse>();
                

        }
    }
}
