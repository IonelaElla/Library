using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect
{
     class Magazine : AbstractElem
    {
        public Magazine(string id, string title, bool limitedStockForBlackFriday) : base(id, title)
        {
        }

        public Magazine(string id, string title) : base(id, title)
        {
        }

        public bool LimitedStockForBlackFriday { get; set; }

        public override String DisplayElement()
        {
            return "\nRevista: " + base.DisplayElement();
        }
         // public Magazine(MagazineParamFactory magazineParamFactory) : base(magazineParamFactory.Id, magazineParamFactory.Title);


        public override string Accept(IAbstractElemVisitor viz)
        {
            //obiectul vizitator primit ca parametru "viziteaza" obiectul curent
            return viz.Visit(this);
        }
    }
}
