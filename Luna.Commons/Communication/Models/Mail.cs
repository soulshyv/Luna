using Luna.Commons.Models.Identity;

namespace Luna.Commons.Communication.Models
{
    public class Mail
    {
        public Person From { get; set; }
        public Person To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public Person()
        {
        }

        public Person(LunaIdentityUser user)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
        }

        public Person(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}