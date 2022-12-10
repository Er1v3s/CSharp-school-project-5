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

        // Pobiera i ustawia wartość atrybutu
        public string name { get; set; }
        public string brand { get; set; }
        public string color { get; set; }

        //Pusty constructor
        public WashingMachine() { }

        // Konstruktor z parametrami
        public WashingMachine(string nameElement, string brandElement, string colorElement)
        {
            name = nameElement;
            brand = brandElement;
            color = colorElement;
        }
        // Konstruktor który ma unikalny parametr a reszte kopiuje z innego obiektu
        public WashingMachine(string elementName, WashingMachine copy)
        {
            name = elementName;
            brand = copy.brand;
            color = copy.color;
        }

        protected internal void showOptions()
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
                        setWashingTime(90);
                        setWashingTemperature(40);
                        setWashingRPM(1000);

                        Console.WriteLine("Pralka ustawiona na tryb: Eco");
                        info(brand, color, washingTime, washingTemperature, washingRPM);

                        sleep(1000);
                        showOptions();
                        break;
                    case 2:
                        setWashingTime(30);
                        setWashingTemperature(60);
                        setWashingRPM(1500);

                        Console.WriteLine("Pralka ustawiona na tryb: Szybkie");
                        info(brand, color, washingTime, washingTemperature, washingRPM);

                        sleep(1000);
                        showOptions();
                        break;
                    case 3:
                        setWashingTime(180);
                        setWashingTemperature(50);
                        setWashingRPM(800);

                        Console.WriteLine("Pralka ustawiona na tryb: Delikatne");
                        info(brand, color, washingTime, washingTemperature, washingRPM);

                        sleep(1000);
                        showOptions();
                        break;
                    case 4:
                        setWashingTime(120);
                        setWashingTemperature(60);
                        setWashingRPM(1200);

                        Console.WriteLine("Pralka ustawiona na tryb: Codzienne");
                        info(brand, color, washingTime, washingTemperature, washingRPM);

                        sleep(1000);
                        showOptions();
                        break;
                    case 5:
                        setWashingTime(15);
                        setWashingTemperature(30);
                        setWashingRPM(1500);

                        Console.WriteLine("Pralka ustawiona na tryb: Wirowanie");
                        info(brand, color, washingTime, washingTemperature, washingRPM);

                        sleep(1000);
                        showOptions();
                        break;
                    case 6:
                        setWashingTime(0);
                        setWashingTemperature(0);
                        setWashingRPM(0);

                        Console.WriteLine("\n");
                        Console.WriteLine("Pralka ustawiona na tryb: Manualny");
                        info(brand, color, washingTime, washingTemperature, washingRPM);

                        sleep(1000);
                        showOptions();
                        break;
                    case 7:
                        info(brand, color, washingTime, washingTemperature, washingRPM);
                        break;
                }
                option = 0;
            } while (flag == false);
        }

        private int setWashingTime(int wTime)
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

        private int setWashingTemperature(int wTemp)
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

        private int setWashingRPM(int wRPM)
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
        private void info(string brand, string color, int wTime, int wTemperature, int wRPM)
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

        private void sleep(int sleepingTime)
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

        public string details()
        {
            return "To jest " + name + " " + brand + " " + color;
        }
    }
}
