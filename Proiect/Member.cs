using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect
{
     class Member : ICompare<string>
    {

        public string id;
        public string name;
        public string phone;
        public string address;
        private double penalties = 0;
        private List<AbstractElem> listaElemImprumutate = new List<AbstractElem>();
        private List<Tranzaction> listaTranzactii = new List<Tranzaction>();
        private List<Hold> listaRetineri = new List<Hold>();


        public Member(String id, string name, string phone, string address)
        {
            this.id =id;
            this.name = name;
            this.phone = phone;
            this.address = address;
        }
        public String Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Phome { get => phone; set => phone = value; }
        public string Address { get => address; set => address = value; }
        internal List<AbstractElem> ListBorrowElem { get => listaElemImprumutate; set => listaElemImprumutate = value; }
        internal List<Tranzaction> ListaTranzactii { get => listaTranzactii; set => listaTranzactii = value; }
        internal List<Hold> ListaRetineri { get => listaRetineri; set => listaRetineri = value; }
        public double Penalties { get => penalties; set => penalties = value; }

      
        public bool Compara(string id)
        {
            return this.Id.Equals(id);
        }
        public bool BorrowElem (AbstractElem elem)
        {
            ListBorrowElem.Add(elem);

            return true;
        }

        public void AddTranzaction(Tranzaction tranzaction)
        {
            ListaTranzactii.Add(tranzaction);
        }

        public string ShowListElemImpintedMember()
        {
            string message = "";
            foreach (AbstractElem elem in ListBorrowElem)
            {
                message += elem.DisplayElement();
            }
            return message;
        }

        public void ReturneazaElem(AbstractElem elem)
        {
            listaElemImprumutate.Remove(elem);
        }

        public void AdaugaPenalizare(double penalizare)
        {
            Penalties = Penalties + penalties;
        }

        
        public override string ToString()
        {
            return "\nid: " + Id +
                    ", nume: " + name +
                    ", telefon: " + phone +
                    ", adresa: " + address +
                    ", penalizari: " + penalties;
        }
        public void AddHold(Hold hold)
        {
            listaRetineri.Add(hold);
        }
    }
}