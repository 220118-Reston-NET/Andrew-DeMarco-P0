namespace PlanetPaintballModel
{

    public class Orders
    {

        public string UserEmail;
        
        private List<LineItems> _lineItems;
        public List<LineItems> LineItems
        {

            get { return _lineItems }
            set
            {
                _lineItems = value;
            }

        }

        public string StoreFrontLocation;
        public int Price;

    }

}