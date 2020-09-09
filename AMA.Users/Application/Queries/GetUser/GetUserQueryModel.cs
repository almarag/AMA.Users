using AMA.Users.Domain.Models;
using System.Collections.Generic;

namespace AMA.Users.Application.Queries.GetUser
{
    public class GetUserQueryModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Status { get; set; }
        public ICollection<GroupListViewModel> Groups { get; set; }
    }
}