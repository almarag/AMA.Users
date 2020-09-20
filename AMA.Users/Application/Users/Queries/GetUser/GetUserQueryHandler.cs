namespace AMA.Users.Application.Users.Queries.GetUser
{
    using AMA.Common.Interfaces;
    using AMA.Persistence.Models;
    using AMA.Users.Domain.Interfaces;
    using AMA.Users.Domain.Repositories;
    using AutoMapper;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, GetUserQueryModel>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        
        public GetUserQueryHandler(
            IMapper mapper,
            IUserRepository userRepository
        )
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }


        public async Task<GetUserQueryModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var userInfo = await _userRepository.GetUserById(request.Id);
            return _mapper.Map<GetUserQueryModel>(userInfo);
        }
    }
}
