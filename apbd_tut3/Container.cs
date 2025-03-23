using System.Collections;
using System.Security.AccessControl;

namespace apbd_tut3;

public class Container
{
    public bool isInShip { get; set; }
    public double mass { get; set; }
    public double height { get; set; }
    public double tareWeight { get; set; }
    public double depth { get; set; }
    public double maxPayload { get; set; }
    public List<Product> productList { get; set; }
    public char contType { get; set; }
    public String serialNo { get; set; }
    
    public static int serialNoTracker = 1;

    public Container(double height, double tareWeight, double depth , double maxPayload)
    {
        this.height = height;
        this.tareWeight = tareWeight;
        this.depth = depth;
        this.maxPayload = maxPayload;
        productList = new List<Product>();
        this.isInShip = false;
        serialNo = "";
    }

    public virtual void emptyContainer()
    {
        this.mass=tareWeight;
        Console.WriteLine("Container emptied!");
        for (int i = 0; i < productList.Count; i++)
        {
            productList[i].contained=false;
            productList.RemoveAt(i);
        }
    }
    
    public virtual void loadContainer(Product product)
    {
        try
        {
            if (!product.contained)  
            {
                if (product.containerType == this.contType)
                {
                    try
                    {
                        if ((this.mass + product.weight) > this.maxPayload)
                        {
                            throw new OverfillException("This container can not handle this much weight!");
                        }
                        else
                        {
                            this.mass += product.weight;
                            product.contained = true;
                            productList.Add(product);
                        }
                    }
                    catch (OverfillException ex)
                    {
                        Console.WriteLine(ex.Message);
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

    public virtual void PrintContainerInfo(){}

}
public class OverfillException : Exception
{
    public OverfillException(string message) : base(message) { }
}

public class ContainerProductTypeMismatchException : Exception
{
    public ContainerProductTypeMismatchException(string message) : base(message) { }
}