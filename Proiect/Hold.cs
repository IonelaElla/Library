using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect
{
    class Hold
    {
      
            private AbstractElem elem;
            private DateTime data;
            private Member member;

            public Hold(AbstractElem elem, DateTime data, Member member)
            {
                this.Elem = elem;
                this.Data = data;
                this.Member = member;
            }

            public DateTime Data { get => data; set => data = value; }
            internal AbstractElem Elem { get => elem; set => elem = value; }
            internal Member Member { get => member; set => member = value; }


            public override string ToString()
            {
                return base.ToString();
            }
        }
    }
 