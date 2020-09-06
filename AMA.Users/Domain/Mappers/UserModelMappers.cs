namespace AMA.Users.Domain.Mappers
{
    using AMA.Persistence.Models;
    using AMA.Users.Application.Queries.GetUser;
    using AutoMapper;
    using System;

    public class UserModelMappers : Profile
    {
        public UserModelMappers()
        {
            CreateMap<UserModel, GetUserQueryModel>()
                .ForMember(x => x.UserId, map => map.MapFrom(x => x.Id))
                .ForMember(x => x.UserName, map => map.MapFrom(x => x.UserName))
                .ForMember(x => x.FirstName, map => map.MapFrom(x => x.PersonModel.FirstName))
                .ForMember(x => x.LastName, map => map.MapFrom(x => x.PersonModel.LastName))
                .ForMember(x => x.PhoneNumber, map => map.MapFrom(x => x.PersonModel.PhoneNumber))
                .ForMember(x => x.Status, map => map.MapFrom(x => x.Status));
        }
    }
}
