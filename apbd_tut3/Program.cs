// See https://aka.ms/new-console-template for more information


using System.ComponentModel;
using apbd_tut3;
using Container = apbd_tut3.Container;

/*RefrigeratedContainer rc01 = new RefrigeratedContainer(12, 125, 24, 250,(-10));
RefrigeratedContainer rc02 = new RefrigeratedContainer(12, 125, 24, 250,20);
LiquidContainer lc01 = new LiquidContainer(12, 125, 24, 250);
LiquidContainer lc02 = new LiquidContainer(12, 125, 24, 250);
GasContainer gc01 = new GasContainer(12, 125, 24, 250,120);
GasContainer gc02 = new GasContainer(12, 125, 24, 250,120);

Product rp01 =new Product("banana", 13.3 , 5);
Product rp02 =new Product("banana", 13.3 , 2);
Product rp03 =new Product("banana", 13.3 , 200);
Product rp04 =new Product("ice", -18 , 2);

rc01.loadContainer(rp01);
Console.WriteLine(rp01.contained);
rc01.loadContainer(rp02);
rc01.loadContainer(rp03);
rc01.loadContainer(rp04);

Console.WriteLine(rc01.mass);
Console.WriteLine(rp01.weight);
Console.WriteLine(rc01.maxPayload);*/

