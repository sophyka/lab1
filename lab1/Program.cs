using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class FirstPart
    {
        private readonly int[] array;
        public FirstPart(int length)
        {
            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }
            var random = new Random();
            array = new int[length];
            for (int i = 0; i < array.Length; i++)
                array[i] = random.Next(-10, 10);
        }
        public IReadOnlyList<int> Vector
        {
            get
            {
                return array;
            }
        }
        public int FindMinAbsElement()
        {
            int minAbsElement = Math.Abs(array[0]);
            for (int i = 1; i < array.Length; i++)
            {
                int absElement = Math.Abs(array[i]);
                if (absElement < minAbsElement)
                    minAbsElement = absElement;
            }
            return minAbsElement;
        }
        public void SortByAscending()
        {
            Array.Sort(array);
        }
        public int CalculateSumAfterZero(int[] array)
        {
            bool ZeroFound = false;
            int sum = 0;
            for (int i = 0; array.Length < 0; i++)
            {
                if (ZeroFound)
                {
                    sum += Math.Abs(array[i]);
                }
                else if (array[i] == 0)
                {
                    ZeroFound = true;
                }
            }
            return sum;
        }

        internal string CalculateSumAfterZero()
        {
            throw new NotImplementedException();
        }
    }
    public class SecondPart
    {
        private readonly int[,] matrix = new int[10, 10];
        public SecondPart(int rows, int cols)
        {
            if (rows < 0 || cols < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rows) + "or" + nameof(cols));
            }
            matrix = new int[rows, cols];
            var random = new Random();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(-10, 10);
                }
            }
        }
        public int[,] Matix
        {
            get
            {
                return matrix;
            }
        }
        public int GetLocalMins()
        {
            int localmincount = 0;
            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if (matrix[i, j] < matrix[i - 1, j] && matrix[i, j] < matrix[i + 1, j] && matrix[i, j] < matrix[i, j - 1] && matrix[i, j] < matrix[i, j + 1])
                    {
                        localmincount++;
                    }
                }
            }
            return localmincount;
        }
        public int GetSumAbsElementsDiag()
        {
            int sum = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = i + 1; j < 10; j++)
                {
                    sum += Math.Abs(matrix[i, j]);
                }
            }
            return sum;
        }
    }
    internal class Programm
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Часть 1");
            Console.WriteLine("Введите размер массива:");

            int size = int.Parse(Console.ReadLine());
            var firstpart = new FirstPart(size);

            Console.WriteLine("Исходный массив:");
            PrintVector(firstpart.Vector);
            Console.WriteLine("Минимальный элемент по модулю:" + firstpart.FindMinAbsElement());
            Console.WriteLine("Сумма отрицательных элементов по модулю:"
                + firstpart.CalculateSumAfterZero());

            firstpart.SortByAscending();
            Console.WriteLine("После сортировки по возрастанию:");
            PrintVector(firstpart.Vector);

            Console.WriteLine("Втора часть:");
            var secondpart = new SecondPart(10, 10);
            PrintMatrix(secondpart.Matix);

            var localmin = secondpart.GetLocalMins();
            Console.WriteLine("Локальный минимум:" + localmin);

            Console.WriteLine("Сумма элементов выше главной диагонали:" + secondpart.GetSumAbsElementsDiag());

        }
        static void PrintVector(IEnumerable<int> vector)
        {
            Console.WriteLine(string.Join(" ", vector));
        }
        static void PrintMatrix(int[,] matrix)
        {
            for (int i=0; i<matrix.GetLength(0); i++)
            {
                for (int j=0; j<matrix.GetLength(1); j++)
                {
                    Console.WriteLine("", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}



