using Program;
using System;
using System.Runtime.CompilerServices;

namespace App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userChose;
            bool flag = false;

            string brand;
            string color;

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

                    setBrand();
                    setColor();

                    Fridge fridge = new Fridge(brand, color);

                }
                else if (userChose == "pralka" || userChose == "p" || userChose == "2")
                {
                    flag = true;
                    Console.WriteLine("Wybrano Pralke \n");

                    setBrand();
                    setColor();

                    WashingMachine washingMachine = new WashingMachine(brand, color);

                    washingMachine.setWashingTime();
                    washingMachine.setWashingTemperature();
                    washingMachine.setWashingRPM();

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
                    Console.WriteLine("Dostępne opcje: ");
                    Console.WriteLine("1. Whirpool");
                    Console.WriteLine("2. Bosh");
                    Console.WriteLine("3. Beko \n");

                    Console.Write("Wybierz markę: ");
                    brand = Console.ReadLine();
                    brand = brand.ToLower();
                    if (brand == "whirpool" || brand == "bosh" || brand == "beko" ||
                        brand == "1" || brand == "2" || brand == "3")
                    {
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
                    Console.WriteLine("Dostępne opcje: ");
                    Console.WriteLine("1. czarny");
                    Console.WriteLine("2. biały");
                    Console.WriteLine("3. szary \n");
                    Console.Write("Wybierz kolor: ");
                color = Console.ReadLine();
                color = color.ToLower();
                    if (color == "czarny" || color == "biały" || color == "bialy" || color == "szary" ||
                       color == "1" || color == "2" || color == "3")
                    {
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
        }

        
    }
}