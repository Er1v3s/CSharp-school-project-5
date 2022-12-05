using Program;
using System;

namespace App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userChose;
            bool flag = false;

            do
            {
                Console.WriteLine("Wybierz przedmiot, który Cię interesuje: ");
                Console.WriteLine("1. Lodowka");
                Console.WriteLine("2. Pralka \n");

                userChose = Console.ReadLine();
                userChose = userChose.ToLower();

                Console.Clear();

                if (userChose == "lodowka" || userChose == "lodówka" || userChose == "l" || userChose == "1")
                {
                    flag = true;
                    Console.WriteLine("Wybrano Lodówkę \n");

                    Fridge fridge = new Fridge();

                }
                else if (userChose == "pralka" || userChose == "p" || userChose == "2")
                {
                    flag = true;
                    Console.WriteLine("Wybrano Pralke");

                    WashingMachine washingMachine = new WashingMachine();
                }
                else
                { 
                    flag = false;
                    Console.WriteLine("Nieprawidłowy wybór, spróbuj ponownie! \n");
                }

            } while(flag == false);



            Console.ReadLine();

        }
    }
}