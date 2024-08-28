using SocialNetworkAPI.Core.Interfaces;

namespace SocialNetworkAPI.Application.UseCases
{
    public class FollowUser
    {
        private IUserRepository _userRepository;

        public FollowUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Execute(string followerUsername, string followeeUsername)
        {
            var follower = _userRepository.GetUser(followerUsername);
            var followee = _userRepository.GetUser(followeeUsername);
            
            if (follower == null)
            {
                throw new Exception($"User {followerUsername} not found.");
            }

            if (followee == null)
            {
                throw new Exception($"User {followeeUsername} not found.");
            }

            _userRepository.FollowUser(followerUsername, followeeUsername);
        }
    }
}
