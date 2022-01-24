using PlanetPaintballModel;

namespace PlanetPaintballUI
{

    public class AddCustomerMenu : IMenu
    {

        private static Customer _newCustomer = new Customer();

        public void Display()
        {

            Console.WriteLine("===Add Customer Menu===");
            Console.WriteLine("Please enter your name:");
            //read user input
            Console.WriteLine("Please enter your address:");
            //read user input
            Console.WriteLine("Please enter your email address:");
            //read user input
            

        }

    }

}