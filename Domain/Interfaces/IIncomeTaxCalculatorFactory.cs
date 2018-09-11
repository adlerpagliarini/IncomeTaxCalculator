using Domain.Entities.Enum;

namespace Domain.Interfaces
{
    public interface IIncomeTaxCalculatorFactory
    {
        IIncomeTaxDiscountCalculator GetIncomeTaxCalculator(double salary);
        IIncomeTaxDiscountCalculator GetIncomeTaxFactory(IncomeTaxRangeTypes incomeTaxRangeTypes);
    }
}
