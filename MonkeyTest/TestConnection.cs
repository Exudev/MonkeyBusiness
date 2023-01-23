using MonkeyBusiness.Resources;

namespace MonkeyTest
{
    [TestClass]
    public class TestConnection
    {
        [TestMethod]
        public void TestConvertCurrencyDOPtoUSD()
        {
            //Arrange
            MoneyConverter mc = new MoneyConverter();
            decimal value = 15000.00m;
            bool isDop = true;
            decimal expected = 263.62m;

            //Act
            decimal actual = (mc.ConvertCurrency(value, isDop));
            //Assert
            Assert.AreEqual(expected,actual);
        }
        [TestMethod]
        public void TestConvertCurrencyUSDtoDOP()
        { 
        
            //Arrange
            MoneyConverter mc = new MoneyConverter();
            decimal value = 99.11m;
            bool isDop = false;
            decimal expected = 5639.36m;
            //Act
            decimal actual = (mc.ConvertCurrency(value, isDop));
            //Assert
            Assert.AreEqual(expected, actual);
        }

    }
}

