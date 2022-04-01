using System;

namespace Billing.DTOs
{
    public class PaymentDTO
    {
        public int Id { get; set; }
        public int IdCustomer { get; set; }
        public DateTime Date { get; set; }
        public int Value { get; set; }
        public int idBill { get; set; }
        public int TypePay { get; set; }

    }
}
