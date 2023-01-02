using System;

namespace CASample.Domain.Common
{
    public abstract class AuditableEntity
    {
        public string Creator { get; set; }

        public DateTime CreateDate { get; set; }

        public string Modifier { get; set; }

        public DateTime? ModifyDate { get; set; }

    }
}
