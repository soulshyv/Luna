using System.Collections.Generic;
using Luna.Commons.Enums;
using Luna.Commons.Models;

namespace Luna.ViewModels
{
    public class EntityListViewModel
    {
        public EntityTypeEnum Type { get; set; }
        public IEnumerable<ModelBase> Entities { get; set; }
    }
}