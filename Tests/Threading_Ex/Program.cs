using System;
using System.Reactive.Concurrency;
using System.Threading;
using System.Threading.Tasks;

namespace Threading_Ex
{
    
    class Program
    {
        //private static object lockObject = new object();

        static async Task<long> HalfFact(long l, long r)
        {
            if (l > r)
                return 1;
            if (l == r)
                return l;
            if (r - l == 1)
                return (long)l * r;
            long m = (l + r) / 2;
            //var tskFac1 = Task.Factory.StartNew<long>(() => HalfFact(l, m));
            //var tskFac2 = Task.Factory.StartNew<long>(() => HalfFact(m + 1, r));
            var tskFac1 = Task.Run(() => HalfFact(l, m));
            var tskFac2 = Task.Run(() => HalfFact(m + 1, r));
            //Task.WaitAll(tskFac1, tskFac2);
            return await tskFac1 * await tskFac2;
        }

        static long FactoReal(long n)
        {
            if (n < 0)
                return 0;
            if (n == 0)
                return 1;
            if (n == 1 || n == 2)
                return n;
            return HalfFact(2, n).Result;
        }

        static long Sum(long sum, long firstElement)
        {
            long sumReturn = 0;

            for (long i = firstElement; i <= sum; i++)
                sumReturn += i;               
            
            return sumReturn;
        }

        static async Task<long> SumToThread (long number)
        {
            long middle = number / 2;
            if (middle > 1)
            {
                var tskSum1 = Task.Run(() => Sum(middle, 0));
                var tskSum2 = Task.Run(() => Sum(number, middle + 1));
                //Task.WaitAll(tskSum1, tskSum2);
                return await tskSum1 + await tskSum2;
            }
            else
                return Sum(number, 0); 
        }
        static void Main()
        {
            long N = 0;
            Console.WriteLine("Введите число N");
            if (long.TryParse(Console.ReadLine(), out N) && N > 0)
            {
                Console.WriteLine($"Факториал {N} равен {FactoReal(N)}");
                Console.WriteLine($"Сумма {N} чисел равна {SumToThread(N).Result}");
            }
            else
                Console.WriteLine("Вы ввели не число!");
            Console.ReadKey();

        }
        
    }
}
