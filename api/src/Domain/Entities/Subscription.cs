using Domain.Auth;
using System;

namespace Domain.Entities
{
    public class Subscription
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }
        public Guid BookId { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Book Book { get; set; }
    }
}
