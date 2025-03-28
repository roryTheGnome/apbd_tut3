﻿using System.Collections;
using System.Security.AccessControl;

namespace apbd_tut3;

public class LiquidContainer : Container , IHazardNotifier
{
    
    public LiquidContainer(double height, double tareWeight, double depth , double maxPayload) : base(height, tareWeight, depth , maxPayload)
    {
        serialNo = "KON-L-"+serialNoTracker;
        serialNoTracker++;
        this.mass=tareWeight;
        contType = 'L';
    }

    public void SendHazardNotification()
    {
        Console.WriteLine("Hazard Notification!! : There is a hazard in container "+serialNo);
    }
    
    public override void loadContainer(Product product)
    {
        try
        {
            if(!product.contained)
            {
                if (product.containerType == this.contType)
                {
                    if (product.isHazard)
                    {
                        try
                        {
                            if (product.weight + mass > (this.maxPayload) / 2)
                            {
                                throw new OverfillException("This container can not handle this much weight!");
                            }
                            else
                            {
                                mass += product.weight;
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
                        try
                        {
                            if (product.weight + mass > ((this.maxPayload) / 10) * 9)
                            {
                                throw new OverfillException("This container can not handle this much weight!");
                            }
                            else
                            {
                                mass += product.weight;
                                product.contained = true;
                                productList.Add(product);
                            }
                        }
                        catch (OverfillException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
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
                Console.WriteLine("This product is already contained in another container!");
            }
        }
        catch (ContainerProductTypeMismatchException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void emptyContainer(){}
    
    public override void PrintContainerInfo()
    {
        Console.WriteLine($"Container Info:" +
                          $"\nSerial No: {serialNo}" +
                          $"\nHeight: {height} cm" +
                          $"\nTare Weight: {tareWeight} kg" +
                          $"\nDepth: {depth} cm" +
                          $"\nMax Payload: {maxPayload} kg");
    }
}

