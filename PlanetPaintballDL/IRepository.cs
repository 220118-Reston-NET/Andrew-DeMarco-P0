using PPModel;

namespace PPDL
{

    /// <summary>
    /// Data layer project is responsible for interfacting with database and doing crud operations
    /// C -- create, R -- read, U -- update, D -- delete
    /// Think of it as a delivery man. You dont want them to touch or use your items, just to deliver it.
    /// </summary>
    public interface IRepository
    {

        /// <summary>
        /// Add customer to the database
        /// </summary>
        /// <param name="p_customer">The customer object we are adding to the database</param>
        /// <returns>Returns the customer that was added</returns>
        Customer AddCustomer(Customer p_customer);

        /// <summary>
        /// Searches for the customer in the database takes in the customer we are searching for
        /// </summary>
        /// <param name="p_customer"></param>
        /// <returns></returns>
        Customer SearchCustomer(Customer p_customer);
        
    }


}

