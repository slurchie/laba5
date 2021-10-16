using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace metodichka
{
    class Program
    {
        //6.1
        static void counter(char[] data, out int numberVowel, out int numberConsonant)
        {
            numberVowel = 0;
            numberConsonant = 0;
            char[] allVovel = { 'а', 'о', 'э', 'е', 'и', 'ы', 'у', 'ё', 'ю', 'я' };
            char[] allConsonant = { 'б', 'в', 'г', 'д', 'ж', 'з', 'й', 'к', 'л', 'м', 'н', 'п', 'р', 'с', 'т', 'ф', 'х', 'ц', 'ч', 'ш', 'щ' };
            foreach (char a in data)
            {
                foreach (char v in allVovel)
                {
                    if (a == v) numberVowel++;
                }
                foreach (char c in allConsonant)
                {
                    if (a == c) numberConsonant++;
                }
            }
        }
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(args[0]+ "input.txt");//reader читает содержимое файла и возвращает
            string input = reader.ReadToEnd();//объявляем строку в которую будет засписан результат readtoend
            char[] inputData = input.ToCharArray();//возвращает массив символов из которых состоит строка
            counter(inputData, out int vovel, out int consonant);
            Console.WriteLine("количество гласных:" + vovel + " колличество согласных: " + consonant);
            reader.Close(); //всегда пишем в конце
            {
                //6.2
                Console.WriteLine("6.2");
                Console.Write("Число строк в первой матрице: ");
                int n = Convert.ToInt32(Console.ReadLine()); Console.WriteLine();
                Console.Write("Число столбцов в первой матрице: ");
                int m = Convert.ToInt32(Console.ReadLine()); Console.WriteLine();
                Random ran = new Random();
                int[,] FMatrix = new int[n, m];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        FMatrix[i, j] = ran.Next(-100, 100);
                        Console.Write($"{FMatrix[i, j]}\t");
                    }
                    Console.WriteLine("\n \n");
                }

                Console.Write($"Число строк во второй матрице: {m}");
                Console.WriteLine("\n \n");
                Console.Write("Число столбцов во второй матрице: ");
                int k = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                int[,] SMatrix = new int[m, k];
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < k; j++)
                    {
                        SMatrix[i, j] = ran.Next(-100, 100);
                        Console.Write($"{SMatrix[i, j]}\t");
                    }
                    Console.WriteLine("\n \n ");
                }
                int[,] result = new int[n, k];
                for (int str = 0; str < n; str++)
                for (int pil = 0; pil < k; pil++)
                for (int i = 0; i < m; i++)
                result[str, pil] += FMatrix[str, i] * SMatrix[i, pil];
                Console.WriteLine();
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < k; j++)
                        Console.Write($"{result[i, j]}\t");
                    Console.WriteLine("\n \n");
                }

                //6.3
                Console.WriteLine("6.3");
                  double[] Average(int[,] T)
                {
                    double[] average = new double[T.GetLength(0)];
                    for (int i = 0; i < T.GetLength(0); i++)
                    {
                        double sum = 0;
                        for (int j = 0; j < T.GetLength(1); j++)
                        {
                            sum += T[i, j];
                        }
                        average[i] = sum / T.GetLength(1);
                    }
                    return average;
                }
                  void Bubble(double[] massiv)
                {
                    double bubble; //Если элемент массива под номером i будет больше, чем элемент массива под номером j,
                    for (int i = 0; i < massiv.Length; i++) //то меняем элементы местами и продолжаем сравнение дальше
                    {
                        for (int j = i + 1; j < massiv.Length; j++)
                        {
                            if (massiv[i] > massiv[j])
                            {
                                bubble = massiv[i];
                                massiv[i] = massiv[j];
                                massiv[j] = bubble;
                            }
                        }
                    }
                }
                {
                    Random rnd = new Random();
                    int[,] temperature = new int[12, 30];
                    for (int i = 0; i < 12; i++)
                    {

                        Console.WriteLine("Месяц " + i);
                        for (int j = 0; j < 30; j++)
                        {
                            temperature[i, j] = rnd.Next(-30, 30);
                            Console.Write(temperature[i, j] + " ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("Средняя температура:");
                    double[] resultation = Average(temperature);
                    for (int i = 0; i < 12; i++)
                    {
                        Console.Write(resultation[i] + " ");
                    }
                    Console.WriteLine();
                    Bubble(resultation);
                    Console.WriteLine("после сортировки:");
                    for (int i = 0; i < 12; i++)
                    {
                        Console.Write(resultation[i] + " ");
                    }
                    Console.ReadLine();








                }
            }
        }
    }
}
