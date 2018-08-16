using NUnit.Framework;
using System.Collections.Generic;

namespace Thycotic_Test.Tests
{
    [TestFixture]
    public class PriceDeterminatorTests
    {

        public static IEnumerable<TestCaseData> CarPriceTestData
        {
            // expectValue, purchaseValue, ageInMonths, numberOfMiles, numberOfPreviousOwners, numberOfCollisions
            get
            {
                yield return new TestCaseData(25313.40m, 35000m, 3 * 12, 50000, 1, 1);
                yield return new TestCaseData(19688.20m, 35000m, 3 * 12, 150000, 1, 1);
                yield return new TestCaseData(19688.20m, 35000m, 3 * 12, 250000, 1, 1);
                yield return new TestCaseData(20090.00m, 35000m, 3 * 12, 250000, 1, 0);
                yield return new TestCaseData(21657.02m, 35000m, 3 * 12, 250000, 0, 1);
            }

        }

        [TestCaseSource(typeof(PriceDeterminatorTests), "CarPriceTestData")]
        public void DetermineCarPrice_Always_Return_Expected_Value(decimal expectValue, decimal purchaseValue, int ageInMonths, int numberOfMiles, int numberOfPreviousOwners, int numberOfCollisions)
        {
            Car car = new Car
            {
                PurchaseValue = purchaseValue,
                AgeInMonths = ageInMonths,
                NumberOfMiles = numberOfMiles,
                NumberOfPreviousOwners = numberOfPreviousOwners,
                NumberOfCollisions = numberOfCollisions,     
            };

            PriceDeterminator priceDeterminator = new PriceDeterminator();
            decimal result = priceDeterminator.DetermineCarPrice(car);

            Assert.AreEqual(expectValue, result);
        }
    }
}
