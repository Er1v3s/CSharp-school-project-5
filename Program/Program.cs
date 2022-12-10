using Microsoft.VisualBasic.FileIO;
using Program;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Reflection.Metadata;
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
            bool sflag = false;
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

                if (option == 1 || option == 2)
                {
                    flag = true;

                    if (option == 1)
                    {
                        Fridge fridge = new();

                        fridge.ShowOptions();
                    }
                    else if (option == 2)
                    {
                        WashingMachine washingMachine1 = new();
                        Console.Clear();
                        do
                        {
                            try
                            {
                                Console.Write("Wybierz nazwę: ");
                                washingMachine1.name = Console.ReadLine();
                                Console.Write("Wybierz markę: ");
                                washingMachine1.brand = Console.ReadLine();
                                Console.Write("Wybierz kolor: ");
                                washingMachine1.color = Console.ReadLine();

                                if (washingMachine1.name != string.Empty
                                    && washingMachine1.brand != string.Empty
                                    && washingMachine1.color != string.Empty)
                                {
                                    if (!(int.TryParse(washingMachine1.name, out int value))
                                        && !(int.TryParse(washingMachine1.brand, out int value2))
                                        && !(int.TryParse(washingMachine1.color, out int value3)))
                                    {
                                        sflag = true;
                                        Console.Clear();
                                    }
                                    else
                                    {
                                        throw new Exception("Wartość nie może być typu inteeger! Spróbuj ponownie \n");
                                    }
                                }
                                else
                                {
                                    throw new Exception("Wartości nie mogą być puste! Spróbuj ponownie\n");
                                }
                            }
                            catch (Exception e)
                            {
                                Console.Clear();
                                Console.WriteLine(e.Message);
                            }
                        } while (sflag == false);

                        WashingMachine washingMachine2 = new("Pralka (stworzona za pomocą konstruktora): ", brand, color);
                        WashingMachine washingMachine3 = new("Pralka (stworzona za pomocą kopi): ", washingMachine1);

                        Console.WriteLine("### Lista pralek ###\n");
                        Console.WriteLine($"1. {washingMachine1.details()}");
                        Console.WriteLine($"2. {washingMachine2.details()} ");
                        Console.WriteLine($"3. {washingMachine3.details()}");

                        chooseYourWashingMachine();
                    }

                } 
                else
                {
                    Console.Clear();
                    Console.WriteLine("Wprowadzono niepoprawną wartość!\n");
                }

                option = -1;
            } while (!flag);

            void chooseYourWashingMachine()
            {
                int option;

                do
                {
                    Console.Write("\nWybierz swoją pralkę! ( 1 / 2 / 3 ): ");
                    option = Convert.ToInt32(Console.ReadLine());
                } while (!flag);
            }
        }
    }
}