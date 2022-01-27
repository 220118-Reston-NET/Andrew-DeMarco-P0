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

    }

}