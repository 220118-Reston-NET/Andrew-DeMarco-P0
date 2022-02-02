using PPBL;
using PPModel;

namespace PPUI
{
    
    public class PlaceOrderMenu : IMenu
    {

        public void Display()
        {

            Console.WriteLine("===Place Order Menu===");
            Console.WriteLine("Did you want to place an order?");
            Console.WriteLine("Enter Y for yes or N for no:");
            
        }

        public string UserChoice()
        {

            string userInput = Console.ReadLine().ToUpper();

            //switch statment

        }

    }

}