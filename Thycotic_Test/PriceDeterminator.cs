using System;
using System.Collections.Generic;

namespace Thycotic_Test
{
    public class PriceDeterminator
    {
        private Dictionary<string, double> priceDeduction = new Dictionary<string, double>();
        public const int months = 12;
        public const int milage = 150000;
        public const int previousOwners = 2;
        public const int collisions = 5;

        public PriceDeterminator()
        {
            priceDeduction.Add("AGE_DEDUCTION", 0.5 * 0.01);
            priceDeduction.Add("MILES_DEDUCTION", 0.2 * 0.01);
            priceDeduction.Add("PREVIOUS_OWNER_DEDUCTION", 25.0 * 0.01);
            priceDeduction.Add("PREVIOUS_OWNER_ADDITION", 10.0 * 0.01);
            priceDeduction.Add("COLLOSION_DEDUCTION", 2.0 * 0.01);
        }

        public decimal DetermineCarPrice(Car car)
        {
            decimal purchaseValue = car.PurchaseValue;
            decimal calculatedValue = purchaseValue;

            Console.WriteLine("Purchase value : " + calculatedValue);

            if (car.AgeInMonths <= (months*10))
            {
                calculatedValue = calculatedValue - ((calculatedValue * (decimal)priceDeduction["AGE_DEDUCTION"]) * car.AgeInMonths);
            }

            int mileUnits = 0;
            mileUnits = (0 <= car.NumberOfMiles && car.NumberOfMiles <= milage) ? car.NumberOfMiles / 1000 : (car.NumberOfMiles > 150000) ? milage / 1000 : 0;
            
            if (mileUnits > 0)
            {
                calculatedValue = calculatedValue - ((calculatedValue * (decimal)priceDeduction["MILES_DEDUCTION"]) * mileUnits);
            }

            if (car.NumberOfPreviousOwners > previousOwners)
            {
                calculatedValue = calculatedValue - (calculatedValue * (decimal)priceDeduction["PREVIOUS_OWNER_DEDUCTION"]);
            }

            if (car.NumberOfCollisions <= collisions)
            {
                calculatedValue = calculatedValue - ((calculatedValue * (decimal)priceDeduction["COLLOSION_DEDUCTION"]) * car.NumberOfCollisions);
            }
            
            calculatedValue = car.NumberOfPreviousOwners == 0 ? (calculatedValue + (calculatedValue * (decimal)priceDeduction["PREVIOUS_OWNER_ADDITION"])) : calculatedValue;

            Console.WriteLine("New value after owner addition : " + calculatedValue);

            return calculatedValue;
        
        }
    }
}
