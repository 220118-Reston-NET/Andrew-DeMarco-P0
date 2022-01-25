using PPBL;
using PPModel;

namespace PPUI
{

    public class AddCustomerMenu : IMenu
    {

        private static Customer _newCustomer = new Customer();


        //Dependency injection
        private IPlanetPaintballBL _planetPaintballBL;
        public AddCustomerMenu(IPlanetPaintballBL p_planetPaintballBL)
        {
            _planetPaintballBL = p_planetPaintballBL;
        }


        public void Display()
        {

            Console.WriteLine("===Add Customer Menu===");
            Console.WriteLine("Did you want to add a new customer?");
            Console.WriteLine("Enter Y for yes or N for no:");
           
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine().ToUpper();

            switch (userInput)
            {
                case "Y":
                    //add functionality so that user has to enter of type Name, address and email
                    Console.WriteLine("Please enter your name:");
                    _newCustomer.Name = Console.ReadLine();
                    Console.WriteLine("Please enter your address:");
                    _newCustomer.Address = Console.ReadLine();
                    Console.WriteLine("Please enter your email address:");
                    _newCustomer.Email = Console.ReadLine();
                    //add the customer to customer database json file
                    _planetPaintballBL.AddCustomer(_newCustomer);
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