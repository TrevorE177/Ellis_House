using System;
using System.Buffers;
using System.Collections;

PrintHouse();

static void PrintHouse()
{
    Console.WriteLine("Welcome to                 #");
    Console.WriteLine("House o' Matic               #");
    Console.WriteLine("                      /\\   ##");
    Console.WriteLine("                     /  \\  #");
    Console.WriteLine("                    /    \\[]         /\\");
    Console.WriteLine("                   /      \\  /\\     /  \\");
    Console.WriteLine("                  /   []   \\/  \\___/    \\");
    Console.WriteLine("                 /  []      \\   \\ / []   \\");
    Console.WriteLine("                /|          |\\   /|   [] |\\");
    Console.WriteLine("                 |____[]____|_____|______|");
    Console.WriteLine();
    Console.WriteLine("-----------------------------------------");
    Console.Write("Please press \"Enter\" to continue");
    Console.ReadKey();
    Console.Clear();
}

int[] RoomDimensions = new int[10];
string running = "Y";

Console.Write("What is the client's name for this house?: ");
string ClientName = Console.ReadLine();
Console.Clear();

SetRoomDimensions();

void SetRoomDimensions()
{
    int RoomNum = 1;
    for (int i = 0; i < RoomDimensions.Length; i++)
    {
        Console.WriteLine("Please enter the dimensions of room #" + RoomNum++ + ": ");
        Console.Write("Length: ");
        int length = Convert.ToInt32(Console.ReadLine());
        Console.Write("Width: ");
        int width = Convert.ToInt32(Console.ReadLine());
        RoomDimensions[i] = length * width;

        Console.Write("Do you want to enter dimensions for another room? (Y/N): ");
        running = Console.ReadLine();
        Console.Clear();
        if (running.ToUpper() != "Y")
            break;
    }
}

OptionSelectMenu();

void OptionSelectMenu()
{
    static void Display(string prefix, string message)
    {
        Console.Write("[");
        Console.Write(prefix);
        Console.WriteLine("] " + message);
    }

    int loopRun = 1;
    while (loopRun == 1)
    {
        Display("1", "Display total square footage of the house.");
        Display("2", "Display total number of rooms.");
        Display("3", "Display square footage of each room.");
        Display("4", "Display average of all rooms.");
        Display("5", "Display square footage of the largest room.");
        Display("6", "Exit the program.");
        Console.WriteLine("--------------------------------");
        Console.Write("Please select an option for " + ClientName + "'s house: ");        

        string option = Console.ReadLine();
        if (option == "1")
        {
            var sum = RoomDimensions.Sum();
            Console.WriteLine();
            Console.WriteLine("The square footage of the house is " + sum + " feet.");
            Thread.Sleep(3000);
            Console.Clear();
        }
        else if (option == "2")
        {
            var count = RoomDimensions.Count(c => c>0);
            Console.WriteLine();
            Console.WriteLine("There are " + count + " rooms.");
            Thread.Sleep(3000);
            Console.Clear();
        }
        else if (option == "3")
        {
            int RoomNum = 1;
            Console.WriteLine();
            for (int i = 0; i < RoomDimensions.Length; i++)
            {
                if (RoomDimensions[i] != 0)
                    Console.WriteLine("Room #" + RoomNum++ + ": " + RoomDimensions[i] + " feet");
            }
            Thread.Sleep(5000);
            Console.Clear();
        }
        else if (option == "4")
        {
            var sum = RoomDimensions.Sum();
            var count = RoomDimensions.Count(c => c > 0);
            Console.WriteLine();
            Console.WriteLine("The average square footage of all rooms is " + CalcAvg(sum, count) + " feet.");
            Thread.Sleep(3000);
            Console.Clear();
        }
        else if (option == "5")
        {
            int largest = RoomDimensions.Max();
            Console.WriteLine();
            Console.WriteLine("The largest room has a square footage of " + largest + " feet.");
            Thread.Sleep(3000);
            Console.Clear();
        }
        else if (option == "6")
        {
            loopRun = 0;
            Console.Clear();
        }
        else
        {
            Console.WriteLine("Error... Please chose a valid option...");
            Thread.Sleep(2000);
            Console.Clear();
        }
    }
}

int average;
int CalcAvg(int s, int c)
{
    average = s / c;
    return average;
}