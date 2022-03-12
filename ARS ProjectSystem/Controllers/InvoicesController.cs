namespace ARS_ProjectSystem.Controllers
{
    using ARS_ProjectSystem.Data;
    using ARS_ProjectSystem.Infrastructure;
    using ARS_ProjectSystem.Models.Invoices;
    using ARS_ProjectSystem.Services.Invoices;
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using static WebConstants;
    public class InvoicesController : Controller
    {
        private readonly IInvoiceService invoices;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment environment;
        public InvoicesController(IInvoiceService invoices,
            IMapper mapper, 
            IWebHostEnvironment environment)
        {
            this.invoices = invoices;
            this.mapper = mapper;
            this.environment = environment;
        }
        [Authorize]
        
        public IActionResult All()
        {
            var invoiceData = this.invoices.All();

            return View(invoiceData);
        }

        public IActionResult AllCustomerInvoices(string id)
        {
            var invoiceData = this.invoices.AllCustomerInvoices(id);

            return View(invoiceData);
        }

        public IActionResult Details(int id)
        {
            var invoiceData = this.invoices.Details(id);

            return View(invoiceData);
        }

        [Authorize]
        public IActionResult CreateInvoice() => View();

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateInvoice(InvoiceFormModel invoice,string id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var invoiceid = this.invoices.Create(invoice,id);

            return RedirectToAction("Add", "Invoices",new {id=invoiceid }, $"{this.environment.WebRootPath}/images");
        }
        public IActionResult CreateContractInvoice( int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var invoiceid = this.invoices.CreateContractInvoice(id);

            return RedirectToAction("Add", "Invoices", new { id = invoiceid }, $"{this.environment.WebRootPath}/images");
        }
        public IActionResult CreateAdvanceInvoice(int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var invoiceid = this.invoices.CreateAdvanceInvoice(id);

            return RedirectToAction("Add", "Invoices", new { id = invoiceid }, $"{this.environment.WebRootPath}/images");
        }

        [Authorize]
        public IActionResult Add(int id)
        {
            var invoiceModel = this.invoices.Add(id);

            return View(invoiceModel);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(int id)
        {
            var invoice = this.invoices.Details(id);
            var invoiceForm = this.mapper.Map<InvoiceFormModel>(invoice);

            return View(invoiceForm);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(InvoiceFormModel invoice,int id)
        {
            var invoiceIsEdited = this.invoices.Edit(invoice);

            if (!invoiceIsEdited || !User.IsAdmin())
            {
                return BadRequest();
            }

            TempData[GlobalMessageKey] = $"You invoice {invoice.Id} is edited!";

            return RedirectToAction(nameof(All));
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(int id)
        {
             this.invoices.Delete(id);

            return RedirectToAction("All","Customers");
        }

    }
}
