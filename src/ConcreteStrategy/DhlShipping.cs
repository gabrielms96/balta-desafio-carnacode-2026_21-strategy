using DesignPatternChallengeStrategy.Abstraction;
using DesignPatternChallengeStrategy.Model;

namespace DesignPatternChallengeStrategy.ConcreteStrategy
{
    public class DhlShipping : IShippingCalculator
    {
        public decimal CalculateShipping(ShippingInfo info)
        {
            decimal cost = 0.00m;
            // Lógica específica DHL
            cost = 25.00m;
            cost += info.Weight * 4.50m;

            // DHL cobra por faixa de peso
            if (info.Weight > 10)
                cost += (info.Weight - 10) * 2.00m;

            if (info.IsExpress)
                cost += 35.00m;

            Console.WriteLine($"→ Cálculo DHL: R$ {cost:N2}");
            return cost;
        }

        public int GetDeliveryTime(ShippingInfo info)
        {
            return info.IsExpress ? 1 : 4;
        }
    }
}
