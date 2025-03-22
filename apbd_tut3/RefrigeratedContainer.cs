using System.Collections;

namespace apbd_tut3;

public class RefrigeratedContainer  : Container
{
    public double mass { get; set; }
    public double height { get; set; }
    public double tareWeight { get; set; }
    public double depth { get; set; }
    public double maxPayload { get; set; }
    public List<Product> productList { get; set; }
    
    public String serialNo { get; set; }
    public char contType { get; set; }
    public String productType { get; set; }
    public double temperature { get; set; }
    
    
    public RefrigeratedContainer(double height, double tareWeight, double depth , double maxPayload , double temp) : base(height, tareWeight, depth , maxPayload)
    {
        this.productType = "";
        serialNo = "KON-R-"+serialNoTracker;
        serialNoTracker++;
        this.mass=tareWeight;
        this.temperature = temp;
        this.maxPayload = maxPayload;
        contType = 'R';
    }

    public override void loadContainer(Product product)
    {
        try
        {
            if(!product.contained)
            {
                if (product.containerType == this.contType)
                {
                    if (checkForMatch(product))
                    {
                        if (checkForTemp(product))
                        {
                            try
                            {
                                if (checkForWeight(product))
                                {
                                    Console.WriteLine(product.type + " has been added to container " + serialNo);
                                    this.productType = product.type;
                                    mass += product.weight;
                                    product.contained = true;
                                    productList.Add(product);
                                }
                                else
                                {
                                    throw new OverfillException("This container can not handle this much weight!");
                                }
                            }
                            catch (OverfillException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Temp error!!"); //find somethng better to write here
                        }
                    }
                    else
                    {
                        Console.WriteLine("Type match error!!"); //maybe throw new exception here??
                    }
                }
                else
                {
                    throw new ContainerProductTypeMismatchException(
                        "This product can not be contained in this container!!");
                }
            }
            else
            {
                Console.WriteLine("This product can not be contained in this container!");
            }
        }
        catch (ContainerProductTypeMismatchException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    
    public void emptyContainer(){}

    public bool checkForMatch(Product p)
    {
        if (productType == "")
        {
            return true;
        }
        else
        {
            if (productType == p.type)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public bool checkForTemp(Product p)
    {
        if (this.temperature <= p.temperature)
        {
            return true;
        }
        return false;
    }

    public bool checkForWeight(Product p)
    {
        if ((mass + p.weight) < maxPayload)
        {
            return true;
        }
        return false;
    }
    
    public override void PrintContainerInfo()
    {
        Console.WriteLine($"Container Info:" +
                          $"\nSerial No: {serialNo}" +
                          $"\nHeight: {height} cm" +
                          $"\nTare Weight: {tareWeight} kg" +
                          $"\nDepth: {depth} cm" +
                          $"\nMax Payload: {maxPayload} kg" +
                          $"\nTemperature: {temperature} cm");
    }
    
}