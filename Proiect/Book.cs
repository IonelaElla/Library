using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect
{
     class Book : AbstractElem { 

        public int id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public double Discount { get; set; }
        public bool LimitedStockForBlackFriday { get; set; }

        // public Book() { }
        public Book(int id, string title, string author)
        {
            this.id = id;
            this.title = title;
            this.author = author;
        }

        public Book(BookParamFactory bookParamFactory) : base(bookParamFactory.Id, bookParamFactory.Title)
        {
            this.author = bookParamFactory.Author;
        }
        public Book(string id, string title, string author): base(id,title)
        {
           
            this.author = author;
        }
        public bool Compare(string id)
        {
            return id.Equals(id);
        }

        public bool Compara(string id)
        {
            throw new NotImplementedException();
        }
        //Ca sa nu hardcodez ci sa il pot detasa de implementarea claselor putand diferite clase de vizitator

   
        public override string Accept(IAbstractElemVisitor viz)  //este metoda prin care clasa accepta un vizitator
        {
            //obiectul vizitator primit ca parametru "viziteaza" obiectul curent
            return viz.Visit(this);
        }


    }
}
