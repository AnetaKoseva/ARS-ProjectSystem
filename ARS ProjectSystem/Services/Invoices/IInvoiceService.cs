namespace ARS_ProjectSystem.Services.Invoices
{
    using ARS_ProjectSystem.Data.Models;
    using ARS_ProjectSystem.Models.Invoices;
    using System.Collections.Generic;

    public interface IInvoiceService
    {
         IEnumerable<InvoiceServiceModel> All();

         IEnumerable<InvoiceServiceModel> AllCustomerInvoices(string id);

        InvoiceFormModel Details(int id);

         InvoiceFormModel Add(int id);

        int Create(InvoiceFormModel invoice,string id);

        int CreateContractInvoice(int id);

        int CreateAdvanceInvoice(int id);

        bool Edit(InvoiceFormModel invoice);

         int Delete(int id);

    }
}
