using PPModel;

namespace PPBL
{

    /// <summary>
    /// Business layer is responsible for further validation or processing of data obtained from either he database or the user.
    /// 
    /// </summary>
    public interface IPlanetPaintballBL
    {

        /// <summary>
        /// will add a customer data to the database
        /// </summary>
        /// <param name="p_customer"></param>
        /// <returns></returns>
        Customer AddCustomer(Customer p_customer);

        Customer SearchCustomer(Customer p_customer);

    }


}

