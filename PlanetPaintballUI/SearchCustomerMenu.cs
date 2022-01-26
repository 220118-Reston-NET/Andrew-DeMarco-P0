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
                    Console.WriteLine("Please enter the email of the customer you want to search for:");
                    _newCustomer.Email = Console.ReadLine();
                    try
                    {
                        _planetPaintballBL.SearchCustomer(_newCustomer);
                        Console.WriteLine("Press any key to continue:");
                        Console.ReadLine();
                    }
                    catch (System.Exception exc)
                    {
                        Console.WriteLine(exc.Message);
                        Console.WriteLine("Please press any key to continue:");
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