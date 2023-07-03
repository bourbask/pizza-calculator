using System.Collections.Generic;

namespace Pizza.Calculator
{
    public interface IPriceRepository
    {
        IEnumerable<PriceRef> GetPriceReferences();
    }

    public class PriceRef
    {
        public PizzaKind PizzaKind { get; set; }
        public double UnitPrice { get; set; }
    }
}