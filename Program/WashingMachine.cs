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
        private string brand;
        private string color;
        private int washingTime, washingTemperature, washingRPM;
        public WashingMachine(string ElementBrand, string ElementColor) {
            brand = ElementBrand;
            color = ElementColor;
        }

        protected internal int setWashingTime()
        {
            bool flag = false;
            do
            {
                Console.Write("Czas prania(min): ");
                washingTime = Convert.ToInt16(Console.ReadLine());
                if(washingTime > 1 && washingTime < 180 )
                {
                    flag = true;
                } else flag = false;

            } while (false);

            return washingTime;
        }

        protected internal int setWashingTemperature()
        {
            bool flag = false;
            do
            {
                Console.Write("temperatura(\u00b0C): ");
                washingTemperature = Convert.ToInt16(Console.ReadLine());
                if (washingTemperature > 1 && washingTemperature < 80)
                {
                    flag = true;
                }
                else flag = false;

            } while (false);

            return washingTemperature;
        }

        protected internal int setWashingRPM()
        {
            bool flag = false;
            do
            {
                Console.Write("Obroty na minute: ");
                washingRPM = Convert.ToInt16(Console.ReadLine());
                if (washingRPM > 100 && washingRPM < 1500)
                {
                    flag = true;
                }
                else flag = false;

            } while (false);

            return washingRPM;
        }

        protected internal void turnOn(string brand, string color, int washingTime, int washingTemperature, int washingRPM)
        {
            Console.Clear();
            Console.WriteLine("### Pralka ### ");
            Console.WriteLine("marka: ", brand);
            Console.WriteLine("kolor: ", color);
            Console.WriteLine("### Ustawienia ###");
            Console.WriteLine("Czas prania: ", washingTime);
            Console.WriteLine("Temperatura prania: ", washingTemperature);
            Console.WriteLine("Ilość obrotów na minutę: ", washingRPM);
            Console.WriteLine("START!");
        }
    }
}
