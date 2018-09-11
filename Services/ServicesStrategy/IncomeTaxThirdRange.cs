using Domain.Entities;
using Domain.Entities.Enum;
using Domain.Interfaces;

namespace Services.ServicesStrategy
{
    public class IncomeTaxThirdRange : IncomeTaxDiscountCalculator, IIncomeTaxDiscountCalculator
    {
        public IncomeTaxThirdRange() : base(IncomeTax.GetIncomeTax(IncomeTaxRangeTypes.THIRD_RANGE)) { }

        public new Discount CalculateIncomeTaxFromSalary(double salary)
        {
            var discount = DifferentRuleForDiscount(salary, _incomeTax);
            var netSalary = salary - discount;
            return new Discount(_incomeTax, salary, netSalary, discount);
        }

        private double DifferentRuleForDiscount(double salary, IncomeTax incomeTax)
        {
            return (salary * incomeTax.DISCOUNT) - 250;
        }
    }
}
