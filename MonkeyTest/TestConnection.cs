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
    public class TestingConvertidorDeMoneda
    {
        [TestMethod]
        public void Probando_una_compra_de_dolares_en_el_popular()
        {
            // ARRANGE
            float correctRate = StubRateSearcher.RATE_DOP_USD_POPULAR;
            IRateSearcher RateSearcher = new StubRateSearcher();
            MoneyConverter sut = new MoneyConverter(RateSearcher);


            // ACT
            decimal Pesos = sut.ConvertCurrency(20, false);

            // ASSERT
            Assert.AreEqual(20 / correctRate, Pesos);
            Assert.AreEqual(1, ((StubRateSearcher)RateSearcher).MaximumNumberOfCalls);
        }

       
    }

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

