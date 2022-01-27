using PPModel;
using Xunit;

namespace PlanetPaintballTest
{
   
    public class UnitTest1
    {
        /// <summary>
        /// 
        /// </summary>
        /// [Fact] is a data annotation in C# 
        /// and will tell ther compiler that this method is a unit test
        [Fact]
        public void CustomerShouldSetValidData()
        {

            //Arrange
            Customer cust = new Customer();
            string validName = "Bob";

            //Act
            cust.Name = validName;

            //Assert
            Assert.NotNull(cust.Name);
            Assert.Equal(validName, cust.Name);

        }
        
    }

}
