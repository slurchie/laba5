using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace homework
{
    class Program
    {
        static void Main(string[] args)
        {
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
    


