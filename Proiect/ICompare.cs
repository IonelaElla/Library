using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect
{
    public interface ICompare<K>
    {
        bool Compara(K id);
    }
}