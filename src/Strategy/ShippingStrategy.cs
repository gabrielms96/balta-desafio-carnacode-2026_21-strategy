using DesignPatternChallengeStrategy.Abstraction;
using DesignPatternChallengeStrategy.Model;

namespace DesignPatternChallengeStrategy.Contract
{
    public class ShippingStrategy
    {
        private IShippingCalculator _strategy;

        public ShippingStrategy(IShippingCalculator strategy)
        {
            _strategy = strategy;
        }

        public void SetStrategy(IShippingCalculator strategy)
        {
            _strategy = strategy;
        }

        public decimal CalculateShipping(ShippingInfo info)
        {
            return _strategy.CalculateShipping(info);
        }

        public int GetDeliveryTime(ShippingInfo info)
        {
            return _strategy.GetDeliveryTime(info);
        }

        public bool IsAvailable(ShippingInfo info)
        {
            return _strategy.IsAvailable(info);
        }
    }
}
