namespace apbd_tut3;

public class GasContainer : Container , IHazardNotifier
{
    private double mass { get; set; }
    private double height { get; set; }
    private double tareWeight { get; set; }
    private double depth { get; set; }
    private double maxPayload { get; set; }
    
    private String serialNo { get; set; }
    private double pressure { get; set; }
    
    public GasContainer(double height, double tareWeight, double depth ,double maxPayload , double pressure) : base(height, tareWeight, depth , maxPayload)
    {
        this.pressure = pressure;
        serialNo = "KON-G-"+serialNoTracker;
        serialNoTracker++;
        mass=tareWeight;
    }
    
    public void SendHazardNotification()
    {
        Console.WriteLine("Hazard Notification!! : There is a hazard in container "+serialNo);
    }

    public void loadContainer(Product product) {}

    public override void emptyContainer()
    {
        double remainnig= ((mass - tareWeight) / 100)*5;
        mass=tareWeight+remainnig;
    }
}