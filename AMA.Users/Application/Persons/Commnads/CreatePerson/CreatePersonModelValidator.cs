namespace AMA.Users.Application.Persons.Commnads.CreatePerson
{
    using FluentValidation;

    public class CreatePersonModelValidator : AbstractValidator<CreatePersonCommand>
    {
        public CreatePersonModelValidator()
        {
            RuleFor(x => x.FirstName).NotNull().WithMessage("First Name is required");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name should not be empty");
            RuleFor(x => x.LastName).NotNull().WithMessage("Last Name is required");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name should not be empty");
        }
    }
}
