namespace AMA.Users.Domain.Mappers
{
    using AMA.Persistence.Models;
    using AMA.Users.Application.Persons.Commnads.CreatePerson;
    using AutoMapper;
    using System;

    public class PersonModelMappers : Profile
    {
        public PersonModelMappers()
        {
            CreateMap<CreatePersonCommand, PersonModel>()
                .ForMember(x => x.Id, map => map.Ignore())
                .ForMember(x => x.CreationDate, map => map.MapFrom(x => DateTime.Now))
                .ForMember(x => x.UpdateDate, map => map.MapFrom(x => DateTime.Now));

            CreateMap<PersonModel, CreatePersonCommandModel>();
        }
    }
}
