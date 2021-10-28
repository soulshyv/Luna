using System;
using Luna.Commons.Models.Identity;

namespace Luna.Commons.Models
{
    public abstract class AuthorBase
    {
        public Guid UserId { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public LunaIdentityUser Author { get; set; }
    }
}