using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService
{
    class Mymethods
    {

        public Mymethods()
        {

        }

        public string incr(string param)
        {
            int val = int.Parse(param);
            val++;
            return "{ \"status\":200, \"val\":"+val+"}";
        }
    }
}
