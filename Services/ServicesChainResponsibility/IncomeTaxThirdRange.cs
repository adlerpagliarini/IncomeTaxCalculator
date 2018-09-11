using Domain.Entities;
using Domain.Entities.Enum;
using Domain.Interfaces.ChainResponsibility;

namespace Services.ServicesChainResponsibility
{
    public class IncomeTaxThirdRange : IncomeTaxDiscountCalculator, IIncomeTaxThirdRange
    {
        public IncomeTaxThirdRange() : base(null, IncomeTax.GetIncomeTax(IncomeTaxRangeTypes.THIRD_RANGE))
        {
        }

        protected override void CalculateIncomeTax(double salary, out double netSalary, out double discount)
        {
            discount = (salary * _incomeTax.DISCOUNT) - 250;
            netSalary = salary - discount;
        }
    }
}
