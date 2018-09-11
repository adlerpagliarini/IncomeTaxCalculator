using Domain.Entities;
using Domain.Entities.Enum;
using Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Services.ServicesStrategy
{
    public class IncomeTaxCalculatorFactory : IIncomeTaxCalculatorFactory
    {
        public IIncomeTaxDiscountCalculator GetIncomeTaxCalculator(double salary)
        {
            if(salary <= IncomeTax.GetIncomeTax(IncomeTaxRangeTypes.EXEMPT_RANGE).MAX_VALUE)
                return GetIncomeTaxFactory(IncomeTaxRangeTypes.EXEMPT_RANGE);

            if (salary <= IncomeTax.GetIncomeTax(IncomeTaxRangeTypes.FIRST_RANGE).MAX_VALUE)
                return GetIncomeTaxFactory(IncomeTaxRangeTypes.FIRST_RANGE);

            if (salary <= IncomeTax.GetIncomeTax(IncomeTaxRangeTypes.SECOND_RANGE).MAX_VALUE)
                return GetIncomeTaxFactory(IncomeTaxRangeTypes.SECOND_RANGE);

            if (salary <= IncomeTax.GetIncomeTax(IncomeTaxRangeTypes.THIRD_RANGE).MAX_VALUE)
                return GetIncomeTaxFactory(IncomeTaxRangeTypes.THIRD_RANGE);
            else
                throw new NotImplementedException();
        }

        public IIncomeTaxDiscountCalculator GetIncomeTaxFactory(IncomeTaxRangeTypes incomeTaxRangeTypes)
        {
            switch (incomeTaxRangeTypes)
            {
                case IncomeTaxRangeTypes.EXEMPT_RANGE:
                    return new IncomeTaxExemptRange();
                case IncomeTaxRangeTypes.FIRST_RANGE:
                    return new IncomeTaxFirstRange();
                case IncomeTaxRangeTypes.SECOND_RANGE:
                    return new IncomeTaxSecondRange();
                case IncomeTaxRangeTypes.THIRD_RANGE:
                    return new IncomeTaxThirdRange();
                default:
                    throw new KeyNotFoundException();
            }
        }
    }
}
