using System.Data.SqlClient;
using PPModel;

namespace PPDL
{
    public class SQLRepository : IRepository
    {

        private readonly string _connectionStrings;
        public SQLRepository(string p_connectionStrings)
        {
            _connectionStrings = p_connectionStrings;
        }

        public Customer AddCustomer(Customer p_customer)
        {

            string sqlQuery = @"insert into Customer
                                values(@customerName, @customerAddress, @customerEmail)";
        
            using(SqlConnection con = new SqlConnection(_connectionStrings))
            {
                
                //open the connection, do not need to close connection due to using
                con.Open();
 
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@customerName", p_customer.Name);
                command.Parameters.AddWithValue("@customerAddress", p_customer.Address);
                command.Parameters.AddWithValue("@customerEmail", p_customer.Email);

                //execute the SQL statement
                command.ExecuteNonQuery();

            }

            return p_customer;
            
        } 

        public List<Customer> GetAllCustomers()
        {

            List<Customer> listOfCustomers = new List<Customer>();

            string sqlQuery = @"select * from Customer";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {

                //open the connection
                con.Open();

                //command object that has our query and con obj
                SqlCommand command = new SqlCommand(sqlQuery, con);

                //read outputs from sql statement using special class
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    listOfCustomers.Add(new Customer()
                    {
                        ID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Address = reader.GetString(2),
                        Email = reader.GetString(3)
                    });

                }

            }

            return listOfCustomers;

        }

        public List<StoreFront> GetStoreFronts()
        {
            
            List<StoreFront> listOfStores = new List<StoreFront>();

            string sqlQuery = @"select * from StoreFront";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {

                //open the connection
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    listOfStores.Add(new StoreFront()
                    {
                        ID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Address = reader.GetString(2)
                    });

                }

            }

            return listOfStores;

        }

        public Orders MakeOrder(Orders p_order)
        {
            
            //first get the quantity from the database and see if that you have that many items in stock to buy
            string sqlQuery = @"select sfp.quantity from storeFront_product sfp
                            where sfp.productID = @productID";

            //make a temp quantity to store that value for later
            int tempQuantity = 0;

            using(SqlConnection con = new SqlConnection(_connectionStrings))
            {

                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@productID", p_order.LineItems[0]);
                
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    tempQuantity = reader.GetInt32(0);
                }

                // tempQuantity = tempQuantity - 
                // Console.WriteLine(tempQuantity);
            }


            return p_order;

        }

        public void ReplenishInventory(int p_productID, int p_quantity)
        {
            int tempQuantity = 0;
            string sqlQuery = @"select sfp.quantity from storeFront_product sfp
                            where sfp.productID = @productID";
            
            using(SqlConnection con = new SqlConnection(_connectionStrings))
            {

                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@productID", p_productID);
                
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    tempQuantity = reader.GetInt32(0);
                }

                tempQuantity = tempQuantity + p_quantity;
                Console.WriteLine(tempQuantity);
            }
            
            sqlQuery = @"update storeFront_product
                        set quantity = @quantity
                        where productID = @productID";

            using(SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command= new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@quantity", tempQuantity);
                command.Parameters.AddWithValue("@productID", p_productID);

                command.ExecuteNonQuery();
            }

        }

        public Customer SearchCustomer(Customer p_customer)
        {
            return p_customer;
        }

        List<Products> IRepository.GetProductsByStoreAddress(string p_address)
        {
            List<Products> listOfProducts = new List<Products>();

            string sqlQuery = @"select p.productID, p.productName, p.productPrice, p.productDescription, p.productCategory, sp.quantity from Product p
                            inner join storeFront_product sp on sp.productID = p.productID 
                            inner join StoreFront s on s.storeFrontID = sp.storeId
                            where s.storeFrontAddress = @storeFrontAddress";

            using(SqlConnection con = new SqlConnection(_connectionStrings))
            {

                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@storeFrontAddress", p_address);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    
                    listOfProducts.Add(new Products()
                    {
                        ID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Price = reader.GetDecimal(2),
                        Description = reader.GetString(3),
                        Category = reader.GetString(4),
                        quantity = reader.GetInt32(5)
                    });

                }

            }

            return listOfProducts;
        }
    }
}