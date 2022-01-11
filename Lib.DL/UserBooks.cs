using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.DL
{
    public class UserBooks
    {
        public int UserId;
        public List<int> TakenBooksIdList;

        public UserBooks(int userId)
        {
            UserId = userId;
            TakenBooksIdList = new List<int>();
        }
        public override string ToString()
        {
            string takenBooksIds = string.Join(", ", TakenBooksIdList);
            return string.Format($"User's book information:\n\tUser ID: {UserId}\n\tTaken books ID's: {takenBooksIds}");
        }
    }
}
