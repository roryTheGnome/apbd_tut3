using System.Security.AccessControl;

namespace apbd_tut3;

public class LiquidContainer : Container , IHazardNotifier
{
    private double mass { get; set; }
    private double height { get; set; }
    private double tareWeight { get; set; }
    private double depth { get; set; }
    private double maxPayload { get; set; }
    
    private String serialNo;
    
    public LiquidContainer(double height, double tareWeight, double depth , double maxPayload) : base(height, tareWeight, depth , maxPayload)
    {
        serialNo = "KON-L-"+serialNoTracker;
        serialNoTracker++;
        this.mass=tareWeight;
    }

    public void SendHazardNotification()
    {
        Console.WriteLine("Hazard Notification!! : There is a hazard in container "+serialNo);
    }
    
    public override void loadContainer(Product product)
    {
        if (product.isHazard)
        {
            if (product.weight + mass > (this.maxPayload)/2)
            {
                throw new OverfillException("This container can not handle this much weight!");
            }
            else
            {
                mass += product.weight;
            }
        }
        else
        {
            if (product.weight + mass > ((this.maxPayload) / 10) * 9)
            {
                throw new OverfillException("This container can not handle this much weight!");
            }
            else
            {
                mass += product.weight;
            }
        }
    }

    public void emptyContainer(){}
}

