using System;

namespace Luna.Commons.Models.Dtos
{
    public abstract class ModelBaseDto<TModel> where TModel : ModelBase, new()
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        protected ModelBaseDto()
        {
        }

        protected ModelBaseDto(TModel entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.Description;
        }

        public virtual TModel ToModel(Guid userId)
        {
            var entity = new TModel
            {
                Name = Name,
                Description = Description,
                Modified = DateTime.Now,
                UserId = userId
            };

            if (Id.HasValue)
            {
                entity.Id = Id.Value;
            }
            else
            {
                entity.Created = DateTime.Now;
            }

            return entity;
        }
    }
}