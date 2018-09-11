using Domain.Entities;
using Domain.Entities.Enum;
using Domain.Interfaces;

namespace Services.ServicesStrategy
{
    public class IncomeTaxSecondRange : IncomeTaxDiscountCalculator, IIncomeTaxDiscountCalculator
    {
        public IncomeTaxSecondRange() : base(IncomeTax.GetIncomeTax(IncomeTaxRangeTypes.SECOND_RANGE)) { }

        public new Discount CalculateIncomeTaxFromSalary(double salary)
        {
            return base.CalculateIncomeTaxFromSalary(salary);
        }
    }
}
