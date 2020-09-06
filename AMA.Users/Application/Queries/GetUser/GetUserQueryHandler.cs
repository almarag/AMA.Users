namespace AMA.Users.Application.Queries.GetUser
{
    using AMA.Common.Interfaces;
    using AMA.Persistence.Models;
    using AMA.Users.Domain.Repositories;
    using AutoMapper;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, GetUserQueryModel>
    {
        private readonly IMapper _mapper;
        private readonly UserRepository _userRepository;
        
        public GetUserQueryHandler(
            IMapper mapper,
            IRepository<UserModel> userRepository
        )
        {
            _mapper = mapper;
            _userRepository = (UserRepository)userRepository;
        }


        public async Task<GetUserQueryModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var userInfo = await _userRepository.GetUserById(request.Id);
            return _mapper.Map<GetUserQueryModel>(userInfo);
        }
    }
}
