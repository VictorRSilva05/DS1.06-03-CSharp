using ConsoleApp2;
using System;
using System.Collections.Generic;

class Program
{
    //Victor Rafael da Silva
    Program()
    {
        Library library = new Library();

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("1. Register a reader");
            Console.WriteLine("2. Add books to a reader");
            Console.WriteLine("3. Remove a book from a reader");
            Console.WriteLine("4. Donate a book to another reader");
            Console.WriteLine("5. List all readers and their books");
            Console.WriteLine("6. List a single reader and their books");
            Console.WriteLine("7. Exit");
            Console.Write("Option: ");

            int option;
            if (int.TryParse(Console.ReadLine(), out option))
            {
                switch (option)
                {
                    case 1:
                        library.RegisterReader();
                        break;
                    case 2:
                        library.AddBooks();
                        break;
                    case 3:
                        library.RemoveBook();
                        break;
                    case 4:
                        library.DonateBook();
                        break;
                    case 5:
                        library.ListAllReaders();
                        break;
                    case 6:
                        library.ListReader();
                        break;
                    case 7:
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid option.");
            }
        }
    }
    static void Main(string[] args)
    {
        _  = new Program();
    }
}


