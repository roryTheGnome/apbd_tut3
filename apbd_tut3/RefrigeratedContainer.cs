namespace apbd_tut3;

public class RefrigeratedContainer  : Container
{
    private double mass;
    private double height;
    private double tareWeight;
    private double depth;
    private double maxPayload;
    private String serialNo;
    private String type;
    private double temperature;
    private Product p;
    
    
    public RefrigeratedContainer(double height, double tareWeight, double depth , double maxPayload) : base(height, tareWeight, depth , maxPayload)
    {
        this.type = "";
        serialNo = "KON-R-"+serialNoTracker;
        serialNoTracker++;
        this.mass=tareWeight;
    }

    public void loadContainer(Product p)
    {
        if (checkForMatch(p))
        {
            if (checkForTemp(p))
            {
                if (checkForWeight(p))
                {
                    Console.WriteLine(p.type+" has been added to container "+serialNo);
                    type = p.type;
                    mass += p.weight;
                }
                else
                {
                    Console.WriteLine("Weight error!!"); //find somethng better to write here
                }
            }
            else
            {
                Console.WriteLine("Temp error!!"); //find somethng better to write here
            }
        }
        else
        {
            Console.WriteLine("Type match error!!");
        }
    }

    public bool checkForMatch(Product p)
    {
        /*if (type == "")
        {
            if (checkForTemp(p))
            {
                if (checkForWeight(p))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            } 
        }
        else
        {
            if (type == p.type)
            {
                if (checkForTemp(p))
                {
                    if (checkForWeight(p))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                } 
            }
            else
            {
                return false;
            }
        }
        return true;*/
        
        if (type == "")
        {
            return true;
        }
        else
        {
            if (type == p.type)
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
        if (temperature >= p.temperature)
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