namespace apbd_tut3;

public class Product
{
    public String type { get; set; }
    public double temperature { get; set; }
    public double weight { get; set; }
    public bool isHazard { get; set; }
    public char containerType { get; set; }

    //there is an easier way to do this part, implement that later
    public Product(String type, double temperature, double weight) //for refrigerated containers
    {
        this.type = type;
        this.temperature = temperature;
        this.weight = weight;
        containerType = 'R';
    }

    public Product(bool isHazard, String type, double weight)  //for liquid containers
    {
        this.isHazard = isHazard;
        this.type = type;
        this.weight = weight;
        containerType = 'L';
    }

    public Product(String type, double weight)  //for gas containers
    {
        this.type = type;
        containerType = 'G';
    }
    
    
    
}