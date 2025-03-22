namespace apbd_tut3;

public class Product
{
    public String type { get; set; }
    public double temperature { get; set; }
    public double weight { get; set; }
    public bool isHazard { get; set; }
    public char containerType { get; set; }
    public bool contained { get; set; }
    
    public string serialNo  { get; set; }
    public static int counter = 1;

    //there is an easier way to do this part, implement that later
    public Product(String type, double temperature, double weight) //for refrigerated containers
    {
        this.type = type;
        this.temperature = temperature;
        this.weight = weight;
        containerType = 'R';
        contained = false;
        serialNo = "R-Cargo-"+counter.ToString();
        counter++;
    }

    public Product(bool isHazard, String type, double weight)  //for liquid containers
    {
        this.isHazard = isHazard;
        this.type = type;
        this.weight = weight;
        containerType = 'L';
        serialNo = "L-Cargo-"+counter.ToString();
        counter++;
    }

    public Product(String type, double weight)  //for gas containers
    {
        this.type = type;
        this.weight = weight;
        containerType = 'G';
        serialNo = "R-Cargo-"+counter.ToString();
        counter++;
    }
    
}