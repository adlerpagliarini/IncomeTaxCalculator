using ConsoleApp.DependencyInjection.ChainResponsibility;
using Domain.Entities;
using Domain.Interfaces.ChainResponsibility;
using Microsoft.Extensions.DependencyInjection;
using Services.ServicesStrategy;
using Services.ServicesStrategyAttributesReflection;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            services.AddChainResponsibilityDI();
            var provider = services.BuildServiceProvider();

            ServicesFactory();
            ServicesAttributesFactory();
            ServicesChainResponsibility(provider);

            Console.ReadKey();
        }

        #region ServicesFactory
        private static void ServicesFactory()
        {
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            Console.WriteLine("Switching class calculator with a Factory");
            Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");

            IncomeTaxCalculatorFactory incomeTaxCalculatorFactory = new IncomeTaxCalculatorFactory();

            double salary = 1000;
            var result = incomeTaxCalculatorFactory.GetIncomeTaxCalculator(salary).CalculateIncomeTaxFromSalary(salary);
            ConsoleWrite(result);

            salary = 2000;
            result = incomeTaxCalculatorFactory.GetIncomeTaxCalculator(salary).CalculateIncomeTaxFromSalary(salary);
            ConsoleWrite(result);

            salary = 3000;
            result = incomeTaxCalculatorFactory.GetIncomeTaxCalculator(salary).CalculateIncomeTaxFromSalary(salary);
            ConsoleWrite(result);

            salary = 4000;
            result = incomeTaxCalculatorFactory.GetIncomeTaxCalculator(salary).CalculateIncomeTaxFromSalary(salary);
            ConsoleWrite(result);
        }
        #endregion

        #region ServicesChainResponsibility
        private static void ServicesChainResponsibility(ServiceProvider provider)
        {
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            Console.WriteLine("Finding the class calculator with a Chain Responsibility");
            Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");

            var incomeTaxCalculator = provider.GetService<IIncomeTaxExemptRange>();

            double salary = 1000;
            var result = incomeTaxCalculator.CalculateIncomeTaxFromSalary(salary);
            ConsoleWrite(result);

            salary = 2000;
            result = incomeTaxCalculator.CalculateIncomeTaxFromSalary(salary);
            ConsoleWrite(result);

            salary = 3000;
            result = incomeTaxCalculator.CalculateIncomeTaxFromSalary(salary);
            ConsoleWrite(result);

            salary = 4000;
            result = incomeTaxCalculator.CalculateIncomeTaxFromSalary(salary);
            ConsoleWrite(result);
        }
        #endregion

        #region ServicesAttributesFactory
        private static void ServicesAttributesFactory()
        {
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            Console.WriteLine("Switching class calculator with Reflection");
            Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");

            IncomeTaxFactory incomeTaxCalculatorFactory = new IncomeTaxFactory();

            double salary = 1000; //using if statements to return the right Implementation of this range
            var result = incomeTaxCalculatorFactory.GetIncomeTaxCalculator(salary).CalculateIncomeTaxFromSalary(salary);
            ConsoleWrite(result);

            //using reflections to find the right Implementation of this range
            salary = 2000;
            result = incomeTaxCalculatorFactory.GetIncomeTaxFactory(salary).CalculateIncomeTaxFromSalary(salary);
            result = incomeTaxCalculatorFactory.GetIncomeTaxFactory(salary).CalculateIncomeTaxFromSalary(salary);
            ConsoleWrite(result);

            salary = 3000;
            result = incomeTaxCalculatorFactory.GetIncomeTaxFactory(salary).CalculateIncomeTaxFromSalary(salary);
            ConsoleWrite(result);

            salary = 4000;
            result = incomeTaxCalculatorFactory.GetIncomeTaxFactory(salary).CalculateIncomeTaxFromSalary(salary);
            ConsoleWrite(result);
        }
        #endregion

        private static void ConsoleWrite(Discount discount)
        {
            Console.WriteLine("");
            Console.WriteLine("Type: {0}, MaxValue: {1}, DiscountRate: {2}", discount.IncomeTax.TYPE.ToString(),
                                                                             discount.IncomeTax.MAX_VALUE,
                                                                             discount.IncomeTax.DISCOUNT);
            Console.WriteLine("Salary: {0}, NetSalary: {1}, IncomeTax: {2}", discount.Salary,
                                                                             discount.NetSalary,
                                                                             discount.Discounted);
            Console.WriteLine("---------------------------------------------------------------------");
        }

    }
}
