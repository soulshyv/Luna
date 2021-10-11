using System.ComponentModel.DataAnnotations;
using Luna.Commons.Models;

namespace Luna.ViewModels
{
    public class EntityViewModel
    {
        public int? Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Description { get; set; }

        public EntityViewModel()
        {
        }

        public EntityViewModel(ModelBase mb)
        {
            Id = mb.Id;
            Name = mb.Name;
            Description = mb.Description;
        }
    }
}