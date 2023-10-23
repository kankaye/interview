namespace EmployementHeroTest
{

    public class InvoiceItem
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

    public class Invoice
    {
        public Invoice()
        {
            InvoiceItems = new List<InvoiceItem>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public string Number { get; set; }
        public string Seller { get; set; }
        public string Buyer { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? AcceptanceDate { get; set; }
        public IList<InvoiceItem> InvoiceItems { get; set; }
    }

    public interface IInvoiceRepository
    {
        decimal? GetTotal(int invoiceId);
        decimal GetTotalOfUnpaid();
        IReadOnlyDictionary<string, long> GetItemsReport(DateTime? from, DateTime? to);
    }


    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly IQueryable<Invoice> _invoices;

        public InvoiceRepository(IQueryable<Invoice> invoices)
        {
            _invoices = invoices;
        }

        /// <summary>
        /// GetTotal Method
        /// </summary>
        /// <param name="invoiceId">The unique identifier of the invoice.</param>
        /// <returns>Returns the total value of the invoice as a decimal?.
        /// Returns null if the invoice with the given invoiceId does not exist.</returns>
        public decimal? GetTotal(int invoiceId)
        {
            throw new NotImplementedException();

        }

        /// <summary>
        /// GetTotalOfUnpaid Method
        /// </summary>
        /// <returns>Returns the total value of all unpaid invoices as a decimal.</returns>
        public decimal GetTotalOfUnpaid()
        {
            throw new NotImplementedException();

        }

        /// <summary>
        /// GetItemsReport Method
        /// </summary>
        /// <param name="from">The start date of the period (can be null).</param>
        /// <param name="to">The end date of the period (can be null).</param>
        /// <returns>Returns a dictionary where the key is the name of the invoice item and the value is the total number of items bought within the specified time period.</returns>
        public IReadOnlyDictionary<string, long> GetItemsReport(DateTime? from, DateTime? to)
        {
            throw new NotImplementedException();
        }
    }

}
