using PlanetPaintballModel;

namespace PlanetPaintballUI
{

    public class AddCustomerMenu : IMenu
    {

        private static Customer _newCustomer = new Customer();

        public void Display()
        {

            Console.WriteLine("===Add Customer Menu===");
           
        }

        public string UserChoice()
        {
            
            Console.WriteLine("Please enter your name:");
            _newCustomer.Name = Console.ReadLine();
            Console.WriteLine("Please enter your address:");
            _newCustomer.Address = Console.ReadLine();
            Console.WriteLine("Please enter your email address:");
            _newCustomer.Email = Console.ReadLine(); 
            
        }

    }

}