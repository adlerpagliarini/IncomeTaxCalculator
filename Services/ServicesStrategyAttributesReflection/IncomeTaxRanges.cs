using Domain.Entities;
using Domain.Entities.Enum;
using Domain.Interfaces.StrategyAttributesReflection;
using System;

namespace Services.ServicesStrategyAttributesReflection
{
    [IncomeTaxFactoryType(typeof(IncomeTaxExemptRange), IncomeTaxRangeTypes.EXEMPT_RANGE)]
    public sealed class ExemptRange : IIncomeTaxRange
    {
        public Func<IncomeTaxRangeTypes, IncomeTax> GetIncomeType = (parm) => IncomeTax.GetIncomeTax(parm);
    }

    [IncomeTaxFactoryType(typeof(IncomeTaxFirstRange), IncomeTaxRangeTypes.FIRST_RANGE)]
    public sealed class FirstRange : IIncomeTaxRange
    {
    }

    [IncomeTaxFactoryType(typeof(IncomeTaxSecondRange), IncomeTaxRangeTypes.SECOND_RANGE)]
    public sealed class SecondRange : IIncomeTaxRange
    {
    }

    [IncomeTaxFactoryType(typeof(IncomeTaxThirdRange), IncomeTaxRangeTypes.THIRD_RANGE)]
    public sealed class ThirdRange : IIncomeTaxRange
    {
    }
}
