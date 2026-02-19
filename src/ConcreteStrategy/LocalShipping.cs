using DesignPatternChallengeStrategy.Abstraction;
using DesignPatternChallengeStrategy.Model;

namespace DesignPatternChallengeStrategy.ConcreteStrategy
{
    public class LocalShipping : IShippingCalculator
    {
        public decimal CalculateShipping(ShippingInfo info)
        {
            decimal cost = 0.00m;
            // Lógica da transportadora local
            cost = 8.00m;
            cost += info.Weight * 1.50m;

            // Não cobra expresso (sempre é rápido)
            if (info.IsExpress)
                Console.WriteLine("   ℹ️ Transportadora local sempre entrega rápido");

            // Só atende região metropolitana
            if (!info.Destination.Contains("São Paulo-SP"))
            {
                Console.WriteLine("   ❌ Não atende esta região!");
                return 0;
            }

            Console.WriteLine($"→ Cálculo Local: R$ {cost:N2}");
            return cost;
        }

        public int GetDeliveryTime(ShippingInfo info)
        {
            return 1;
        }

        public bool IsAvailable(ShippingInfo info)
        {
            return info.Destination.Contains("São Paulo-SP");
        }
    }
}
