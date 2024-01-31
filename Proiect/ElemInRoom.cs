using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect
{
     class ElemInRoom : AbstractElem
    {
        private AbstractElem abstractElem;
        private Boolean inSala;
        private double taxa;

        public bool InSala { get => inSala; set => inSala = value; }
        internal AbstractElem AbstractElem { get => abstractElem; set => abstractElem = value; }


        public ElemInRoom(AbstractElem abstractElem)
        {
            this.abstractElem = abstractElem;
            this.inSala = true;
        }

        public ElemInRoom(AbstractElem abstractElem, double taxa)
        {
            this.abstractElem = abstractElem;
            this.inSala = true;
            this.taxa = taxa;
        }

        public override string AfisElem()
        {
            return "\nElementul: " + base.AfisElem() +
                    ", in sala: " + InSala;
        }

        public override string Accept(IAbstractElemVisitor viz)
        {
            //obiectul vizitator primit ca parametru "viziteaza" obiectul curent
            return viz.Visit(this);
        }
    }
}