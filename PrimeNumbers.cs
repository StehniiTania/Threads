using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HomeWorkSystemProg02
{
    class PrimeNumbers
    {
        public int nStart { set; get; }
        public int nEnd { set; get; }
        public List<int> listPrimeNumber { set; get; }

        public PrimeNumbers(int nSt, int eEn)
        {
            nStart = nSt;
            nEnd = eEn;
            listPrimeNumber = new List<int>();
            if (CheckPrime(nStart))
            {
                listPrimeNumber.Add(nStart);                
            }
                
            else
            {
                listPrimeNumber.Add(SearchPrimeNumber(nStart));                
            }
                
                

            bool flagEnd = false;

            while (!flagEnd)
            {
                int n = listPrimeNumber.Last();
                int nNext = SearchPrimeNumber(n);
                if (nNext < nEnd && nNext != n)
                {
                    listPrimeNumber.Add(nNext);                    
                }
                else
                    flagEnd = true;
            }
        }

        private bool CheckPrime(int number)
        {
            bool flagPrimeNumber = true;

            for (int i = 2; i < number; i++)
                if (number % i == 0 && i != number)
                {
                    flagPrimeNumber = false;
                    break;
                }

            if (flagPrimeNumber == true)
                return true;
            else
                return false;
        }

        //возвращает ближайшее к number простое число
        private int SearchPrimeNumber(int number)
        {
            int num = number;
            bool flagPrimeNumber = false;
            while (num <= nEnd)
            {
                num++;

                flagPrimeNumber = CheckPrime(num);

                if (flagPrimeNumber == true)
                    break;
            }

            if (flagPrimeNumber == false)
                return number;
            else
                return num;
        }
    }
}
