namespace GitAnalyzer.Models
{
    public class User
    {
        public User(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public string Name { get; private set; }

        public string Email { get; private set; }
    }
}
