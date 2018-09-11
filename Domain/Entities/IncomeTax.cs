using Domain.Entities.Constants;
using Domain.Entities.Enum;
using System.Collections.Generic;
using System.Reflection;

namespace Domain.Entities
{
    public class IncomeTax
    {
        public readonly IncomeTaxRangeTypes TYPE;
        public readonly double MAX_VALUE;
        public readonly double DISCOUNT;

        internal IncomeTax(IncomeTaxRangeTypes type, double max_value, double discount)
        {
            TYPE = type;
            MAX_VALUE = max_value;
            DISCOUNT = discount;
        }

        public static IncomeTax GetIncomeTax(IncomeTaxRangeTypes incomeTaxRangeType)
        {
            string property_name = incomeTaxRangeType.ToString();

            //Get the property inside IncomeTaxRangeConstants by a string Name
            var property = (typeof(IncomeTaxRangeConstants)).GetProperty(property_name, BindingFlags.NonPublic | BindingFlags.Static);

            //Get values from property
            var values = (Dictionary<IncomeTaxRangeTypes, IncomeTax>)property.GetValue(null, null);

            values.TryGetValue(incomeTaxRangeType, out IncomeTax result);
            return result;
        }
    }
}
