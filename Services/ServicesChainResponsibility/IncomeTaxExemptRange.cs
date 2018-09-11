using Domain.Entities;
using Domain.Entities.Enum;
using Domain.Interfaces.ChainResponsibility;

namespace Services.ServicesChainResponsibility
{
    public class IncomeTaxExemptRange : IncomeTaxDiscountCalculator, IIncomeTaxExemptRange
    {
        public IncomeTaxExemptRange(IIncomeTaxFirstRange higherIncomeTaxRange) : base(higherIncomeTaxRange, IncomeTax.GetIncomeTax(IncomeTaxRangeTypes.EXEMPT_RANGE))
        {
        }
    }
}
