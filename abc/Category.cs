using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abc
{

    public abstract class Category
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsAvailable { get; set; }

        public abstract string ToString();

    }

    public class Book : Category
    {
        public string ISBN { get; set; }

        public Book(string title, string author, string isbn)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            IsAvailable = true;
        }

        public override string ToString()
        {
            return $"Title Book: {Title} | Author: {Author} | ISBN: {ISBN}";
        }
    }

    public class Magazine : Category
    {
        public DateTime Date { get; set; }

        public Magazine(string title, string author, DateTime date)
        {
            Title = title;
            Author = author;
            Date = date;
            IsAvailable = true;
        }

        public override string ToString()
        {
            return $"Title Magazine: {Title} | Author: {Author} | Date: {Date}";
        }
    }

}
