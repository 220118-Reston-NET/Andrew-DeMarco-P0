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

        public Customer SearchCustomer(Customer p_customer)
        {
            return p_customer;
        }

        List<Products> IRepository.GetProductsByStoreAddress(string p_address)
        {
            List<Products> listOfProducts = new List<Products>();

            string sqlQuery = @"";

            return listOfProducts;
        }
    }
}