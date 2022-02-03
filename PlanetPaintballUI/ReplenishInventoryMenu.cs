using PPBL;
using PPModel;

namespace PPUI
{
    
    public class ReplenishInventoryMenu : IMenu
    {

        private static StoreFront _newStore = new StoreFront();

        //Dependency injection
        private IPlanetPaintballStoresBL _planetPaintballStoresBL;
        public ReplenishInventoryMenu(IPlanetPaintballStoresBL p_planetPaintballStoresBL)
        {
            _planetPaintballStoresBL = p_planetPaintballStoresBL;
        }

        public void Display()
        {

            Console.WriteLine("===Replenish Inventory Menu===");
            Console.WriteLine("Did you want to replenish a store's inventory?");
            Console.WriteLine("Enter Y for yes or N for no:");

        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine().ToUpper();

            switch (userInput)
            {
                case "Y":
                    Console.WriteLine("Enter the store address you wish to view and replenish:");
                    string storeLocation = Console.ReadLine();
                    try
                    {
                        List<StoreFront> listOfStores = _planetPaintballStoresBL.ViewInventory(storeLocation);
                        Console.WriteLine("Here is the list of products that the store has:");
                        List<Products> listOfStoreProducts = _planetPaintballStoresBL.GetProductsByStoreAddress(storeLocation);
                        foreach(var item in listOfStoreProducts)
                        {
                            Console.WriteLine(item);
                        }
                        Console.WriteLine("Enter the ID for the item you wish to replenish:");
                        int replenishID = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the amount of items you are adding to the quantity:");
                        int replenishAmount = Convert.ToInt32(Console.ReadLine());
                        _planetPaintballStoresBL.ReplenishInventory(replenishID, replenishAmount);
                    }
                    catch(System.Exception exc)
                    {
                        Console.WriteLine(exc.Message);
                        Console.WriteLine("Please press any key to continue:");
                        Console.ReadLine();
                    }
                    Console.ReadLine();
                    return "ReplenishInventory";
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