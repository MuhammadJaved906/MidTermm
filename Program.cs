


using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        StudentClub studentClub = new StudentClub();

        while (true)
        {
            Console.WriteLine("Student Club Management System");
            Console.WriteLine("______________________________");
            Console.WriteLine("1. Go for Registeration of a New Society");
            Console.WriteLine("2. Make Funding to Societies");
            Console.WriteLine("3. Registeration of  an Event for a Society");
            Console.WriteLine("4. Display Society Funding Information");
            Console.WriteLine("5. Display Events for a Society");
            Console.WriteLine("6. Exit");
            Console.Write("Please chose suitable option: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    studentClub.RegisterSociety();
                    break;
                case 2:
                    studentClub.DispenseFunds();
                    break;
                case 3:
                    studentClub.AddEventToSociety();
                    break;
                case 4:
                    studentClub.DisplaySocietyFundingInfo();
                    break;
                case 5:
                    studentClub.DisplayEvents();
                    break;
                case 6:
                    return;
                default:
                    Console.WriteLine("You entered wrong potion please enter valid option.");
                    break;
            }
        }
    }
}

class StudentClub
{
    public double Budget { get; set; } = 2000;
    public List<Society> Societies { get; set; } = new List<Society>();

    public void RegisterSociety()
    {
        Console.Write("Enter society name: ");
        string name = Console.ReadLine();
        Console.Write("Enter contact person: ");
        string contact = Console.ReadLine();
        Console.Write("Is this a funded society? (yes/no): ");
        string isFunded = Console.ReadLine().ToLower();

        if (isFunded == "yes")
        {
            Console.Write("Enter funding amount: ");
            double funding = double.Parse(Console.ReadLine());
            Societies.Add(new FundedSociety(name, contact, funding));
        }
        else
        {
            Societies.Add(new NonFundedSociety(name, contact));
        }
        Console.WriteLine("Society registered successfully.");
    }

    public void DispenseFunds()
    {
        foreach (var society in Societies)
        {
            if (society is FundedSociety fundedSociety)
            {
                Console.WriteLine($"Funding allocated to {fundedSociety.Name}: ${fundedSociety.FundingAmount}");
            }
        }
    }

    public void AddEventToSociety()
    {
        Console.Write("Enter society name: ");
        string name = Console.ReadLine();
        Society society = Societies.Find(s => s.Name == name);

        if (society != null)
        {
            Console.Write("Enter event name: ");
            string eventName = Console.ReadLine();
            society.AddActivity(eventName);
            Console.WriteLine("Event added successfully.");
        }
        else
        {
            Console.WriteLine("Society not found.");
        }
    }

    public void DisplaySocietyFundingInfo()
    {
        foreach (var society in Societies)
        {
            Console.WriteLine($"Society: {society.Name}, Contact: {society.Contact}");
            if (society is FundedSociety fundedSociety)
            {
                Console.WriteLine($"Funding: ${fundedSociety.FundingAmount}");
            }
            else
            {
                Console.WriteLine("Funding: None");
            }
            Console.WriteLine();
        }
    }

    public void DisplayEvents()
    {
        Console.Write("Enter society name: ");
        string name = Console.ReadLine();
        Society society = Societies.Find(s => s.Name == name);

        if (society != null)
        {
            society.ListEvents();
        }
        else
        {
            Console.WriteLine("Society not found.");
        }
    }
}

class ClubRole
{
    public string Name { get; set; }
    public string Role { get; set; }
    public string ContactInfo { get; set; }
}

class Society
{
    public string Name { get; set; }
    public string Contact { get; set; }
    public List<string> Activities { get; set; } = new List<string>();

    public Society(string name, string contact)
    {
        Name = name;
        Contact = contact;
    }

    public void AddActivity(string activity)
    {
        Activities.Add(activity);
    }

    public void ListEvents()
    {
        Console.WriteLine($"Events for {Name}:");
        foreach (var activity in Activities)
        {
            Console.WriteLine($"- {activity}");
        }
        Console.WriteLine();
    }
}

class FundedSociety : Society
{
    public double FundingAmount { get; set; }

    public FundedSociety(string name, string contact, double fundingAmount)
        : base(name, contact)
    {
        FundingAmount = fundingAmount;
    }
}

class NonFundedSociety : Society
{
    public NonFundedSociety(string name, string contact)
        : base(name, contact)
    {
    }
}

