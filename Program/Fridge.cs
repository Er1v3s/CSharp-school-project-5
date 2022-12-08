﻿using System;
using System.Collections;
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
        private bool flag = false;
        private int option, id;
        private ArrayList shoppingList = new ArrayList();
        public Fridge(string ElementBrand, string ElementColor) : base(ElementBrand, ElementColor)
        {
            
        }

        protected internal void showOptions ()
        {
            Console.Clear();
            do
            { 
                Console.WriteLine("### LODÓWKA ### \n");
                Console.WriteLine("1. Książka kucharska");
                Console.WriteLine("2. Lista zakupów");
                Console.WriteLine("3. Ustawienia");
                Console.WriteLine("4. Wyjdź \n");

                Console.Write("Twój wybór: ");

                try
                {
                    option = Convert.ToInt32(Console.ReadLine());
                } catch (Exception) {
                    flag = false;
                    Console.Clear();
                }

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
                        option = 0;
                        break;
                }

            } while(!flag);

            flag = false;
            option = 0;
        }

        private void settings()
        {
            Console.Clear();
            do
            {
                Console.WriteLine("### USTAWIENIA ### \n");
                Console.WriteLine("1. Temperatura chłodzenia");
                Console.WriteLine("2. Temperatura mrożenia");
                Console.WriteLine("3. Rozmrażanie");
                Console.WriteLine("4. Powrót");
                Console.WriteLine("5. Wyjdź \n");

                Console.Write("Twój wybór: ");
                try
                {
                    option = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    flag = false;
                    Console.Clear();
                }

                if (option == 1 || option == 2 || option == 3 || option == 4 || option == 5)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                    Console.WriteLine("Nieprawidłowa wartość, wprowadź jeszcze raz! \n");
                }

                switch (option)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("1");
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("2");
                        break;
                    case 3:
                        Console.Clear();
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

        private void showCookbook()
        {
            Console.Clear();
            do
            {
                Console.WriteLine("### KSIĄŻKA KUCHARSKA ### \n");
                Console.WriteLine("1. Naleśniki");
                Console.WriteLine("2. Kurczak po chińsku");
                Console.WriteLine("3. Zapiekanka ziemniaczana");
                Console.WriteLine("4. Powrót");
                Console.WriteLine("5. Wyjdź");

                Console.WriteLine("\n");
                Console.Write("Twój wybór: ");

                try
                {
                    option = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    flag = false;
                    Console.Clear();
                }

                if (option == 1 || option == 2 || option == 3 || option == 4 || option == 5)
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
                        Console.Clear();
                        Console.WriteLine("Przepis na naleśniki: \n");
                        flag = false;
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Przepis na kurczaka po chińsku: \n");
                        flag = false;
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Przepis na zapiekanke ziemniaczną: \n");
                        flag = false;
                        break;
                    case 4:
                        showOptions();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                }
            } while (!flag);
            
            option = 0;
            flag = false;
        }

        private void showShoppingList()
        {
            string article;

            Console.Clear();
            do
            { 
                Console.WriteLine("1. Dodaj artykół");
                Console.WriteLine("2. Usuń artykół");
                Console.WriteLine("3. Wyczyść listę");
                Console.WriteLine("4. Powrót");
                Console.WriteLine("5. Wyjdź \n");

                Console.WriteLine("### Lista zakupów ### \n");

                int i = 1;
                foreach (string item in shoppingList)
                {
                    Console.WriteLine(i + ". " + item);
                    i++;
                }

                Console.WriteLine("\n#######################");

                Console.WriteLine("\n");
                Console.Write("Twój wybór: ");

                try
                {
                    option = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    flag = false;
                    Console.Clear();
                }

                if (option == 1 || option == 2 || option == 3 || option == 4 || option == 5)
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
                        Console.Write("nazwa artykułu: ");
                        article = Console.ReadLine();
                        shoppingList.Add(article);
                        Console.Clear();
                        flag = false;
                        break;
                    case 2:
                        if (shoppingList.Count > 0)
                        {
                            Console.Write("numer artykułu: ");
                            try
                            {
                                id = Convert.ToInt32(Console.ReadLine());
                                shoppingList.Reverse();
                                shoppingList.RemoveAt(shoppingList.Count - id);
                                shoppingList.Reverse();
                                Console.Clear();
                            }
                            catch (Exception)
                            {
                                flag = false;
                                Console.Clear();
                                Console.WriteLine("Na liście nie ma takiego artykułu! \n");
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Na liśnie jeszcze nic nie ma! \n");
                        }
                        flag = false;
                        break;
                    case 3:
                        shoppingList.Clear();
                        Console.Clear();
                        flag = false;
                        break;
                    case 4:
                        showOptions();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                }
                option = 0;
            } while (!flag);
            flag = false;
            option = 0;
        }

        //private int setCoolingTemperature(int coolingTemp)
        //{ 
        //    return coolingTemperature;
        //}

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