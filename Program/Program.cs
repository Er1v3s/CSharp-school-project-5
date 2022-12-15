using Microsoft.VisualBasic.FileIO;
using Program;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace App
{
    internal class Program
    {
        static void Main()
        {
            string brand = String.Empty, color = String.Empty;
            bool sflag = false;
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

                if (option == 1 || option == 2)
                {
                    flag = true;

                    if (option == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Wybrano Lodówkę \n");
                        Console.WriteLine("Wersja lodówki z 2 drzwiami różni się funkcjami, czy chcesz zobaczyć DEMO jednej z nich?");
                        Console.WriteLine("1. TAK");
                        Console.WriteLine("2. NIE");
                        Console.WriteLine("3. Chce zobaczyć ile drzwi miały by razem x drzwiowe lodówki!");
                        Console.WriteLine("4. Chce porównać, która lodówka zużywa więcej prądu!\n");
                        Console.Write("Twój wybór: ");
                        int sOption = -1;
                        do
                        {
                            try
                            {
                                sOption = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Wprowadzono niepoprawną wartość!\n");
                            }

                        } while (sOption != 1 && sOption != 2 && sOption != 3 && sOption !=4 );

                        if (sOption == 1)
                        {
                            Fridge.ShowShoppingList(2, Fridge.Flag, Fridge.Option);
                        }
                        else if (sOption == 2)
                        {
                            Console.Clear();
                            Fridge fridge = new();
                            fridge.SetNumOfDoors();
                            fridge.ShowOptions();
                        }
                        else if(sOption == 3)
                        {
                            Console.Clear();

                            Fridge f1 = new Fridge();
                            Console.Write("Pierwsza: ");
                            f1.SetNumOfDoors();

                            Console.Write("\nDruga: ");
                            Fridge f2 = new Fridge();
                            f2.SetNumOfDoors();

                            Fridge f3 = f1 + f2;
                            Console.WriteLine($"\nObie lodówki razem miały by {f3.Doors} drzwi");
                        }
                        else if (sOption == 4)
                        {
                            Console.Clear();

                            Fridge f1 = new Fridge();
                            Console.Write("Pierwsza: ");
                            f1.SetNumOfDoors();

                            Console.Write("\nDruga: ");
                            Fridge f2 = new Fridge();
                            f2.SetNumOfDoors();

                            Fridge f3 = f1 > f2;
                            Console.WriteLine($"\nLodówka o liczbie drzwi {f1.Doors} zużywa {f1.ZuzyciePradu} prądu.");
                            Console.WriteLine($"Lodówka o liczbie drzwi {f2.Doors} zużywa {f2.ZuzyciePradu} prądu.");
                            Console.WriteLine($"Więcej prądu zużywa lodówka o liczbie drzwi {f3.Doors}");
                        }
                    }
                    else if (option == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("W jaki sposób chciałbyś stworzyć swoją pralkę? \n");
                        Console.WriteLine("1. Generuj sam");
                        Console.WriteLine("2. Wybierz z istniejących");
                        Console.WriteLine("3. Kopiuj z istniejących (warunek: wcześniej musiałeś skorzystać z opcji 1)\n");
                        Console.Write("Twój wybór: ");
                        do
                        {
                            try
                            {
                                option = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Wprowadzono niepoprawną wartość!\n");
                            }

                            if (option == 1 || option == 2 || option == 3)
                            {
                                sflag = true;
                                Console.Clear();
                                if (option == 1)
                                {
                                    WashingMachine washingMachine = new();
                                    washingMachine = washingMachine.CreateNewWashingMachine();
                                    washingMachine.CreateMessage();
                                    Thread.Sleep(5000);
                                    washingMachine.ShowOptions();
                                }
                                else if (option == 2)
                                {
                                    WashingMachine washingMachine = new();
                                    washingMachine = washingMachine.CreateNewWashingMachine_usingConstructor(brand, color);
                                    washingMachine.CreateMessage();
                                    Thread.Sleep(5000);
                                    washingMachine.ShowOptions();
                                }
                                else if (option == 3)
                                {
                                    WashingMachine washingMachine = new();
                                    washingMachine = washingMachine.CreateNewWashingMachine_usingCopy(washingMachine.CreateNewWashingMachine());
                                    washingMachine.CreateMessage();
                                    Thread.Sleep(5000);
                                    washingMachine.ShowOptions();
                                }
                            }
                        } while (sflag == false);
                        sflag = false;
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