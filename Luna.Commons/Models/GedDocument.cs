using System;

namespace Luna.Commons.Models
{
    public class GedDocument : ModelBase
    {
        public Guid PublicId { get; set; }
        public string Path { get; set; }
    }
}