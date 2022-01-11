using System;

namespace Lib.DL
{
    public class User
    {
        public string Name { get; set; }
        public int Id;

        public User(string name, int id)
        {
            Name = name;
            Id = id;
        }

        public override string ToString()
        {
            return string.Format($"User information:\n\tUsername: {Name}\n\tID: {Id}");
        }
    }
}
