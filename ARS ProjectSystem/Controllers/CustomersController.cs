namespace ARS_ProjectSystem.Controllers
{
    using ARS_ProjectSystem.Services.Customers;
    using ARS_ProjectSystem.Models.Customers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    

    using static WebConstants;
    using ARS_ProjectSystem.Infrastructure;
    using Azure.Storage.Blobs;
    using System.Linq;
    using System.Threading.Tasks;

    public class CustomersController:Controller
    {
        private readonly ICustomerService customers;
        private readonly BlobServiceClient blobService;

        public CustomersController(ICustomerService customers,
            BlobServiceClient blobService)
        {
            this.customers = customers;
            this.blobService = blobService;
        }

        public IActionResult AllLogos()
        {
            var container = this.blobService.GetBlobContainerClient("logos");

            var names = container.GetBlobs().Select(x => x.Name).ToList();
            
            this.ViewBag.Names = names;

            return View();
        }

        public FileStreamResult GetImage(string name)
        {
            var container = this.blobService.GetBlobContainerClient("logos");

            var blob = container.GetBlobClient(name);

            var image = blob.Download();

            return File(image.Value.Content, image.Value.ContentType);
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(FileInputModel fileModel)
        {
            var stream = fileModel.FormFile.OpenReadStream();
            
            var container = this.blobService.GetBlobContainerClient("logos");

            await container.UploadBlobAsync("test", stream);

            return Ok();
        }

        [Authorize]
        public IActionResult Add()=>View();

        [Authorize]
        public IActionResult All([FromQuery] AllCustomersQueryModel query)
        {
            var userId = this.User.GetId();
            if(User.IsInRole("Administrator"))
            {
                var queryResult = this.customers.All(query.SearchTerm);

                query.Customers = queryResult.Customers;

                return View(query);
            }
            else
            {
                var queryResult = this.customers.GetById(query.SearchTerm, userId);

                query.Customers = queryResult.Customers;

                return View(query);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public IActionResult Add(AddCustomerFormModel customer)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            this.customers.Add(customer);

            TempData[GlobalMessageKey] = $"Customer {customer.Name} is added succesfully!";

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        [Authorize]
        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(string id)
        {
            var customerName = this.customers.GetNameById(id);
            var customerData = this.customers.Delete(id);

            TempData[GlobalMessageKey] = $"Customer {customerName} is deleted succesfully!";
            return RedirectToAction(nameof(All));
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(string id)
        {
            var customer = this.customers.GetCustomerById(id);

            return View(customer);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(AddCustomerFormModel customer)
        {
            var customerToEdit = this.customers.Edit(customer);

            if (!customerToEdit || !User.IsAdmin())
            {
                return BadRequest();
            }

            TempData[GlobalMessageKey] = $"You customer's data {customer.Name} is edited!";

            return RedirectToAction(nameof(All));
        }
    }
}
