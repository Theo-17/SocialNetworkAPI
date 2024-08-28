using Moq;
using SocialNetworkAPI.Application.UseCases;
using SocialNetworkAPI.Core.Entities;
using SocialNetworkAPI.Core.Interfaces;


public class PostMessageTests
{
    [Fact]
    public void Execute_ShouldAddPost_WhenUserExists()
    {
        // Arrange
        var userRepositoryMock = new Mock<IUserRepository>();
        userRepositoryMock.Setup(repo => repo.GetUser("Alfonso")).Returns(new User("Alfonso"));
        var postMessage = new PostMessage(userRepositoryMock.Object);

        // Act
        postMessage.Execute("Alfonso", "Hello World");

        // Assert
        userRepositoryMock.Verify(repo => repo.AddPost("Alfonso", It.IsAny<Post>()), Times.Once);
    }

    [Fact]
    public void Execute_ShouldThrowException_WhenUserDoesNotExist()
    {
        // Arrange
        var userRepositoryMock = new Mock<IUserRepository>();
        userRepositoryMock.Setup(repo => repo.GetUser("Alfonso")).Returns((User)null);
        var postMessage = new PostMessage(userRepositoryMock.Object);

        // Act & Assert
        Assert.Throws<Exception>(() => postMessage.Execute("Alfonso", "Hello World"));
    }
}
