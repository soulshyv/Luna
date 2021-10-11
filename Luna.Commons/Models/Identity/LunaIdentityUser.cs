using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Luna.Commons.Models.Identity
{
    public class LunaIdentityUser : IdentityUser<Guid>
    {
        public override Guid Id { get; set; }
        public override string UserName { get; set; }
        public override string Email { get; set; }
        public override bool EmailConfirmed { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public override string SecurityStamp { get; set; }
        public override string PhoneNumber { get; set; }
        public override bool PhoneNumberConfirmed { get; set; }
        public override bool TwoFactorEnabled { get; set; }
        public override DateTimeOffset? LockoutEnd { get; set; }
        public override bool LockoutEnabled { get; set; }
        public override int AccessFailedCount { get; set; }
        
        public virtual IList<Character> Characters { get; set; }
        public virtual IList<CharacterType> CharacterTypes { get; set; }
        public virtual IList<CustomSection> CustomSections { get; set; }
        public virtual IList<CustomProperty> CustomProperties { get; set; }
        public virtual IList<CustomPropertyType> CustomPropertieTypes { get; set; }
        public virtual IList<GedDocument> GedDocuments { get; set; }
        public virtual IList<Race> Races { get; set; }
    }
}