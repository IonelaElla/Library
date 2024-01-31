using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect
{
    //reduce numarul de clase generice
     class ElemCuTaxa:AbstractElem
    {
           
        private double taxa;
        private AbstractElem abstractElem;
        private ElemInRoom elemInSala;

        public ElemCuTaxa(string id, string titlu, double taxa) : base(id, titlu)
        {
            this.taxa = taxa;
        }

        public ElemCuTaxa(AbstractElem abstractElem, double taxa)
        {
            this.abstractElem = abstractElem;
            this.taxa = taxa;
        }

        public ElemCuTaxa(ElemInRoom elemInSala)
        {
            this.elemInSala = elemInSala;
        }

        public double Taxa { get => taxa; set => taxa = value; }
        internal AbstractElem AbstractElem { get => abstractElem; set => abstractElem = value; }

        public override string AfisElem()
        {
            return "\nElementul: " + base.AfisElem() +
                    ", taxa: " + taxa;
        }

        public override string Accept(IAbstractElemVisitor viz)
        {
            //obiectul vizitator primit ca parametru "viziteaza" obiectul curent
            return viz.Visit(this);
        }
    
}
}
