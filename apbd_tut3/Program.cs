// See https://aka.ms/new-console-template for more information


using System.Collections.Specialized;
using System.ComponentModel;
using apbd_tut3;
using Container = apbd_tut3.Container;


    List<Container> AllContainers = new List<Container>();
    List<Ship> AllShips = new List<Ship>();
    List<Product> AllProducts = new List<Product>();
    List<Voyage> AllVoyages = new List<Voyage>();
    
    
    
    ///THIS DUMMY DATA IS CREATED BY AI JUST TO TEST THE PROJECT
    /*
    AllContainers.Add(new RefrigeratedContainer(10, 150, 20, 500, -5));
    AllContainers.Add(new RefrigeratedContainer(15, 200, 30, 800, -18));
    AllContainers.Add(new GasContainer(12, 180, 25, 700, 100));
    AllContainers.Add(new LiquidContainer(8, 130, 22, 600));

    AllProducts.Add(new Product("Ice Cream", -10, 50)); // Refrigerated product
    AllProducts.Add(new Product("Bananas", 15, 100));   // Refrigerated product
    AllProducts.Add(new Product("Propane", 120));       // Gas product
    AllProducts.Add(new Product(true, "Crude Oil", 500)); // Hazardous liquid product

    AllShips.Add(new Ship(100, 50000, 40)); // Can carry up to 100 containers, max weight 50000, speed 40 knots
    AllShips.Add(new Ship(50, 25000, 30));  // Can carry 50 containers, max weight 25000, speed 30 knots

    AllVoyages.Add(new Voyage("2025-04-01", "2025-05-01", "New York", "London"));
    AllVoyages.Add(new Voyage( "2025-06-15", "2025-07-20", "Shanghai", "Los Angeles"));
    */
    
    
    
    

        bool proceed = true;
        Console.WriteLine("***WELCOME TO VOYAGE CREATER***");
        while (proceed)
        {
            Console.WriteLine("Please choose an action : " +
                              "\n   1  -Add a container " +
                              "\n   2  -Register a cargo " +
                              "\n   3  -Add a ship " +
                              "\n   4  -Create a new voyage " +
                              "\n   5  -Load container with a registired cargo " +
                              "\n   6  -Load container onto a ship " +
                              "\n   7  -Load a list of containers onto a ship" +
                              "\n   8  -Remove a container from a ship " +
                              "\n   9  -Unload a container" +
                              "\n   10 -Replace a container in a ship with another" +
                              "\n   11 -Display information of a container" +
                              "\n   12 -Display information of a ship" +
                              "\n   13 -Display information of a voyage" +
                              "\n   0  -Exit");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    case1();
                    break;
                case "2":
                    case2();
                    break;
                case "3":
                    case3();
                    break;
                case "4":
                    case4();
                    break;
                case "5":
                    case5();
                    break;
                case "6":
                    case6();
                    break;
                case "7":
                    case7();
                    break;
                case "8":
                    case8();
                    break;
                case "9":
                    case9();
                    break;
                case "10":
                    case10();
                    break;
                case "11":
                    case11();
                    break;
                case "12":
                    case12();
                    break;
                case "13":
                    case13();
                    break;
                case "0":
                    proceed = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
        

    void case1() //Add container
    {
        Console.WriteLine("Choose your container type :" +
                          "\n   R-Refrigerated  G-Gas   L-Liquid    B-Go back to main menu");
        string choice = Console.ReadLine();
        switch (choice)
        {
            //in here im just hoping user to enter correct data type
            case "R":
                Console.WriteLine("Enter the height of the container :");
                double height = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter the tare weight :");
                double tareWeight = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter the depth :");
                double depth = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter the max payload :");
                double maxPayload = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter the temperature :");
                double temperature = double.Parse(Console.ReadLine());
                RefrigeratedContainer rf = new RefrigeratedContainer
                    (height, tareWeight, depth, maxPayload, temperature);
                Console.WriteLine("New container created");
                rf.PrintContainerInfo();
                AllContainers.Add(rf);
                break;
            case "G":
                Console.WriteLine("Enter the height of the container :");
                height = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter the tare weight :");
                tareWeight = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter the depth :");
                depth = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter the max payload :");
                maxPayload = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter the pressure :");
                double pressure = double.Parse(Console.ReadLine());
                GasContainer gc = new GasContainer(height, tareWeight, depth, maxPayload, pressure);
                Console.WriteLine("New container created");
                gc.PrintContainerInfo();
                AllContainers.Add(gc);
                break;
            case "L":
                Console.WriteLine("Enter the height of the container :");
                height = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter the tare weight :");
                tareWeight = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter the depth :");
                depth = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter the max payload :");
                maxPayload = double.Parse(Console.ReadLine());
                LiquidContainer lc = new LiquidContainer(height, tareWeight, depth, maxPayload);
                Console.WriteLine("New container created");
                lc.PrintContainerInfo();
                AllContainers.Add(lc);
                break;
            case "B":
                return;
                break;
            default:
                Console.WriteLine("Invalid choice.");
                case1();
                break;
        }

    }

    void case2() //Add cargo(product)
    {
        Console.WriteLine("Choose your product type :" +
                          "\n   R-Refrigerated  G-Gas   L-Liquid    B-Go back to main menu");
        string choice = Console.ReadLine();
        switch (choice)
        {
            //in here im just hoping user to enter correct data type
            case "R":
                Console.WriteLine("Enter the type :");
                string type = Console.ReadLine();
                Console.WriteLine("Enter the temperature :");
                double temperature = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter the weight :");
                double weight = double.Parse(Console.ReadLine());
                Product pR = new Product(type, temperature, weight);
                AllProducts.Add(pR);
                Console.WriteLine("New cargo created");
                break;
            case "G":
                Console.WriteLine("Enter the type :");
                type = Console.ReadLine();
                Console.WriteLine("Enter the tare weight :");
                weight = double.Parse(Console.ReadLine());
                Product pG = new Product(type, weight);
                AllProducts.Add(pG);
                Console.WriteLine("New cargo created");
                break;
            case "L":
                Console.WriteLine("Is this a  hazardous cargo (e.g., fuel) :" +
                                  "\n 1 -Yes");
                string answr = Console.ReadLine();
                bool isHazared = answr == "1";
                Console.WriteLine("Enter the type :");
                type = Console.ReadLine();
                Console.WriteLine("Enter the tare weight :");
                weight = double.Parse(Console.ReadLine());
                Product pL = new Product(isHazared, type, weight);
                AllProducts.Add(pL);
                Console.WriteLine("New cargo created");
                break;
            case "B":
                return;
                break;
            default:
                Console.WriteLine("Invalid choice.");
                case2();
                break;
        }

    }

    void case3() //Add ship
    {
        Console.WriteLine("Enter max amount of containers ship can have :");
        int maxAmount = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter max weight ship can have :");
        double maxWeight = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter max speed ship can have :");
        double speed = double.Parse(Console.ReadLine());
        Ship ss = new Ship(maxAmount, maxWeight, speed);
        Console.WriteLine("New ship created");
        ss.PrintShipInfo();
        AllShips.Add(ss);
    }

    void case4() //Add new voyage
    {
        Console.WriteLine("Enter serial No :");
        string serialNo = (Console.ReadLine());
        Console.WriteLine("Enter start date :");
        string startDate = (Console.ReadLine());
        Console.WriteLine("Enter expected end date :");
        string expectedEndDay = (Console.ReadLine());
        Console.WriteLine("Enter start location :");
        string startLocation = (Console.ReadLine());
        Console.WriteLine("Enter destination:");
        string destination = (Console.ReadLine());
        Voyage v = new Voyage( startDate, expectedEndDay, startLocation, destination);
        Console.WriteLine("New voyage created");
        v.PrintVoyageInfo();
        AllVoyages.Add(v);
    }

    void case5() //Load container
    {
        /*Console.WriteLine("Cargos :");
        foreach (Product cargo in AllProducts)
        {
            Console.WriteLine($"- {cargo.serialNo}");
        }*/
        displayAllProducts();
        Console.WriteLine("Please enter the serial number of the cargo you want to load :");
        string cargoNumber = Console.ReadLine();
        int i = 0;
        int ii = 0;
        foreach (Product cargo in AllProducts)
        {
            if (cargo.serialNo == cargoNumber)
            {
                if (cargo.contained)
                {
                    Console.WriteLine($"{cargo.serialNo} already has been loaded");
                    return;
                }

                switch (cargo.containerType)
                {
                    case 'R':
                        foreach (Container container in AllContainers)
                        {
                            if (container.contType == 'R')
                            {
                                Console.WriteLine($"- {container.serialNo}");
                            }
                        }

                        Console.WriteLine("Enter the target containers serial number:");
                        string targetContainer = Console.ReadLine();
                        foreach (Container container in AllContainers)
                        {
                            if (container.contType == 'R')
                            {
                                if (container.serialNo == targetContainer)
                                {
                                    container.loadContainer(cargo);
                                    return;
                                }
                            }
                        }

                        Console.WriteLine("No such container exists");
                        break;
                    case 'L':
                        foreach (Container container in AllContainers)
                        {
                            if (container.contType == 'L')
                            {
                                Console.WriteLine($"- {container.serialNo}");
                            }
                        }

                        Console.WriteLine("Enter the target containers serial number:");
                        targetContainer = Console.ReadLine();
                        foreach (Container container in AllContainers)
                        {
                            if (container.contType == 'L')
                            {
                                if (container.serialNo == targetContainer)
                                {
                                    container.loadContainer(cargo);
                                    return;
                                }
                            }
                        }

                        Console.WriteLine("No such container exists");
                        break;
                    case 'G':
                        foreach (Container container in AllContainers)
                        {
                            if (container.contType == 'G')
                            {
                                Console.WriteLine($"- {container.serialNo}");
                            }
                        }

                        Console.WriteLine("Enter the target containers serial number:");
                        targetContainer = Console.ReadLine();
                        foreach (Container container in AllContainers)
                        {
                            if (container.contType == 'G')
                            {
                                if (container.serialNo == targetContainer)
                                {
                                    container.loadContainer(cargo);
                                    return;
                                }
                            }
                        }

                        Console.WriteLine("No such container exists");
                        break;

                }

                i++;
            }
        }

        if (i == 0)
        {
            Console.WriteLine("No such cargo exist pls try again");
            return;
        }
    }

    void case6() //Load ship
    {
        /*Console.WriteLine("Containers :");
        foreach (Container container in AllContainers)
        {
            Console.WriteLine($"- {container.serialNo}");
        }*/
        displayAllContainers();
        Console.WriteLine("Please enter the serial number of the container you want to load into a ship :");
        string contNo = Console.ReadLine();

        foreach (Container c in AllContainers)
        {
            if (c.serialNo == contNo)
            {
                if (c.isInShip)
                {
                    Console.WriteLine($"{c.serialNo} already has been loaded");
                    return;
                }

                /*foreach (Ship ss in AllShips)
                {
                    Console.WriteLine($"- {ss.serialNo}");
                }*/
                displayAllShips();
                Console.WriteLine("Please enter the serial number of the ship you want to load onto :");
                string ssNo = Console.ReadLine();

                foreach (Ship ss in AllShips)
                {
                    if (ss.serialNo == ssNo)
                    {
                        ss.LoadContainer(c);
                        return;
                    }

                }

                Console.WriteLine("no such ship exists");
                return;
            }
        }

        Console.WriteLine("No such container exists");
        return;
    }

    void case7() //Load ship with list of containers
    {
        List<Container> contList = new List<Container>();
        bool justKeepSwimming = true;
        int i = 0;
        displayAllContainers();
        while (justKeepSwimming)
        {
            Console.WriteLine(
                "Please enter the serial number of the container you want to load or enter 0 to end the list:");
            String answer = Console.ReadLine();
            if (answer.Equals("0"))
            {
                justKeepSwimming = false;
            }
            else
            {
                foreach (Container c in AllContainers)
                {
                    if (c.serialNo == answer)
                    {
                        if (c.isInShip)
                        {
                            Console.WriteLine($"{c.serialNo} already has been loaded");
                        }
                        else
                        {
                            contList.Add(c);
                            i++;
                        }
                    }
                }

                if (i == 0)
                {
                    Console.WriteLine("No such container exists");
                }
                else
                {
                    i = 0;
                }
            }
        }


        Console.WriteLine("Please enter the serial number of the ship you want to load onto :");
        string ssNo = Console.ReadLine();

        foreach (Ship ss in AllShips)
        {
            if (ss.serialNo == ssNo)
            {
                foreach (Container c in contList)
                {
                    ss.LoadContainer(c);
                }

                return;
            }

        }

        Console.WriteLine("no such ship exists");
        return;
    }

    void case8() //Remove container from the ship
    {
        displayAllShips();
        Console.WriteLine("Please enter the serial number of the ship :");
        string ssNo = Console.ReadLine();

        foreach (Ship ss in AllShips)
        {
            if (ss.serialNo == ssNo)
            {
                Console.WriteLine("Containers in this ship :");
                foreach (Container cont in ss.containers)
                {
                    Console.WriteLine($"- {cont.serialNo}");
                }

                Console.WriteLine("Please enter the serial number of the container you want to remove :");
                string contNo = Console.ReadLine();
                foreach (Container cont in ss.containers)
                {
                    if (cont.serialNo == contNo)
                    {
                        ss.RemoveContainer(contNo);
                        Console.WriteLine($"{contNo} numbered container is removed from ship {ss.serialNo}");
                        return;
                    }
                }

                Console.WriteLine("no such container exists");
                return;
            }
        }

        Console.WriteLine("no such ship exists");
        return;
    }

    void case9() //Unload container
    {
        displayAllContainers();
        Console.WriteLine("Please enter the serial number of the container to unload :");
        string contNo = Console.ReadLine();

        foreach (Container c in AllContainers)
        {
            if (c.serialNo == contNo)
            {
                c.emptyContainer();
                return;
            }
        }
    }

    void case10() //Replace container in ship
    {
        displayAllShips();
        Console.WriteLine("Please enter the serial number of the ship :");
        string ssNo = Console.ReadLine();

        foreach (Ship ss in AllShips)
        {
            if (ss.serialNo == ssNo)
            {
                Console.WriteLine("All the containers in this ship :");
                foreach (var cont in ss.containers)
                {
                    Console.WriteLine($"- {cont.serialNo}");
                }

                Console.WriteLine("Please enter the serial number of the container you want to replace :");
                String contNo = Console.ReadLine();
                foreach (Container c1 in AllContainers)
                {
                    if (c1.serialNo == contNo)
                    {
                        Console.WriteLine("Availiable containers to replace with :");
                        foreach (var container in AllContainers)
                        {
                            if (!container.isInShip)
                            {
                                Console.WriteLine($"- {container.serialNo}");
                            }
                        }

                        Console.WriteLine("Please enter the serial number of the container you want to replace with :");
                        String contNo2 = Console.ReadLine();
                        foreach (var container in AllContainers)
                        {
                            if (!container.isInShip)
                            {
                                if (container.serialNo == contNo2)
                                {
                                    ss.RemoveContainer(contNo2);
                                    ss.LoadContainer(container);
                                    return;
                                }
                            }
                        }

                        Console.WriteLine("no such container exists");
                    }
                }

                Console.WriteLine("no such container exists");
            }
        }

        Console.WriteLine("no such ship exists");
        return;

    }

    void case11() //Display container info
    {
        displayAllContainers();
        Console.WriteLine("Please enter the serial number of a container to display info :");
        String contNo = Console.ReadLine();
        foreach (Container c in AllContainers)
        {
            if (c.serialNo == contNo)
            {
                c.PrintContainerInfo();
                return;
            }
        }

        Console.WriteLine("no such container exists");
    }

    void case12() //Display ship info
    {
        displayAllShips();
        Console.WriteLine("Please enter the serial number of a ship to display info :");
        String ssNo = Console.ReadLine();
        foreach (Ship ss in AllShips)
        {
            if (ss.serialNo == ssNo)
            {
                ss.PrintShipInfo();
                return;
            }
        }

        Console.WriteLine("no such ship exists");
    }

    void case13() //Display voyage info
    {
        displayAllVoyages();
        Console.WriteLine("Please enter the serial number of a voyage to display info :");
        String no = Console.ReadLine();
        foreach (Voyage v in AllVoyages)
        {
            if (v.serialNo == no)
            {
                v.PrintVoyageInfo();
                return;
            }
        }

        Console.WriteLine("no such voyage exists");
    }

    void displayAllProducts()
    {
        Console.WriteLine("Cargos :");
        foreach (Product cargo in AllProducts)
        {
            Console.WriteLine($"- {cargo.serialNo}");
        }
    }

    void displayAllContainers()
    {
        Console.WriteLine("Containers :");
        foreach (var container in AllContainers)
        {
            Console.WriteLine($"- {container.serialNo}");
        }
    }

    void displayAllShips()
    {
        Console.WriteLine("Ships :");
        foreach (Ship ship in AllShips)
        {
            Console.WriteLine($"- {ship.serialNo}");
        }
    }

    void displayAllVoyages()
    {
        Console.WriteLine("Voyages :");
        foreach (Voyage v in AllVoyages)
        {
            Console.WriteLine($"- {v.serialNo}");
        }
    }


//TODO handle exception                                                                     DONE
//TODO make sure to handle adding one product in multi containers (check contained)         DONE
//TODO make sure correct type of product goes to the correct container                      DONE
//TODO add ship class                                                                       DONE
//FIXME fix the dup of VOYAGE serialNo
//TODO make display all lists methods this looks crayz atm                                  sTILL CRAZY BUT BETTER
