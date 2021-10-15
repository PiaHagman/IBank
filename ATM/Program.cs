using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Logic;

namespace ATM
{
    class Program
    {
        static void Main(string[] args)
        {
            DebitAccount debitAccount = new DebitAccount(new List<Transaction>());
            int choice;
            RealDate date = new RealDate();

            Console.WriteLine("***Välkommen till uttagsautomaten!***");
            Console.WriteLine("Vänligen gör ditt val, 1-4:");
            Console.WriteLine("1. Kolla saldo");
            Console.WriteLine("2. Uttag");
            Console.WriteLine("3. Insättning");
            Console.WriteLine("4. Avsluta");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine($"Ditt saldo är {debitAccount.GetBalance()} SEK");
                    break;
                case 2:
                    Console.WriteLine("Ange belopp för uttag:");
                    double withDrawal = double.Parse(Console.ReadLine());
                    debitAccount.WithdrawFunds(withDrawal, date);
            }

        }
    }
}
