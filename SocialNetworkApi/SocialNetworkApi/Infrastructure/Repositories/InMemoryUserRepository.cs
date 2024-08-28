using SocialNetworkAPI.Core.Entities;
using SocialNetworkAPI.Core.Interfaces;

namespace SocialNetworkAPI.Infrastructure.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private readonly List<User> _users;

        public InMemoryUserRepository()
        {
            _users = new List<User>();
            InitializeUsers();
        }

        private void InitializeUsers()
        {
            var alfonso = new User("Alfonso");
            var ivan = new User("Ivan");
            var alicia = new User("Alicia");

            _users.AddRange(new[] { alfonso, ivan, alicia });

        }

        public User GetUser(string username)
        {
            return _users.SingleOrDefault(u => u.Username == username);
        }

        public void AddPost(string username, Post post)
        {
            var user = GetUser(username);
            if (user != null)
            {
                user.AddPost(post);
            }
        }

        public void FollowUser(string followerUsername, string followeeUsername)
        {
            var follower = GetUser(followerUsername);
            var followee = GetUser(followeeUsername);

            if (follower != null && followee != null)
            {
                follower.Follow(followee);
            }
        }

        public IEnumerable<Post> GetPostsForUser(string username)
        {
            var user = GetUser(username);
            return user?.Posts ?? Enumerable.Empty<Post>();
        }

        public IEnumerable<Post> GetDashboardPosts(string username)
        {
            var user = GetUser(username);
            var posts = user?.Following.SelectMany(f => f.Posts) ?? Enumerable.Empty<Post>();
            posts = posts.Concat(user?.Posts ?? Enumerable.Empty<Post>());

            return posts.OrderByDescending(p => p.Timestamp);
        }
    }
}
