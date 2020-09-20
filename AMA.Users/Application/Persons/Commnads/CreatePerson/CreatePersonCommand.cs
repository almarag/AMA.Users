namespace AMA.Users.Application.Persons.Commnads.CreatePerson
{
    using MediatR;

    public class CreatePersonCommand : IRequest<CreatePersonCommandModel>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
