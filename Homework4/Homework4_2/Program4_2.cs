using System;

namespace d2 {
    class Program4_2
    {
        static void Main(string[] args)
        {
            int[] array = new int[100];
            Funct funct = new Funct();
            funct.CreatRandomArray(array);

            Console.WriteLine("创建的100个随机整数为：");
            funct.PrintArray(array);

            Console.WriteLine("对100个随机整数降序排列后：");
            funct.PrintArray(funct.UPSortArray(array));

            funct.Calculate(array);
            Console.ReadKey();
        }
    }

    public class Funct {

        //创建100个0-1000的随机整数
        public void CreatRandomArray(int[] array) {
            Random rd = new Random();
            for (int i = 0; i < 100; i++) { 
                array[i] = rd.Next(1001);
            }
        }

        //使用LINQ语句对整数数组从大到小排序
        public int[] UPSortArray(int[] array) {
            var sortedArray = from n in array
                         orderby n descending  // 按数值降序
                         select n;
            return sortedArray.ToArray();
        }

        //使用LINQ语句对整数数组求和
        public void Calculate(int[] array) { 
            var ARRAY = array;
            int sum = ARRAY.Sum();
            Console.WriteLine("随机整数的和为：{0}", sum);
            double avg = ARRAY.Average();
            Console.WriteLine("随机整数的平均数为：{0}", avg);
        }

        //打印数组元素
        public void PrintArray(int[] array) {
            int a = 0;
            if(array.Length%5 == 0)
                a = array.Length/5;
            else
                a=array.Length/5+1;

            for (int i = 0; i < a; i++) {
                for (int j = 0; j < 5; j++) {
                    Console.Write(array[i*5+j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }

}