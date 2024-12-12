using System;
using System.ComponentModel;
using System.Text;
using System.IO;
using System.Globalization;

namespace Tumakov
{
   class Program
    {
        static void StartTask(string name)
        {
            Console.WriteLine($"Задание {name}\n");
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

        static void Main()
        {
            //Task1();
            //string str;
            //Console.WriteLine(Task2(out str));
            //Task3();
        }
    }
}