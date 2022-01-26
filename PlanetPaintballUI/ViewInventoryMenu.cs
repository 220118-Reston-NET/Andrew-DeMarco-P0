using PPModel;

namespace PPUI
{

    public class ViewInventoryMenu : IMenu
    {

        public void Display()
        {

            Console.WriteLine("===View Inventory Menu===");
            Console.WriteLine("Did you want to view a store's inventory?");
            Console.WriteLine("Enter Y for yes or N for no:");

        }

        public string UserChoice()
        {

            string userInput = Console.ReadLine().ToUpper();

            switch(userInput)
            {

                case "Y":
                    return "ViewInventory";
                

                case "N":
                    return "MainMenu";

                default:
                    Console.WriteLine("You entered an illegal character! Please try again.");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadLine();
                    return "ViewInventory";

            }

        }

    }

}