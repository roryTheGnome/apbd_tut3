namespace apbd_tut3;

public class GasContainer : Container , HazardNotifier
{
    private double mass;
    private double height;
    private double tareWeight;
    private double depth;
    private double maxPayload;
    
    private String serialNo;
    private double pressure;
    
    public GasContainer(double height, double tareWeight, double depth ,double maxPayload , double pressure) : base(height, tareWeight, depth , maxPayload)
    {
        this.pressure = pressure;
        serialNo = "KON-G-"+serialNoTracker;
        serialNoTracker++;
        this.mass=tareWeight;
    }
    
    public void SendHazardNotification()
    {
        Console.WriteLine("Hazard Notification!! : There is a hazard in container "+serialNo);
    }

    public void load()
    {
        
    }
    
    public bool checkForWeight()
    {
        if ((mass) < maxPayload)
        {
            return true;
        }
        return false;
    }
}