using AutoMapper;
using Vk.UserManagementSystem.Application.Users.Queries.GetUserDetails;
using Vk.UserManagementSystem.Persistence;
using Vk.UserManagementSystem.Tests.Common;
using Xunit;
using Shouldly;
using Vk.UserManagementSystem.Application.Users.ViewModels;

namespace Vk.UserManagementSystem.Tests.Users.Queries;

[Collection("QueryCollection")]
public class GetUserDetailsByIdQueryHandlerTests
{
    private readonly UserManagementSystemDbContext _context;
    private readonly IMapper _mapper;

    public GetUserDetailsByIdQueryHandlerTests(QueryTestFixture fixture)
    {
        _context = fixture.Context;
        _mapper = fixture.Mapper;
    }

    [Fact]
    public async Task GetUserDetailsByIdQueryHandler_Success()
    {
        
        var handler = new GetUserDetailsByIdQueryHandler(_context, _mapper);

       
        var result = await handler.Handle(
            new GetUserDetailsByIdQuery
            {                
                Id = Guid.Parse("909F7C29-891B-4BE1-8504-21F84F262084")
            },
            CancellationToken.None);
        
        result.ShouldBeOfType<UserDetailsViewModel>();
        result.Login.ShouldBe("Alex");        
    }
}
