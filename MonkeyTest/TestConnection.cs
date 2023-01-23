using MonkeyBusiness.Resources;

namespace MonkeyTest
{
    [TestClass]
    public class StubRateSearcher : IRateSearcher
    {
        public const float RATE_USD_DOP_POPULAR = 55.5f;
        public const float RATE_DOP_USD_POPULAR = 45.6f;

        public int MaximumNumberOfCalls = 0;
        public async Task<List<Rate>> GetCurrencyRates()
        {
            MaximumNumberOfCalls++;
            List<Rate> rates = new List<Rate>();
            rates.Add(new Rate(RATE_USD_DOP_POPULAR, "USD", "DOP", "Banco Popular"));
            rates.Add(new Rate(RATE_DOP_USD_POPULAR, "DOP", "USD", "Banco Popular"));
            return rates;
        }
    }

    [TestClass]
    public class TestingMoneyConverter
    {
        [TestMethod]
        public void Testing_buying_pesos() //el resultado matematico da correcto pero da un error con system.single expected, actual system.decimal
        {
            // ARRANGE
            float correctRate = StubRateSearcher.RATE_DOP_USD_POPULAR;
            IRateSearcher RateSearcher = new StubRateSearcher();
            MoneyConverter sut = new MoneyConverter(RateSearcher);


            // ACT
            decimal Pesos = sut.ConvertCurrency(20, false);

            // ASSERT
            Assert.AreEqual(20 * correctRate, Pesos);
            Assert.AreEqual(1, ((StubRateSearcher)RateSearcher).MaximumNumberOfCalls);
        }

       
    }

    [TestClass]
    public class TestConnection
    {
       
        [TestMethod]
        public void TestConvertCurrencyDOPtoUSD()
        {
            //Arrange
            MoneyConverter SUT = new MoneyConverter();
            decimal value = 15000.00m;
            bool isDop = true;
            decimal expected = 263.62m;

            //Act
            decimal actual = (SUT.ConvertCurrency(value, isDop));
            //Assert
            Assert.AreEqual(expected,actual);
        }
        [TestMethod]
        public void TestConvertCurrencyUSDtoDOP()
        { 
        
            //Arrange
            MoneyConverter SUT = new MoneyConverter();
            decimal value = 99.11m;
            bool isDop = false;
            decimal expected = 5639.36m;
            //Act
            decimal actual = (SUT.ConvertCurrency(value, isDop));
            //Assert
            Assert.AreEqual(expected, actual);
        }

    }
}

