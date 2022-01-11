using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.DL
{
    public class UserBooksRepository
    {
        private const string Path = "userBooks.json";

        public List<UserBooks> UserBooksList;

        public UserBooksRepository()
        {
            UserBooksList = new List<UserBooks>();
            var books = GetUserBooksList();

            if (books != null) UserBooksList = books;
        }

        public string TakeBook(int userId, int bookId)
        {
            string message = "";

            UserBooks userBooksObject;

            
            userBooksObject = UserBooksList.SingleOrDefault(obj => obj.UserId == userId);

            if (userBooksObject == null) userBooksObject = CreateNewUserBooksObject(userId);
            if(userBooksObject.TakenBooksIdList.Count < 3)
            {
                userBooksObject.TakenBooksIdList.Add(bookId);

                message = "Book added to user's collection.";
            }
            else
            {
                message = "User can't take more books.";
            }

            SaveUserBooksToJsonFile();

            return message;
        }

        private UserBooks CreateNewUserBooksObject(int userId)
        {
            var userBooksObject = new UserBooks(userId);
            UserBooksList.Add(userBooksObject);
            return userBooksObject;
        }

        public string RetriveBookIds(int userId)
        {
            UserBooks userBooksObject;

            userBooksObject = UserBooksList.SingleOrDefault(obj => obj.UserId == userId);

            return userBooksObject.ToString();
        }

        public string ReturnBook(int userId, int bookId)
        {
            UserBooks userBooksObject;
            string message;

            userBooksObject = UserBooksList.SingleOrDefault(obj => obj.UserId == userId);
            userBooksObject.TakenBooksIdList.Remove(bookId);

            message = "Book removed from user's collection.";

            SaveUserBooksToJsonFile();
            return message;
        }

        public List<UserBooks> GetUserBooksList()
        {
            return JsonConvert.DeserializeObject<List<UserBooks>>(File.ReadAllText(Path));
        }

        public void SaveUserBooksToJsonFile()
        {
            File.WriteAllText(Path, JsonConvert.SerializeObject(UserBooksList));
        }
    }
}
