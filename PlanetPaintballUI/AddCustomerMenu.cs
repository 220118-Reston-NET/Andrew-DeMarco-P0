using PPBL;
using PPModel;
using System.Text.RegularExpressions;
    
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
                    
                    //validation uses very simple regex.
                    //more specific data entry checks either involve more complex regex
                    //or something like a web service/database to check input against (ie street address checking).

                    //prompts user to enter in their first name.
                    //checks user input with regex for a name a-zA-Z
                    //if user cannot type the name within three tries after failing, 
                    //it makes them go back to the main menu
                    Console.WriteLine("Please enter your first name:");
                    string firstName = Console.ReadLine();
                    int failedAttempts = 0;
                    while((Regex.IsMatch(firstName, @"^[a-zA-Z]+$") == false))
                    {
                        if(failedAttempts > 2)
                        {
                            Console.WriteLine("You failed to enter in the correct format for a name too many times. Taking you back to the main menu");
                            Console.WriteLine("Press any key to continue:");
                            Console.ReadLine();
                            return "MainMenu";
                        }

                        Console.WriteLine("Invalid entry! Please enter your first name without spaces or punctuation marks:");
                        firstName = Console.ReadLine();
                        failedAttempts = failedAttempts + 1;
                    }

                    //prompts user to enter in their last name.
                    //checks user input with regex for a name a-zA-Z
                    //if user cannot type the name within three tries after failing, 
                    //it makes them go back to the main menu
                    Console.WriteLine("Please enter your last name:");
                    string lastName = Console.ReadLine();
                    failedAttempts = 0;
                    while((Regex.IsMatch(lastName, @"^[a-zA-Z]+$") == false))
                    {
                        if(failedAttempts > 2)
                        {
                            Console.WriteLine("You failed to enter in the correct format for a name too many times. Taking you back to the main menu");
                            Console.WriteLine("Press any key to continue:");
                            Console.ReadLine();
                            return "MainMenu";
                        }
                        Console.WriteLine("Invalid entry! Please enter your last name without spaces or punctuation marks:");
                        lastName = Console.ReadLine();
                        failedAttempts = failedAttempts + 1;
                    }
                    //adds the first and last name to the format that we will use for customer name object
                    string fullName = firstName + " " + lastName;

                    //prompts user to enter in their address
                    //checks user input with regex for an address
                    //if user cannot type the address within three tries after failing,
                    //it makes them go back to the main menu
                    Console.WriteLine("Please enter your address:");
                    string address = Console.ReadLine();
                    failedAttempts = 0;
                    while((Regex.IsMatch(address, @"^[#.0-9a-zA-Z\s,-]+$") == false))
                    {
                        if(failedAttempts > 2)
                        {
                            Console.WriteLine("You failed to enter in the correct format for a name too many times. Taking you back to the main menu");
                            Console.WriteLine("Press any key to continue:");
                            Console.ReadLine();
                            return "MainMenu";
                        }
                        Console.WriteLine("Invalid entry! Please enter your address wihout any illegal characters:");
                        address = Console.ReadLine();
                        failedAttempts = failedAttempts + 1;
                    }

                    //prompts user to enter in their email address
                    //checks user input with regex for an email address
                    //if user cannot type the email address within three tries after failing,
                    //it makes them go back to the main menu
                    Console.WriteLine("Please enter your email:");
                    string email = Console.ReadLine();
                    failedAttempts = 0;
                    while((Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$") == false))
                    {
                        if(failedAttempts > 2)
                        {
                            Console.WriteLine("You failed to enter in the correct format for a name too many times. Taking you back to the main menu");
                            Console.WriteLine("Press any key to continue:");
                            Console.ReadLine();
                            return "MainMenu";
                        }
                        Console.WriteLine("Invalid entry! Please enter your email wihout any illegal characters:");
                        email = Console.ReadLine();
                        failedAttempts = failedAttempts + 1;
                    }

                    //add all the fields for a customer (name, address, email) to customer object and then to customer database json file
                    _newCustomer.Name = fullName;
                    _newCustomer.Address = address;
                    _newCustomer.Email = email;
                    try
                    {
                        _planetPaintballBL.AddCustomer(_newCustomer);
                    }
                    catch (System.Exception exc)
                    {
                        Console.WriteLine(exc.Message);
                        Console.WriteLine("Please press any key to continue");
                        Console.ReadLine();
                    }

                    return "AddCustomer";
                        
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