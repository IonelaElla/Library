using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect
{
    class DisplayFormat : IAbstractElemVisitor
    {
        public string Visit(AbstractElem elem)
        {
            return "\nElementul " + elem.Id + ", " + elem.Titlel + ", " + elem.BorrowBy;
        }

        public string Visit(Book book)
        {
            return "\nCARTEA: " + book.Id + ", " + book.Titlel + ", " + book.author;
        }

        public string Visit(Magazine magazine)
        {
            return "\nREVISTA: " + magazine.Id + ", " + magazine.Titlel;
        }

        public string Visit(ElemInRoom elemInSala)
        {
            string mesaj = "disponibil doar in sala de lectura";
            if (elemInSala.AbstractElem is Book)
            {
                return "\nCartea " + elemInSala.AbstractElem.Id + " author: " + ((Book)elemInSala.AbstractElem).author + " titlu " + elemInSala.AbstractElem.Titlel + mesaj;
            }
            else
            //if(elemInSala.AbstractElem is Revista)
            {
                return "\revista " + elemInSala.AbstractElem.Id + " titlu " + elemInSala.AbstractElem.Titlel + mesaj;

            }
        }

        public string Visit(ElemCuTaxa elemCuTaxa)
        {
            string mesaj = "disponibil cu taxa";
            if (elemCuTaxa.AbstractElem is Book)
            {
                return "\nCartea " + elemCuTaxa.AbstractElem.Id + " author: " + ((Book)elemCuTaxa.AbstractElem).author + " titlu " + elemCuTaxa.AbstractElem.Titlel + mesaj;
            }
            else

            {
                return "\revista " + elemCuTaxa.AbstractElem.Id + " titlu " + elemCuTaxa.AbstractElem.Titlel + mesaj;

            }
        }
    }
}