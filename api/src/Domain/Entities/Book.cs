using System;
using System.Collections;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Book
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Text { get; set; }
        public double PurchasePrice { get; set; }

        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}
