using PlanetPaintballUI;

bool repeat = true;

IMenu menu = new MainMenu();

while (repeat)
{

    Console.Clear();
    menu.Display();
    string ans = menu.UserChoice();

    switch (ans)
    {
        case "AddCustomer":
            menu = new AddCustomerMenu();
            break;
        case "SearchCustomer":
            menu = new AddCustomerMenu();
            break;
        case "ViewInventory":
            menu = new ViewInventoryMenu();
            break;
        case "PlaceOrder":
            menu = new PlaceOrderMenu();
            break;
        case "ViewOrderHistory":
            menu = new ViewOrderHistoryMenu();
            break;
        case "ReplenishInventory":
            menu = new ReplenishInventoryMenu();
            break;
        case "Exit":
            repeat = false;
            break;
        default:
            Console.WriteLine("Page does not exist!");
            break;
    }

}