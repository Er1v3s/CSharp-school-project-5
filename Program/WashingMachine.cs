using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class WashingMachine
    {
        private string brand, color;
        private int washingTime, washingTemperature, washingRPM, option;
        public WashingMachine(string ElementBrand, string ElementColor) {
            brand = ElementBrand;
            color = ElementColor;
        }

        protected internal void showOptions()
        {
            bool flag = false;
            Console.Clear();

            do
            {
                Console.WriteLine("Wybierz program prania: ");
                Console.WriteLine("1. Eco");
                Console.WriteLine("2. Szybkie");
                Console.WriteLine("3. Delikatne");
                Console.WriteLine("4. Codzienne");
                Console.WriteLine("5. Wirowanie");
                Console.WriteLine("6. Ustawienia manulane \n");

                option = Convert.ToInt32(Console.ReadLine());
                if (option == 1 || option == 2 || option == 3 || option == 4 || option == 5 || option == 6)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                    Console.Clear();
                    Console.WriteLine("Nieprawidłowa wartość, wprowadź jeszcze raz! \n");
                }

                switch (option)
                {
                    case 1:
                        setWashingTime(90);
                        setWashingTemperature(40);
                        setWashingRPM(1000);
                        break;
                    case 2:
                        setWashingTime(30);
                        setWashingTemperature(60);
                        setWashingRPM(1500);
                        break;
                    case 3:
                        setWashingTime(180);
                        setWashingTemperature(50);
                        setWashingRPM(800);
                        break;
                    case 4:
                        setWashingTime(120);
                        setWashingTemperature(60);
                        setWashingRPM(1200);
                        break;
                    case 5:
                        setWashingTime(15);
                        setWashingTemperature(30);
                        setWashingRPM(1500);
                        break;
                    case 6:
                        setWashingTime(0);
                        setWashingTemperature(0);
                        setWashingRPM(0);
                        break;
                    default:
                        flag = false;
                        break;
                }
            } while (flag == false);

            turnOn(brand, color, washingTime, washingTemperature, washingRPM);
        }

        private int setWashingTime(int wTime)
        {
            if (wTime != 0)
            {
                washingTime = wTime;
            }
            else
            {
                bool flag = false;
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
                bool flag = false;
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
                bool flag = false;
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

            return washingRPM;
        }

        private void turnOn(string brand, string color, int wTime, int wTemperature, int wRPM)
        {
            Console.Clear();
            Console.WriteLine("### Pralka ### \n");
            Console.WriteLine("marka: " + brand);
            Console.WriteLine("kolor: " + color + "\n");
            Console.WriteLine("### Ustawienia ### \n");
            Console.WriteLine("Czas prania: " + wTime);
            Console.WriteLine("Temperatura prania: " + wTemperature);
            Console.WriteLine("Ilość obrotów na minutę: " + wRPM + "\n");
            Console.WriteLine("PRANIE START!");
        }
    }
}
