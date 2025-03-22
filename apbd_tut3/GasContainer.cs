using System.Collections;

namespace apbd_tut3;

public class GasContainer : Container , IHazardNotifier
{
    public double mass { get; set; }
    public double height { get; set; }
    public double tareWeight { get; set; }
    public double depth { get; set; }
    public double maxPayload { get; set; }
    public List<Product> productList { get; set; }
    
    public String serialNo { get; set; }
    public char contType { get; set; }
    public double pressure { get; set; }
    
    public GasContainer(double height, double tareWeight, double depth ,double maxPayload , double pressure) : base(height, tareWeight, depth , maxPayload)
    {
        this.pressure = pressure;
        serialNo = "KON-G-"+serialNoTracker;
        serialNoTracker++;
        mass=tareWeight;
        contType = 'G';
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
        for (int i = 0; i < productList.Count; i++)
        {
            productList[i].contained=false;
            productList.RemoveAt(i);
        }
    }
    
    public override void PrintContainerInfo()
    {
        Console.WriteLine($"Container Info:" +
                          $"\nSerial No: {serialNo}" +
                          $"\nHeight: {height} cm" +
                          $"\nTare Weight: {tareWeight} kg" +
                          $"\nDepth: {depth} cm" +
                          $"\nMax Payload: {maxPayload} kg" +
                          $"\nPressure: {pressure} atmospheres");
    }
}