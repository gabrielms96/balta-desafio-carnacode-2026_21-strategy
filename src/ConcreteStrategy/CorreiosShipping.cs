using DesignPatternChallengeStrategy.Abstraction;
using DesignPatternChallengeStrategy.Model;

namespace DesignPatternChallengeStrategy.ConcreteStrategy
{
    public class CorreiosShipping : IShippingCalculator
    {
        public decimal CalculateShipping(ShippingInfo info)
        {
            decimal cost = 0.00m;
            // Lógica específica dos Correios
            cost = 15.00m; // Taxa base
            cost += info.Weight * 2.50m; // Por kg

            if (info.IsExpress)
                cost += 25.00m; // Taxa SEDEX

            // Desconto para mesmo estado
            if (info.Origin.Split('-')[1] == info.Destination.Split('-')[1])
                cost *= 0.85m;

            Console.WriteLine($"→ Cálculo Correios: R$ {cost:N2}");
            return cost;
        }

        public int GetDeliveryTime(ShippingInfo info)
        {
            return info.IsExpress ? 3 : 7;
        }

        public bool IsAvailable(ShippingInfo info)
        {
            return true;
        }
    }
}
