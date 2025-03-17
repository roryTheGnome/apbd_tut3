namespace apbd_tut3;

public class Container
{
    private double mass;
    private double height;
    private double tareWeight;
    private double depth;
    private double maxPayload;
    
    public static int serialNoTracker = 1;

    public Container(double height, double tareWeight, double depth , double maxPayload)
    {
        this.height = height;
        this.tareWeight = tareWeight;
        this.depth = depth;
        this.maxPayload = maxPayload;
    }
}