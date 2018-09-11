using Domain.Entities;
using Domain.Entities.Enum;
using Domain.Interfaces;

namespace Services.ServicesStrategy
{
    public class IncomeTaxExemptRange : IncomeTaxDiscountCalculator, IIncomeTaxDiscountCalculator
    {  
        public IncomeTaxExemptRange() : base(IncomeTax.GetIncomeTax(IncomeTaxRangeTypes.EXEMPT_RANGE)) { }        

        public new Discount CalculateIncomeTaxFromSalary(double salary)
        {
            return base.CalculateIncomeTaxFromSalary(salary);
        }
    }
}
