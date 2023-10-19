using System;
using System.Collections.Generic;

namespace abc
{
    public class User
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public List<Category> Borrowed { get; set; }
        public User(string Name, string Address, string Phone)
        {
            this.Name = Name;
            this.Address = Address;
            this.Phone = Phone;
            Borrowed = new List<Category>();
        }

        public string ToString()
        {
            return $"Name: {Name} | Address: {Address} | Phone: {Phone} ";
        }
    }
}
