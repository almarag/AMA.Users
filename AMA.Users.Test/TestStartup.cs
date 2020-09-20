namespace AMA.Users.Test
{
    using AMA.Persistence.Models;
    using AMA.Users.Domain.Interfaces;
    using AutoMapper;
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;
    using Moq;
    using System;
    using System.Collections.Generic;
    
    public class TestStartup
    {
        private IServiceCollection _services;
        private IServiceProvider _provider;
        private IMediator _mediator;

        public IServiceCollection InitializeServices()
        {
            var userApplicationAssembly = new UsersAssemblyApplication().GetAssembly();

            _services = new ServiceCollection();
            _services.AddMediatR(userApplicationAssembly);
            _services.AddAutoMapper(userApplicationAssembly);

            ConfigureMocks();

            _provider = _services.BuildServiceProvider();
            _mediator = _provider.GetService<IMediator>();

            return _services;
        }

        public IServiceProvider GetProvider()
        {
            return _provider;
        }

        public IMediator GetMediator(IServiceProvider provider)
        {
            return _mediator;
        }

        public void ConfigureMocks()
        {
            Mock<IHttpContextAccessor> mockContextAccessor = new Mock<IHttpContextAccessor>();
            mockContextAccessor.Setup(s => s.HttpContext).Returns(new DefaultHttpContext());

            var userRepositoryMock = new Mock<IUserRepository>();
            var personRepositoryMock = new Mock<IPersonRepository>();

            userRepositoryMock.Setup(x => x.GetAllUsers())
                .ReturnsAsync(
                    new List<UserModel>()
                    {
                        new UserModel()
                        {
                            Id = 1,
                            CreationDate = DateTime.Now,
                            Password = "testPassword",
                            PersonModel = new PersonModel()
                            {
                                CreationDate = DateTime.Now,
                                FirstName = "Test",
                                Id = 1,
                                LastName = "User",
                                PhoneNumber = "5555555555",
                                UpdateDate = DateTime.Now
                            },
                            Status = "Active",
                            UpdateDate = DateTime.Now,
                            UserGroups = new List<UserGroupModel>()
                            {
                                new UserGroupModel()
                                {
                                    GroupId = 1,
                                    GroupModel = new GroupModel()
                                    {
                                        Id = 1,
                                        Name = "test"
                                    },
                                    UserId = 1,
                                    UserModel = new UserModel()
                                    {
                                        Id = 1,
                                        UserName = "test"
                                    }
                                }
                            },
                            UserName = "test"                            
                        }
                    }
                );

            userRepositoryMock.Setup(x => x.GetUserById(It.IsAny<int>()))
                .ReturnsAsync(
                    new UserModel()
                    {
                        Id = 1,
                        CreationDate = DateTime.Now,
                        Password = "testPassword",
                        PersonModel = new PersonModel()
                        {
                            CreationDate = DateTime.Now,
                            FirstName = "Test",
                            Id = 1,
                            LastName = "User",
                            PhoneNumber = "5555555555",
                            UpdateDate = DateTime.Now
                        },
                        Status = "Active",
                        UpdateDate = DateTime.Now,
                        UserGroups = new List<UserGroupModel>()
                        {
                            new UserGroupModel()
                            {
                                GroupId = 1,
                                UserId = 1,
                                GroupModel = new GroupModel()
                                {
                                    Id = 1,
                                    Name = "test"
                                },
                                UserModel = new UserModel()
                                {
                                    Id = 1,
                                    UserName = "test"
                                }
                            }
                        },
                        UserName = "test"
                    }
                );

            personRepositoryMock.Setup(x => x.CreatePerson(It.IsAny<PersonModel>()))
                .ReturnsAsync(It.IsAny<PersonModel>());

            _services.AddTransient(c => userRepositoryMock.Object);
            _services.AddTransient(c => personRepositoryMock.Object);
        }
    }
}
