using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreriaConsola.domain;

namespace LibreriaConsola.data
{
    internal class InvoiceRepository : IRepository<Invoice, int>
    {

        Invoice_DetailsRepository InvoiceDetailsRepo;

        public InvoiceRepository()
        {
            InvoiceDetailsRepo = new Invoice_DetailsRepository();
        }

        public bool Delete(int entity)
        {
            throw new NotImplementedException();
        }

        public List<Invoice>? GetAll()
        {
            List<Invoice> invoices = new List<Invoice>();
            
            foreach (DataRow row in DataHelper.GetInstance().ExecuteSPRead("OBTENER_FACTURAS").Rows)
            {
                invoices.Add(new Invoice()
                {
                    Number = Convert.ToInt32(row["nro_factura"]),
                    Date = Convert.ToDateTime(row["fecha"]),
                    Client = (string)row["cliente"],
                    Payment_Method = new Payment_Method()
                    {
                        Id = Convert.ToInt32(row["id_forma_pago"]),
                        Description = (string)row["forma_pago"]
                    },
                    ListDetails = InvoiceDetailsRepo.GetAll(Convert.ToInt32(row["nro_factura"]))
                });
            }

            return invoices;
        }

        public Invoice? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(Invoice i)
        {
            List<Parameter> p = new List<Parameter>();

            Parameter param = new Parameter("@nro_factura", i.Number, true);
            p.Add(param);
            p.Add(new Parameter("@fecha", i.Date));
            p.Add(new Parameter("@id_forma_pago", i.Payment_Method.Id));
            p.Add(new Parameter("@cliente", i.Client));

            bool result = DataHelper.GetInstance().ExecuteSPModify("MODIFICAR_FACTURAS", p) > 0;

            if (result)
            {
                DataTable dt = DataHelper.GetInstance().ExecuteSPRead("OBTENER_ULTIMA_FACTURA");

                i.Number = Convert.ToInt32(dt.Rows[0][0]);
            }

            return result;
        }
    }
}
