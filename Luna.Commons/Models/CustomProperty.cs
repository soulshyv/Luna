namespace Luna.Commons.Models
{
    public class CustomProperty : ModelBase
    {
        public virtual int CustomSectionId { get; set; }
        public virtual int TypeId { get; set; }
        public virtual int RaceId { get; set; }
        
        public virtual int Valeur { get; set; }
        public virtual int? ValeurMax { get; set; }
        public string Unite { get; set; }

        public virtual CustomPropertyType Type { get; set; }
        public virtual CustomSection CustomSection { get; set; }
        public virtual Race Race { get; set; }
    }
}