using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect
{
    internal interface IAbstractElemVisitor
    {

        //functionalitatea vizitari afisarii,se pot adauga operatii polimorfice in classe fara a modifica clasele

        //metode specifice de "vizitare" (afisare in aceasta aplicatie)
        //functie de tipul de obiect vizitat
        //Prin utilizarea unui sablon de proiectare Visitor, se permite adăugarea de noi operații fără a modifica clasele existente

        string Visit(AbstractElem elem);
        string Visit(Book book);
        string Visit(Magazine magazine); 

        string Visit(ElemInRoom elemInRoom);

        string Visit(ElemCuTaxa elemCuTaxa);




        //este metoda prin care clasa accepta un vizitator
    }
}
