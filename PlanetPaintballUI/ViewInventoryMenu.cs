using PPBL;
using PPModel;

namespace PPUI
{

    public class ViewInventoryMenu : IMenu
    {

        private static StoreFront _newStore = new StoreFront();

        //dependency injection
        private IPlanetPaintballStoresBL _planetPaintballStoresBL;
        public ViewInventoryMenu(IPlanetPaintballStoresBL p_planetPaintballStoresBL)
        {
            _planetPaintballStoresBL = p_planetPaintballStoresBL;
        }

        public void Display()
        {

            Console.WriteLine("===View Inventory Menu===");
            Console.WriteLine("Did you want to view a store's inventory?");
            Console.WriteLine("Enter Y for yes or N for no:");

        }

        public string UserChoice()
        {

            //used to log user input to user.txt file
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("./logs/user.txt") 
                .CreateLogger();

            string userInput = Console.ReadLine().ToUpper();

            switch(userInput)
            {

                case "Y":
                    Console.WriteLine("Enter the Store location You wish to buy from:");
                    string storeLocation = Console.ReadLine();
                    Log.Information("User entered in a store location.");
                    try
                    {
                        List<StoreFront> listOfStores = _planetPaintballStoresBL.ViewInventory(storeLocation);
                        Console.WriteLine("Here is the list of products that store has:");
                        List<Products> listOfStoreProducts = _planetPaintballStoresBL.GetProductsByStoreAddress(storeLocation);
                        foreach (Products item in listOfStoreProducts)
                        {
                            Console.WriteLine(item);
                        }
                        Log.Information("Displayed list of items store has to user.");
                        Console.WriteLine("Press any key to continue:");
                        Console.ReadLine();
                    }  
                    catch(System.Exception exc)
                    {
                        Console.WriteLine(exc.Message);
                        Log.Warning("No store found with that address.");
                        Console.WriteLine("Please press any key to continue:");
                        Console.ReadLine();
                    }
                    return "ViewInventory";
                

                case "N":
                    return "MainMenu";

                default:
                    Console.WriteLine("You entered an illegal character! Please try again.");
                    Log.Warning("User entered in an illegal menu option.");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadLine();
                    return "ViewInventory";

            }

        }

    }

}