using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.DL
{
    public class UserRepository
    {
        private const string Path = @"C:\Users\kiril.konstandi\source\repos\LibV2\Lib.DL\users.json";

        public List<User> UserList;

        public UserRepository()
        {
            UserList = new List<User>();
            var users = GetUserList();

            if (users != null) UserList = users;

        }

        public User GetfUserIfExists(string username)
        {
            return UserList.SingleOrDefault(user => user.Name == username);
        }

        public User AddNewUser(string username)
        {
            User user;

            if(UserList.Count < 1)
            {
                user = new User(username, 1);
            }
            else
            {
                var lastUser = UserList.LastOrDefault();
                user = new User(username, lastUser.Id + 1);
            }

            UserList.Add(user);

            SaveUsersToJsonFile();

            return user;
        }

        public User UserExists(string username, string id)
        {
            User user;

            user = UserList.SingleOrDefault(user => user.Name == username && user.Id == Int32.Parse(id));

            return user;
        }

        

        private List<User> GetUserList()
        {
            return JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(Path));
        }

        private void SaveUsersToJsonFile()
        {
           File.WriteAllText(Path, JsonConvert.SerializeObject(UserList));
        }

    }
}
