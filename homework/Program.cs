using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace homework
{
    class Program
    {
        static bool DecodePass(string[] variants, ref string password2)
        {
            for (int i = 0; i < variants.Length; i++)
            {
                string strochka = "";
                for (int j = 0; j < variants[i].Length; j++)
                {
                    strochka = strochka + Convert.ToString(variants[i][j], 2);
                }
                if (strochka == password2)
                {
                    password2 = variants[i];
                    return true;
                }
            }
            return false;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Проверка пароля");
            string[] password = { "password", "pass123", "pass" };
            StreamReader reader = new StreamReader(".txt");
            string passBinary = reader.ReadToEnd(); //ReadToEnd-считывает все символы, начиная с текущей позиции до конца потока
            passBinary = passBinary.Replace(" ", "");
            if (DecodePass(password, ref passBinary))
            {
                Console.WriteLine(passBinary);
            }
            else
            {
                Console.WriteLine("false");
            }
            Console.WriteLine("адская кухня");
                char[] allVovel = { 'О', 'Э', 'Е', 'И', 'Ы', 'У', 'Ё', 'Ю', 'Я' };
                Console.WriteLine("что должен сказать Гордон?");
                string input = Console.ReadLine();
                input = input.ToUpper();
                string[] words = input.Split();
                string output = "";
                for (int i = 0; i < words.Length; i++)
                {
                    char[] word = words[i].ToCharArray();
                    for (int j = 0; j < word.Length; j++)
                    {
                        if (word[j] == 'А')
                        {
                            word[j] = '@';
                        }
                        else
                        {
                            foreach (char vovel in allVovel)
                            {
                                 if (vovel == word[j])
                                {
                                    word[j] = '*';
                                }
                            }
                        }
                    }
                    string outputWord = "";//строка чтобы прикреплять к ней другие строчки
                    for (int j = 0; j < word.Length; j++)
                    {
                        outputWord += word[j];
                    }
                    output += outputWord + "!!!! ";
                }
                Console.WriteLine(output);
            }
        }
     }
    


