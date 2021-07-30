using Money;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestProjectQuestion1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void MoneyParts()
        {
            //Values
            double value = 10.5;

            MoneyParts moneyParts = new MoneyParts();

            var result = moneyParts.Build(value);

            if (result.Count > 0)
            {
                List<double> num = result[0];

                double sum = 0;

                foreach (double item in num)
                {
                    sum += item;
                }

                if (sum == value)
                {
                    Assert.Pass();
                }
                else
                {
                    Assert.Fail();
                }
            }
            else
            {
                Assert.Fail();
            }
        }
    }
}