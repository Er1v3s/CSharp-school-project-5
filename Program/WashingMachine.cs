using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class WashingMachine
    {
        bool flag;
        private int washingTime, washingTemperature, washingRPM, option;

        private double zuzyciePradu = 450;

        // Pobiera i ustawia wartość atrybutu
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }

        //Pusty constructor
        public WashingMachine() { }

        // Konstruktor z parametrami
        public WashingMachine(string nameElement, string brandElement, string colorElement)
        {
            Name = nameElement;
            Brand = brandElement;
            Color = colorElement;
        }

        // Konstruktor który ma unikalny parametr a reszte kopiuje z innego obiektu
        public WashingMachine(string elementName, WashingMachine copy)
        {
            Name = elementName;
            Brand = copy.Brand;
            Color = copy.Color;
        }

        public WashingMachine CreateNewWashingMachine()
        {
            bool sflag = false;
            Console.Clear();
            WashingMachine washingMachine1 = new();
            do
            {
                try
                {
                    washingMachine1.Name = "Pralka stworzona za pomocą get i set ";
                    Console.Write("Wybierz markę: ");
                    washingMachine1.Brand = Console.ReadLine();
                    Console.Write("Wybierz kolor: ");
                    washingMachine1.Color = Console.ReadLine();

                    if (washingMachine1.Name != string.Empty
                        && washingMachine1.Brand != string.Empty
                        && washingMachine1.Color != string.Empty)
                    {
                        if (!(int.TryParse(washingMachine1.Name, out int value))
                            && !(int.TryParse(washingMachine1.Brand, out int value2))
                            && !(int.TryParse(washingMachine1.Color, out int value3)))
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

            Console.Clear();
            return washingMachine1;
        }

        // Argument przekazywany przez wartość
        public WashingMachine CreateNewWashingMachine_usingConstructor(string brand, string color)
        {
            bool sflag = false;
            int option;
            do
            {
                Console.Clear();
                Console.WriteLine("1. Bosh");
                Console.WriteLine("2. Whirpool");
                Console.WriteLine("3. Beko");
                Console.Write("Wybierz markę: ");

                option = Convert.ToInt32(Console.ReadLine());

                if (option == 1 || option == 2 || option == 3) sflag = true;
                if (option == 1) brand = "Bosh";
                else if (option == 2) brand = "Whirpool";
                else if (option == 3) brand = "Beko";
                else Console.WriteLine("Wprowadzono niepoprawną wartość\n");

            } while (sflag == false);

            sflag = false;
            do
            {
                Console.Clear();
                Console.WriteLine("1. Biała");
                Console.WriteLine("2. Czarna");
                Console.WriteLine("3. Srebrna");
                Console.Write("Wybierz kolor: ");
                option = Convert.ToInt32(Console.ReadLine());

                if (option == 1 || option == 2 || option == 3) sflag = true;
                if (option == 1) color = "Biała";
                else if (option == 2) color = "Czarna";
                else if (option == 3) color = "Srebrna";
                else Console.WriteLine("Wprowadzono niepoprawną wartość\n");

            } while (sflag == false);

            Console.Clear();
            WashingMachine washingMachine2 = new("Pralka stworzona za pomocą konstruktora ", brand, color);
            return washingMachine2;
        }

        public WashingMachine CreateNewWashingMachine_usingCopy(WashingMachine copy)
        {
            WashingMachine washingMachine3 = new("Pralka stworzona za pomocą kopii ", copy);
            return washingMachine3;
        }

        protected internal void ShowOptions()
        {
            flag = false;
            Console.Clear();

            do
            {
                Console.WriteLine("Wybierz program prania: \n");
                Console.WriteLine("1. Eco");
                Console.WriteLine("2. Szybkie");
                Console.WriteLine("3. Delikatne");
                Console.WriteLine("4. Codzienne");
                Console.WriteLine("5. Wirowanie");
                Console.WriteLine("6. Ustawienia manulane");
                Console.WriteLine("7. INFO \n");

                Console.Write("Twój wybór: ");
                try
                {
                    option = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    flag = false;
                    Console.Clear();
                    Console.WriteLine("Nieprawidłowa wartość, wprowadź jeszcze raz!");

                }

                if (option == 1 || option == 2 || option == 3 || option == 4 || option == 5 || option == 6)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                    Console.Clear();
                    Console.WriteLine("Nieprawidłowa wartość, wprowadź jeszcze raz!");
                }

                Console.Write("\n");
                switch (option)
                {
                    case 1:
                        SetWashingTime(90);
                        SetWashingTemperature(40);
                        SetWashingRPM(1000);

                        Console.WriteLine("Pralka ustawiona na tryb: Eco");
                        Info(Brand, Color, washingTime, washingTemperature, washingRPM);

                        Sleep(1000);
                        ShowOptions();
                        break;
                    case 2:
                        SetWashingTime(30);
                        SetWashingTemperature(60);
                        SetWashingRPM(1500);

                        Console.WriteLine("Pralka ustawiona na tryb: Szybkie");
                        Info(Brand, Color, washingTime, washingTemperature, washingRPM);

                        Sleep(1000);
                        ShowOptions();
                        break;
                    case 3:
                        SetWashingTime(180);
                        SetWashingTemperature(50);
                        SetWashingRPM(800);

                        Console.WriteLine("Pralka ustawiona na tryb: Delikatne");
                        Info(Brand, Color, washingTime, washingTemperature, washingRPM);

                        Sleep(1000);
                        ShowOptions();
                        break;
                    case 4:
                        SetWashingTime(120);
                        SetWashingTemperature(60);
                        SetWashingRPM(1200);

                        Console.WriteLine("Pralka ustawiona na tryb: Codzienne");
                        Info(Brand, Color, washingTime, washingTemperature, washingRPM);

                        Sleep(1000);
                        ShowOptions();
                        break;
                    case 5:
                        SetWashingTime(15);
                        SetWashingTemperature(30);
                        SetWashingRPM(1500);

                        Console.WriteLine("Pralka ustawiona na tryb: Wirowanie");
                        Info(Brand, Color, washingTime, washingTemperature, washingRPM);

                        Sleep(1000);
                        ShowOptions();
                        break;
                    case 6:
                        SetWashingTime(0);
                        SetWashingTemperature(0);
                        SetWashingRPM(0);

                        Console.WriteLine("\n");
                        Console.WriteLine("Pralka ustawiona na tryb: Manualny");
                        Info(Brand, Color, washingTime, washingTemperature, washingRPM);

                        Sleep(1000);
                        ShowOptions();
                        break;
                    case 7:
                        Info(Brand, Color, washingTime, washingTemperature, washingRPM);
                        break;
                }
                option = 0;
            } while (flag == false);
        }

        private int SetWashingTime(int wTime)
        {
            if (wTime != 0)
            {
                washingTime = wTime;
            }
            else
            {
                do
                {
                    Console.Write("Czas prania(min): ");
                    washingTime = Convert.ToInt32(Console.ReadLine());
                    if (washingTime > 1 && washingTime < 180)
                    {
                        flag = true;
                    }
                    else flag = false;

                } while (false);
            }

            flag = false;
            return washingTime;
        }

        private int SetWashingTemperature(int wTemp)
        {
            if (wTemp != 0)
            {
                washingTemperature = wTemp;
            }
            else
            {
                do
                {
                    Console.Write("temperatura(\u00b0C): ");
                    washingTemperature = Convert.ToInt32(Console.ReadLine());
                    if (washingTemperature > 1 && washingTemperature < 80)
                    {
                        flag = true;
                    }
                    else flag = false;

                } while (false);
            }

            flag = false;
            return washingTemperature;
        }

        private int SetWashingRPM(int wRPM)
        {
            if(wRPM != 0)
            {
                washingRPM = wRPM;
            }
            else
            {
                do
                {
                    Console.Write("Obroty na minute: ");
                    washingRPM = Convert.ToInt32(Console.ReadLine());
                    if (washingRPM > 100 && washingRPM < 1500)
                    {
                        flag = true;
                    }
                    else flag = false;

                } while (false);
            }

            flag = false;
            return washingRPM;
        }

        private void Info(string brand, string color, int wTime, int wTemperature, int wRPM)
        {
            Console.Clear();
            Console.WriteLine("### Pralka ### \n");
            Console.WriteLine("marka: " + brand);
            Console.WriteLine("kolor: " + color + "\n");
            Console.WriteLine("### Ustawienia ### \n");
            Console.WriteLine("Czas prania: " + wTime);
            Console.WriteLine("Temperatura prania: " + wTemperature);
            Console.WriteLine("Ilość obrotów na minutę: " + wRPM + "\n");
        }

        private void Sleep(int sleepingTime)
        {
            Console.WriteLine("Powrót za: ");
            Thread.Sleep(sleepingTime);
            Console.WriteLine("3");
            Thread.Sleep(sleepingTime);
            Console.WriteLine("2");
            Thread.Sleep(sleepingTime);
            Console.WriteLine("1");
            Thread.Sleep(sleepingTime);
        }

        public void CreateMessage()
        {
            Console.WriteLine($"{Name}: {Brand} {Color}");
        }
    }
}
