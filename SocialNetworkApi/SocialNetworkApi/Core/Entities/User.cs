
using SocialNetworkAPI.Application.UseCases;

namespace SocialNetworkAPI.Core.Entities
{
    public class User
    {
        public string Username { get; set; }
        public List<Post> Posts { get; set; }
        public List<User> Following { get; set; }

        public User(string username)
        {
            Username = username;
            Posts = new List<Post>();
            Following = new List<User>();
        }

        public void AddPost(Post post)
        {
            Posts.Add(post);
        }

        public void Follow(User user)
        {
            if (!Following.Contains(user))
            {
                Following.Add(user);
            }
            
        }
    }
}
