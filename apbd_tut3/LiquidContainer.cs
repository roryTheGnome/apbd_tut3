using System.Security.AccessControl;

namespace apbd_tut3;

public class LiquidContainer : Container , HazardNotifier
{
    private double mass;
    private double height;
    private double tareWeight;
    private double depth;
    private double maxPayload;
    
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
}