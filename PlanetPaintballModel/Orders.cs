namespace PPModel
{

    public class Orders
    {
        public int OrderID;

        public int CustomerID;
    
        public int StoreID;

        public decimal orderTotalCost;

        private List<LineItems> _lineItems;
        public List<LineItems> LineItems
        {

            get { return _lineItems; }
            set
            {
                _lineItems = value;
            }

        }

        public string StoreFrontLocation;
        public int Price;

        //string version of the object
        public override string ToString()
        {
            return $"=====================\nOrder ID: {OrderID}\nCustomer ID: {CustomerID}\nStore ID: {StoreID}\nTotal Spent: ${orderTotalCost.ToString("0.00")}\n=====================\n";
        }

    }

}