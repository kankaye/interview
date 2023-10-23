# Invoice and InvoiceRepository Class Function Requirements

## Objective
Implement `InvoiceRepository` classes, which provide functionalities for managing and querying a collection of invoices.

---

## Invoice Class

```csharp
	public class Invoice
	{

    public Invoice()
    {
      InvoiceItems = new List<InvoiceItem>();
    }
  	// A unique numerical identifier of an invoice (mandatory)
  	public int Id { get; set; }
  
  	// A short description of an invoice (optional)
  	public string Description { get; set; }
  
  	// A number of an invoice e.g. 134/10/2018 (mandatory)
  	public string Number { get; set; }
  
  	// An issuer of an invoice e.g. Metz-Anderson, 600 Hickman Street, Illinois (mandatory)
  	public string Seller { get; set; }
  
  	// A buyer of a service or a product e.g. John Smith, 4285 Deercove Drive, Dallas (mandatory)
  	public string Buyer { get; set; }
  
  	// A date when an invoice was issued (mandatory)
  	public DateTime CreationDate { get; set; }
  
  	// A date when an invoice was paid (optional)
  	public DateTime? AcceptanceDate { get; set; }
  
  	// A collection of invoice items for a given invoice (can be empty but is never null)
  	public IList<InvoiceItem> InvoiceItems { get; }
}
```

---
## InvoiceRepository Class

### Class Signature
```csharp
public class InvoiceRepository : IInvoiceRepository
```

### Constructor
```csharp
// Constructor
// Accepts an IQueryable<Invoice> representing the collection of invoices.
public InvoiceRepository(IQueryable<Invoice> invoices)
```

### Method 1: GetTotal
```csharp
/// <summary>
/// GetTotal Method
/// </summary>
/// <param name="invoiceId">The unique identifier of the invoice.</param>
/// <returns>Returns the total value of the invoice as a decimal?.
/// Returns null if the invoice with the given invoiceId does not exist.</returns>
public decimal? GetTotal(int invoiceId)
```

### Method 2: GetTotalOfUnpaid
```csharp
/// <summary>
/// GetTotalOfUnpaid Method
/// </summary>
/// <returns>Returns the total value of all unpaid invoices as a decimal.</returns>
public decimal GetTotalOfUnpaid()
```

### Method 3: GetItemsReport
```csharp
/// <summary>
/// GetItemsReport Method
/// </summary>
/// <param name="from">The start date of the period (can be null).</param>
/// <param name="to">The end date of the period (can be null).</param>
/// <returns>Returns a dictionary where the key is the name of the invoice item and the value is the total number of items bought within the specified time period.</returns>
public IReadOnlyDictionary<string, long> GetItemsReport(DateTime? from, DateTime? to)
```
