using Domain.Entities;
using Domain.Entities.Enum;
using Domain.Interfaces;
using Domain.Interfaces.StrategyAttributesReflection;
using System;
using System.Linq;

namespace Services.ServicesStrategyAttributesReflection
{
    public class IncomeTaxFactory
    {
        public IIncomeTaxDiscountCalculator GetIncomeTaxCalculator(double salary)
        {
            if(salary <= IncomeTax.GetIncomeTax(IncomeTaxRangeTypes.EXEMPT_RANGE).MAX_VALUE)
                return GetIncomeTaxFactory(new ExemptRange());

            if (salary <= IncomeTax.GetIncomeTax(IncomeTaxRangeTypes.FIRST_RANGE).MAX_VALUE)
                return GetIncomeTaxFactory(new FirstRange());

            if (salary <= IncomeTax.GetIncomeTax(IncomeTaxRangeTypes.SECOND_RANGE).MAX_VALUE)
                return GetIncomeTaxFactory(new SecondRange());

            if (salary <= IncomeTax.GetIncomeTax(IncomeTaxRangeTypes.THIRD_RANGE).MAX_VALUE)
                return GetIncomeTaxFactory(new ThirdRange());
            else
                throw new NotImplementedException();
        }

        private IIncomeTaxDiscountCalculator GetIncomeTaxFactory(IIncomeTaxRange incomeTaxRange)
        {
            var calculator = incomeTaxRange.GetType().GetCustomAttributes(typeof(IncomeTaxFactoryType), true).First()
                as IncomeTaxFactoryType;

            object[] parms = new object[] { calculator.GetIncomeTaxRange };
            return (IIncomeTaxDiscountCalculator)Activator.CreateInstance(calculator.GetFactoryType, parms);
        }


        //Removing IF statements from GetIncomeTaxCalculator with Reflections
        public IIncomeTaxDiscountCalculator GetIncomeTaxFactory(double salary)
        {
            var _incomeTaxRange = typeof(IIncomeTaxRange);
            var classImplementations = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => _incomeTaxRange.IsAssignableFrom(p) && !p.IsInterface);

            foreach (var i in classImplementations)
            {
                var baseImplementation = (IIncomeTaxRange) Activator.CreateInstance(i);

                var calculator = baseImplementation.GetType()
                                .GetCustomAttributes(typeof(IncomeTaxFactoryType), true)
                                .First()
                                    as IncomeTaxFactoryType;

                if (salary <= calculator.GetIncomeTaxRange.MAX_VALUE)
                {
                    object[] parms = new object[] { calculator.GetIncomeTaxRange as IncomeTax };
                    return (IIncomeTaxDiscountCalculator)Activator.CreateInstance(calculator.GetFactoryType, parms);
                }
            }
            throw new NotImplementedException();
        }
    }
}
