using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication33
{
    class Program
    {
        static void Main(string[] args)
        {
            char buf = ' ';
            int rezult = 0;
            int k = 0;
            int x = 0;
            int res = 0;
            char[] abetka = new char[] { 'а', 'б', 'в', 'г', 'д', 'e', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ы', 'ь', 'э', 'ю', 'я' };
            int length = abetka.Length;
            int[] count = new int[length];
            string input = "Когда Леонард подрос,его перевезли к бабушке в Базель,где он учился в гимназии (продолжая при этом увлечённо изучать математику).Он обратил на себя внимание профессора Иоганна Бернулли (младшего брата Якоба Бернулли).Знаменитый учёный передал одарённому подростку для изучения математические статьи,разрешив при этом для прояснения трудных мест приходить к нему домой по субботам после обеда";
            string[] str = input.Split(new Char[] { ' ', ',', '.' });
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Исходный текст");
            Console.WriteLine("-----------------------------");
            Console.WriteLine(input);
            Console.WriteLine("-----------------------------");
            char[] indx = new char[str.Length + 1];

            for (int i = 0; i < input.Length; i++) // Проверка исходного текста на соответсвие с буквами алфавита
            {
                for (int j = 0; j < abetka.Length; j++)
                {
                    if (input[i] == abetka[j])
                    {
                        count[j] = count[j] + 1; // При соответствии счетчик для данной буквы алфавита увеличивается на 1 

                    }
                }
            }

            for (int j = 0; j < abetka.Length; j++)  // Вывод графика который отображает количество вхождений в текст для каждой буквы алфавита
            {
                if (count[j] != 0)
                {
                    Console.Write(abetka[j]);
                    Console.Write(' ');
                    for (k = 0; k < count[j]; k++)
                    {
                        Console.Write('*');
                    }
                    Console.WriteLine();
                }
            }

            Console.WriteLine("!!!Введите количество букв в словах которые будут отображены в подсчете статистики!!! ");
            int paramSlov = Convert.ToInt32(Console.ReadLine());

            string[] Slovar = new string[str.Length + 1];  //Записываем слова из исходного текста в массив "словарь"
            for (int i = 0; i < str.Length; i++)
            {
                for (int j = 1; j < str.Length; j++)
                {

                    if (str[i].Length > paramSlov)
                    {
                        if (str[i] != Slovar[j])
                        {
                            Slovar[i] = str[i];

                        }
                    }
                }
            }
            int[] countSlov = new int[Slovar.Length];

            for (int i = 0; i < Slovar.Length; i++) // Делаем проверку на совпадение слов из исходного текста с словами из словаря 
            {

                for (int j = 0; j < Slovar.Length; j++)
                {

                    if (Slovar[i] == Slovar[j])
                    {
                        countSlov[i] = countSlov[i] + 1; // При соответствии счетчик для данной буквы алфавита увеличивается на 1 
                    }
                }
            }

            for (int i = 1; i < str.Length; i++) // вывод статистики слов
            {

                if (Slovar[i] != Slovar[i - 1]) // защита от лишних действий
                {

                    if (countSlov[i] != 0)
                    {
                        Console.Write(Slovar[i]);
                        Console.Write(' ');
                        for (k = 0; k < countSlov[i]; k++)
                        {

                            if (k != countSlov[i] && countSlov[i] != 0 && countSlov[i] != 1)
                            {
                                Console.Write('*');
                            }
                        }
                        Console.WriteLine();
                    }
                }
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}

