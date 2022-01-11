using System;
using System.Collections.Generic;
using Lib.DL;

namespace Lib.BL
{
    public class UserService
    {
        public static UserRepository userRepository;

        public UserService()
        {
            userRepository = new UserRepository();
        }

        public List<User> GetAllUsers()
        {
            return userRepository.UserList;
        }
        public string WelcomeNewUser(string username)
        {
            User user = userRepository.AddNewUser(username);
            return $"New user added. Welcome USER: {user.Name}, ID: {user.Id}";
        }

        public string WelcomeExistingUser(string username, string id)
        {
            string message;

            User user = userRepository.UserExists(username, id);

            if(user != null)
            {
                message = $"Welcome USER: {user.Name}, ID: {user.Id}";
            }
            else
            {
                message = "User doesn't exist.";
            }

            return message;
        }
    }
}
