using MonkeyBusiness.Handler;
using MonkeyBusiness.Models;
using MonkeyBusiness.Views;

namespace MonkeyTest
{
    [TestClass]
    public class TestAccount
    {
        [TestMethod]
       
        public void TestingupdateNextID()
        {
            //Arrange
            Account SUT = new Account();
            SUT.Id = 1;
            int expected = 2;
            //Act
           SUT.updateNextID(SUT.Id);
           int actual = SUT.NextId;
            
            //Assert
            Assert.AreEqual(expected, actual);
        }
        
    }
}