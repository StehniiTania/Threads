using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HomeWorkSystemProg02
{    
    public partial class MainWindow : Window
    {
        int end = 2147483647;
        int begin = 2;
        PrimeNumbers primeNumbers;
        FibonacciNumbers fibonacciNumbers;
        Thread threadPrimeNumber;
        Thread threadFibonNumber;

        public MainWindow()
        {
            InitializeComponent();
            
            Start1.Text = "" + begin;           
            Stop1.Text = "" + end;
            Stop2.Text = "" + end;
        }     

        private void Start2_Click(object sender, RoutedEventArgs e)
        {
            end = Convert.ToInt32(Stop2.Text);
            
            threadFibonNumber = new Thread((obj) =>
            {
                FibonacciNumbers value = (FibonacciNumbers)obj;
                fibonacciNumbers = new FibonacciNumbers(end);
                //string str = "";
                foreach (int elem in fibonacciNumbers.listFibonNumber)
                {
                    Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.ContextIdle,
                           new Action(delegate ()
                           {
                               TextBlock textBlock = new TextBlock();
                               textBlock.Text = "" + elem;
                               Stack2.Children.Add(textBlock);
                               Thread.Sleep(100);
                           }));
                }
                
            });

            threadFibonNumber.Start(fibonacciNumbers);
        }    

        private void Start1_Click(object sender, RoutedEventArgs e)
        {
            begin = Convert.ToInt32(Start1.Text);
            end = Convert.ToInt32(Stop1.Text);

            threadPrimeNumber = new Thread((obj) =>
            {
                PrimeNumbers value = (PrimeNumbers)obj;
                primeNumbers = new PrimeNumbers(begin, end);                
                foreach (int elem in primeNumbers.listPrimeNumber)
                {
                    Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.ContextIdle,
                       new Action(delegate ()
                       {
                           TextBlock textBlock = new TextBlock();
                           textBlock.Text = "" + elem;
                           Stack1.Children.Add(textBlock);
                           Thread.Sleep(100);
                       }));
                }                
            });
            threadPrimeNumber.Start(primeNumbers);
        }

        private void Stop1_Click(object sender, RoutedEventArgs e)
        {
            if (threadPrimeNumber != null)
                threadPrimeNumber.Abort();
        }

        private void Stop2_Click(object sender, RoutedEventArgs e)
        {
            if (threadFibonNumber != null)
                threadFibonNumber.Abort();
        }
    }
}
