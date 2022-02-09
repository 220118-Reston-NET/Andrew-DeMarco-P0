using PPModel;
using Xunit;

namespace PlanetPaintballTest
{
   
    public class StoreFrontTest
    {
        /// <summary>
        /// 
        /// </summary>
        /// [Fact] is a data annotation in C# 
        /// and will tell ther compiler that this method is a unit test
        [Fact]
        public void StoreFrontShouldSetValidData()
        {

            //Arrange
            StoreFront store = new StoreFront();
            string validAddress = "21 Paint St";

            //Act
            store.Address = validAddress;

            //Assert
            Assert.NotNull(store.Address);
            Assert.Equal(validAddress, store.Address);

        }
        
    }

}
