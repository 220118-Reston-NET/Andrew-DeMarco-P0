using PPDL;
using PPModel;

namespace PPBL
{

    public interface IPlanetPaintballStoresBL
    {

        /// <summary>
        /// will display the inventory of the store along with the store information.
        /// </summary>
        /// <param name="p_address"></param>
        /// <returns></returns>
        List<StoreFront> ViewInventory(string p_address);

        /// <summary>
        /// will display the products that a specific store
        /// </summary>
        /// <param name="p_address"></param>
        /// <returns></returns>
        List<Products> GetProductsByStoreAddress(string p_address);

        /// <summary>
        /// will replenish the inventory of a store with the amount given
        /// </summary>
        /// <param name="p_productID"></param>
        /// <param name="p_quantity"></param>
        void ReplenishInventory(int p_productID, int p_quantity);

        /// <summary>
        /// will make the order of the items the customer has ordered
        /// </summary>
        /// <param name="newOrder"></param>
        public Orders MakeOrder(Orders p_order);
    }

}