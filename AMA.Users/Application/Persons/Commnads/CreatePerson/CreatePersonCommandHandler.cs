namespace AMA.Users.Application.Persons.Commnads.CreatePerson
{
    using AMA.Persistence.Models;
    using AMA.Users.Domain.Interfaces;
    using AutoMapper;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, CreatePersonCommandModel>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public CreatePersonCommandHandler(
            IMapper mapper,
            IPersonRepository personRepository
        )
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<CreatePersonCommandModel> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<PersonModel>(request);
            var responseModel = await _personRepository.CreatePerson(model);

            return _mapper.Map<CreatePersonCommandModel>(responseModel);
        }
    }
}
