using System;
using System.Linq;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Food.Authorization.Users;

namespace Food.Ordering
{
    public class Order : Entity<int>, IFullAudited<User>
    {
        public OrderForm Form { get; set; }
        public Payment Payment { get; set; }
        public Basket Basket { get; set; }

        //audit
        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public User CreatorUser { get; set; }
        public User LastModifierUser { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletionTime { get; set; }
        public long? DeleterUserId { get; set; }
        public User DeleterUser { get; set; }
    }
}
