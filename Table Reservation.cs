using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace Table_Reservation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string x = ("");

            //List for Reservation 
            List<int> ID = new List<int>();
            List<string> name = new List<string>();
            List<int> peopleCount = new List<int>();
            List<DateTime> dates = new List<DateTime>();
            List<int> tablenumber = new List<int> ();

            //Restaurant contraints
            int totalTable = 5;


            while (x != "6")
            {
                Console.WriteLine("1. Add Reservation: ");
                Console.WriteLine("2. View Reservation: ");
                Console.WriteLine("3. Modify Reservation: ");
                Console.WriteLine("4. Cancel Reservation: ");
                Console.WriteLine("5. View Table Status: ");
                Console.WriteLine("6. Quit: ");

                x = Console.ReadLine();



                
                 if (x == "1") // Add Reservation
                {
                    Console.WriteLine("Enter Reservation ID: ");
                    int a = int.Parse(Console.ReadLine());

                    //Prevent duplicat IDs
                    if (ID.Contains(a)) { Console.WriteLine("Error: Duplicate Reservation ID. "); }

                    
                    Console.WriteLine("Enter Guest's name: ");
                    string names = Console.ReadLine();
                    
                    Console.WriteLine("Enter number of people: ");
                    int count = int.Parse(Console.ReadLine());
                    
                    Console.WriteLine("Enter the date and time: ");
                    DateTime date = DateTime.Parse(Console.ReadLine());



                    Console.WriteLine("Enter table number (1-5): "); // Ask for table number
                    int t = int.Parse(Console.ReadLine());
                    

                    // Table Availability check
                    bool taken = false;
                    for (int i = 0; i < tablenumber.Count; i++)
                    {
                        if (tablenumber[i] == t && dates[i] == date)
                        { taken = true; }
                    }
                    if (taken) { Console.WriteLine("Error: Table already reserved at this time. ");
                        continue;// do NOT add reservation

                    }

                    // Add reservation ONlY if all checks pass
                    ID.Add(a);
                    name.Add(names);
                    peopleCount.Add(count);
                    dates.Add(date);
                    tablenumber.Add(t);

                    Console.WriteLine("Reservation added! ");


                }
                if (x == "2") // View Reservations
                {
                    Console.WriteLine("List of Reservations: ");
                    for (int i = 0; i < ID.Count; i++)
                    {
                        Console.WriteLine($"{ID[i]}, {name[i]},{peopleCount[i]},{dates[i]} ");
                    }

                }
                if (x == "3") // Modify Reservations
                {
                    for (int i = 0; i < ID.Count; i++)
                    {
                        Console.WriteLine($"{ID[i]}, {name[i]},{peopleCount[i]},{dates[i]} ");
                    }
                    Console.WriteLine("Enter the Reservation ID you want to modify: ");
                    int newID = int.Parse(Console.ReadLine());
                    int index = ID.IndexOf(newID);
                    if (index == -1)
                    {
                        Console.WriteLine("Reservation not found.");

                    }
                    else
                    {
                        Console.WriteLine("What would you like to modify?");
                        Console.WriteLine("1. Guest Name");
                        Console.WriteLine("2. Number of people");
                        Console.WriteLine("3. Date & Time");
                        string choice = Console.ReadLine();
                        if (choice == "1")
                        {
                            Console.WriteLine("Enter new Guest name: ");
                            name[index] = Console.ReadLine();

                        }
                        else if (choice == "2")
                        {
                            Console.WriteLine("Enter new number of people: ");
                            peopleCount[index] = int.Parse(Console.ReadLine());
                            

                        }
                        else if (choice == "3")
                        {
                            Console.WriteLine("Enter new Date & Time: ");
                            dates[index] = DateTime.Parse(Console.ReadLine());
                        }
                        else
                        {
                            Console.WriteLine("Invaild Options");
                        }
                        Console.WriteLine("Reservation updated!");
                    }
                }

                if (x == "4")// Cancel Reservation
                {
                    for (int i = 0; i < ID.Count; i++)
                    {
                        Console.WriteLine($"{ID[i]}, {name[i]},{peopleCount[i]},{dates[i]} ");
                    }
                    Console.WriteLine("Enter the Reservation ID you would like to cancel: ");
                    int cancelid = int.Parse(Console.ReadLine());
                    int cancelindex = ID.IndexOf(cancelid);
                    if (cancelindex == -1)
                    { Console.WriteLine("Reservation not found."); }
                    else
                    {
                        ID.RemoveAt(cancelindex);
                        name.RemoveAt(cancelindex);
                        peopleCount.RemoveAt(cancelindex);
                        dates.RemoveAt(cancelindex);
                        Console.WriteLine("Reservation canceled!");
                    }

                }
                if (x == "5") // View Table Status
                    for (int table = 1; table <= 5; table++)
                    {
                        bool reserved = false;
                        for (int i = 0; i < tablenumber.Count; i++)
                        {
                            if (tablenumber[i] == table)
                            {
                                Console.WriteLine($"Table{table}: Reserved for {name[i]} at {dates[i]}");
                                reserved = true;
                            }
                        }
                        if (!reserved) { Console.WriteLine($"Table {table}: Available");
                        }
                    }
            }
        }
    }
}


