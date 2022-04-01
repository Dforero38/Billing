using System;
using System.Collections.Generic;

namespace Billing.DTOs
{
    public class MovementBillDTO
    {
        public int Id { get; set; }
        public int IdCustomer { get; set; }
        public int IdTransactionType { get; set; }
        public int NumberBill { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Iva { get; set; }


        public string BusinessName { get; set; }
        public int Nit { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool State { get; set; }
        public DateTime RegistrationDate { get; set; }

    }
}
