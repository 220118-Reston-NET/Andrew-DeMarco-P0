using PPBL;
using PPModel;

namespace PPUI
{

    public class SearchCustomerMenu : IMenu
    {

        private static Customer _newCustomer = new Customer();

        //Dependency injection
        private IPlanetPaintballBL _planetPaintballBL;
        public SearchCustomerMenu(IPlanetPaintballBL p_planetPaintballBL)
        {
            _planetPaintballBL = p_planetPaintballBL;
        }

        public void Display()
        {

            Console.WriteLine("===Search Customer Menu===");
            Console.WriteLine("Did you want to search for a customer?");
            Console.WriteLine("Enter Y for yes or N for no:");
        
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine().ToUpper();

            switch (userInput)
            {
                case "Y":
                    Console.WriteLine("How do you want to search?");
                    Console.WriteLine("1: Search by Email.");
                    Console.WriteLine("2: Search by Name.");
                    string searchMode = Console.ReadLine();
                    
                    if(searchMode == "1")
                    {
                        searchMode = "email";
                        Console.WriteLine("Enter the email you want to search for:");
                        string customerEmail = Console.ReadLine();
                        try
                        {
                            List<Customer> listOfCustomers = _planetPaintballBL.SearchCustomer(searchMode, customerEmail);
                            Console.WriteLine("Customer found. Here is their information:");
                            foreach(var item in listOfCustomers)
                            {
                                Console.WriteLine(item);
                            }
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
                        searchMode = "name"; 
                        Console.WriteLine("Enter in the name you want to search for:");   
                        string customerName = Console.ReadLine();
                        try
                        {
                            List<Customer> listOfCustomers = _planetPaintballBL.SearchCustomer(searchMode, customerName);
                            Console.WriteLine("Customer(s) found. Here is their information:");
                            foreach(var item in listOfCustomers)
                            {
                                Console.WriteLine(item);
                            }
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
                    else
                    {
                        Console.WriteLine("You did not enter a menu option!");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadLine();
                    }

                    return "SearchCustomer";
                case "N":
                    return "MainMenu";
                default:
                    Console.WriteLine("Please input a valid response of Y or N.");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadLine();
                    return "AddCustomer";
            }
            
        }

    }

}