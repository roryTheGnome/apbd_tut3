namespace apbd_tut3;

public class Voyage
{
    public string serialNo { get; set; }
    public string startDate { get; set; }
    public string expectedEndDate { get; set; }
    public List<Ship> shipList { get; set; }
    public bool hasEnded { get; set; }
    public string endDate { get; set;}
    
    public string startLocation { get; set;}
    public string destination { get; set;}
    
    public Voyage(string serialNo, string startDate, string expectedEndDate , string startLocation, string destination)
    {
        this.serialNo = serialNo;
        this.startDate = startDate;
        this.expectedEndDate = expectedEndDate;
        this.startLocation = startLocation;
        this.destination = destination;
        shipList = new List<Ship>();
        hasEnded = false;
    }

    public void AddShip(Ship ship)
    {
        if (!ship.isAvailable)
        {
            shipList.Add(ship);
            ship.isAvailable = true;
        }
        else
        {
            Console.WriteLine("This ship has registered into another voyage!!");
        }
    }

    public void removeShip()
    {
        foreach (var ship in shipList)
        {
            Console.WriteLine("Ship List : ");
            Console.WriteLine($" - {ship.serialNo}");  
        }
        Console.WriteLine("Please enter the serialNo of the ship you want to remove : ");
        string targerSerialNo = Console.ReadLine();
        foreach (var ship in shipList)
        {
            if (ship.serialNo == targerSerialNo)  //TODO if i get time left n if im not too lazy plss combine all the checking shits in one method
            {
                ship.isAvailable = true;
                shipList.Remove(ship);
                Console.WriteLine($"Ship {ship.serialNo} has removed from this voyage");
                return;
            }
        }
        Console.WriteLine("You entered an invalid serialNo!!");
    }

    public void endVoyage(string endDate)
    {
        hasEnded = true;
        this.endDate = endDate;
        foreach (Ship ship in shipList)
        {
            ship.isAvailable = false;
        }
    }
    
    public void PrintVoyageInfo()
    {
        Console.WriteLine($"Voyage Info:" +
                          $"\nSerial No : {serialNo}" +
                          $"\nStart Date : {startDate}" +
                          $"\nExpected End DAte : {expectedEndDate}" +
                          $"\nIs this voyage still active : {hasEnded}" +
                          $"\nStart location : {startLocation}" +
                          $"\nDestination : {destination}");
        if (hasEnded)
        {
            Console.WriteLine($"End Date : {endDate}");
        }
        Console.WriteLine($"Ships Attending this voyage: {shipList.Count} ships has registered");
        foreach (var ship in shipList)
        {
            Console.WriteLine($" - {ship.serialNo}");
        }
        Console.WriteLine("Would you like to take a closer look in the ships ? (1 for yes)");
        string choice = Console.ReadLine();
        if (choice == "1")
        {
            foreach (Ship ship in shipList)
            {
                ship.PrintShipInfo();
                Console.WriteLine();
            }
        }
        return;
    }
    
}