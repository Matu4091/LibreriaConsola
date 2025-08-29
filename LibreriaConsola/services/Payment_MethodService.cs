using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreriaConsola.data;
using LibreriaConsola.domain;

namespace LibreriaConsola.services
{
    internal class Payment_MethodService
    {

        private IRepository<Payment_Method, int> PaymentMethodRepo;

        public Payment_MethodService()
        {
            PaymentMethodRepo = new Payment_MethodRepository();
        }

        public List<Payment_Method>? BringPaymentMethods()
        {
            return PaymentMethodRepo.GetAll();
        }
    }
}
