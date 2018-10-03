using Domain.Entities;
using Domain.Entities.Enum;
using Domain.Interfaces;

namespace Services.ServicesStrategyAttributesReflection
{
    public class IncomeTaxThirdRange : IncomeTaxDiscountCalculator, IIncomeTaxDiscountCalculator
    {
        public IncomeTaxThirdRange(IncomeTax incomeTax) : base(incomeTax) { }

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
