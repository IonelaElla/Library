using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Proiect
{
    class AbstractElemFactory
    //creaza diferite tipuri de elemente carte/revista)
    //Această clasă va furniza metoda de adaugare a unui element în funcție de tipul ales de utilizator.
    //Aici am mai creat si clasa ParamFactory :

 
    {
        private static AbstractElemFactory singleton;

        private AbstractElemFactory() { }
        public static AbstractElemFactory Instance()
        {
            if (singleton == null)
                singleton = new AbstractElemFactory();
            return singleton;
        }

        public AbstractElem CreateElemConcret(int tip, string id, string title, string autor,double taxa)
        {
            
            switch (tip)
            {
                //poti sa creezi alte obiecte 
                case 1:
                    return new Book(id, autor, title); 
                case 2:
                    return new Magazine(id, title);
                case 3:
                    return new ElemCuTaxa(new ElemInRoom(new Book(id, autor, title), taxa)); //carte sala taxa
                case 4:
                    return new ElemCuTaxa(new Book(id, autor, title), taxa); //carte taxa
                case 5:
                    return new Magazine(id, title); //revista
                case 6:
                    return new ElemInRoom(new Magazine(id, title)); //revista sala
                case 7:
                    return new ElemCuTaxa(new ElemInRoom(new Magazine(id, title), taxa)); //revista sala taxa
                case 8:
                    return new ElemCuTaxa(new Magazine(id, title), taxa); //revista taxa


            }
            return default;
        }

      


        public AbstractElem CreateElemConcret(ParamFactory p)
        {
            //creaza/initializeaza obiectul 
            //BookParamFactory si MagazineParamFactory initializeaza parametri care sunt trimisi dupa la crearea de obiecte carte/revista

            if (p.GetType() == typeof(BookParamFactory))
            {
                BookParamFactory book = (BookParamFactory)p;
                return new Book(book.Id, book.Title, book.Author);
            }
            else
            {
                MagazineParamFactory mag = (MagazineParamFactory)p;
                return new Magazine(mag.Id, mag.Title);
            }
            
        }
    }
}