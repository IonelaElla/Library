using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect
//Factory Ca sa deculpam procesul de creara de obiecte de restl aplicatiei

// creaza dif. tip de elem(revista/carte) din asta dervam clase concrete
//derivam clase concrete(revista/carte) 
//Ap implmentam clasa magazine si mostenim proprietatiilt din abstact
//Abstractelemfactory



{
    abstract class AbstractElem : ICompare<string>
    {
        private String id;
        private String Title;
        private Nullable<DateTime> dataReturn;
        private Member borrowBy;
        private List<Hold> holds = new List<Hold>();


        protected AbstractElem(string id, string title)
        {
            this.id = id;
            Title = title;
        }
        public virtual string AfisElem()
        {
            return "id: " + Id +
                    ", titlu: " + Title;
        }

        public AbstractElem() { }

        public string Id { get => id; set => id = value; }
        public string Titlel { get => Title; set => Title = value; }
        public List<Hold> Hold { get => holds; set => holds = value; }
        
        public Member BorrowBy { get => borrowBy; set => borrowBy = value; }

        public DateTime? DataReturn { get => dataReturn; set => dataReturn = value; }

        public bool Compara(string id)
        {
            return this.Id.Equals(id);
        }
      
        public virtual string DisplayElement()
        {
            return "id: " + Id +
                    ", titlu: " + Title;
        }
      
        
        public bool BorrowElem(Member member)
        {
            borrowBy = member;
            DataReturn = DateTime.Now.AddDays(14);
            return true;
        }
        public bool verifyBorrow()
        {
            if (borrowBy != null)
                return true;
            return false; //nu este imprumutata
        }
        public bool verifyHold()
        {
            if (holds.Count() == 0)
                return false; //nu sunt retineri
            return true;
        }

        public void RemoveBorrow()
        {
            borrowBy = null;
            DataReturn = null;
        }
        public void AddHold(Hold hold)
        {
            holds.Add(hold);
        }
        public bool RemoveHold(Member membru)
        {
            foreach (Hold hold in Hold)
            {
                if (hold.Member.Compara(membru.Id))
                    return Hold.Remove(hold);
            }
            return false;
        }
        public int Penalizare()
        {
            // Verificăm dacă diferența dintre data curentă și DataReturn este mai mare decât 0 zile

            if (((TimeSpan)(DateTime.Now.Date - DataReturn)).Days > 0)
            {
                // Verificăm dacă lista Hold nu conține nicio intrare

                if (Hold.Count == 0)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
            else
            {
                // Dacă diferența dintre data curentă și DataReturn nu este mai mare decât 0 zile, returnează 0

                return 0;
            }
        }
        public void ProcesareRetinere()
        {

        }

        public virtual string Accept(IAbstractElemVisitor viz)
        {
            //obiectul vizitator primit ca parametru "viziteaza" obiectul curent
            return viz.Visit(this);

        }
    }
}
