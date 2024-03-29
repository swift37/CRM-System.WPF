﻿using CRM.DAL.Entities.Base;
using CRM.Interfaces;

namespace CRM.DAL.Entities
{
    public class OrderDetails : Entity, IArchivable
    {
        public int OrderId { get; set; }
        
        public virtual Order? Order { get; set; }

        public int ProductId { get; set; }

        public virtual Product? Product { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public decimal Discount { get; set; }

        public bool IsActual { get; set; } = true;
    }
}
