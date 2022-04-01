using System;

namespace Billing.DTOs
{
    public class CreateBillDTO
    {
        public int Id { get; set; }
        public int IdCustomer { get; set; }
        public int IdTransactionType { get; set; }
        public int NumberBill { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Iva { get; set; }
    }
}
