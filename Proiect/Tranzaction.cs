using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect
{
     class Tranzaction
    {
        private DateTime data;
        private string type;

        public Tranzaction(DateTime data, string type)
        {
            this.data = data;
            this.Type = type;
        }
        public DateTime Data { get => data; set => data = value; }
        public string Type { get => type; set => type = value; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
