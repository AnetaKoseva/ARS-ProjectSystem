namespace ARS_ProjectSystem.Controllers
{
    using ARS_ProjectSystem.Data;
    using ARS_ProjectSystem.Infrastructure;
    using ARS_ProjectSystem.Models.Contracts;
    using ARS_ProjectSystem.Services.Contracts;
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;

    using static WebConstants;
    public class ContractsController: Controller
    {
        private readonly IContractService contracts;
        private readonly IMapper mapper;
        public ContractsController(IContractService contracts,
            IMapper mapper )
        {
            this.contracts = contracts;
            this.mapper = mapper;
        }
        [Authorize]

        public IActionResult All()
        {
            var contractData = this.contracts.All();

            return View(contractData);
        }

        public IActionResult AllCustomerContracts(string id)
        {
            var contractData = this.contracts.AllCustomerContracts(id);

            return View(contractData);
        }

        public IActionResult Details(int id)
        {
            var contractData = this.contracts.Details(id);

            return View(contractData);
        }

        [Authorize]
        public IActionResult CreateContract() => View();

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateContract(ContractFormModel contract, string id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var contractId = this.contracts.Create(contract, id);

            return RedirectToAction("AddBG", "Contracts", new { id = contractId });
        }

        [Authorize]
        public IActionResult AddBG(int id)
        {
            var contractModel = this.contracts.Add(id);

            return View(contractModel);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(int id)
        {
            var contract = this.contracts.Details(id);
            var contractForm = this.mapper.Map<ContractFormModel>(contract);

            return View(contractForm);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(ContractFormModel contract, int id)
        {
            var contractIsEdited = this.contracts.Edit(contract);

            if (!contractIsEdited || !User.IsAdmin())
            {
                return BadRequest();
            }

            TempData[GlobalMessageKey] = $"You contract {contract.Id} is edited!";

            return RedirectToAction(nameof(All));
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(int id)
        {
            this.contracts.Delete(id);

            return RedirectToAction("All", "Customers");
        }
    }
}
