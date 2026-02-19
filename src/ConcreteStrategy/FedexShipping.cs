using DesignPatternChallengeStrategy.Abstraction;
using DesignPatternChallengeStrategy.Model;

namespace DesignPatternChallengeStrategy.ConcreteStrategy
{
    public class FedexShipping : IShippingCalculator
    {
        public decimal CalculateShipping(ShippingInfo info)
        {
            decimal cost = 0.00m;
            // Lógica específica FedEx
            cost = 30.00m; // Taxa base internacional
            cost += info.Weight * 5.00m;

            if (info.IsExpress)
                cost *= 1.8m; // 80% a mais para expresso

            // Taxa adicional para destinos remotos
            if (info.Destination.Contains("Norte") || info.Destination.Contains("Nordeste"))
                cost += 20.00m;

            Console.WriteLine($"→ Cálculo FedEx: R$ {cost:N2}");

            return cost;
        }

        public int GetDeliveryTime(ShippingInfo info)
        {
            return info.IsExpress ? 2 : 5;
        }
    }
}
