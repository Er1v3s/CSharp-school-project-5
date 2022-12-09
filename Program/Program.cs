using Microsoft.VisualBasic.FileIO;
using Program;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace App
{
    internal class Program
    {
        static void Main()
        {
            string brand = "Bosh", color = "czarna";
            bool flag = false;
            int option = -1;

            do
            {
                Console.WriteLine("Wybierz przedmiot: \n");
                Console.WriteLine("1. Lodówka");
                Console.WriteLine("2. Pralka\n");
                Console.Write("Twój wybór: ");

                try
                {
                    option = Convert.ToInt32(Console.ReadLine());
                } 
                catch (Exception)
                {
                    Console.WriteLine("Wprowadzono niepoprawną wartość!\n");
                }

                if(option == 1 || option == 2)
                {
                    flag = true;

                    if(option == 1)
                    {
                        Fridge fridge = new Fridge();

                        fridge.ShowOptions();
                    }
                    else if(option == 2 )
                    {
                        WashingMachine washingMachine1 = new WashingMachine();
                        Console.Clear();
                        Console.Write("Nazwa pralki: ");
                        washingMachine1.name = Console.ReadLine();
                        Console.Write("Marka pralki: ");
                        washingMachine1.brand = Console.ReadLine();
                        Console.Write("Kolor pralki: ");
                        washingMachine1.color = Console.ReadLine();

                        WashingMachine washingMachine2 = new WashingMachine("Pralka 2", brand, color);

                        WashingMachine washingMachine3 = new WashingMachine("Pralka 3 (Kopia pralki numer 2)", washingMachine2);

                        Console.WriteLine(washingMachine1.details());
                        Console.WriteLine(washingMachine2.details());
                        Console.WriteLine(washingMachine3.details());

                        Console.ReadLine();
                    }

                } 
                else
                {
                    Console.Clear();
                    Console.WriteLine("Wprowadzono niepoprawną wartość!\n");
                }

                option = -1;
            } while (!flag);

        }
    }
}