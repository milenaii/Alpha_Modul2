using System;

namespace pr2
{
    public class Program
    {
        private static int[] arr;
        public static void Main()
        {
            int num = 3;
            arr = new int[num];
            Combination(0);
        }

        private static void Combination(int index)
        {
            if (index == arr.Length)
            {
                Console.WriteLine(string.Join(" ", arr));
                return;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                arr[index] = i + 1;
                Combination(index + 1);
            }
        }
    }
}