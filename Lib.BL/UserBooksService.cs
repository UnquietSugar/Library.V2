using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.DL;

namespace Lib.BL
{
    public class UserBooksService
    {
        public static UserBooksRepository userBooksRepository;

        public UserBooksService()
        {
            userBooksRepository = new UserBooksRepository();
        }

        public string TakeBook(int userId, int bookId)
        {
            return userBooksRepository.TakeBook(userId, bookId);
        }

        public string RetriveBookIds(int userId)
        {
            return userBooksRepository.RetriveBookIds(userId);
        }

        public string ReturnBook(int userId, int bookId)
        {
            return userBooksRepository.ReturnBook(userId, bookId);
        }


    }
}
