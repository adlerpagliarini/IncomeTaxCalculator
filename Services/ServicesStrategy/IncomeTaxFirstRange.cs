using Domain.Entities;
using Domain.Entities.Enum;
using Domain.Interfaces;

namespace Services.ServicesStrategy
{
    public class IncomeTaxFirstRange : IncomeTaxDiscountCalculator, IIncomeTaxDiscountCalculator
    {
        public IncomeTaxFirstRange() : base(IncomeTax.GetIncomeTax(IncomeTaxRangeTypes.FIRST_RANGE)) { }

        public new Discount CalculateIncomeTaxFromSalary(double salary)
        {
            return base.CalculateIncomeTaxFromSalary(salary);
        }
    }
}
