using System.Collections.Generic;

namespace Prototype__.NET_
{
    public static class UserStore
    {
        private static readonly Dictionary<string, User> users = new Dictionary<string, User>();

        public static void AddUser(string username, string password, string firstName, string lastName)
        {
            users[username] = new User
            {
                Username = username,
                Password = password,
                FirstName = firstName,
                LastName = lastName
            };
        }

        public static User GetUser(string username)
        {
            users.TryGetValue(username, out User user);
            return user;
        }

        public class User
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
}
