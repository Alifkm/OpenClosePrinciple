namespace OpenClosePrinciple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Invoice invoice = new Invoice { Amount = 100};
            BillingService billinService = new BillingService();
            double total = billinService.CalculateTotal(invoice);
            Console.WriteLine($"Total: {total}");

            DiscountedInvoice discountedInvoice = new DiscountedInvoice { Amount = 200, Discount = 170 };
            DiscountedBillingService discountedBillingService = new DiscountedBillingService();
            double discountedTotal = discountedBillingService.CalculateTotal( discountedInvoice );
            Console.WriteLine($"Discount: {discountedTotal}");
        }
    }

    public class Invoice
    {
        public double Amount { get; set; }
    }

    public class DiscountedInvoice : Invoice // inheritence dari Invoice
    { 
        public double Discount { get; set; }
    }    

    public class BillingService
    {
        public virtual double CalculateTotal(Invoice invoice) // guna nya virtual supaya bisa dipanggil sama child nya
        {
            return invoice.Amount;
        }
    }

    public class DiscountedBillingService : BillingService // inheritence dari BillingService
    {
        public override double CalculateTotal(Invoice invoice)
        {
            if(invoice is DiscountedInvoice discountedInvoice)
            {
                return discountedInvoice.Amount - discountedInvoice.Discount;
            }

            return base.CalculateTotal(invoice);
        }
    }
}