using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect
{
     class BookParamFactory : ParamFactory
    {
        private String author;

        public BookParamFactory(string id, string title, string author) : base(id, title)
        {
            this.author = author;
        }

        public string Author { get => author; set => author = value; }
    }
}

