using System;

namespace Billing.DTOs
{
    public class CreateMovementProductDTO
    {
        public int Id { get; set; }
        public int IdMovementBill { get; set; }
        public int IdProduct { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public decimal UnitValue { get; set; }
        public decimal TotalValue { get; set; }
    }
}
