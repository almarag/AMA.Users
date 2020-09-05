namespace AMA.Users.Application.Queries.GetUser
{
    public class GetUserQueryModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
    }
}