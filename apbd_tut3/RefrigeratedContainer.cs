namespace apbd_tut3;

public class RefrigeratedContainer  : Container
{
    private double mass { get; set; }
    private double height { get; set; }
    private double tareWeight { get; set; }
    private double depth { get; set; }
    private double maxPayload { get; set; }
    
    
    private String serialNo;
    private String productType;
    private double temperature;
    private Product p;
    
    
    public RefrigeratedContainer(double height, double tareWeight, double depth , double maxPayload) : base(height, tareWeight, depth , maxPayload)
    {
        this.productType = "";
        serialNo = "KON-R-"+serialNoTracker;
        serialNoTracker++;
        this.mass=tareWeight;
    }

    public override void loadContainer(Product p)
    {
        if (checkForMatch(p))
        {
            if (checkForTemp(p))
            {
                if (checkForWeight(p))
                {
                    Console.WriteLine(p.type+" has been added to container "+serialNo);
                    this.productType = p.type;
                    mass += p.weight;
                }
                else
                {
                    throw new OverfillException("This container can not handle this much weight!");
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
    
}