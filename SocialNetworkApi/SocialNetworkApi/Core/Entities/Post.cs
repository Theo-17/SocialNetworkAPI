namespace SocialNetworkAPI.Core.Entities
{
    public class Post
    {
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public User Author { get; set; }

        public Post(string content, User author)
        {
            Content = content;
            Author = author;
            Timestamp = DateTime.Now;
        }
    }
}
