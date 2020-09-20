using System;

namespace AMA.Users.Application.Persons.Commnads.CreatePerson
{
    public class CreatePersonCommandModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreationDate { get; set; }
    }
}