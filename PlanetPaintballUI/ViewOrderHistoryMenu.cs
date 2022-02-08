using PPBL;
using PPModel;

namespace PPUI
{
    
    public class ViewOrderHistoryMenu : IMenu
    {

        private static Customer _newCustomer = new Customer();
        private static StoreFront _newStore = new StoreFront();
        
        //Dependency injection
        private IPlanetPaintballBL _planetPaintballBL;
        private IPlanetPaintballStoresBL _planetPaintballStoresBL;
        public ViewOrderHistoryMenu(IPlanetPaintballBL p_planetPaintballBL, IPlanetPaintballStoresBL p_planetPaintballStoresBL)
        {
            _planetPaintballBL = p_planetPaintballBL;
            _planetPaintballStoresBL = p_planetPaintballStoresBL;
        }

        public void Display()
        {
            
            Console.WriteLine("===View Order History Menu===");
            Console.WriteLine("Did you want to view an order history?");
            Console.WriteLine("Enter Y for yes or N for no:");

        }

        public string UserChoice()
        {

            string userInput = Console.ReadLine().ToUpper();

            switch(userInput)
            {
                case "Y":
                    Console.WriteLine("How do you want to search?");
                    Console.WriteLine("1: Search a customer order history.");
                    Console.WriteLine("2: Search a store front order history.");
                    string searchMode = Console.ReadLine();

                    if(searchMode == "1")
                    {

                        searchMode = "email";
                        Console.WriteLine("Enter the email you want to search for:");
                        string customerEmail = Console.ReadLine();
                        try
                        {
                            List<Customer> listOfCustomers = _planetPaintballBL.SearchCustomer(searchMode, customerEmail);
                            Console.WriteLine("Customer found. Here is "+ listOfCustomers[0].Name +"'s order history information:");
                            //code to print out the list of orders a customer has made
                            //this current code below print's the customer information, not their order history
                            // foreach(var item in listOfCustomers)
                            // {
                            //     Console.WriteLine(item);
                            // }
                            Console.WriteLine("Press any key to continue:");
                            Console.ReadLine();
                        }
                        catch (System.Exception exc)
                        {
                            Console.WriteLine(exc.Message);
                            Console.WriteLine("Please press any key to continue:");
                            Console.ReadLine();
                        }

                    }
                    else if(searchMode == "2")
                    {
                        
                        Console.WriteLine("Enter the store location you want to search for:");
                        String storeLocation = Console.ReadLine();

                        try
                        {
                            List<StoreFront> listOfStores = _planetPaintballStoresBL.ViewInventory(storeLocation);
                            Console.WriteLine("Store found. Here is the order history of " + listOfStores[0].Name + " " + listOfStores[0].Address+ ":");
                            //code to post the store order history
                            //right now the code does not do this, it would print the store's items
                            // foreach (var item in listOfStores)
                            // {
                            //     Console.WriteLine(item);
                            // }
                            Console.WriteLine("Press any key to continue:");
                            Console.ReadLine();
                        }  
                        catch(System.Exception exc)
                        {
                            Console.WriteLine(exc.Message);
                            Console.WriteLine("Please press any key to continue:");
                            Console.ReadLine();
                        }

                    }
                    else
                    {
                        Console.WriteLine("You did not enter a menu option!");
                        Console.WriteLine("Press any key to continue:");
                        Console.ReadLine();
                    }
                    
                    return "ViewOrderHistory";
                case "N":
                    return "MainMenu";
                default:
                    Console.WriteLine("Please input a valid response of Y or N.");
                    Console.WriteLine("Press any key to continue:");
                    Console.ReadLine();
                    return "ViewOrderHistoryMenu";

            }
            

        }

    }

}