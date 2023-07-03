using System;
using System.Linq;

namespace Pizza.Calculator
{
    public class PizzaCalculator : IPizzaCalculator
    {
        private const double sliceCountPerPizza = 6;
        private const double discountPerHundredPeople = 0.05;
        private IPizzaRepository pizzaRepository;
        private IPriceRepository priceRepository;

        public PizzaCalculator(IPizzaRepository pizzaRepository, IPriceRepository priceRepository)
        {
            this.pizzaRepository = pizzaRepository;
            this.priceRepository = priceRepository;
        }

        public int GetPizzaCount(uint personCount, PizzaKind pizzaKind)
        {
            var pizzaStats = this.pizzaRepository.GetPizzaStatistics();
            var foundPizzaStat = pizzaStats.FirstOrDefault(s => s.PizzaKind.Equals(pizzaKind));
            if (foundPizzaStat == null)
            {
                throw new InvalidOperationException("Type de pizza inconnu");
            }

            double pizzaCount = ((double)foundPizzaStat.AverageSliceCount * personCount)/sliceCountPerPizza;
            return (int)Math.Ceiling(pizzaCount);
        }

        public uint GetGroupPrice(uint personCount)
        {
            uint groupPrice = Math.Floor(personCount / 100);

            if (groupPrice < 1)
            {
                throw new InvalidOperationException("Participants insuffisants");
            }

            return groupPrice;
        }

        public double GetDiscountedPrice(
            uint groupPrice,
            uint pizzaCount,
            PizzaKind pizzaKind
        ) {
            var priceRef = this.priceRepository.GetPriceReferences();
            var foundPriceRef = priceRef.FirstOrDefault(r => r.PizzaKind.Equals(pizzaKind));
            if (foundPriceRef == null)
            {
                throw new InvalidOperationException("Type de pizza inconnu");
            }

            double discountValue = 1 - (groupPrice * discountPerHundredPeople);
            double discountedPrice = ((double)foundPriceRef.UnitPrice * pizzaCount) * discountValue;
        }
    }
}