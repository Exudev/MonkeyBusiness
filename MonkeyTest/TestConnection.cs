using MonkeyBusiness.Resources;

namespace MonkeyTest
{
    [TestClass]
    public class TestConnection
    {
        [TestMethod]
        public void TestConvertCurrency()
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

    }
}

