using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*1493. В одном шаге от счастья
Ограничение времени: 1.0 секунды
Ограничение памяти: 64 МБ

Вова купил билет в трамвае 13-го маршрута и сразу посчитал суммы первых трёх цифр и последних трёх цифр номера билета (номер у билета шестизначный). Оказалось, что суммы отличаются ровно на единицу. «Я в одном шаге от счастья», — подумал Вова, — «или предыдущий или следующий билет точно счастливый». Прав ли он?
Исходные данные
В единственной строке записан номер билета. Номер состоит ровно из шести цифр, среди которых могут быть и нули. Гарантируется, что Вова умеет считать, то есть суммы первых трёх цифр и последних трёх цифр отличаются ровно на единицу.
Результат
Выведите «Yes», если Вова прав, и «No», если нет.
Примеры
исходные данные	результат
715068            Yes
445219            No
012200            Yes

*/

namespace LuckyTicket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();

            Console.WriteLine("Input tickets number: ");
            string ticket = Console.ReadLine();

            stopwatch.Start();

            string first_number = ticket.Substring(0, 3);
            string second_number = ticket.Substring(3, 3);

            //Console.WriteLine(first_number);
            //Console.WriteLine(second_number);

            int first = int.Parse(first_number);
            int second = int.Parse(second_number);
            int second_plus_one = second + 1;
            int second_minus_one = second - 1;

            int sumfirst = 0;
            int sumsecond_plus_one = 0;
            int sumsecond_minus_one = 0;

            //Console.WriteLine(first);
            //Console.WriteLine(second);

            FirstSum(ref first, ref sumfirst);
            SecondPlusOneSum(ref second_plus_one, ref sumsecond_plus_one);
            SecondMinusOneSum(ref second_minus_one, ref sumsecond_minus_one);

            LuckyChecker(sumfirst, sumsecond_plus_one, sumsecond_minus_one);

            stopwatch.Stop();
            long memory = GC.GetTotalMemory(true);
            Console.WriteLine(stopwatch.ElapsedMilliseconds + " seconds");
            Console.WriteLine(memory + " memory used");
        }

        static int FirstSum(ref int first, ref int sumfirst)
        {
            for (int i = 0; i < 3; i++)
            {
                sumfirst += first % 10;
                first /= 10;   
            }
            //Console.WriteLine(sumfirst);
            return sumfirst;    
        }

        static int SecondPlusOneSum(ref int second_plus_one, ref int sumsecond_plus_one)
        {
            for (int i = 0; i < 3; i++)
            {
                sumsecond_plus_one += second_plus_one % 10;
                second_plus_one /= 10;
            }
            //Console.WriteLine(sumsecond_plus_one);
            return sumsecond_plus_one;

        }

        static int SecondMinusOneSum(ref int second_minus_one, ref int sumsecond_minus_one)
        {
            for (int i = 0; i < 3; i++)
            {
                sumsecond_minus_one += second_minus_one % 10;
                second_minus_one /= 10;
            }
            //Console.WriteLine(sumsecond_minus_one);
            return sumsecond_minus_one;
        }

        static void LuckyChecker(int sumfirst, int sumsecond_plus_one, int sumsecond_minus_one)
        {
            if (sumfirst == sumsecond_plus_one || sumfirst == sumsecond_minus_one)
            {
                Console.WriteLine("Yes!");
            }

            else
            {
                Console.WriteLine("No!");
            }            
        }
    }
}
