global using Serilog;
using PPBL;
using PPDL;
using PPUI;



//creating and configuring our logger
//logger will save to user.txt in logs folder
Log.Logger = new LoggerConfiguration()
    .WriteTo.File("./logs/user.txt") 
    .CreateLogger();

bool repeat = true;

IMenu menu = new MainMenu();

while (repeat)
{

    Console.Clear();
    menu.Display();
    string ans = menu.UserChoice();

    switch (ans)
    {
        case "MainMenu":
            Log.Information("Displaying the MainMenu to user.");
            menu = new MainMenu();
            break;
        case "AddCustomer":
            Log.Information("Displaying the AddCustomerMenu to user.");
            menu = new AddCustomerMenu(new PlanetPaintballBL(new Repository()));
            break;
        case "SearchCustomer":
            Log.Information("Displaying the SearchCustomerMenu to user.");
            menu = new SearchCustomerMenu(new PlanetPaintballBL(new Repository()));
            break;
        case "ViewInventory":
            Log.Information("Displaying the ViewInventoryMenu to user.");
            menu = new ViewInventoryMenu(new PlanetPaintballStoresBL(new Repository()));
            break;
        case "PlaceOrder":
            //menu = new PlaceOrderMenu();
            break;
        case "ViewOrderHistory":
            //menu = new ViewOrderHistoryMenu();
            break;
        case "ReplenishInventory":
            //menu = new ReplenishInventoryMenu();
            break;
        case "Exit":
            Log.Information("Exiting application.");
            Log.CloseAndFlush(); //closes logger resource
            repeat = false;
            break;
        default:
            Console.WriteLine("Page does not exist!");
            break;
    }

}