using Domain.Entities;
using Domain.Entities.Enum;
using Domain.Interfaces.ChainResponsibility;

namespace Services.ServicesChainResponsibility
{
    public class IncomeTaxSecondRange : IncomeTaxDiscountCalculator, IIncomeTaxSecondRange
    {
        public IncomeTaxSecondRange(IIncomeTaxThirdRange higherIncomeTaxRange) : base(higherIncomeTaxRange, IncomeTax.GetIncomeTax(IncomeTaxRangeTypes.SECOND_RANGE))
        {
        }
    }
}
