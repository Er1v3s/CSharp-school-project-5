using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Program
{
    internal class Fridge : WashingMachine
    {
        private string coolingTemperature, freezingTemperature;
        public Fridge(string ElementBrand, string ElementColor) : base(ElementBrand, ElementColor)
        {
            
        }

        protected internal void showOptions ()
        {
            Console.WriteLine("### LODÓWKA ### \n");
            Console.WriteLine("1. Książka kucharska");
            Console.WriteLine("2. Lista zakupów");
            Console.WriteLine("3. Ustawienia");
            Console.WriteLine("4. Powrót");
        }

        private void settings()
        {
            Console.WriteLine("### USTAWIENIA ### \n");
            Console.WriteLine("1. Temperatura chłodzenia");
            Console.WriteLine("2. Temperatura mrożenia");
            Console.WriteLine("3. Rozmrażanie");
        }

        //private int setCoolingTemperature(int coolingTemp)
        //{




        //    return coolingTemperature;
        //}

    }
}


//Console.WriteLine("Temperatura chłodzenia 1/3/5/7 (\u00b0C): ");
//Console.WriteLine("Temperatura mrożenia -14/-16/-18/-20 (\u00b0C): ");