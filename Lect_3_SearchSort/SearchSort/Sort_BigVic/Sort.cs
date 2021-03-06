﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Sort
    {
        static void Main()
        {
            List<Country> numbers = new List<Country>();
            for (int i = 0; i < 100; i++)
            {
                numbers.Add(new Country() { Name = "C" + i, Temperature = i });
            }

            numbers = numbers.OrderBy(c => Guid.NewGuid()).ToList();
            //Shuffle(numbers);
            Console.WriteLine(string.Join(" ", numbers));
            Console.WriteLine();
            Console.WriteLine(string.Join(" ", CountingSort(numbers, 0, 99, c => c.Temperature)));
            //return;


            //Stopwatch stopwatch = new Stopwatch();

            //stopwatch.Start();
            //CountingSort(numbers, 0, 999, c => c);
            //stopwatch.Stop();

            //Console.WriteLine(stopwatch.ElapsedMilliseconds);

            //stopwatch = new Stopwatch();

            //stopwatch.Start();
            //numbers.Sort();
            //stopwatch.Stop();

            //Console.WriteLine(stopwatch.ElapsedMilliseconds);
        }

        public static void Shuffle(List<int> numbers)
        {
            Random random = new Random();
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                int newIndex = random.Next(i + 1, numbers.Count - 1);
                int temp = numbers[newIndex];
                numbers[newIndex] = numbers[i];
                numbers[i] = temp;
            }
        }

        public static List<int> QuickSort(List<int> numbers)
        {
            if (numbers.Count < 2)
            {
                return numbers;
            }

            int pivodIndex = numbers.Count / 2;
            List<int> left = new List<int>();
            List<int> right = new List<int>();
            for (int i = 0; i < numbers.Count; i++)
            {
                if (i == pivodIndex)
                {
                    continue;
                }

                if (numbers[i] < numbers[pivodIndex])
                {
                    left.Add(numbers[i]);
                }
                else
                {
                    right.Add(numbers[i]);
                }
            }

            List<int> result = new List<int>();
            List<int> sortedLeft = QuickSort(left);
            List<int> sortedRight = QuickSort(right);

            result.AddRange(sortedLeft);
            result.Add(numbers[pivodIndex]);
            result.AddRange(sortedRight);

            return result;
        }

        public static List<int> MergeSort(List<int> numbers, bool isAsync)
        {
            if (numbers.Count < 2)
            {
                return numbers;
            }

            List<int> left = numbers.Take(numbers.Count / 2).ToList();
            List<int> right = numbers.Skip(numbers.Count / 2).ToList();

            if (isAsync)
            {
                Task leftResult = Task.Run(() => left = MergeSort(left, isAsync));
                Task rightResult = Task.Run(() => right = MergeSort(right, isAsync));
                Task.WaitAll(leftResult, rightResult);
            }
            else
            {
                left = MergeSort(left, isAsync);
                right = MergeSort(right, isAsync);
            }

            return MergeSortedLists(left, right);
        }

        private static List<int> MergeSortedLists(List<int> left, List<int> right)
        {
            int i = 0;
            int j = 0;
            List<int> result = new List<int>();
            while (i < left.Count && j < right.Count)
            {
                if (left[i] <= right[j])
                {
                    result.Add(left[i]);
                    i++;
                }
                else
                {
                    result.Add(right[j]);
                    j++;
                }
            }

            while (i < left.Count)
            {
                result.Add(left[i]);
                i++;
            }

            while (j < right.Count)
            {
                result.Add(right[j]);
                j++;
            }

            return result;
        }

        public static List<int> CountingSort(List<int> numbers, int min, int max)
        {
            int[] positions = new int[max - min + 1];
            for (int i = 0; i < numbers.Count; i++)
            {
                positions[numbers[i] - min]++;
            }

            List<int> result = new List<int>();
            for (int i = 0; i < positions.Length; i++)
            {
                int j = positions[i];
                while (j > 0)
                {
                    result.Add(i + min);
                    j--;
                }
            }

            return result;
        }

        public static List<T> CountingSort<T>(List<T> elements, int min, int max, Func<T, int> getValue)
        {
            int positionsCount = max - min + 1;
            List<List<T>> positions = new List<List<T>>(positionsCount);
            for (int i = 0; i < positionsCount; i++)
            {
                positions.Add(new List<T>());
            }

            for (int i = 0; i < elements.Count; i++)
            {
                int elementPosition = getValue(elements[i]) - min;
                positions[elementPosition].Add(elements[i]);
            }

            List<T> result = positions.SelectMany(p => p).ToList();

            return result;
        }


    }

    public class Country
    {
        public string Name { get; set; }

        public int Temperature { get; set; }

        public override string ToString()
        {
            return this.Name + " " + this.Temperature.ToString();
        }
    }
}