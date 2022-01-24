namespace PlanetPaintballModel
{

    public class Customer
    {
        
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        
        private List<Orders> _orders;
        public List<Orders> Orders
        {
            get { return _orders }
            set
            {
                _orders = value;
            }
        }

        public Customer()
        {
            
            Name = "Johnny Appleseed"
            Address = "ThisAddress Street"
            Email = "JohnnyAppleseed@Email.com"
            _orders = new List<Orders>()
            {
                new Orders()
            };
            
        }

    }

}
