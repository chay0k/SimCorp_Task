using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCorp_Task
{
    //public interface IPaymentsBuilder
    //{
    //    public decimal 
    //}

    public class LendMoney
    {
        private double _annuityRatio;
        private decimal _money;
        private double _interest;
        private double _years;
        private DateTime _agreementDate;
        private List<Payment> payments = new List<Payment>();
        public LendMoney() { }

        public LendMoney(DateTime agreementDate, decimal x, double r, double n)
        {
            if(n <= 0)
            {
                throw new ArgumentException($"{n} is an incredible number of years!");
            }
            _agreementDate = agreementDate;
            _interest = r;
            _years = n;
            _money = x;
            CalculatePayments();
        }
        public void CalculatePayments()
        {
            var numberOfPayments = _years * 12;
            var monthInterest = _interest / 12 / 100;

            _annuityRatio = monthInterest * Math.Pow(1 + monthInterest, numberOfPayments) / (Math.Pow(1 + monthInterest, numberOfPayments) - 1);
            var amountPayment = _money * (decimal)_annuityRatio;
            var balanceDebt = _money;

            for (int i = 0; i < numberOfPayments; i++)
            {
                var currentDate = _agreementDate.AddMonths(i + 1);
                var interestPayment = balanceDebt * ((decimal)_interest / 12 / 100);
                var amortization = amountPayment - interestPayment;
                balanceDebt -= amortization;
                AddPayment(currentDate, balanceDebt, amountPayment, interestPayment, amortization);
            }
        }
        private void AddPayment(DateTime date, decimal balanceDebt, decimal amountPayment, decimal interestPayment, decimal amortization)
        {
            var currentPayment = new Payment();
            currentPayment.date = date;
            currentPayment.balanceDebt = balanceDebt;
            currentPayment.amountPayment = amountPayment;
            currentPayment.interestPayment = interestPayment;
            currentPayment.amortization = amortization; 
            payments.Add(currentPayment);
        }
        public void ShowPayments(DateTime dateStart)
        {
            foreach (var payment in payments)
            {
                if (payment.date >= dateStart)
                    Console.WriteLine($"{payment.date.ToString("d")}:'\t'{payment.balanceDebt.ToString("C")},'\t'{payment.amountPayment.ToString("C")}," +
                    $"'\t'{payment.interestPayment.ToString("C")},'\t'{payment.amortization.ToString("C")}.");
            }
        }
        public void ShowPayments()
        {
            this.ShowPayments(_agreementDate);
        }
        public decimal SumOfInterestPayments(DateTime dateStart)
        {
            decimal sum = 0;
            foreach (var payment in payments)
            {
                if (payment.date >= dateStart)
                    sum += payment.interestPayment;
            }
            return sum;
        }
        public decimal SumOfInterestPayments()
        {
            return this.SumOfInterestPayments(_agreementDate);
        }
    }

    //public static class Payments
    //{

    //}
    internal struct Payment
    {
        public decimal balanceDebt;
        public decimal amountPayment;
        public decimal interestPayment;
        public decimal amortization;
        public DateTime date;
    }
}
