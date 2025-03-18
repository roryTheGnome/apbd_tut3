using System.Security.AccessControl;

namespace apbd_tut3;

public class Container
{
    private double mass { get; set; }
    private double height { get; set; }
    private double tareWeight { get; set; }
    private double depth { get; set; }
    private double maxPayload { get; set; }
    
    public static int serialNoTracker = 1;

    public Container(double height, double tareWeight, double depth , double maxPayload)
    {
        this.height = height;
        this.tareWeight = tareWeight;
        this.depth = depth;
        this.maxPayload = maxPayload;
    }

    public virtual void emptyContainer()
    {
        this.mass=tareWeight;
        Console.WriteLine("Product added to container!");
    }
    
    public virtual void loadContainer(Product product)
    {
        if ((this.mass + product.weight) > this.maxPayload)
        {
            throw new OverfillException("This container can not handle this much weight!");
        }
        else
        {
            this.mass+=product.weight;
        }
    }
    
}
public class OverfillException : Exception
{
    public OverfillException(string message) : base(message) { }
}