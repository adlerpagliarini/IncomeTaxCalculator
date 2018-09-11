using Domain.Entities.Enum;
using System.Collections.Generic;

namespace Domain.Entities.Constants
{
    internal static class IncomeTaxRangeConstants
    {
        private static Dictionary<IncomeTaxRangeTypes, IncomeTax> EXEMPT_RANGE
        {
            get
            {
                return new Dictionary<IncomeTaxRangeTypes, IncomeTax>() {
                    {
                        IncomeTaxRangeTypes.EXEMPT_RANGE,
                                            new IncomeTax(IncomeTaxRangeTypes.EXEMPT_RANGE, 1000, 0)
                    }
                };
            }
        }

        private static Dictionary<IncomeTaxRangeTypes, IncomeTax> FIRST_RANGE
        {
            get
            {
                return new Dictionary<IncomeTaxRangeTypes, IncomeTax>() {
                    {
                        IncomeTaxRangeTypes.FIRST_RANGE,
                                            new IncomeTax(IncomeTaxRangeTypes.FIRST_RANGE, 2000, (10.00/100))
                    }
                };
            }
        }

        private static Dictionary<IncomeTaxRangeTypes, IncomeTax> SECOND_RANGE
        {
            get
            {
                return new Dictionary<IncomeTaxRangeTypes, IncomeTax>() {
                    {
                        IncomeTaxRangeTypes.SECOND_RANGE,
                                            new IncomeTax(IncomeTaxRangeTypes.SECOND_RANGE, 3000, (15.00/100))
                    }
                };
            }
        }

        private static Dictionary<IncomeTaxRangeTypes, IncomeTax> THIRD_RANGE
        {
            get
            {
                return new Dictionary<IncomeTaxRangeTypes, IncomeTax>() {
                    {
                        IncomeTaxRangeTypes.THIRD_RANGE, new IncomeTax(IncomeTaxRangeTypes.THIRD_RANGE, double.MaxValue, (20.00/100))
                    }
                };
            }
        }

        /*public static class THIRD_RANGE
        {
            public const double MAX_VALUE = 3000.00;
            public const double DISCOUNT = (30) / 100;
        }*/
    }
}
