namespace Luna.Commons.Models
{
    public class CustomPropertyHasCustomField : AuthorBase
    {
        public virtual int Id { get; set; }

        public virtual string Valeur { get; set; }
        
        public virtual int PropertyId { get; set; }
        public virtual int FieldId { get; set; }

        public virtual CustomProperty CustomProperty { get; set; }
        public virtual CustomField CustomField { get; set; }
    }
}