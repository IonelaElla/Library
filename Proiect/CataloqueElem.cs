using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect
{   class CatalogueElem : ListElem<AbstractElem, string>
    {
        private static CatalogueElem singleton;
        private CatalogueElem() { }
        public static CatalogueElem Instance()
        {
            if (singleton == null)
                singleton = new CatalogueElem();
            return singleton;
        }
        public bool AddElem(AbstractElem element)
        {
            return base.Add(element, element.Id);
        }
        public AbstractElem SearchElem(string id)
        {
            return base.Search(id);
        }
        public Boolean EliminaElem(string id)
        {
            return base.Delete(id);
        }
        public List<AbstractElem> GetElem()
        {
            return base.GetElemList();
        }
        public string ShowCataloqueBooks(IAbstractElemVisitor format)
        {
            string cataloque = "";
            foreach (AbstractElem element in GetElem())
            {
                cataloque += element.Accept(format);
            }
            return cataloque;
        }
        public string DisplayElementCataloque(DisplayFormat formatAfisare)
        {
            string mesaj = "";
            foreach (AbstractElem element in GetElem())
            {
                mesaj += element.DisplayElement();
            }
            return mesaj;
        }
    }

}