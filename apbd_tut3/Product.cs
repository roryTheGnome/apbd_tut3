namespace apbd_tut3;

public class Product
{
    public String type;
    public double temperature;
    public double weight;

    //there is an easier way to do this part, implement that later
    public Product(String type, double temperature, double weight)
    {
        this.type = type;
        this.temperature = temperature;
        this.weight = weight;
    }
}