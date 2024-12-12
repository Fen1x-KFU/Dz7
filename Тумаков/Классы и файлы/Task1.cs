using System;

namespace Tumakov
{
    public class BankScore
    {
        private string bankscore;
        private decimal balanc;
        private string scoreType;

        public BankScore(string bankscore, string balanc, string scoreType)
        {
            this.bankscore = bankscore;
            this.balanc = ChekBalance(balanc);
            this.scoreType = ChekType(scoreType);
        }

        public BankScore(string bankscore)
        {
            this.bankscore = bankscore;
            this.balanc = 0;
            this.scoreType = "Неопредилён";
        }

        public BankScore()
        {
            this.bankscore = "";
            this.balanc = 0;
            this.scoreType = "Неопредилён";
        }

        public string ChekType(string type)
        {
            if (type == "Текущий")
            {
                return "Текущий";
            }
            else if (type == "Сберегательный")
            {
                return "Сберегательный1";
            }
            else { return "Неопредилён"; }
        }

        public decimal ChekBalance(string balance)
        {
            if (decimal.TryParse(balance, out decimal balic))
            {
                if (balic < 0)
                {
                    Console.WriteLine("Вы ввели отрицательное число!");
                    balic = 0;
                    return balic;
                }
                else
                {
                    return balic;
                }
            }
            else
            {
                Console.WriteLine("Вы ввели не число!");
                balic = 0;
                return balic;
            }
        }

        public void NewBalic(BankScore bankScore1, BankScore bankScore2, string balic)
        {
            if ((bankScore1.balanc - ChekBalance(balic)) < 0)
            {
                Console.WriteLine("Не хватает средств на балансе.");
            }
            else
            {
                bankScore1.balanc -= ChekBalance(balic);
                bankScore2.balanc += ChekBalance(balic);
            }
        }
        public void Print(BankScore bankScore1, BankScore bankScore2)
        {
            Console.WriteLine($"На первом счету: {bankScore1.balanc} рублей!");
            Console.WriteLine($"На втором счету: {bankScore2.balanc} рублей!");
        }
    }
}