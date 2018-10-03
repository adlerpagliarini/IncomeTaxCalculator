using Domain.Entities;
using Domain.Entities.Enum;
using Domain.Interfaces;

namespace Services.ServicesStrategyAttributesReflection
{ 
    public class IncomeTaxExemptRange : IncomeTaxDiscountCalculator, IIncomeTaxDiscountCalculator
    {  
        public IncomeTaxExemptRange(IncomeTax incomeTax) : base(incomeTax) { }        

        public new Discount CalculateIncomeTaxFromSalary(double salary)
        {
            return base.CalculateIncomeTaxFromSalary(salary);
        }
    }
}
