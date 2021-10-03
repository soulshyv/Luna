using System;
using Microsoft.AspNetCore.Identity;

namespace Luna.Commons.Models.Identity
{
    public class LunaIdentityRole : IdentityRole<Guid>
    {
        public override Guid Id { get; set; }
        public override string Name { get; set; }
        public string DisplayName { get; set; }
    }
}