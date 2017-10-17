namespace GitAnalyzer.Models
{
    public class Author
    {
        public Author(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public string Name { get; private set; }

        public string Email { get; private set; }
    }
}
