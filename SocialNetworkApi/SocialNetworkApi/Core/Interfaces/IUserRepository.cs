using SocialNetworkAPI.Core.Entities;

namespace SocialNetworkAPI.Core.Interfaces
{
    public interface IUserRepository
    {
        User GetUser(string username);
        void AddPost(string username, Post post);
        void FollowUser(string followerUsername, string followeeUsername);
        IEnumerable<Post> GetPostsForUser(string username);
        IEnumerable<Post> GetDashboardPosts(string username);

    }
}
