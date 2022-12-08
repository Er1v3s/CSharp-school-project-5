using Microsoft.VisualBasic.FileIO;
using Program;
using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace App
{
    internal class Program
    {
        static void Main()
        {
            string userChose;
            int option = -1;
            bool flag = false;

            string brand;
            string color;

            do
            {
                Console.WriteLine("Wybierz przedmiot, który Cię interesuje: \n");
                Console.WriteLine("1. Lodówka");
                Console.WriteLine("2. Pralka \n");

                Console.Write("Twój wybór: ");
                userChose = Console.ReadLine();
                userChose = userChose.ToLower();

                Console.Clear();

                if (userChose == "lodowka" || userChose == "lodówka" || userChose == "l" || userChose == "1")
                {
                    flag = true;
                    Console.WriteLine("Wybrano Lodówkę \n");

                    option = setNumOfDoors();

                    if (option == 1)
                    {
                        Fridge fridge = new Fridge();
                        fridge.ShowOptions();
                    }
                    else if(option == 2)
                    {
                        Fridge fridge = new Fridge(2);
                        fridge.ShowOptions();
                    }
                    option = -1;
                }
                else if (userChose == "pralka" || userChose == "p" || userChose == "2")
                {
                    flag = true;
                    Console.WriteLine("Wybrano Pralke \n");

                    setBrand();
                    setColor();

                    WashingMachine washingMachine = new WashingMachine("Wzór", brand, color);
                    WashingMachine washingMachine2 = new WashingMachine(washingMachine);

                    washingMachine2.name = "Kopia";

                    Console.WriteLine(washingMachine.details());
                    Console.WriteLine(washingMachine2.details());

                    Thread.Sleep(5000);

                    washingMachine2.showOptions();
                }
                else
                { 
                    flag = false;
                    Console.WriteLine("Nieprawidłowa wartość, wprowadź jeszcze raz! \n");
                }

            } while(flag == false);

            Console.ReadLine();

            string setBrand()
            {
                bool brandIsChoosen = false;
                do
                {
                    Console.WriteLine("Dostępne opcje: \n");
                    Console.WriteLine("1. Whirpool");
                    Console.WriteLine("2. Bosh");
                    Console.WriteLine("3. Beko \n");
                    Console.Write("Wybierz markę: ");
                    brand = Console.ReadLine();
                    brand = brand.ToLower();

                        if (brand == "whirpool" || brand == "bosh" || brand == "beko" ||
                            brand == "1" || brand == "2" || brand == "3")
                        {
                            if (brand == "1") brand = "Whirpool";
                            else if (brand == "2") brand = "Bosh";
                            else if (brand == "3") brand = "Beko";

                            brandIsChoosen = true;
                            Console.Clear();
                        }
                        else
                        {
                            brandIsChoosen = false;
                            Console.Clear();
                            Console.WriteLine("Nieprawidłowa wartość, wprowadź jeszcze raz! \n");
                        }

                } while (brandIsChoosen == false);

                return brand;
            }

            string setColor()
            {
                bool colorIsChoosen = false;
                do
                {
                    Console.WriteLine("Dostępne opcje: \n");
                    Console.WriteLine("1. czarny");
                    Console.WriteLine("2. biały");
                    Console.WriteLine("3. szary \n");
                    Console.Write("Wybierz kolor: ");
                    color = Console.ReadLine();
                    color = color.ToLower();

                        if (color == "czarny" || color == "biały" || color == "bialy" || color == "szary" ||
                           color == "1" || color == "2" || color == "3")
                        {
                            if (color == "1") color = "Czarny";
                            else if (color == "2" || color == "bialy") color = "Biały";
                            else if (color == "3") color = "Szary";

                            colorIsChoosen = true;
                            Console.Clear();
                        }
                        else
                        {
                            colorIsChoosen = false;
                            Console.Clear();
                            Console.WriteLine("Nieprawidłowa wartość, wprowadź jeszcze raz! \n");
                        }

                } while (colorIsChoosen == false);

                return color;
            }

            int setNumOfDoors()
            {
                do
                {
                    Console.WriteLine("Ilu drzwiowa ma być lodówka? 1 czy 2 \n");
                    Console.Write("Twój wybór: ");
                    try
                    {
                        option = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Nieprawidłowa wartość, wprowadź jeszcze raz!");
                    }

                    if (option == 1 || option == 2)
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                        Console.Clear();
                        Console.WriteLine("Nieprawidłowa wartość, wprowadź jeszcze raz!");
                    }

                } while (flag == false);
                
                return option;
            }
        }
    }
}