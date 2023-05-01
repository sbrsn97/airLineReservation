namespace HavaYolu
{
    internal class Program
    {
        static int choice;
        static string fullName = "";
        static string[] businessNames = { "", "", "", "", "", "", "", "" };
        static string[] economyNames = { "", "", "", "", "", "", "", "", "", "", "", "" };
        static int counterBusiness = 0;
        static int counterEconomy = 0;
        static int seatChoice = 0;
        static void Main(string[] args)
        {
            ClassChoice();
            GetName();
            CheckSeat();
            Reservation();
            if(counterBusiness + counterEconomy == 20)
            {
                Quit();
            }           
            Main(null);
        }
        private static void ClassChoice()
        {
            Console.WriteLine(new string('*', 20) + "Welcome to BilgeAdam airlines!" + new string('*', 20));
            if (counterBusiness != businessNames.Length)
            {
                Console.WriteLine("1.Business class");
            }
            else
            {
                Console.WriteLine("All business class seats are taken");
            }
            if (counterEconomy != economyNames.Length)
            {
                Console.WriteLine("2.Economy class");
            }
            else
            {
                Console.WriteLine("All economy class seats are taken");
            }
            try
            {
                choice = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Faulty input");
                ClassChoice();
            }
            switch (choice)
            {
                case 1:
                    if(counterBusiness == businessNames.Length)
                    {
                        ClassChoice();
                    }
                    break;
                case 2:
                    if (counterEconomy == economyNames.Length)
                    {
                        ClassChoice();
                    }
                    break;
                default:
                    Console.WriteLine("Faulty input, please enter a valid class.");
                    ClassChoice();
                    break;
            }
        }
        private static void GetName()
        {
            Console.WriteLine("Enter your full name");
            fullName = Console.ReadLine();
            for (int i = 0; i < fullName.Length; i++)
            {
                if (char.IsDigit(fullName[i]))
                {
                    Console.WriteLine("Name can not contain numbers.");
                    GetName();
                }
            }
        }
        private static void CheckSeat()
        {
            if (choice == 1)
            {             
                    for (int i = 0; i < businessNames.Length; i++)
                    {
                        if (businessNames[i] == "")
                        {
                            Console.WriteLine($"{i + 1}. seat is available");
                        }
                        else
                        {
                            Console.WriteLine($"{i + 1}. seat is reserved by {businessNames[i]}");
                        }
                    }               
            }
            else if (choice == 2)
            {                            
                    for (int i = 0; i < economyNames.Length; i++)
                    {
                        if (economyNames[i] == "")
                        {
                            Console.WriteLine($"{i + 1}. seat is available");
                        }
                        else
                        {
                            Console.WriteLine($"{i + 1}. seat is reserved by {economyNames[i]}");
                        }
                    }
            }
        }
        private static void Reservation()
        {
            if(choice == 1)
            {
                try
                {
                    Console.WriteLine("Choose a seat");
                    seatChoice = Convert.ToInt32(Console.ReadLine()) - 1;
                    if (businessNames[seatChoice]=="")
                    {
                        businessNames[seatChoice] = fullName;
                        counterBusiness++;
                    }
                    else
                    {
                        Console.WriteLine("The seat you've chosen is taken.");
                        Reservation();
                    }
                    //Console.WriteLine($"{seatChoice+1}. seat is reserved by {businessNames[seatChoice]}");
                    CheckSeat();
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine($"{seatChoice}. seat doesn't exist");
                    Reservation();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid seat number.");
                    Reservation();
                }
            }
            else if(choice == 2)
            {
                try
                {
                    Console.WriteLine("Choose a seat");
                    seatChoice = Convert.ToInt32(Console.ReadLine()) - 1;
                    if (economyNames[seatChoice] == "")
                    {
                        economyNames[seatChoice] = fullName;
                        counterEconomy++;
                    }
                    else
                    {
                        Console.WriteLine("The seat you've chosen is taken.");
                        Reservation();
                    }
                    //Console.WriteLine($"{seatChoice + 1}. seat is reserved by {economyNames[seatChoice]}");
                    CheckSeat();
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine($"{seatChoice}. seat doesn't exist");
                    Reservation();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid seat number.");
                    Reservation();
                }
            }
        }

        private static void Quit()
        {
            Console.WriteLine("This flight is full, press 'Q' to quit.");
            string quit = Console.ReadLine().ToLower();
            if (quit == "q")
            {
                Environment.Exit(0);
            }
            else
                Quit();
        }

    }
}