using System;

namespace ConsoleApp1
{
    class Program
    {
        private static int Index;  // Переменная индекса элемента
        private static int Member; // Переменная элемента последовательности
        private static int Mode;   // Переменная режима
        private static int x1 = 0, x2 = 1, y = x1 + x2; // х1, х2 - первые элементы последовательности, известны; у - следующий элемент
        static void Main(string[] args)
        {
            Console.WriteLine("Введите режим (1 или 2):");
            Mode = int.Parse(Console.ReadLine());
            GetFibonacсiValue(Mode);

        }
        static int GetValueFibonacсiCycle(int Index)
        {
            // Частные случаи
            //------------------------
            if (Index == 0)
            {
                return x1;
            }
            else if (Index == 1)
            {
                return x2;
            }
            //------------------------
            else
            {
                for (int i = 2; i <= Index; i++) // Индекс 0 и 1 уже отработаны, поэтому i = 2
                {
                    y = x1 + x2;
                    x1 = x2;
                    x2 = y;
                }
                return y;
            }
        }
        static int GetValueFibonacсiRecursion(int Index)
        {
            if (Index > 1)
            {
                y = GetValueFibonacсiRecursion(Index - 1) + GetValueFibonacсiRecursion(Index - 2);
            }
            // Частные случаи
            //------------------------
            else if (Index == 1)
            {
                return x2;
            }
            else if (Index == 0)
            {
                return x1;
            }
            else
            {
                return -1;
            }
            //------------------------
            return y;
        }
        static int GetIndexOfMemberFibonacсi(int FibonacciMember)
        {
            // Т.к. элементов со значением равным 1 в последовательности - 2, индекс для этих значений всегда будет равен 1
            int index = 1;

            // Частные случаи
            //------------------------
            if (FibonacciMember == 0)
            {
                index = 0;
                return index;
            }
            else if (FibonacciMember == 1)
            {
                index = 1;
                return index;
            }
            //------------------------
            else
            {
                while (y < FibonacciMember)
                {
                    y = x1 + x2;
                    x1 = x2;
                    x2 = y;
                    index++;
                    // Если был введен корректный член последовательности Фибоначчи,выполниться условие y == FibonacciMember
                    // и index будет иметь свое максимальное значение т.к. следующая итерация цикла не произойдет
                    if (y > FibonacciMember)
                        index = -1;
                }
                return index;
            }
        }

        static void GetFibonacсiValue(int Mode)
        {
            if (Mode == 1)
            {
                Console.WriteLine("Введите индекс элемента:");
                Index = int.Parse(Console.ReadLine());
                Console.WriteLine("Элемент последовательности через цикл: " + GetValueFibonacсiCycle(Index));
                x1 = 0; x2 = 1; y = x1 + x2;
                Console.WriteLine("Элемент последовательности через рекурсию: " + GetValueFibonacсiRecursion(Index));
            }
            else if (Mode == 2)
            {
                Console.WriteLine("Введите элемент последовательности:");
                Member = int.Parse(Console.ReadLine());
                Console.WriteLine("Индекс элемента последовательности: " + GetIndexOfMemberFibonacсi(Member));
            }
            else
            {
                Console.WriteLine("Ошибка: Некорректный режим!");
            }
        }
    }
}
