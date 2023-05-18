using System;
using System.Collections.Generic;

namespace Homework_number_42
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string СommandAdd = "1";
            const string CommandRemove = "2";
            const string CommandShowBooks = "3";
            const string CommandShowBooksToYear = "4";
            const string CommandShowBooksToAuthor = "5";
            const string CommandExit = "6";

            Repository repository = new Repository();

            bool isExit = false;
            string userInput;

            while (isExit == false)
            {
                Console.WriteLine("Меню\n" +
                           "\nДоступные команды\n\n" +
                           $"1) Для добавления книги в хранилище нажмите: {СommandAdd}\n\n" +
                           $"2) Для удаление книги в хранилище нажмите: {CommandRemove}\n\n" +
                           $"3) Что бы показать весь список книг нажмите: {CommandShowBooks}\n\n" +
                           $"4) Что бы показать список книг по году выпуска нажмите: {CommandShowBooksToYear}\n\n" +
                           $"5) Что бы показать список книг по одному автору нажмите: {CommandShowBooksToAuthor}\n\n" +
                           $"6) Для того что бы закрыть приложение нажмите {CommandExit}\n\n" +
                           $"Укажите команду: ");

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case СommandAdd:
                        repository.Add();
                        break;

                    case CommandRemove:
                        repository.Remove();
                        break;

                    case CommandShowBooks:
                        repository.ShowBooks();
                        break;

                    case CommandShowBooksToYear:
                        repository.ShowBooksToYear();
                        break;

                    case CommandShowBooksToAuthor:
                        repository.ShowBooksToAuthor();
                        break;

                    case CommandExit:
                        isExit = true;
                        break;

                    default:
                        Console.WriteLine("Такой команды нет в наличии!");
                        break;
                }
            }
        }
    }

    class Book
    {
        public Book(string title, string author, int yearProduction)
        {
            Title = title;
            Author = author;
            YearProduction = yearProduction;
        }

        public string Title { get; private set; }
        public string Author { get; private set; }
        public int YearProduction { get; private set; }
    }

    class Repository
    {
        private List<Book> _books = new List<Book>();

        public void Add()
        {
            ShowMessage("Укажите название книги: ", ConsoleColor.Blue);
            string title = Console.ReadLine();

            ShowMessage("Укажите автора книги: ", ConsoleColor.Blue);
            string author = Console.ReadLine();

            int yearProduction = GetNumber("Укажите го выпуска:");

            _books.Add(new Book(title, author, yearProduction));

            ShowMessage("Книга успешно добавлена");
        }

        public void Remove()
        {
            ShowMessage("Укажите название книги для её удаления: ", ConsoleColor.Blue);
            string title = Console.ReadLine();

            if (TryGetBook(out Book book, title) == true)
            {
                _books.Remove(book);

                ShowMessage("Книга успешно удалена");
            }
        }

        public void ShowBooks()
        {
            for (int i = 0; i < _books.Count; i++)
            {
                ShowMessage($"Название:{_books[i].Title} Автор: {_books[i].Author} Год выпуска: {_books[i].YearProduction}");
            }
        }

        public void ShowBooksToYear()
        {
            int yearProduction = GetNumber("Укажите год выпуска:");

            for (int i = 0; i < _books.Count; i++)
            {
                if (_books[i].YearProduction == yearProduction)
                {
                    ShowMessage($"Название:{_books[i].Title} Автор: {_books[i].Author} Год выпуска: {_books[i].YearProduction}");
                }
            }
        }

        public void ShowBooksToAuthor()
        {
            ShowMessage("Укажите автора книги: ", ConsoleColor.Blue);
            string author = Console.ReadLine();

            for (int i = 0; i < _books.Count; i++)
            {
                if (_books[i].Author == author)
                {
                    ShowMessage($"Название:{_books[i].Title} Автор: {_books[i].Author} Год выпуска: {_books[i].YearProduction}");
                }
            }
        }

        private bool TryGetBook(out Book book, string title)
        {
            book = null;

            for (int i = 0; i < _books.Count; i++)
            {
                if (_books[i].Title == title)
                {
                    book = _books[i];

                    return true;
                }
            }

            ShowMessage("Такой книги нет в базе!");

            return false;
        }

        private void ShowMessage(string text, ConsoleColor consoleColor = ConsoleColor.Green)
        {
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        private int GetNumber(string title)
        {
            bool isNumber = false;
            string userInput;
            int number = 0;

            while (isNumber == false)
            {
                ShowMessage(title, ConsoleColor.Blue);
                userInput = Console.ReadLine();

                if (int.TryParse(userInput, out number))
                {
                    isNumber = true;
                }
                else
                {
                    ShowMessage("Не верный формат вода", ConsoleColor.Red);
                }
            }

            return number;
        }
    }
}
