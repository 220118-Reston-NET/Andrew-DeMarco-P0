using PPBL;
using PPModel;

namespace PPUI
{
    
    public class PlaceOrderMenu : IMenu
    {

        private static Customer _newCustomer = new Customer();
        private static Orders _newOrder = new Orders();
        private static StoreFront _newStore = new StoreFront();
        private static LineItems _newLineItem = new LineItems();

        //Dependency injection
        private IPlanetPaintballBL _planetPaintballBL;
        private IPlanetPaintballStoresBL _planetPaintballStoresBL;
        public PlaceOrderMenu(IPlanetPaintballBL p_planetPaintballBL, IPlanetPaintballStoresBL p_planetPaintballStoresBL)
        {
            _planetPaintballBL = p_planetPaintballBL;
            _planetPaintballStoresBL = p_planetPaintballStoresBL;
        }

        public void Display()
        {

            Console.WriteLine("===Place Order Menu===");
            Console.WriteLine("Did you want to place an order?");
            Console.WriteLine("Enter Y for yes or N for no:");
            
        }

        public string UserChoice()
        {

            string userInput = Console.ReadLine().ToUpper();

            switch(userInput)
            {
                case "Y":
                    Console.WriteLine("Enter your customer email:");
                    string customerEmail = Console.ReadLine();
                    try
                    {
                        List<Customer> listOfCustomers = _planetPaintballBL.SearchCustomer("email", customerEmail);
                        //listOfCustomers[0] = the customer's name
                        Console.WriteLine("Shopping as: " + listOfCustomers[0].Name);
                    }
                    catch (System.Exception exc)
                    {
                        Console.WriteLine(exc.Message);
                        Console.WriteLine("Taking you back to the Place Order Menu.");
                        Console.WriteLine("Please press any key to continue:");
                        Console.ReadLine();
                        return "PlaceOrder";
                    }


                    Console.WriteLine("Enter the Store location You wish to buy from:");
                    string storeLocation = Console.ReadLine();
                    try
                    {
                        List<StoreFront> listOfStores = _planetPaintballStoresBL.ViewInventory(storeLocation);
                        Console.WriteLine("Here is the list of possible products you can order:");
                        List<Products> listOfStoreProducts = _planetPaintballStoresBL.GetProductsByStoreAddress(storeLocation);
                        foreach(var item in listOfStoreProducts)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    catch(System.Exception exc)
                    {
                        Console.WriteLine(exc.Message);
                        Console.WriteLine("Taking you back to the Place Order Menu.");
                        Console.WriteLine("Please press any key to continue:");
                        Console.ReadLine();
                        return "PlaceOrder";
                    }

                    List<LineItems> itemsOrdered = new List<LineItems>();
                    bool userIsShopping = true; 
                    while (userIsShopping)
                    {
                
                        Console.WriteLine("What do you want to do?");
                        Console.WriteLine("1: Add a product to my order.");
                        Console.WriteLine("2: View my current Order.");
                        Console.WriteLine("3: Check out.");
                        string orderMode = Console.ReadLine();

                        if(orderMode == "1")
                        {
                            Console.WriteLine("Please enter in the ID number for the item you want to add to your cart:");
                            int itemIDNum = Convert.ToInt32(Console.ReadLine());
                            try
                            {
                                Console.WriteLine("How many would you like to buy?");
                                int quantityOrdered = Convert.ToInt32(Console.ReadLine());
                                _newLineItem.ProductID = itemIDNum;
                                _newLineItem.ProductQuantity = quantityOrdered;
                                itemsOrdered.Add(_newLineItem);
                                Console.WriteLine("Adding your item!");
                            }
                            catch (System.Exception exc)
                            {
                                Console.WriteLine(exc.Message);
                                Console.WriteLine("Please press any key to continue:");
                                Console.ReadLine();
                            }

                        }
                        else if(orderMode == "2")
                        {
                            try
                            {
                                Console.WriteLine("Here is your current order:");
                                foreach(LineItems item in itemsOrdered)
                                {
                                    Console.WriteLine(item);
                                }
                                Console.WriteLine("Please press any key to continue:");
                                Console.ReadLine(); 
                            }
                            catch (System.Exception exc)
                            {
                                Console.WriteLine(exc.Message);
                                Console.WriteLine("Please press any key to continue:");
                                Console.ReadLine();
                            }            
                        }
                        else if (orderMode == "3")
                        {
                            userIsShopping = false;
                            Console.WriteLine("Checking out!");
                            List<Customer> listOfCustomers = _planetPaintballBL.SearchCustomer("email", customerEmail);
                            List<StoreFront> listOfStores = _planetPaintballStoresBL.ViewInventory(storeLocation);
                            _newOrder.CustomerID = listOfCustomers[0].ID;
                            _newOrder.StoreID = listOfStores[0].ID;
                            _newOrder.LineItems = itemsOrdered;
                            _planetPaintballStoresBL.MakeOrder(_newOrder);
                            Console.WriteLine("Please press any key to continue:");
                            Console.ReadLine();
                        }


                    }
                    return "PlaceOrder";

                case "N":
                    return "MainMenu";
                default:
                    Console.WriteLine("Please input a valid response of Y or N.");
                    Console.WriteLine("Press any key to continue:");
                    Console.ReadLine();
                    return "PlaceOrder";
            }


        }

    }

}