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

                return _repo.AddCustomer(p_customer);

            }

            public Customer SearchCustomer(Customer p_customer)
            {

                return _repo.SearchCustomer(p_customer);

            }

    }

}