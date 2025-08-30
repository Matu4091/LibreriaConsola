using LibreriaConsola.data;
using LibreriaConsola.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaConsola.services
{
    internal class UnitOfWork
    {
        private InvoiceRepository invoiceRepo;
        private Invoice_DetailsRepository invoiceDetailsRepo;

        public UnitOfWork()
        {
            invoiceRepo = new InvoiceRepository();
            invoiceDetailsRepo = new Invoice_DetailsRepository();
        }

        public bool SaveInvoiceWithDetails(Invoice i)
        {
            if (!invoiceRepo.Save(i)) { return false; }

            if (i.ListDetails != null && i.ListDetails.Count > 0)
            {
                foreach (Invoice_Details detail in i.ListDetails)
                {
                    detail.Invoice_Number = i.Number;
                }
                if (i.ListDetails != null && i.ListDetails.Count > 0)
                {
                    return invoiceDetailsRepo.Save(i.ListDetails);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        public List<Invoice>? BringAllInvoices()
        {
            return invoiceRepo.GetAll();
        }

        public bool DeleteInvoiceWithDetails(Invoice i)
        {
            return invoiceRepo.Delete(i.Number);
        }
    }
}
