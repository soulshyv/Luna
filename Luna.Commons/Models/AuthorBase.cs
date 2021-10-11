using System;
using Luna.Commons.Models.Identity;

namespace Luna.Commons.Models
{
    public class AuthorBase
    {
        public Guid Userid { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public LunaIdentityUser Author { get; set; }
    }
}