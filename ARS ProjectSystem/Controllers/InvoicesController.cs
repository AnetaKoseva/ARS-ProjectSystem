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

    using System.Linq;

    using static WebConstants;
    public class InvoicesController : Controller
    {
        private readonly ProjectSystemDbContext data;
        private readonly IInvoiceService invoices;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment environment;
        public InvoicesController(ProjectSystemDbContext data, IInvoiceService invoices, IMapper mapper, IWebHostEnvironment environment)
        {
            this.data = data;
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

        [Authorize]
        public IActionResult CreateInvoice() => View();

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateInvoice(InvoiceFormModel invoice,string id)
        {
            var userId = this.User.GetId();
            var userNumber = this.data.Users.Where(x => x.Number == id);
            
            var customer = this.data.Customers.FirstOrDefault(c => c.RegistrationNumber == id);
            
                if (!ModelState.IsValid)
            {
                return View();
            }
            var invoiceid = this.invoices.Create(invoice,customer);

            return RedirectToAction("Add", "Invoices",new {id=invoiceid }, $"{this.environment.WebRootPath}/images");
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
