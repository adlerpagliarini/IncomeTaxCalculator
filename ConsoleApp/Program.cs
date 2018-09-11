using ConsoleApp.DependencyInjection.ChainResponsibility;
using Domain.Entities;
using Domain.Interfaces.ChainResponsibility;
using Microsoft.Extensions.DependencyInjection;
using Services.ServicesStrategy;
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
            ServicesChainResponsibility(provider);

            Console.ReadKey();
        }

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
