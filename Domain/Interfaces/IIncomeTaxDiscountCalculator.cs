using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IIncomeTaxDiscountCalculator
    {
        Discount CalculateIncomeTaxFromSalary(double salary);
    }
}
