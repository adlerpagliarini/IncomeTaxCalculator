using Domain.Entities;
using Domain.Interfaces;

namespace Services.ServicesChainResponsibility
{
    public class IncomeTaxDiscountCalculator : IIncomeTaxDiscountCalculator
    {
        protected readonly IIncomeTaxDiscountCalculator HigherIncomeTaxRange;
        protected readonly IncomeTax _incomeTax;

        public IncomeTaxDiscountCalculator(IIncomeTaxDiscountCalculator higherIncomeTaxRange, IncomeTax incomeTax)
        {
            HigherIncomeTaxRange = higherIncomeTaxRange;
            _incomeTax = incomeTax;
        }

        public Discount CalculateIncomeTaxFromSalary(double salary)
        {
            if (salary <= _incomeTax.MAX_VALUE)
            {
                double netSalary;
                double discount;
                CalculateIncomeTax(salary, out netSalary, out discount);
                return new Discount(_incomeTax, salary, netSalary, discount);
            }
            else if (HigherIncomeTaxRange != null)
                return HigherIncomeTaxRange.CalculateIncomeTaxFromSalary(salary);

            return null;
        }

        protected virtual void CalculateIncomeTax(double salary, out double netSalary, out double discount)
        {
            discount = salary * _incomeTax.DISCOUNT;
            netSalary = salary - discount;
        }
    }
}
