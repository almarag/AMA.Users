namespace AMA.Users.Application.Users.Queries.GetUser
{
    using MediatR;

    public class GetUserQuery : IRequest<GetUserQueryModel>
    {
        public int Id { get; set; }
    }
}
