using abc;
using System.Collections.Generic;
using System;

internal class Library
{
    public List<Category> Categories { get; set; } = new List<Category>();
    public List<User> Users { get; set; }= new List<User>();
    public void Add(Category category)
    {
        Categories.Add(category);
    }
 
    public void ShowCategories()
    {
        foreach (var category in Categories)
        {
            Console.WriteLine(category.ToString());
        }
    }
    public void Search(Category category)
    {
        Console.WriteLine($"Title: {category.Title} | Author: { category.Author} ");
    }
    public void ShowUserBorrowed(User user)
    {
        foreach (var borrowedCategory in user.Borrowed)
        {
            Console.WriteLine(borrowedCategory.ToString());
        }
    }
    public void AddUser(User user)
    {
        Users.Add(user);
    }
    public void ShowUsers()
    {
        foreach (var user in Users)
        {
            Console.WriteLine(user.ToString());
        }
    }

    public void Borrow(Category category, User user)
    {
        if (category.IsAvailable)
        {
            category.IsAvailable = false;
            user.Borrowed.Add(category);
            Console.WriteLine($"{user.Name} has borrowed {category.Title}.");
        }
        else
        {
            Console.WriteLine($"{category.Title} is not available for borrowing.");
        }
    }

    public void Return(Category category, User user)
    {
        if (user.Borrowed.Contains(category))
        {
            category.IsAvailable = true;
            user.Borrowed.Remove(category);
            Console.WriteLine($"{user.Name} has returned {category.Title}.");
        }
        else
        {
            Console.WriteLine($"{user.Name} did not borrow {category.Title}.");
        }
    }
}