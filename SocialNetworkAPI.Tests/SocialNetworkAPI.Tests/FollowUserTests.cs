using Moq;
using SocialNetworkAPI.Application.UseCases;
using SocialNetworkAPI.Core.Entities;
using SocialNetworkAPI.Core.Interfaces;

public class FollowUserTests
{
    [Fact]
    public void Execute_ShouldFollowUser_WhenUsersExist()
    {
        // Arrange
        var userRepositoryMock = new Mock<IUserRepository>();
        userRepositoryMock.Setup(repo => repo.GetUser("Alfonso")).Returns(new User("Alfonso"));
        userRepositoryMock.Setup(repo => repo.GetUser("Ivan")).Returns(new User("Ivan"));
        var followUser = new FollowUser(userRepositoryMock.Object);

        // Act
        followUser.Execute("Alfonso", "Ivan");

        // Assert
        userRepositoryMock.Verify(repo => repo.FollowUser("Alfonso", "Ivan"), Times.Once);
    }

    [Fact]
    public void Execute_ShouldThrowException_WhenFollowerDoesNotExist()
    {
        // Arrange
        var userRepositoryMock = new Mock<IUserRepository>();
        userRepositoryMock.Setup(repo => repo.GetUser("Alfonso")).Returns((User)null);
        var followUser = new FollowUser(userRepositoryMock.Object);

        // Act & Assert
        Assert.Throws<Exception>(() => followUser.Execute("Alfonso", "Ivan"));
    }

    [Fact]
    public void Execute_ShouldThrowException_WhenFolloweeDoesNotExist()
    {
        // Arrange
        var userRepositoryMock = new Mock<IUserRepository>();
        userRepositoryMock.Setup(repo => repo.GetUser("Alfonso")).Returns(new User("Alfonso"));
        userRepositoryMock.Setup(repo => repo.GetUser("Ivan")).Returns((User)null);
        var followUser = new FollowUser(userRepositoryMock.Object);

        // Act & Assert
        Assert.Throws<Exception>(() => followUser.Execute("Alfonso", "Ivan"));
    }
}
