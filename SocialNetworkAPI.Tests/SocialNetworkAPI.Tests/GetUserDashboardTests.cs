using Moq;
using SocialNetworkAPI.Application.UseCases;
using SocialNetworkAPI.Core.Entities;
using SocialNetworkAPI.Core.Interfaces;

public class GetUserDashboardTests
{
    [Fact]
    public void Execute_ShouldReturnPosts_WhenUserHasPosts()
    {
        // Arrange
        var posts = new List<Post> { new Post("Hello World", new User("Alfonso")) };
        var userRepositoryMock = new Mock<IUserRepository>();
        userRepositoryMock.Setup(repo => repo.GetDashboardPosts("Alfonso")).Returns(posts);
        var getUserDashboard = new GetUserDashboard(userRepositoryMock.Object);

        // Act
        var result = getUserDashboard.Execute("Alfonso");

        // Assert
        Assert.Single(result);
    }
}
