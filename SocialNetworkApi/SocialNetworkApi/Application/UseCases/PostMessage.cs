using SocialNetworkAPI.Core.Entities;
using SocialNetworkAPI.Core.Interfaces;

namespace SocialNetworkAPI.Application.UseCases
{
    public class PostMessage
    {
        private readonly IUserRepository _userRepository;

        public PostMessage(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Execute(string username, string content)
        {
            var user = _userRepository.GetUser(username);
            if (user == null)
            {
                throw new Exception($"User {username} not found.");
            }

            var post = new Post(content, user);
            _userRepository.AddPost(username, post);
            user.AddPost(post);
        }
    }
}
