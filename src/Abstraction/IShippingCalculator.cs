using DesignPatternChallengeStrategy.Model;

namespace DesignPatternChallengeStrategy.Abstraction
{
    public interface IShippingCalculator
    {
        decimal CalculateShipping(ShippingInfo info);
        int GetDeliveryTime(ShippingInfo info);
        bool IsAvailable(ShippingInfo info)
        {
            return info.Weight <= 50;
        }
    }
}
