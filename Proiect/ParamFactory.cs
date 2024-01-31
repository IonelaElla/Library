using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect
{
    abstract class ParamFactory
    {
        //A fost creata pentru transmiterea de paramentri a unui obiect concret
        //carte revistsa clasa comuna


        //Clasele BookParamFactory și MagasineParamFactory  sunt clase derivate din clasa ParamFactory:
 
        private String id;
        private String title;

        protected ParamFactory(string id, string title)
        {
            this.id = id;
            this.title = title;
        }

        public string Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }

    }
}
