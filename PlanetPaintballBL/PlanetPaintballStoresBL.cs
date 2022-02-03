using PPDL;
using PPModel;

namespace PPBL
{

    public class PlanetPaintballStoresBL : IPlanetPaintballStoresBL
    {

        private IRepository _repo;

        public PlanetPaintballStoresBL(IRepository p_repo)
        {
            _repo = p_repo;
        }

        public List<StoreFront> ViewInventory(string p_address)
        {

            List<StoreFront> listOfStores = _repo.GetStoreFronts();
            var found = listOfStores.Find(p => p.Address.Equals(p_address));
            if(found != null)
            {
                //validation process using LINQ Library
                return listOfStores
                    .Where(store => store.Address.Equals(p_address))
                    .ToList();
            }
            else
            {
                throw new Exception("A store with this address has not been found.");
            }

        }


        public List<Products> GetProductsByStoreAddress(string p_address)
        {
            return _repo.GetProductsByStoreAddress(p_address);
        }

        public void ReplenishInventory(int p_productID, int p_quantity)
        {
            _repo.ReplenishInventory(p_productID, p_quantity);
        }

        public Orders MakeOrder(Orders p_order)
        {
            return _repo.MakeOrder(p_order);
        }
    }

}