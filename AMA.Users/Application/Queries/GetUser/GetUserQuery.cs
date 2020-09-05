namespace AMA.Users.Application.Queries.GetUser
{
    using MediatR;

    public class GetUserQuery : IRequest<GetUserQueryModel>
    {
        public int UserId { get; set; }
    }
}
