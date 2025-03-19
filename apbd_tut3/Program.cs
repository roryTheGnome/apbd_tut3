// See https://aka.ms/new-console-template for more information


using apbd_tut3;

RefrigeratedContainer rc01 = new RefrigeratedContainer(12, 125, 24, 250,(-10));
RefrigeratedContainer rc02 = new RefrigeratedContainer(12, 125, 24, 250,20);
LiquidContainer lc01 = new LiquidContainer(12, 125, 24, 250);
LiquidContainer lc02 = new LiquidContainer(12, 125, 24, 250);
GasContainer gc01 = new GasContainer(12, 125, 24, 250,120);
GasContainer gc02 = new GasContainer(12, 125, 24, 250,120);

Product rp01 =new Product("banana", 13.3 , 5);
Product rp02 =new Product("banana", 13.3 , 2);
Product rp03 =new Product("banana", 13.3 , 200);
Product rp04 =new Product("ice", -18 , 2);

rc01.loadContainer(rp01);
Console.WriteLine(rp01.contained);
rc01.loadContainer(rp02);
rc01.loadContainer(rp03);
rc01.loadContainer(rp04);

Console.WriteLine(rc01.mass);
Console.WriteLine(rp01.weight);
Console.WriteLine(rc01.maxPayload);

//TODO handle exception                                                                     DONE
//TODO make sure to handle adding one product in multi containers (check contained)         DONE
//TODO make sure correct type of product goes to the correct container                      DONE
//TODO add ship class  