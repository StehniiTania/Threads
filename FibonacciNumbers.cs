using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkSystemProg02
{
    class FibonacciNumbers
    {
        public int nEnd { set; get; }
        public List<int> listFibonNumber { set; get; }

        public FibonacciNumbers(int eEn)
        {
            nEnd = eEn;
            listFibonNumber = new List<int>();
            listFibonNumber.Add(0);
            listFibonNumber.Add(1);
            int n0 = 0;
            int n1 = 1;
            int index_last = 2;
            while (n1 < nEnd)
            {
                index_last = listFibonNumber.Count() - 1;
                n0 = listFibonNumber.ElementAt(index_last - 1);
                n1 = listFibonNumber.ElementAt(index_last);
                if ((n0 + n1) <= nEnd)
                {
                    listFibonNumber.Add(n0 + n1);
                    n1 = n0 + n1;
                }
                else break;
            }
        }
    }
}