List<Container> AllContainers = new List<Container>();
List<Ship> AllShips = new List<Ship>();
List<Product> AllProducts = new List<Product>();
List<Voyage> AllVoyages = new List<Voyage>();
void Main(string[] args)
{
    bool proceed = true;
    Console.WriteLine("***WELCOME TO VOYAGE CREATER***");
    while(proceed)
    {
        Console.WriteLine("Please choose an action : " +
                          "\n   1  -Add a container " +
                          "\n   2  -Register a cargo " +
                          "\n   3  -Add a ship " +
                          "\n   4  -Create a new voyage " +
                          "\n   5  -Load container with a registired cargo " +
                          "\n   6  -Load container onto a ship " +
                          "\n   7  -Load a list of containers onto a ship" +
                          "\n   8  -Remove a container from a ship " +
                          "\n   9  -Unload a container" +
                          "\n   10 -Replace a container in a ship with another" +
                          "\n   11 -Display information of a container" +
                          "\n   12 -Display information of a ship" +
                          "\n   13 -Display information of a voyage" +
                          "\n   0  -Exit");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                case1();
                break;
            case "2":
                case2();
                break;
            case "3":
                case3();
                break;
            case "4":
                break;
            case "5":
                break;
            case "6":
                break;
            case "7":
                break;
            case "8":
                break;
            case "9":
                break;
            case "10":
                break;
            case "11":
                break;
            case "12":
                break;
            case "13":
                break;
            case "0":
                proceed = false;
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

}

void case1() //add container
{
    Console.WriteLine("Choose your container type :" +
                      "\n   R-Refrigerated  G-Gas   L-Liquid    B-Go back to main menu");
    string choice = Console.ReadLine();
    switch (choice)
    {   //in here im just hoping user to enter correct data type
        case "R":
            Console.WriteLine("Enter the height of the container :");
            double height = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the tare weight :");
            double tareWeight = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the depth :");
            double depth = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the max payload :");
            double maxPayload = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the temperature :");
            double temperature = double.Parse(Console.ReadLine());
            RefrigeratedContainer rf=new RefrigeratedContainer
                (height, tareWeight, depth, maxPayload, temperature);
            Console.WriteLine("New container created");
            rf.PrintContainerInfo();
            AllContainers.Add(rf);
            break;
        case "G":
            Console.WriteLine("Enter the height of the container :");
            height = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the tare weight :");
            tareWeight = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the depth :");
            depth = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the max payload :");
            maxPayload = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the pressure :");
            double pressure = double.Parse(Console.ReadLine());
            GasContainer gc=new GasContainer(height, tareWeight, depth, maxPayload, pressure);
            Console.WriteLine("New container created");
            gc.PrintContainerInfo();
            AllContainers.Add(gc);
            break;
        case "L":
            Console.WriteLine("Enter the height of the container :");
            height = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the tare weight :");
            tareWeight = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the depth :");
            depth = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the max payload :");
            maxPayload = double.Parse(Console.ReadLine());
            LiquidContainer lc=new LiquidContainer(height, tareWeight, depth, maxPayload);
            Console.WriteLine("New container created");
            lc.PrintContainerInfo();
            AllContainers.Add(lc);
            break;
        case "B":
            return;
            break;
        default:
            Console.WriteLine("Invalid choice.");
            case1();
            break;
    }

}

void case2() //add cargo(product)
{
    Console.WriteLine("Choose your product type :" +
                      "\n   R-Refrigerated  G-Gas   L-Liquid    B-Go back to main menu");
    string choice = Console.ReadLine();
    switch (choice)
    {   //in here im just hoping user to enter correct data type
        case "R":
            Console.WriteLine("Enter the type :");
            string type =Console.ReadLine();
            Console.WriteLine("Enter the temperature :");
            double temperature = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the weight :");
            double weight = double.Parse(Console.ReadLine());
            Product pR=new Product(type,temperature,weight);
            AllProducts.Add(pR);
            Console.WriteLine("New cargo created");
            break;
        case "G":
            Console.WriteLine("Enter the type :");
            type =Console.ReadLine();
            Console.WriteLine("Enter the tare weight :");
            weight = double.Parse(Console.ReadLine());
            Product pG=new Product(type,weight);
            AllProducts.Add(pG);
            Console.WriteLine("New cargo created");
            break;
        case "L":
            Console.WriteLine("Is this a  hazardous cargo (e.g., fuel) :" +
                              "\n 1 -Yes");
            string answr =Console.ReadLine();
            bool isHazared=answr == "1";
            Console.WriteLine("Enter the type :");
            type =Console.ReadLine();
            Console.WriteLine("Enter the tare weight :");
            weight = double.Parse(Console.ReadLine());
            Product pL=new Product(isHazared,type,weight);
            AllProducts.Add(pL);
            Console.WriteLine("New cargo created");
            break;
        case "B":
            return;
            break;
        default:
            Console.WriteLine("Invalid choice.");
            case2();
            break;
    }

}

void case3() //add ship
{
    Console.WriteLine("Enter max amount of containers ship can have :");
    int  maxAmount = int.Parse(Console.ReadLine());
    Console.WriteLine("Enter max weight ship can have :");
    double  maxWeight = double.Parse(Console.ReadLine());
    Console.WriteLine("Enter max speed ship can have :");
    double  speed = double.Parse(Console.ReadLine());
    Ship ss=new Ship(maxAmount,maxWeight,speed);
    Console.WriteLine("New ship created");
    ss.PrintShipInfo();
    AllShips.Add(ss);
}

void case4() //add new voyage
{
    Console.WriteLine("Enter serial No :");
    string serialNo=(Console.ReadLine());
    Console.WriteLine("Enter start date :");
    string startDate=(Console.ReadLine());
    Console.WriteLine("Enter expected end date :");
    string expectedEndDay=(Console.ReadLine());
    Console.WriteLine("Enter start location :");
    string startLocation=(Console.ReadLine());
    Console.WriteLine("Enter destination:");
    string destination=(Console.ReadLine());
    Voyage v=new Voyage(serialNo,startDate,expectedEndDay,startLocation,destination);
    Console.WriteLine("New voyage created");
    v.PrintVoyageInfo();
    AllVoyages.Add(v);
}

void case5()
{
    
}

//TODO handle exception                                                                     DONE
//TODO make sure to handle adding one product in multi containers (check contained)         DONE
//TODO make sure correct type of product goes to the correct container                      DONE
//TODO add ship class                                                                       DONE
