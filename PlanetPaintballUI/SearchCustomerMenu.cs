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
                    //add functionality so that user has to enter of type Name, address and email
                    Console.WriteLine("Please enter the email of the customer you want to search for:");
                    string customerEmailInput = Console.ReadLine();
                    _planetPaintballBL.SearchCustomer(_newCustomer);
                    return "MainMenu";
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