using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
            int option;
            bool flag = false;

            do
            {
                Console.Clear();
                Console.WriteLine("### LODÓWKA ### \n");
                Console.WriteLine("1. Książka kucharska");
                Console.WriteLine("2. Lista zakupów");
                Console.WriteLine("3. Ustawienia");
                Console.WriteLine("4. Wyjdź \n");

                option = Convert.ToInt32(Console.ReadLine());
                if (option == 1 || option == 2 || option == 3 || option == 4) 
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
                        showCookbook();
                        break;
                    case 2:
                        showShoppingList();
                        break;
                    case 3:
                        settings();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        flag = false;
                        break;
                }

            } while(!flag);
        }

        private void settings()
        {
            int option;
            bool flag = false;

            Console.Clear();
            Console.WriteLine("### USTAWIENIA ### \n");
            Console.WriteLine("1. Temperatura chłodzenia");
            Console.WriteLine("2. Temperatura mrożenia");
            Console.WriteLine("3. Rozmrażanie \n");
            Console.WriteLine("4. Powrót \n");
            Console.WriteLine("5. Wyjdź \n");

            do
            {

                option = Convert.ToInt32(Console.ReadLine());
                if (option == 1 || option == 2 || option == 3)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                    //Console.Clear();
                    Console.WriteLine("Nieprawidłowa wartość, wprowadź jeszcze raz! \n");
                }

                switch (option)
                {
                    case 1:
                        Console.WriteLine("1");
                        break;
                    case 2:
                        Console.WriteLine("2");
                        break;
                    case 3:
                        Console.WriteLine("3");
                        break;
                    case 4:
                        showOptions();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        flag = false;
                        break;
                }

            } while (!flag);
        }

        //private int setCoolingTemperature(int coolingTemp)
        //{ 
        //    return coolingTemperature;
        //}

        private void showCookbook()
        {
            Console.Clear();
            Console.WriteLine("### KSIĄŻKA KUCHARSKA ### \n");
            Console.WriteLine("1. Naleśniki");
            Console.WriteLine("2. Kurczak po chińsku");
            Console.WriteLine("3. Zapiekanka ziemniaczana");
        }

        private void showShoppingList()
        {
            Console.Clear();
            Console.WriteLine("### Lista zakupów ### \n");

        }

        //private int setCoolingTemperature(int coolTemp)
        //{

        //}

        //private int setFreezingTemperature(int freeztemp)
        //{

        //}

        //private void defrosting()
        //{
        //    setCoolingTemperature();
        //    setFreezingTemperature();
        //}

    }
}


//Console.WriteLine("Temperatura chłodzenia 1/3/5/7 (\u00b0C): ");
//Console.WriteLine("Temperatura mrożenia -14/-16/-18/-20 (\u00b0C): ");