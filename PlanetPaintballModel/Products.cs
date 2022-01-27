namespace PPModel
{

    public class Products
    {

        public string Name { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }

        public override string ToString()
        {   
            return $"Name: {Name}\nPrice: {Price}\nDescription: {Description}\nCategory: {Category}";    
        }

    }

    
}