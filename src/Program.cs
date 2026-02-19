using DesignPatternChallengeStrategy.Abstraction;
using DesignPatternChallengeStrategy.ConcreteStrategy;
using DesignPatternChallengeStrategy.Contract;
using DesignPatternChallengeStrategy.Model;

namespace DesignPatternChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            var correios = new CorreiosShipping();
            var fedex = new FedexShipping();
            var dhl = new DhlShipping();
            var local = new LocalShipping();
            var strategy = new ShippingStrategy(correios);

            Console.WriteLine("=== Sistema de Cálculo de Frete ===");


            var shipping1 = new ShippingInfo
            {
                Origin = "São Paulo-SP",
                Destination = "Rio de Janeiro-RJ",
                Weight = 5.0m,
                IsExpress = false
            };

            var shipping2 = new ShippingInfo
            {
                Origin = "São Paulo-SP",
                Destination = "Manaus-AM",
                Weight = 8.0m,
                IsExpress = true
            };

            // Testando diferentes transportadoras
            Console.WriteLine("\n=== Testando Correios ===");
            var correiosCost = strategy.CalculateShipping(shipping1);
            var correiosTime = strategy.GetDeliveryTime(shipping1);
            Console.WriteLine($"Prazo: {correiosTime} dias úteis\n");
            EndLine();

            Console.WriteLine("\n=== Testando FedEx ===");
            strategy.SetStrategy(fedex);
            var fedexCost = strategy.CalculateShipping(shipping2);
            var fedexTime = strategy.GetDeliveryTime(shipping2);
            Console.WriteLine($"Prazo: {fedexTime} dias úteis\n");
            EndLine();

            Console.WriteLine("\n=== Testando DHL ===");
            strategy.SetStrategy(dhl);
            var dhlCost = strategy.CalculateShipping(shipping1);
            var dhlTime = strategy.GetDeliveryTime(shipping1);
            Console.WriteLine($"Prazo: {dhlTime} dias úteis\n");
            EndLine();

            Console.WriteLine("\n=== Testando Local Shipping ===");
            strategy.SetStrategy(local);
            var localCost = strategy.CalculateShipping(shipping1);
            var localTime = strategy.GetDeliveryTime(shipping1);
            Console.WriteLine($"Prazo: {localTime} dias úteis\n");
            EndLine();


            Console.WriteLine("\n=== Comparando Opções ===");
            var carriers = new List<IShippingCalculator> { correios, fedex, dhl, local };

            foreach (var carrier in carriers)
            {
                strategy.SetStrategy(carrier);
                if (strategy.IsAvailable(shipping1))
                {
                    var cost = strategy.CalculateShipping(shipping1);
                    var time = strategy.GetDeliveryTime(shipping1);
                }
            }
        }

        public static void EndLine()
        {
            Console.WriteLine("\n---------------------------------------");
        }
    }
}