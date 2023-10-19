using System;
using System.Linq;


namespace abc
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            while (true)
            {
                Console.WriteLine("\nLibrary Management Menu:");
                Console.WriteLine("1. Add Category");
                Console.WriteLine("2. Add Member");
                Console.WriteLine("3. Borrow Category");
                Console.WriteLine("4. Return Category");
                Console.WriteLine("5. Display Library");
                Console.WriteLine("6. Display User's Borrow");
                Console.WriteLine("7. Search");
                Console.WriteLine("8. Show User");
                Console.WriteLine("9. Exit");

                Console.Write("Select an option (1-9): ");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            bool i = true;
                            while (i)
                            {
                                Console.WriteLine("1. Add Book");
                                Console.WriteLine("2. Add Magazine");
                                Console.WriteLine("3. Exit");
                                Console.WriteLine("Choose Category:");
                                int choose = Convert.ToInt32(Console.ReadLine());
                                if (choose == 1)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Enter Title:");
                                    string ETitle = Console.ReadLine();
                                    if (!library.Categories.Any(book => book.Title == ETitle))
                                    {
                                        Console.WriteLine("Enter Author:");
                                        string EAuthor = Console.ReadLine();
                                        Console.WriteLine("Enter ISBN:");
                                        string EISBN = Console.ReadLine();
                                        Book newBook = new Book(ETitle, EAuthor, EISBN);
                                        library.Add(newBook);
                                        i = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Title already exists in the library");
                                    }

                                }
                                if (choose == 2)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Enter Title:");
                                    string ETitle = Console.ReadLine();
                                    Console.WriteLine("Enter Author:");
                                    string EAuthor = Console.ReadLine();
                                    Console.WriteLine("Enter Date");
                                    DateTime EDate = DateTime.Parse(Console.ReadLine());
                                    Magazine magazine = new Magazine(ETitle, EAuthor, EDate);
                                    library.Add(magazine);
                                    i = false;
                                }
                                if (choose == 3)
                                {
                                    i = false;
                                }
                            }
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Enter Name:");
                            string EName = Console.ReadLine();
                            Console.WriteLine("Enter Address:");
                            string EAddress = Console.ReadLine();
                            Console.WriteLine("Enter Phone:");
                            string EPhone = Console.ReadLine();
                            User newUser = new User(EName, EAddress, EPhone);
                            library.AddUser(newUser);
                            break;
                        case 3:
                            bool y = true;
                            while (y)
                            {
                                Console.Clear();
                                Console.WriteLine("1. Borrow Book");
                                Console.WriteLine("2. Borrow Magazine");
                                Console.WriteLine("3. Exit");
                                Console.WriteLine("Choose Category:");
                                int choose = Convert.ToInt32(Console.ReadLine());
                                if (choose == 1)
                                {
                                    Console.Clear();
                                    Console.Write("Enter User Name: ");
                                    string BNameB = Console.ReadLine();
                                    Console.Write("Enter Book Title: ");
                                    string BBook = Console.ReadLine();
                                    User borrower = library.Users.Find(n => n.Name == BNameB);
                                    Book book = library.Categories.Find(b => b.Title == BBook) as Book;
                                    if (borrower != null && book != null)
                                    {
                                        library.Borrow(book, borrower);
                                    }
                                    else
                                    {
                                        Console.WriteLine("User or Book not found.");
                                    }
                                    y = false;
                                }
                                if (choose == 2)
                                {
                                    Console.Clear();
                                    Console.Write("Enter User Name: ");
                                    string BNameN = Console.ReadLine();
                                    Console.Write("Enter Magazine Title: ");
                                    string BNpaper = Console.ReadLine();
                                    User borrower = library.Users.Find(n => n.Name == BNameN);
                                    Magazine magazine = library.Categories.Find(m => m.Title == BNpaper) as Magazine;

                                    if (borrower != null && magazine != null)
                                    {
                                        library.Borrow(magazine, borrower);
                                    }
                                    else
                                    {
                                        Console.WriteLine("User or Magazine not found.");
                                    }
                                    y = false;
                                }
                                if (choose == 3)
                                {
                                    y = false;
                                }
                            }
                            break;
                        case 4:
                            bool x = true;
                            while (x)
                            {
                                Console.Clear();
                                Console.WriteLine("1. Return Book");
                                Console.WriteLine("2. Return Magazine");
                                Console.WriteLine("3. Exit");
                                Console.WriteLine("Choose Category:");
                                int choose = Convert.ToInt32(Console.ReadLine());
                                if (choose == 1)
                                {
                                    Console.Clear();
                                    Console.Write("Enter User Name: ");
                                    string RNameB = Console.ReadLine();
                                    Console.Write("Enter Book Title: ");
                                    string BBook = Console.ReadLine();
                                    User returner = library.Users.Find(n => n.Name == RNameB);
                                    Book book = library.Categories.Find(b => b.Title == BBook) as Book;
                                    if (returner != null && book != null)
                                    {
                                        library.Return(book, returner);
                                    }
                                    else
                                    {
                                        Console.WriteLine("User or Book not found.");
                                    }
                                    x = false;
                                }
                                if (choose == 2)
                                {
                                    Console.Clear();
                                    Console.Write("Enter User Name: ");
                                    string RNameN = Console.ReadLine();
                                    Console.Write("Enter Magazine Title: ");
                                    string RNpaper = Console.ReadLine();
                                    User retuner = library.Users.Find(n => n.Name == RNameN);
                                    Magazine magazine = library.Categories.Find(m => m.Title == RNpaper) as Magazine;

                                    if (retuner != null && magazine != null)
                                    {
                                        library.Return(magazine, retuner);
                                    }
                                    else
                                    {
                                        Console.WriteLine("User or Magazine not found.");
                                    }
                                    x = false;
                                }
                                if (choose == 3)
                                {
                                    x = false;
                                }
                            }
                            break;
                        case 5:
                            Console.Clear();
                            if (library.Categories.Any(book => book.Title != null))
                            {
                                library.ShowCategories();
                            }
                            else { Console.WriteLine("It's already exists in the library."); }
                            break;
                        case 6:
                            Console.Clear();
                            Console.Write("Enter User Name: ");
                            string SName = Console.ReadLine();

                            User showu = library.Users.Find(n => n.Name == SName);

                            if (showu != null)
                            {
                                library.ShowUserBorrowed(showu);
                            }
                            else
                            {
                                Console.WriteLine("User not found.");
                            }
                            break;
                        case 7:
                            Console.Clear();
                            Console.Write("Enter Title: ");
                            string STitle = Console.ReadLine();
                            Category category = library.Categories.Find(b => b.Title == STitle);
                            if (category != null)
                            {
                                library.Search(category);
                            }
                            else
                            {
                                Console.WriteLine(" It's not found.");
                            }
                            break;
                        case 8:
                            Console.Clear();
                            if (library.Users.Any(u => u.Name != null))
                            {
                                library.ShowUsers();
                            }
                            else { Console.WriteLine("It's already exists in the library."); }
                            break;
                        case 9:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid entry!! Please enter valid");
                            break;
                    }
                }
            }
        }

    }
}

