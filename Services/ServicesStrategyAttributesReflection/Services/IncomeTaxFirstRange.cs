using Domain.Entities;
using Domain.Entities.Enum;
using Domain.Interfaces;

namespace Services.ServicesStrategyAttributesReflection
{
    public class IncomeTaxFirstRange : IncomeTaxDiscountCalculator, IIncomeTaxDiscountCalculator
    {
        public IncomeTaxFirstRange(IncomeTax incomeTax) : base(incomeTax) { }

        public new Discount CalculateIncomeTaxFromSalary(double salary)
        {
            return base.CalculateIncomeTaxFromSalary(salary);
        }
    }
}
