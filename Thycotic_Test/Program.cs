using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thycotic_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Azmath");
            PriceDeterminator priceDeterminator = new PriceDeterminator();
            Car car = new Car
            {
                AgeInMonths = 3 * 12,
                NumberOfCollisions = 0,
                NumberOfMiles = 250000,
                NumberOfPreviousOwners = 1,
                PurchaseValue = 35000m
            };

            priceDeterminator.DetermineCarPrice(car);

            Console.ReadLine();
        }
    }
}
