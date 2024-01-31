// În clasa DisplayFormat2
using Proiect;

class DisplayFormat2 : IAbstractElemVisitor
{
    public string Visit(AbstractElem elem)
    {
        return $"\nElement: {elem.Id}, Titlu: {elem.Titlel}, Împrumutat de: {elem.BorrowBy}";
    }

    public string Visit(Book book)
    {

        return "\nCARTEA: " + "\n\tid: " + book.Id + "\n\ttitlul: " + book.Titlel + "\n\tautorul: " + book.author;

    }

    public string Visit(Magazine magazine)
    {
        return "\nREVISTA:" + "\n\tid: " + magazine.Id + "\n\ttitlul: " + magazine.Titlel;

    }

    public string Visit(ElemInRoom elemInRoom)
    {
        string mesaj = "disponibil doar in sala de lectura";
        if (elemInRoom.AbstractElem is Book)
        {
            return "\nCartea " + elemInRoom.AbstractElem.Id + " author: " + ((Book)elemInRoom.AbstractElem).author + " titlu " + elemInRoom.AbstractElem.Titlel + mesaj;
        }
        else
        //if(elemInSala.AbstractElem is Revista)
        {
            return "\revista " + elemInRoom.AbstractElem.Id + " titlu " + elemInRoom.AbstractElem.Titlel + mesaj;

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

