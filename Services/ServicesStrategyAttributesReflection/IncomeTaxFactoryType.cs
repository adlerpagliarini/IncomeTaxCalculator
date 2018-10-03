using Domain.Entities;
using Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.ServicesStrategyAttributesReflection
{
    public class IncomeTaxFactoryType : Attribute
    {
        private readonly IncomeTaxRangeTypes IncomeTaxType;

        public IncomeTaxFactoryType(Type type, IncomeTaxRangeTypes incomeTaxType)
        {
            GetFactoryType = type;
            IncomeTaxType = incomeTaxType;
        }

        public Type GetFactoryType { get; }
        public IncomeTax GetIncomeTaxRange { get { return IncomeTax.GetIncomeTax(IncomeTaxType); } }
    }
}
