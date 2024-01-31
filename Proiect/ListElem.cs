using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect

{//clasa de colectie generica
    class ListElem<T, K> where T : ICompare<K>
        //T - tipul elementului din colectie
        //k - tipul coampului din cadrul elementelor colectie utillizat in comaratie
    {
        public static List<T> lista = new List<T>();//cream lista

        public List<T> GetElemList()//return
        {
            return lista;
        }
        //metoda de cautare dupa id, implementeaza functia Compara din interfata IComparare

        public T Search(K id)
        {
            foreach (T elem in lista)
            {
                if (elem.Compara(id))
                    return elem;
            }
            return default;

        }

        //metoda de adaugare, se adauga elemente de tipul T, si K(tipul campului)
        public bool Add(T entity, K id)
        {
            if (Search(id) == null)
            {
                lista.Add(entity);
                return true;
            }
            return false;
        }

        public bool Delete(K id)
        {
            //se elimina obiectul care corespunde id-ului din lista
            return lista.Remove(Search(id));

        }
    }
}
