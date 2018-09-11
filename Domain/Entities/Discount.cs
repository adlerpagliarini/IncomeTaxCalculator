namespace Domain.Entities
{
    public class Discount
    {
        public IncomeTax IncomeTax { get; private set; }
        public double Salary { get; private set; }
        public double NetSalary { get; private set; }
        public double Discounted { get; private set; }

        public Discount(IncomeTax incomeTax, double salary, double netSalary, double discounted)
        {
            IncomeTax = incomeTax;
            Salary = salary;
            NetSalary = netSalary;
            Discounted = discounted;
        }
    }
}
