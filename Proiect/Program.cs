using Proiect;
using System;

namespace Project
{
    class Program
    {
        private static Library library = Library.Instance();

        static void Main(string[] args)
        {
            InitializeBookCatalog();
            InitializeMemberCatalog();
            Menu();
        }

        public static void Menu()
        {
            int option;
            do
            {
                Console.WriteLine("\n\n......Menu......");
                Console.WriteLine("1. Add a book");
                Console.WriteLine("2. Add a member");
                Console.WriteLine("3. Display the book catalog");
                Console.WriteLine("4. Display the member catalog");
                Console.WriteLine("5. Borrow a book");
                Console.WriteLine("6. Exit the program");
                Console.WriteLine("7. Display the list of books borrowed by a member");
                Console.WriteLine("8. Remove a book");
                Console.WriteLine("9. Return a book");
                Console.WriteLine("10. Place a hold");
                Console.WriteLine("11. Remove a hold");

                Console.WriteLine("\nEnter an option: ");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        AddBook();
                        break;
                    case 2:
                        AddMember();
                        break;
                    case 3:
                        DisplayFormattedBooks();
                        break;
                    case 4:
                        library.DisplayMembers();
                        break;
                    case 5:
                        BorrowBook();
                        break;
                    case 7:
                        DisplayListOfBooksBorrowedByMember();
                        break;
                    case 8:
                        RemoveBook();
                        break;
                    case 9:
                        ReturnBook();
                        break;
                    case 10:
                        PlaceHold();
                        break;
                    case 11:
                        RemoveHold();
                        break;
                    default:
                        Console.WriteLine("\nYou chose to exit the program...");
                        break;
                }
            } while (option != 0);
        }

        public static class ProgramFeedback
        {
            public static readonly string SuccessAddBook = "The book was added successfully.";
            public static readonly string SuccessAddMember = "The member was added successfully.";
            public static readonly string ErrorAddBook = "!!The book could not be added.";
            public static readonly string ErrorAddMember = "!!The member could not be added.";
            public static readonly string SuccessBorrowBook = "The book was borrowed successfully.";
            public static readonly string ErrorBorrowBook = "!!The book could not be borrowed.";
            public static readonly string SuccessRemoveBook = "The book was removed successfully.";
            public static readonly string ErrorRemoveBook = "The book could not be removed.";
            public static readonly string SuccessReturnBook = "The book was returned successfully.";
            public static readonly string ErrorReturnBook = "!!The book could not be returned.";
            public static readonly string SuccessPlaceHold = "The hold was placed successfully.";
            public static readonly string ErrorPlaceHold = "!!The hold could not be placed.";
        }

        public static void InitializeBookCatalog()
        {
            library.AddElemT(1, "101", "Mara", "Ioan Slavici", 12);
            library.AddElemT(1, "102", "Childhood Memories", "Ion Creanga", 15);
            library.AddElemT(5, "133", "Magazine 1", null, 25);
            library.AddElemT(5, "134", "Magazine 2", null, 10);
        }

        public static void InitializeMemberCatalog()
        {
            library.AddMember("10", "Marcus Bem", "0746453356", "Oradea, Avram Street, No. 12");
            library.AddMember("11", "Aurelian Noe", "0789462537", "Satu Mare, Main Street, No. 5");
        }

        public static void AddBook()
        {
            string id, title, author;

            Console.Write("\nId:");
            id = Console.ReadLine();
            Console.Write("Title:");
            title = Console.ReadLine();
            Console.Write("Author:");
            author = Console.ReadLine();
            if (library.AddBook(id, title, author) != null)
            {
                Console.Write(ProgramFeedback.SuccessAddBook);
            }
            else
                Console.Write(ProgramFeedback.ErrorAddBook);
        }

        public static void AddMember()
        {
            string id, name, address, phone;
            Console.Write("\nId:");
            id = Console.ReadLine();
            Console.Write("Name:");
            name = Console.ReadLine();
            Console.Write("Address:");
            address = Console.ReadLine();
            Console.Write("Phone:");
            phone = Console.ReadLine();
            if (library.AddMember(id, name, address, phone) != null)
            {
                Console.Write(ProgramFeedback.SuccessAddMember);
            }
            else
                Console.Write(ProgramFeedback.ErrorAddMember);
        }

        public static void BorrowBook()
        {
            string idBook, idMember;
            Console.Write("\nBook Id:");
            idBook = Console.ReadLine();
            Console.Write("Member Id:");
            idMember = Console.ReadLine();

            if (library.BorrowElem(idBook, idMember) != null)
            {
                Console.Write(ProgramFeedback.SuccessBorrowBook);
            }
            else
                Console.Write(ProgramFeedback.ErrorBorrowBook);
        }

        public static void DisplayListOfBooksBorrowedByMember()
        {
            string idMember;
            Console.Write("Member Id:");
            idMember = Console.ReadLine();
            library.ShowListElemImprintedMember(idMember);
        }

        public static void RemoveBook()
        {
            string idBook;
            Console.Write("Book Id:");
            idBook = Console.ReadLine();
            if (library.RemoveElem(idBook))
            {
                Console.WriteLine(ProgramFeedback.SuccessRemoveBook);
            }
            else
                Console.WriteLine(ProgramFeedback.ErrorRemoveBook);
        }

        public static void ReturnBook()
        {
            string idBook;
            Console.Write("Book Id:");
            idBook = Console.ReadLine();
            if (library.ReturnElem(idBook))
            {
                Console.WriteLine(ProgramFeedback.SuccessReturnBook);
            }
            else
                Console.WriteLine(ProgramFeedback.ErrorReturnBook);
        }

        public static void PlaceHold()
        {
            string idBook, idMember;
            Console.Write("\nBook Id:");
            idBook = Console.ReadLine();
            Console.Write("Member Id:");
            idMember = Console.ReadLine();

            DateTime dueDate;
            Console.WriteLine("Due Date: ");
            dueDate = DateTime.Parse(Console.ReadLine());

            if (library.PlacementHold(idMember, idBook, dueDate) != null)
            {
                Console.WriteLine(ProgramFeedback.SuccessPlaceHold);
            }
            else
            {
                Console.WriteLine(ProgramFeedback.ErrorPlaceHold);
            }
        }
        public static void RemoveHold()
        {
            string idBook, idMember;
            Console.Write("\nMember Id: ");
            idMember = Console.ReadLine();
            Console.Write("Book Id: ");
            idBook = Console.ReadLine();
            Console.WriteLine(library.RemoveHold(idBook, idMember));
        }

        public static void DisplayFormattedBooks()
        {
            int formatId;
            Console.WriteLine("Choose display format: ");
            Console.WriteLine("1. Format 1 - format initial display vertically");
            Console.WriteLine("2. Format 2 - format de rezerva(blackfriday)display horizontally");
            formatId = Convert.ToInt32(Console.ReadLine());
            switch (formatId)
            {
                case 1:
                    DisplayFormat format1 = new DisplayFormat();
                    library.DisplayElem(format1);
                    break;
                case 2:
                    DisplayFormat2 format2 = new DisplayFormat2();
                    library.DisplayElem(format2);
                    break;
                default:
                    break;
            }
        }
    }
}
