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
            Account account = new Account();
            account.Id = 1;
            //Act
            account.updateNextID(account.Id);
            int expected = 2;
            //Assert
            Assert.AreEqual(expected, account.NextId);
        }
        
    }
}