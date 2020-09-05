using FluentValidation;

namespace AMA.Users.Application.Queries.GetUser
{
    public class GetUserValidation : AbstractValidator<GetUserQuery>
    {
        public GetUserValidation()
        {
            RuleFor(x => x.UserId).NotNull().WithMessage("User should not be null");
            RuleFor(x => x.UserId).NotEqual(0).WithMessage("Invalid User Id");
        }
    }
}
