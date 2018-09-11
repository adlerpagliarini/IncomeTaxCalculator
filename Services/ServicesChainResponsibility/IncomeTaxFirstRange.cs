using Domain.Entities;
using Domain.Entities.Enum;
using Domain.Interfaces.ChainResponsibility;

namespace Services.ServicesChainResponsibility
{
    public class IncomeTaxFirstRange : IncomeTaxDiscountCalculator, IIncomeTaxFirstRange
    {
        public IncomeTaxFirstRange(IIncomeTaxSecondRange higherIncomeTaxRange) : base(higherIncomeTaxRange, IncomeTax.GetIncomeTax(IncomeTaxRangeTypes.FIRST_RANGE))
        {
        }
    }
}
