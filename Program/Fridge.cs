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
        private int coolingTemperature, freezingTemperature, doors;
        private static int option;
        private static bool flag = false;
        private string line;
        private static ArrayList shoppingList = new();

        private int zuzyciePradu;

        public int ZuzyciePradu { get { return zuzyciePradu; } }

        public static int Option
        {
            get { return option; }
            set { option = value; }
        }

        public static bool Flag
        {
            get { return flag; }
            set { flag = value; }
        }

        public static Fridge operator +(Fridge left, Fridge right)
        {
            return new Fridge(left.doors + right.doors);
        }

        public static Fridge operator >(Fridge left, Fridge right)
        {
            if(left.zuzyciePradu > right.zuzyciePradu)
            {
                return new Fridge(left.doors);
            }
            else
            {
                return new Fridge(right.doors);
            }
        }

        public static Fridge operator <(Fridge left, Fridge right)
        {
            if (left.zuzyciePradu < right.zuzyciePradu)
            {
                return new Fridge(right.doors);
            }
            else
            {
                return new Fridge(left.doors);
            }
        }

        public Fridge() { }

        public Fridge(int numOfDoors)
        {
            doors = numOfDoors;
        }

        public int Doors { get { return doors;  } }

        public int SetNumOfDoors()
        {
            do
            {
                Console.WriteLine("Ilu drzwiowa ma być lodówka? 1 czy 2 \n");
                Console.Write("Twój wybór: ");
                try
                {
                    doors = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Nieprawidłowa wartość, wprowadź jeszcze raz!");
                }

                if (doors == 1 || doors == 2)
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

            if(doors == 1)
            {
                zuzyciePradu = 650;
            }
            else if(doors == 2)
            {
                zuzyciePradu = 1000;
            }

            return option;
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
                        ShowCookbook();
                        break;
                    case 2:
                        ShowShoppingList(doors, flag, option);
                        break;
                    case 3:
                        Settings();
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

        private void ShowCookbook()
        {
            Console.Clear();

            if(doors == 2)
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
                            FileReader("/Users/filip_statkiewicz/Programing Projects/C#/zadanie-5/CSharp-school-project-5/src/przepisy/nalesniki.txt");

                            flag = false;
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Przepis na kurczaka po chińsku: \n");
                            FileReader("/Users/filip_statkiewicz/Programing Projects/C#/zadanie-5/CSharp-school-project-5/src/przepisy/kurczak.txt");

                            flag = false;
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Przepis na zapiekanke ziemniaczną: \n");
                            FileReader("/Users/filip_statkiewicz/Programing Projects/C#/zadanie-5/CSharp-school-project-5/src/przepisy/.txt");

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
                Sleep(1000);
                ShowOptions();
            }
        }

        public static void ShowShoppingList(int doorsRef, bool flagRef, int optionRef)
        {
            Console.Clear();
            if (doorsRef == 2)
            {
                int id;
                string article;
                do
                {
                    Console.WriteLine("1. Dodaj artykół");
                    Console.WriteLine("2. Usuń artykół");
                    Console.WriteLine("3. Wyczyść listę");;
                    Console.WriteLine("4. Wyjdź \n");

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
                        optionRef = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        flagRef = false;
                        Console.Clear();
                    }

                    if (optionRef == 1 || optionRef == 2 || optionRef == 3 || optionRef == 4 || optionRef == 5)
                    {
                        flag = true;
                    }
                    else
                    {
                        flagRef = false;
                        Console.Clear();
                        Console.WriteLine("Nieprawidłowa wartość, wprowadź jeszcze raz! \n");
                    }

                    switch (optionRef)
                    {
                        case 1:
                            Console.Write("nazwa artykułu: ");
                            article = Console.ReadLine();
                            shoppingList.Add(article);
                            Console.Clear();
                            flagRef = false;
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
                                    flagRef = false;
                                    Console.Clear();
                                    Console.WriteLine("Na liście nie ma takiego artykułu! \n");
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Na liśnie jeszcze nic nie ma! \n");
                            }
                            flagRef = false;
                            break;
                        case 3:
                            shoppingList.Clear();
                            Console.Clear();
                            flagRef = false;
                            break;
                        case 4:
                            Environment.Exit(0);
                            break;
                    }
                    optionRef = 0;
                } while (!flagRef);
                flagRef = false;
                optionRef = 0;
            } else
            {
                Console.WriteLine("Niestety tylko lodówki dwódrzwiowe są wyposażone w tą opcję \n");
                Sleep(1000);
            }
        }

        private void Settings()
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
                        SetCoolingTemperature(1, ref coolingTemperature);
                        break;
                    case 2:
                        Console.Clear();
                        SetFreezingTemperature(1, ref freezingTemperature);
                        break;
                    case 3:
                        Console.Clear();
                        Defrosting();
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

        private void SetCoolingTemperature(int coolTemp, ref int coolingTemperature)
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
                        SetCoolingTemperature(1, ref coolingTemperature);

                    }
                }
                else
                {
                    coolingTemperature = coolTemp;
                }
                    
            }
            catch (Exception)
            { 
                SetCoolingTemperature(1, ref coolingTemperature);
            }

            option = 0;
            if (coolTemp != 0)
            {
                Sleep(1000);
                ShowOptions();
            }
        }

        private void SetFreezingTemperature(int freezTemp, ref int freezingTemperature)
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
                        SetFreezingTemperature(1, ref freezingTemperature);

                    }
                }
                else
                {
                    freezingTemperature = freezTemp;
                }
            }
            catch (Exception)
            {
                SetFreezingTemperature(1, ref freezingTemperature);
            }

            option = 0;
            if(freezTemp != 0)
            {
                Sleep(1000);
                ShowOptions();
            }
        }

        private void Defrosting()
        {
            SetCoolingTemperature(0, ref coolingTemperature);
            SetFreezingTemperature(0, ref freezingTemperature);

            Console.Clear();
            Console.WriteLine("Lodówka ustawiona na rozmrażanie \n");

            Sleep(1000);
            ShowOptions();
        }

        private void FileReader(string filepath)
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
            catch (Exception)
            {
                Console.WriteLine("Jeżeli nie widzisz przepisu, zgłoś to do serwisu!");
            }
        }

        private static void Sleep(int sleepingTime)
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