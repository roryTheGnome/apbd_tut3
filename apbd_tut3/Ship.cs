namespace apbd_tut3;

public class Ship
{
    public string serialNo { get; set; }
    public List<Container> containers { get; set; }
    public int maxContainers { get; set; }
    public double maxWeight { get; set; } 
    public double maxSpeed { get; set; }
    public bool isAvailable { get; set; }
    public static int serialNoTracker = 1;

    public Ship(int maxContainers, double maxWeight, double maxSpeed)
    {
        this.maxContainers = maxContainers;
        this.maxWeight = maxWeight * 1000; //i prefer to use kg as default so converted tons to kg here
        this.maxSpeed = maxSpeed;
        containers = new List<Container>();
        isAvailable = false;
        this.serialNo = "SS"+(serialNoTracker++.ToString());
    }

    public void LoadContainer(Container container)
    {
        if (containers.Count >= maxContainers)
        {
            Console.WriteLine("This ship is already full!");
            return;
        }

        double totalWeight = containers.Sum(c => c.mass);
        if (totalWeight + container.mass > maxWeight)
        {
            Console.WriteLine("Adding this cpntainer exceeds weight limit!");
            return;
        }

        containers.Add(container);
        container.isInShip = true;
        Console.WriteLine($"Container {container.serialNo} loaded onto ship.");
    }

    public void RemoveContainer(string serialNo)
    {
        Container container = containers.FirstOrDefault(c => c.serialNo == serialNo);
        if (container != null)
        {
            containers.Remove(container);
            container.isInShip = false;
            Console.WriteLine($"Container {serialNo} removed from ship.");
        }
        else
        {
            Console.WriteLine("404 container not found!");
        }
    }
    
    public void TransferContainer(Ship destinationShip, Container container)
    {
        if (!containers.Contains(container))
        {
            Console.WriteLine("Container not found on this ship.");
            return;
        }

        // Check if the destination ship can take the container
        if (destinationShip.containers.Count >= destinationShip.maxContainers)
        {
            Console.WriteLine("Transfer failed: Destination ship has reached its container limit.");
            return;
        }

        double totalWeight = destinationShip.containers.Sum(c => c.mass);
        if (totalWeight + container.mass > destinationShip.maxWeight)
        {
            Console.WriteLine("Transfer failed: Destination ship cannot handle more weight.");
            return;
        }

        if (containers.Contains(container))
        {
            RemoveContainer(container.serialNo);
            destinationShip.LoadContainer(container);
            Console.WriteLine($"Container {container.serialNo} transferred to another ship.");
        }
        else
        {
            Console.WriteLine("Container not found on this ship.");
        }
    }

    public void PrintShipInfo()
    {
        Console.WriteLine($"Ship Info:" +
                          $"\nMax Speed: {maxSpeed} knots" +
                          $"\nMax Containers: {maxContainers}" +
                          $"\nMax Weight: {maxWeight / 1000} tons");
        Console.WriteLine($"Currently Loaded Containers: {containers.Count}");
        foreach (var container in containers)
        {
            Console.WriteLine($" - {container.serialNo} ({container.contType})");
        }
    }
}
