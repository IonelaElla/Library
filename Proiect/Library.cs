using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Proiect
{
    class Library
    {
        //Facade acesta ascunde complexitatea internă reducerea complexitati 
        //Mem Book cat.Membook

        // nu este necesară instanțierea multiplă a obiectelor din această clasă.
        // În cadrul aplicației este necesară o singură instanță a unui obiect din clasa Biblioteca
        // CatalogueElem, CataloqueMember, și clasa AbstractElemFactory.

        
        private static Library singleton;
        private CatalogueElem cataloqueElem = CatalogueElem.Instance();
        private CataloqueMember cataloqueMember = CataloqueMember.Instance();
        private const double COST_PENALIZARE = 5;
        private Library()
        {

        }
        public static Library Instance()
        {
            if (singleton == null)
                singleton = new Library();
            return singleton;
        }
        public Book AddBook(string id, string title, string author)
        {
            Book book = new Book(id, title, author);
            if (cataloqueElem.AddElem(book))
                return book;
            else
                return null;
        }

        public AbstractElem AddElemP(ParamFactory p)
        {
            AbstractElemFactory abstractElemFactory = AbstractElemFactory.Instance();
            AbstractElem elem = abstractElemFactory.CreateElemConcret(p);
            if (cataloqueElem.AddElem(elem))
                return elem;
            else
                return null;
        }

        public AbstractElem AddElemT(int tip, string id, string titlu, string autor, double taxa)
        {
            AbstractElemFactory abstractElemFactory = AbstractElemFactory.Instance();
            AbstractElem elem = abstractElemFactory.CreateElemConcret(tip, id, titlu, autor, taxa);
            if (cataloqueElem.AddElem(elem))
                return elem;
            else
                return null;
        }
        public void ShowCatalogMember(DisplayFormat format)//afisam elementele catalogului in funcție de formatul ales
        {
            foreach (AbstractElem elem in cataloqueElem.GetElemList())//se itereaza printre elementele catalogului

            {
                elem.Accept(format);
            }
        }
        public void DisplayElem(IAbstractElemVisitor format)
        {

            Console.WriteLine("\nCatalogul contine urmatoarele elemente: " + cataloqueElem.ShowCataloqueBooks(format));
        }

        public Member AddMember(string id, string name, string addres, string phone) //metode de adaugare a unui membru in colectie
        {
            Member membru = new Member(id, name, addres, phone); //se creaza un obiect de tip membru 
            if (cataloqueMember.AddMember(membru)) //se adaugă elemental dacă nu există deja 
                return membru; //se returnează obiectul
            else
                return null; //altfel se returneaza null 
        }

        public void DisplayMembers()//metoda de listare a catalogului de membri
        {
            Console.WriteLine("\nMembrii bibliotecii sunt:" + cataloqueMember.ShowMembersCatalogue());
        }

        public AbstractElem BorrowElem(string idBook, string idMember)
        {
            AbstractElem element = cataloqueElem.SearchElem(idBook);
            Member membru = cataloqueMember.SearchMember(idMember);
            if (element != null && membru != null)
            {
                if (element.BorrowBy != null)
                {
                    Console.WriteLine("Elementul este imprumutat");
                }
                else
                {
                    Boolean borrowBook = membru.BorrowElem(element);
                    Tranzaction tranzaction = new Tranzaction(DateTime.Now, "imprumuta carte");
                    membru.AddTranzaction(tranzaction);
                    element.BorrowElem(membru);
                }
            }

            return element;
        }

        public void ShowListElemImprintedMember(string idMembru)
        {
            Member membru = cataloqueMember.SearchMember(idMembru);
            if (membru != null)
            {
                
                Console.WriteLine(membru.ShowListElemImpintedMember());
            }
        }

        public bool RemoveElem(string idElem)
        {
            AbstractElem element = cataloqueElem.SearchElem(idElem);
            if (element != null)
            {
                if (element.verifyHold() == false && element.verifyHold() == false)
                {
                    //Console.WriteLine("elimina carte result:" + catalogDeCarti.EliminaCarte(idCarte));
                    return cataloqueElem.EliminaElem(idElem);
                }
            }
            return false;
        }

        public bool ReturnElem(string idElem)
        {
            AbstractElem element = cataloqueElem.SearchElem(idElem);
            if (element != null)
            {
                if (element.BorrowBy != null)
                {
                    Member membru = element.BorrowBy;
                    membru.ReturneazaElem(element);
                    Tranzaction tranzactie = new Tranzaction(DateTime.Now, "returneaza carte");
                    membru.AddTranzaction(tranzactie);
                    double penalizare = element.Penalizare();
                    membru.AdaugaPenalizare(penalizare * COST_PENALIZARE);

                    switch (penalizare)
                    {
                        case 1:
                            Console.WriteLine("Membrul a fost penalizat o data");
                            break;
                        case 2:
                            Console.WriteLine("Membrul a fost penalizat de doua ori");
                            break;
                        default:
                            Console.WriteLine("Membrul a facut returnarea la timp");
                            break;
                    }
                    if (element.verifyHold())
                    {
                        Console.WriteLine("Cartea are retineri");
                        element.ProcesareRetinere();
                    }
                    else
                        Console.WriteLine("Cartea nu are retineri");
                    return true;
                }
                else
                {
                    Console.WriteLine("Elementul nu este imprumutat");
                    return false;
                }
            }
            else
                return false;
        }

        public Hold PlacementHold(string idMembru, string idElem, DateTime dataLImita)
        {
            AbstractElem element = cataloqueElem.SearchElem(idElem);
            Member membru = cataloqueMember.SearchMember(idMembru);
            if (element != null && membru != null)
            {
                if (element.verifyBorrow() == false)
                {
                    Hold hold = new Hold(element, dataLImita, membru);
                    element.AddHold(hold);
                    membru.AddHold(hold);
                    Tranzaction tranzaction = new Tranzaction(DateTime.Now, "imprumuta carte");
                    membru.AddTranzaction(tranzaction);
                    return hold;
                }
            }
            return null;
        }


        public string RemoveHold(string idElem, string idMembru)
        {
            AbstractElem elem = cataloqueElem.SearchElem(idElem);
            Member member = cataloqueMember.SearchMember(idMembru);
            if (member != null)
            {
                if (elem != null)
                {
                    if (elem.Hold.Count == 0)
                    {
                        return "Elementul nu are retineri.";
                    }
                    else
                    {
                        Tranzaction tranzaction = new Tranzaction(DateTime.Now, "elimina retinere");
                        member.AddTranzaction(tranzaction);
                        if (elem.RemoveHold(member))
                            return "Eliminarea retinerii s-a realizat cu succes.";
                        else
                            return "Retinerea nu a fost gasita.";
                    }
                }
                else
                {
                    return "Elementul nu a fost gasit.";
                }
            }
            return "Membrul nu a fost gasit.";
        }

    }
}
