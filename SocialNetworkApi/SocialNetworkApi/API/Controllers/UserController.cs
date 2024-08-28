using Microsoft.AspNetCore.Mvc;
using SocialNetworkAPI.Application.UseCases;
using SocialNetworkAPI.API.Models;
using SocialNetworkAPI.Core.Interfaces;

namespace SocialNetworkAPI.API.Controllers
{
    [ApiController]
    [Route("api/Controlador")]
    public class UserController : ControllerBase
    {
        private PostMessage _postMessage;
        private FollowUser _followUser;
        private GetUserDashboard _getUserDashboard;
        private IUserRepository _userRepository;

        public UserController(PostMessage postMessage, FollowUser followUser, GetUserDashboard getUserDashboard, IUserRepository userRepository)
        {
            _postMessage = postMessage;
            _followUser = followUser;
            _getUserDashboard = getUserDashboard;
            _userRepository = userRepository;
        }

        // Endpoint para publicar un mensaje
        [HttpPost("post")]
        public IActionResult PostMessage([FromQuery] string username, [FromBody] PostRequest request)
        {
            try
            {
                _postMessage.Execute(username, request.Content);
                return Ok($"{username} posted -> \"{request.Content}\" @ {DateTime.Now:HH:mm}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Endpoint para seguir a un usuario
        [HttpPost("follow")]
        public IActionResult FollowUser([FromQuery] string followerUsername, [FromQuery] string followeeUsername)
        {
            try
            {
                _followUser.Execute(followerUsername, followeeUsername);
                return Ok($"{followerUsername} empezó a seguir a {followeeUsername}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Endpoint para obtener el dashboard del usuario
        [HttpGet("dashboard")]
        public IActionResult GetDashboard([FromQuery] string username)
        {
            try
            {
                var posts = _getUserDashboard.Execute(username);
                return Ok(posts.Select(p => new { p.Content, p.Author.Username, Timestamp = p.Timestamp.ToString("HH:mm") }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
