using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    internal class Fridge
    {
        private int coolingTemperature, freezingTemperature, option, id, doors;
        private bool flag = false;
        private string line;
        private ArrayList shoppingList = new ArrayList();
        public Fridge() { }

        public Fridge(int numOfDoors)
        {
            doors = numOfDoors;
        }

        protected internal void ShowOptions()
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

        private void showCookbook()
        {
            Console.Clear();

            if(doors == 1)
            {
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
                            fileReader("..\\..\\..\\..\\src\\przepisy\\nalesniki.txt");

                            flag = false;
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Przepis na kurczaka po chińsku: \n");
                            fileReader("..\\..\\..\\..\\src\\przepisy\\kurczak.txt");

                            flag = false;
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Przepis na zapiekanke ziemniaczną: \n");
                            fileReader("..\\..\\..\\..\\src\\przepisy\\zapiekanka.txt");

                            flag = false;
                            break;
                        case 4:
                            ShowOptions();
                            break;
                        case 5:
                            Environment.Exit(0);
                            break;
                    }
                } while (!flag);

                option = 0;
                flag = false;
            }
            else
            {
                Console.WriteLine("Niestety tylko lodówki dwódrzwiowe są wyposażone w tą opcję \n");
                sleep(1000);
                ShowOptions();
            }
        }

        private void showShoppingList()
        {
            Console.Clear();
            if (doors == 1)
            {
                string article;
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
                            ShowOptions();
                            break;
                        case 5:
                            Environment.Exit(0);
                            break;
                    }
                    option = 0;
                } while (!flag);
                flag = false;
                option = 0;
            } else
            {
                Console.WriteLine("Niestety tylko lodówki dwódrzwiowe są wyposażone w tą opcję \n");
                sleep(1000);
                ShowOptions();
            }
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
                        setCoolingTemperature(1);
                        break;
                    case 2:
                        Console.Clear();
                        setFreezingTemperature(1);
                        break;
                    case 3:
                        Console.Clear();
                        defrosting();
                        break;
                    case 4:
                        ShowOptions();
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

        private void setCoolingTemperature(int coolTemp)
        {
            Console.WriteLine("Temperatura chłodzenia 1/3/5/7 (\u00b0C): ");

            Console.Write("Twój wybór: ");
            try
            {
                if (coolTemp != 0)
                {
                    option = Convert.ToInt32(Console.ReadLine());
                    if (option == 1 || option == 3 || option == 5 || option == 7)
                    {
                        coolingTemperature = option;

                        Console.WriteLine("\nUstawiono temerature chłodzenia na: " + coolingTemperature + "\n");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Nieprawidłowa wartość, wprowadź jeszcze raz! \n");
                        setCoolingTemperature(1);

                    }
                }
                else
                {
                    coolingTemperature = coolTemp;
                }
                    
            }
            catch (Exception)
            { 
                setCoolingTemperature(1);
            }

            option = 0;
            if (coolTemp != 0)
            {
                sleep(1000);
                ShowOptions();
            }
        }

        private void setFreezingTemperature(int freezTemp)
        {
            Console.WriteLine("Temperatura mrożenia -14/-16/-18/-20 (\u00b0C): ");

            Console.Write("Twój wybór: ");
            try
            {
                if (freezTemp != 0)
                {
                    option = Convert.ToInt32(Console.ReadLine());
                    if (option == -14 || option == -16 || option == -18 || option == -20)
                    {
                        freezingTemperature = option;

                        Console.WriteLine("\nUstawiono temerature mrożenia na: " + freezingTemperature + "\n");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Nieprawidłowa wartość, wprowadź jeszcze raz! \n");
                        setFreezingTemperature(1);

                    }
                }
                else
                {
                    freezingTemperature = freezTemp;
                }
            }
            catch (Exception)
            {
                setFreezingTemperature(1);
            }

            option = 0;
            if(freezTemp != 0)
            {
                sleep(1000);
                ShowOptions();
            }
        }

        private void defrosting()
        {
            setCoolingTemperature(0);
            setFreezingTemperature(0);

            Console.Clear();
            Console.WriteLine("Lodówka ustawiona na rozmrażanie \n");

            sleep(1000);
            ShowOptions();
        }

        private void fileReader(string filepath)
        {
            try
            {
                StreamReader sr = new StreamReader(filepath);
                line = sr.ReadLine();
                while (line != null)
                {
                    Console.WriteLine($"{line}");
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Jeżeli nie widzisz przepisu, zgłoś to do serwisu!");
            }
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
    }
}