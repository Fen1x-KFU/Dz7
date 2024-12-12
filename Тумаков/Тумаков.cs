using System;
using System.ComponentModel;
using System.Text;
using System.IO;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Collections;

namespace Tumakov
{
    class Program
    {
        static void StartTask(string name)
        {
            Console.WriteLine($"Задание {name}\n");
        }
        static void CheckIFormattableImplementation(object obj)
        {
            if (obj is IFormattable)
            {
                IFormattable formattableObject = obj as IFormattable;
                Console.WriteLine("Объект реализует интерфейс IFormattable.");
                Console.WriteLine(obj.GetType());
                Console.WriteLine(formattableObject);
            }
            else
            {
                Console.WriteLine("Объект НЕ реализует интерфейс IFormattable.");
            }
        }

        static void FileFIOEmail(string fileName1, string fileName2)
        {
            if (File.Exists(fileName1))
            {
                string[] lines1 = File.ReadAllLines(fileName1);
                string[] lines2 = new string[lines1.Length];

                // Читаем файл построчно
                for (int i = 0; i < lines1.Length; i++)
                {
                    int importantchar = lines1[i].IndexOf('#');
                    string email = lines1[i].Substring(importantchar);
                    string lineFIO = lines1[i].Substring(0, importantchar);

                    lines1[i] = lineFIO;
                    lines2[i] = email;
                    File.WriteAllLines(fileName1, lines1);
                    File.WriteAllLines(fileName2, lines2);
                }
            }
            else
            {
                Console.WriteLine("Файл не найден.");
            }
        }

        static void Task1()
        {
            StartTask("8.1");

            Console.WriteLine("Введите номер своего банковского счёта.");
            string bankscore1 = Console.ReadLine();

            Console.WriteLine("Введите сумму пополнения баланса");
            string balance1 = Console.ReadLine();

            Console.WriteLine("Введите тип банковского счёта");
            string typeaccount1 = Console.ReadLine();

            BankScore bankScore1 = new BankScore(bankscore1, balance1, typeaccount1);

            Console.WriteLine("Введите номер счёта, НА КОТОРЫЙ вы хотите отправить сумму денег");
            string bankscore2 = Console.ReadLine();

            BankScore bankScore2 = new BankScore(bankscore2);

            Console.WriteLine("Введите сумму, которую выхотите перевести на другой счёт.");
            string balic = Console.ReadLine();
            bankScore1.NewBalic(bankScore1, bankScore2, balic);
            bankScore1.Print(bankScore1, bankScore2);
        }

        static string Task2(out string str1)
        {
            StartTask("8.2");

            Console.WriteLine("Введите строку, которая станет перевёрнутой");
            str1 = Console.ReadLine();
            StringBuilder str2 = new StringBuilder();
            char[] strchar = str1.ToCharArray();

            for (int c = str1.Length - 1; c >= 0; c--)
            {
                str2.Append(strchar[c]);
            }

            return str2.ToString();
        }

        static void Task3()
        {
            StartTask("8.3");

            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory; // Получение базового каталога    

            string[] files = Directory.GetFiles(baseDirectory, "*.txt"); // Получаем все файлы с расширением .txt

            Console.WriteLine("Текстовые файлы в базовом каталоге:");
            foreach (string file in files)
            {
                Console.WriteLine(Path.GetFileName(file)); // Выводим название файла
            }

            Console.WriteLine("Задайте название файла, который вы хотите найти");
            string name = Console.ReadLine();
            string fullNamefile = String.Format($"{name}.txt");


            // Поиск файла в указанной директории
            string[] myFile = Directory.GetFiles(baseDirectory, fullNamefile, SearchOption.AllDirectories);

            if (myFile.Length > 0)
            {
                Console.WriteLine("Файл найден. Полный путь: " + myFile[0] + "\n");

                // Использование относительного пути для чтения файла
                string content = File.ReadAllText(myFile[0]);
                File.Delete(myFile[0]);

                File.AppendAllText(fullNamefile, content.ToUpper());

                Console.WriteLine("Теперь выведем текст, где все буквы станут заглавными!\n");
                Console.WriteLine(File.ReadAllText(myFile[0]));
            }
            else
            {
                Console.WriteLine("Файл не найден.");
            }
        }

        static void Task4()
        {
            StartTask("8.4");

            // Создаем объект для проверки его реализации интерфейса IFormattable
            object obj = "Y";

            // Вызываем метод для проверки
            CheckIFormattableImplementation(obj);
        }

        static void Task5()
        {
            StartTask("8.1");

            string fileName1 = "Текст1.txt";
            string fileName2 = "Текст2.txt";

            string[] linefile1 = File.ReadAllLines(fileName1);
            string[] linefile2 = File.ReadAllLines(fileName2);

            FileFIOEmail(fileName1, fileName2);

            string[] newlinefile1 = File.ReadAllLines(fileName1);
            string[] newlinefile2 = File.ReadAllLines(fileName2);

            Console.WriteLine("Сщдержимое 1 файла!\n");
            for (int i = 0; i < newlinefile1.Length; i++)
            {
                Console.WriteLine(newlinefile1[i]);
            }

            Console.WriteLine();

            Console.WriteLine("Сщдержимое 2 файла!\n");
            for (int i = 0; i < newlinefile2.Length; i++)
            {
                Console.WriteLine(newlinefile2[i]);
            }
            File.Delete(fileName1);
            File.Delete(fileName2);
            File.AppendAllLines(fileName1, linefile1);
            File.AppendAllLines(fileName2, linefile2);
        }

        static void Task6()
        {
            StartTask("8.2");

            Song firstSong = new Song();
            firstSong.SetName("Тепло");
            firstSong.SetAuthor("Макс Корж");

            Song secondSong = new Song();
            secondSong.SetName("TSM");
            secondSong.SetAuthor("MACAN");

            Song thirdSong = new Song();
            thirdSong.SetName("Тепло"); 
            thirdSong.SetAuthor("Елена Темникова"); 

            Song fourthSong = new Song();
            fourthSong.SetName("Без названия"); 
            fourthSong.SetAuthor("MACAN"); 

            List<Song> list = new List<Song>(); // Создаем список песен

            // Добавляем песни в список
            list.Add(firstSong);
            list.Add(secondSong);
            list.Add(thirdSong);
            list.Add(fourthSong);

            // Выводим автора для каждой песни из списка
            for (int i = 0; i < list.Count; i ++)
            {
                list[i].Print(list[i].Title(list[i].name, list[i].author));

                if (i == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Сравним 1 и 2 песню!");
                    if (list[i].Equals(list[1]))
                    {
                        Console.WriteLine("У этих песен есть схожесть!\n");
                    }
                    else { Console.WriteLine("Эти песни разные!\n"); }
                }
            }   
        }

        static void Main()
        {
            //Task1();
            //string str;
            //Console.WriteLine(Task2(out str));
            //Task3();
            //Task4();
            //Task5();
            Task6();
        }
    }
}