using PPDL;
using PPModel;

namespace PPBL
{

    public class PlanetPaintballBL : IPlanetPaintballBL
    {

            private IRepository _repo;

            public PlanetPaintballBL(IRepository p_repo)
            {
                _repo = p_repo;
            }

            public Customer AddCustomer(Customer p_customer)
            {
                
                //get the list of customers and then add a new customer to the list
                List<Customer> listOfCustomers = _repo.GetAllCustomers();
                var found = listOfCustomers.Find(p => p.Email == p_customer.Email);
                if(found != null)
                {
                    throw new Exception("A customer with this email already exists! Customer emails must be unique.");
                }
                else
                {   
                    return _repo.AddCustomer(p_customer);
                }

               

            }

            public Customer SearchCustomer(Customer p_customer)
            {

                //validation process
                List<Customer> listOfCustomers = _repo.GetAllCustomers();
                var found = listOfCustomers.Find(p => p.Email == p_customer.Email);
                if(found != null)
                {
                    Console.WriteLine("Yes. This Email is in our customers list.");
                    return _repo.SearchCustomer(p_customer);

                }
                else
                {
                    throw new Exception("A customer with this email has not been found.");
                }
                
            }

    }

}