
using SocialNetworkAPI.Core.Entities;
using SocialNetworkAPI.Core.Interfaces;

namespace SocialNetworkAPI.Application.UseCases
{
    public class GetUserDashboard
    {
        private readonly IUserRepository _userRepository;

        public GetUserDashboard(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<Post> Execute(string username)
        {
            return _userRepository.GetDashboardPosts(username);
        }
    }
}
