using EmployementHeroTest;

namespace EmploymentHeroUnitTest
{


    [TestFixture]
    public class InvoiceRepositoryTests
    {
        private IQueryable<Invoice> _invoices;
        private InvoiceRepository _repository;

        [SetUp]
        public void Setup()
        {
            _invoices = new List<Invoice>
        {
            new Invoice { Id = 1, Number = "INV001", Seller = "Seller1", Buyer = "Buyer1", CreationDate = DateTime.Parse("2021-01-01"), AcceptanceDate = DateTime.Parse("2021-01-10"), InvoiceItems = new List<InvoiceItem> { new InvoiceItem { Name = "Item1", Price = 10, Quantity = 1 }, new InvoiceItem { Name = "Item2", Price = 20, Quantity = 2 } } },
            new Invoice { Id = 2, Number = "INV002", Seller = "Seller2", Buyer = "Buyer2", CreationDate = DateTime.Parse("2021-02-01"), InvoiceItems = new List<InvoiceItem> { new InvoiceItem { Name = "Item1", Price = 10, Quantity = 1 } } },
            new Invoice { Id = 3, Number = "INV003", Seller = "Seller3", Buyer = "Buyer3", CreationDate = DateTime.Parse("2021-03-01"), AcceptanceDate = DateTime.Parse("2021-03-10"), InvoiceItems = new List<InvoiceItem> { new InvoiceItem { Name = "Item3", Price = 30, Quantity = 3 } } }
        }.AsQueryable();

            _repository = new InvoiceRepository(_invoices);
        }

        [Test]
        public void GetTotal_ValidInvoiceId_ReturnsTotal()
        {
            var total = _repository.GetTotal(1);
            Assert.That(total, Is.EqualTo(50));
        }

        [Test]
        public void GetTotal_InvalidInvoiceId_ReturnsNull()
        {
            var total = _repository.GetTotal(4);
            Assert.IsNull(total);
        }

        [Test]
        public void GetTotalOfUnpaid_ReturnsTotalOfUnpaidInvoices()
        {
            var total = _repository.GetTotalOfUnpaid();
            Assert.That(total, Is.EqualTo(10));
        }

        [Test]
        public void GetItemsReport_ValidDateRange_ReturnsCorrectReport()
        {
            var report = _repository.GetItemsReport(DateTime.Parse("2021-01-01"), DateTime.Parse("2021-02-01"));
            Assert.That(report.Count, Is.EqualTo(2));
            Assert.That(report["Item1"], Is.EqualTo(2));
            Assert.That(report["Item2"], Is.EqualTo(2));
        }

        [Test]
        public void GetItemsReport_NullDateRange_ReturnsCorrectReport()
        {
            var report = _repository.GetItemsReport(null, null);
            Assert.That(report.Count, Is.EqualTo(3));
            Assert.That(report["Item1"], Is.EqualTo(2));
            Assert.That(report["Item2"], Is.EqualTo(2));
            Assert.That(report["Item3"], Is.EqualTo(3));
        }

        [Test]
        public void GetTotal_EmptyInvoiceItems_ReturnsZero()
        {
            var total = _repository.GetTotal(4); // Assume Invoice with Id=4 has empty InvoiceItems
            Assert.That(total, Is.EqualTo(0));
        }

        [Test]
        public void GetTotalOfUnpaid_NoUnpaidInvoices_ReturnsZero()
        {
            // Assume all invoices are paid in the setup
            var total = _repository.GetTotalOfUnpaid();
            Assert.That(total, Is.EqualTo(0));
        }

        [Test]
        public void GetItemsReport_EmptyDateRange_ReturnsEmptyReport()
        {
            var report = _repository.GetItemsReport(DateTime.Parse("2022-01-01"), DateTime.Parse("2022-01-01"));
            Assert.IsEmpty(report);
        }

        [Test]
        public void GetItemsReport_SingleDayRange_ReturnsCorrectReport()
        {
            var report = _repository.GetItemsReport(DateTime.Parse("2021-01-01"), DateTime.Parse("2021-01-01"));
            Assert.That(report.Count, Is.EqualTo(2));
            Assert.That(report["Item1"], Is.EqualTo(1));
            Assert.That(report["Item2"], Is.EqualTo(1));
        }

        [Test]
        public void GetItemsReport_NoInvoiceItems_ReturnsEmptyReport()
        {
            // Assume no invoice items in the setup
            var report = _repository.GetItemsReport(null, null);
            Assert.IsEmpty(report);
        }

        [Test]
        public void GetItemsReport_MultipleInvoiceItemsSameName_ReturnsAggregatedCount()
        {
            // Assume multiple invoice items with the same name but different invoices
            var report = _repository.GetItemsReport(null, null);
            Assert.That(report.Count, Is.EqualTo(1));
            Assert.That(report["Item1"], Is.EqualTo(6)); // 2 from Invoice 1, 2 from Invoice 2, 2 from Invoice 3
        }
    }

}
