namespace AMA.Users.Application.Queries.GetUser
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, GetUserQueryModel>
    {
        public Task<GetUserQueryModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new GetUserQueryModel()
            {
                UserId = 1,
                Email = "test@example.com",
                Status = "Active",
                UserName = "almarag"
            });
        }
    }
}
