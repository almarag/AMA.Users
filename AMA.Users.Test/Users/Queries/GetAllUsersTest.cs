namespace AMA.Users.Test.Users.Queries
{
    using AMA.Users.Domain.Interfaces;
    using MediatR;
    using Xunit;
    using Microsoft.Extensions.DependencyInjection;
    using AMA.Users.Application.Users.Queries.GetUser;

    [Collection("UsersCollection")]
    public class GetAllUsersTest
    {
        private readonly IMediator _mediator;
        private readonly IUserRepository _userRepository;

        public GetAllUsersTest()
        {
            var startup = new TestStartup();

            var services = startup.InitializeServices();
            var provider = startup.GetProvider();

            _mediator = startup.GetMediator(provider);
            _userRepository = provider.GetService<IUserRepository>();
        }


        [Fact]
        public async void TestGetUsers_NotNull()
        {
            var query = new GetUserQuery()
            {
                Id = 1
            };
            var result = await _mediator.Send(query);

            Assert.NotNull(result);
        }
    }
}
