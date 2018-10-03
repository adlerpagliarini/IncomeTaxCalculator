using Domain.Entities;
using Domain.Interfaces;

namespace Services.ServicesStrategyAttributesReflection
{
    public class IncomeTaxDiscountCalculator : IIncomeTaxDiscountCalculator
    {
        protected readonly IncomeTax _incomeTax;

        public IncomeTaxDiscountCalculator(IncomeTax incomeTax) 
        {
            _incomeTax = incomeTax;
        }
        public Discount CalculateIncomeTaxFromSalary(double salary)
        {
            var discount = salary * _incomeTax.DISCOUNT;
            var netSalary = salary - discount;
            return new Discount(_incomeTax, salary, netSalary, discount);
        }
    }
}
