using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Library
    {
        //Victor Rafael da Silva
        private List<Reader> Readers = new List<Reader>();

        public void RegisterReader()
        {
            Console.WriteLine();
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("CPF: ");
            string cpf = Console.ReadLine();

            if (Readers.Exists(l => l.Cpf == cpf))
            {
                Console.WriteLine("CPF already exists.");
                return;
            }

            Reader newReader = new Reader(name, cpf);
            Readers.Add(newReader);
            Console.WriteLine("Reader successfully registered!");
        }

        public void AddBooks()
        {
            Console.WriteLine();
            Console.Write("CPF: ");
            string cpf = Console.ReadLine();

            Reader reader = Readers.Find(l => l.Cpf == cpf);
            if (reader == null)
            {
                Console.WriteLine("Reader could not be found.");
                return;
            }

            Console.Write("Enter the book title: ");
            string book = Console.ReadLine();
            reader.Books.Add(book);
        }

        public void RemoveBook()
        {
            Console.WriteLine();
            Console.Write("CPF: ");
            string cpf = Console.ReadLine();

            Reader reader = Readers.Find(l => l.Cpf == cpf);
            if (reader == null)
            {
                Console.WriteLine("Reader could not be found.");
                return;
            }

            Console.Write("Enter the title of the book: ");
            string lostBook = Console.ReadLine();
            if (reader.Books.Remove(lostBook))
            {
                Console.WriteLine("Book successfully removed.");
            }
            else
            {
                Console.WriteLine("Book could not be found on the readers list");
            }
        }

        public void DonateBook()
        {
            Console.WriteLine();
            Console.Write("Enter the CPF of the donor: ");
            string donorCpf = Console.ReadLine();

            Reader reader1 = Readers.Find(l => l.Cpf == donorCpf);
            if (reader1 == null)
            {
                Console.WriteLine("Reader was not found.");
                return;
            }

            Console.WriteLine();
            Console.Write("Enter the CPF of the receiver: ");
            string ReceiverCpf = Console.ReadLine();

            Reader reader = Readers.Find(l => l.Cpf == ReceiverCpf);
            if (reader == null)
            {
                Console.WriteLine("Reader was not found.");
                return;
            }

            Console.Write("Enter the title of the book that's going to be donated: ");
            string donatedBook = Console.ReadLine();
            reader.Books.Add(donatedBook);
            reader1.Books.Remove(donatedBook);
            Console.WriteLine("Book successfully donated!.");
        }

        public void ListAllReaders()
        {
            Console.WriteLine();
            Console.WriteLine("Readers and books:");
            foreach (var reader in Readers)
            {
                Console.WriteLine($"Name: {reader.Name}, CPF: {reader.Cpf}");
                Console.WriteLine("Books:");
                foreach (var book in reader.Books)
                {
                    Console.WriteLine($"- {book}");
                }
                Console.WriteLine();
            }
        }

        public void ListReader()
        {
            Console.WriteLine();
            Console.Write("Enter the CPF of the reader: ");
            string cpf = Console.ReadLine();

            Reader reader = Readers.Find(l => l.Cpf == cpf);
            if (reader == null)
            {
                Console.WriteLine("Reader could not be found.");
                return;
            }

            Console.WriteLine($"Nome: {reader.Name}, CPF: {reader.Cpf}");
            Console.WriteLine("Livros:");
            foreach (var book in reader.Books)
            {
                Console.WriteLine($"- {book}");
            }
        }
    }
}
