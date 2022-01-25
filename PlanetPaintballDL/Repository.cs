using System.Text.Json;
using PPModel;

namespace PPDL
{

    public class Repository : IRepository
    {


        private string _filepath = "../PlanetPaintballDL/Database/";
        private string _jsonString;


        public Customer AddCustomer(Customer p_customer)
        {

            string path = _filepath + "PlanetPaintballCustomer.json";
            
            _jsonString = JsonSerializer.Serialize(p_customer, new JsonSerializerOptions {WriteIndented = true});

            File.WriteAllText(path, _jsonString);

            return p_customer;

        }

        public Customer SearchCustomer(Customer p_customer)
        {

            string path = _filepath + "PlanetPaintballCustomer.json";

            _jsonString = File.ReadAllText(path);

            List<Customer> customers = JsonSerializer.Deserialize<List<Customer>>(_jsonString);

            Console.WriteLine("Name " + customers[0].Name);
            Console.WriteLine("Address " + customers[0].Address);
            Console.WriteLine("Email: " + customers[0].Email);

            return p_customer;

        }

    }

}