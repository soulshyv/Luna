using Microsoft.EntityFrameworkCore;

namespace Luna.Commons.Models
{
    // https://docs.microsoft.com/fr-fr/ef/core/cli/dotnet
    
    public partial class LunaDbContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<CharacterType> CharacterTypes { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<CustomSection> CustomSections { get; set; }
        public DbSet<CustomProperty> CustomProperties { get; set; }
        public DbSet<CustomPropertyType> CustomPropertyTypes { get; set; }
        public DbSet<CustomField> CustomFields { get; set; }
        public DbSet<CustomPropertyHasCustomField> CustomPropertyHasCustomFields { get; set; }

        // public LunaDbContext()
        // {
        // }

        public LunaDbContext(DbContextOptions<LunaDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CharacterMapping(modelBuilder);
            CharacterTypeMapping(modelBuilder);
            RaceMapping(modelBuilder);
            CustomSectionMapping(modelBuilder);
            CustomPropertyMapping(modelBuilder);
            CustomPropertyTypeMapping(modelBuilder);
            CustomFieldMapping(modelBuilder);
            CustomPropertyHasCustomFieldMapping(modelBuilder);

            CustomizeMapping(ref modelBuilder);

            RelationshipsMapping(modelBuilder);
        }

        private void CharacterMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>().ToTable("luna_rpg_character");
            modelBuilder.Entity<Character>().Property(_ => _.Id).HasColumnName("id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Character>().Property(_ => _.Name).HasColumnName("nom").HasColumnType("varchar(255)").IsRequired();
            modelBuilder.Entity<Character>().Property(_ => _.Description).HasColumnName("description").HasColumnType("blob");
            modelBuilder.Entity<Character>().Property(_ => _.TypeId).HasColumnName("type_id").HasColumnType("int");
            modelBuilder.Entity<Character>().Property(_ => _.RaceId).HasColumnName("race_id").HasColumnType("int");
            modelBuilder.Entity<Character>().Property(_ => _.Created).HasColumnName("created").HasColumnType("datetime");
            modelBuilder.Entity<Character>().Property(_ => _.Modified).HasColumnName("modified").HasColumnType("datetime");
            modelBuilder.Entity<Character>().Property(_ => _.UserId).HasColumnName("user_id").HasColumnType("char(36)");
            
            modelBuilder.Entity<Character>().HasKey(_ => _.Id);
        }

        private void CustomSectionMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomSection>().ToTable("luna_rpg_custom_section");
            modelBuilder.Entity<CustomSection>().Property(_ => _.Id).HasColumnName("id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<CustomSection>().Property(_ => _.Name).HasColumnName("nom").HasColumnType("varchar(255)").IsRequired();
            modelBuilder.Entity<CustomSection>().Property(_ => _.Description).HasColumnName("description").HasColumnType("blob");
            modelBuilder.Entity<CustomSection>().Property(_ => _.CharacterId).HasColumnName("character_id").HasColumnType("int");
            modelBuilder.Entity<CustomSection>().Property(_ => _.Created).HasColumnName("created").HasColumnType("datetime");
            modelBuilder.Entity<CustomSection>().Property(_ => _.Modified).HasColumnName("modified").HasColumnType("datetime");
            modelBuilder.Entity<CustomSection>().Property(_ => _.UserId).HasColumnName("user_id").HasColumnType("char(36)");
            
            modelBuilder.Entity<CustomProperty>().HasKey(_ => _.Id);
        }

        private void CustomPropertyMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomProperty>().ToTable("luna_rpg_custom_property");
            modelBuilder.Entity<CustomProperty>().Property(_ => _.Id).HasColumnName("id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<CustomProperty>().Property(_ => _.Name).HasColumnName("nom").HasColumnType("varchar(255)").IsRequired();
            modelBuilder.Entity<CustomProperty>().Property(_ => _.Description).HasColumnName("description").HasColumnType("blob");
            modelBuilder.Entity<CustomProperty>().Property(_ => _.CustomSectionId).HasColumnName("section_id").HasColumnType("int");
            modelBuilder.Entity<CustomProperty>().Property(_ => _.TypeId).HasColumnName("type_id").HasColumnType("int").IsRequired();
            modelBuilder.Entity<CustomProperty>().Property(_ => _.RaceId).HasColumnName("race_id").HasColumnType("int").IsRequired(false);
            modelBuilder.Entity<CustomProperty>().Property(_ => _.Created).HasColumnName("created").HasColumnType("datetime");
            modelBuilder.Entity<CustomProperty>().Property(_ => _.Modified).HasColumnName("modified").HasColumnType("datetime");
            modelBuilder.Entity<CustomProperty>().Property(_ => _.UserId).HasColumnName("user_id").HasColumnType("char(36)");
            
            modelBuilder.Entity<CustomProperty>().HasKey(_ => _.Id);
        }

        private void RaceMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Race>().ToTable("luna_rpg_race");
            modelBuilder.Entity<Race>().Property(_ => _.Id).HasColumnName("id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Race>().Property(_ => _.Name).HasColumnName("nom").HasColumnType("varchar(255)").IsRequired();
            modelBuilder.Entity<Race>().Property(_ => _.Description).HasColumnName("description").HasColumnType("blob");
            modelBuilder.Entity<Race>().Property(_ => _.Created).HasColumnName("created").HasColumnType("datetime");
            modelBuilder.Entity<Race>().Property(_ => _.Modified).HasColumnName("modified").HasColumnType("datetime");
            modelBuilder.Entity<Race>().Property(_ => _.UserId).HasColumnName("user_id").HasColumnType("char(36)");
            
            modelBuilder.Entity<Race>().HasKey(_ => _.Id);
        }

        private void CharacterTypeMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CharacterType>().ToTable("luna_rpg_character_type");
            modelBuilder.Entity<CharacterType>().Property(_ => _.Id).HasColumnName("id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<CharacterType>().Property(_ => _.Name).HasColumnName("nom").HasColumnType("varchar(255)").IsRequired();
            modelBuilder.Entity<CharacterType>().Property(_ => _.Description).HasColumnName("description").HasColumnType("blob");
            modelBuilder.Entity<CharacterType>().Property(_ => _.Created).HasColumnName("created").HasColumnType("datetime");
            modelBuilder.Entity<CharacterType>().Property(_ => _.Modified).HasColumnName("modified").HasColumnType("datetime");
            modelBuilder.Entity<CharacterType>().Property(_ => _.UserId).HasColumnName("user_id").HasColumnType("char(36)");
            
            modelBuilder.Entity<CharacterType>().HasKey(_ => _.Id);
            modelBuilder.Entity<CharacterType>().HasIndex(_ => _.Name).IsUnique();
        }

        private void CustomPropertyTypeMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomPropertyType>().ToTable("luna_rpg_custom_property_type");
            modelBuilder.Entity<CustomPropertyType>().Property(_ => _.Id).HasColumnName("id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<CustomPropertyType>().Property(_ => _.Name).HasColumnName("nom").HasColumnType("varchar(255)").IsRequired();
            modelBuilder.Entity<CustomPropertyType>().Property(_ => _.Description).HasColumnName("description").HasColumnType("blob");
            modelBuilder.Entity<CustomPropertyType>().Property(_ => _.Created).HasColumnName("created").HasColumnType("datetime");
            modelBuilder.Entity<CustomPropertyType>().Property(_ => _.Modified).HasColumnName("modified").HasColumnType("datetime");
            modelBuilder.Entity<CustomPropertyType>().Property(_ => _.UserId).HasColumnName("user_id").HasColumnType("char(36)");
            
            modelBuilder.Entity<CustomPropertyType>().HasKey(_ => _.Id);
            modelBuilder.Entity<CustomPropertyType>().HasIndex(_ => _.Name).IsUnique();
        }

        private void CustomFieldMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomField>().ToTable("luna_rpg_custom_field");
            modelBuilder.Entity<CustomField>().Property(_ => _.Id).HasColumnName("id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<CustomField>().Property(_ => _.Name).HasColumnName("nom").HasColumnType("varchar(255)").IsRequired();
            modelBuilder.Entity<CustomField>().Property(_ => _.Description).HasColumnName("description").HasColumnType("blob");
            modelBuilder.Entity<CustomField>().Property(_ => _.TypeId).HasColumnName("type_id").HasColumnType("int").IsRequired();
            modelBuilder.Entity<CustomField>().Property(_ => _.Created).HasColumnName("created").HasColumnType("datetime");
            modelBuilder.Entity<CustomField>().Property(_ => _.Modified).HasColumnName("modified").HasColumnType("datetime");
            modelBuilder.Entity<CustomField>().Property(_ => _.UserId).HasColumnName("user_id").HasColumnType("char(36)");
            
            modelBuilder.Entity<CustomField>().HasKey(_ => _.Id);
        }

        private void CustomPropertyHasCustomFieldMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomPropertyHasCustomField>().ToTable("luna_rpg_custom_property_has_custom_property");
            modelBuilder.Entity<CustomPropertyHasCustomField>().Property(_ => _.Id).HasColumnName("id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<CustomPropertyHasCustomField>().Property(_ => _.Valeur).HasColumnName("valeur").HasColumnType("blob").IsRequired();
            modelBuilder.Entity<CustomPropertyHasCustomField>().Property(_ => _.PropertyId).HasColumnName("type_id").HasColumnType("int").IsRequired();
            modelBuilder.Entity<CustomPropertyHasCustomField>().Property(_ => _.FieldId).HasColumnName("type_id").HasColumnType("int").IsRequired();
            modelBuilder.Entity<CustomPropertyHasCustomField>().Property(_ => _.Created).HasColumnName("created").HasColumnType("datetime");
            modelBuilder.Entity<CustomPropertyHasCustomField>().Property(_ => _.Modified).HasColumnName("modified").HasColumnType("datetime");
            modelBuilder.Entity<CustomPropertyHasCustomField>().Property(_ => _.UserId).HasColumnName("user_id").HasColumnType("char(36)");
            
            modelBuilder.Entity<CustomField>().HasKey(_ => _.Id);
        }

        partial void CustomizeMapping(ref ModelBuilder modelBuilder);

        private void RelationshipsMapping(ModelBuilder modelBuilder)
        {
            // Character
            modelBuilder.Entity<Character>()
                .HasOne(_ => _.Race)
                .WithMany(_ => _.Characters)
                .IsRequired()
                .HasForeignKey("RaceId");
            modelBuilder.Entity<Character>()
                .HasOne(_ => _.Type)
                .WithMany(_ => _.Characters)
                .IsRequired()
                .HasForeignKey("TypeId");
            modelBuilder.Entity<Character>()
                .HasMany(_ => _.CustomSections)
                .WithOne(_ => _.Character)
                .HasForeignKey("CharacterId");
            modelBuilder.Entity<Character>()
                .HasOne(_ => _.Author)
                .WithMany(_ => _.Characters)
                .HasForeignKey("UserId");
            
            // CustomSection
            modelBuilder.Entity<CustomSection>()
                .HasOne(_ => _.Character)
                .WithMany(_ => _.CustomSections)
                .IsRequired()
                .HasForeignKey("CharacterId");
            modelBuilder.Entity<CustomSection>()
                .HasMany(_ => _.CustomProperties)
                .WithOne(_ => _.CustomSection)
                .HasForeignKey("CustomSectionId");
            modelBuilder.Entity<CustomSection>()
                .HasOne(_ => _.Author)
                .WithMany(_ => _.CustomSections)
                .HasForeignKey("UserId");
            
            // CustomProperty
            modelBuilder.Entity<CustomProperty>()
                .HasOne(_ => _.CustomSection)
                .WithMany(_ => _.CustomProperties)
                .IsRequired()
                .HasForeignKey("CustomSectionId");
            modelBuilder.Entity<CustomProperty>()
                .HasOne(_ => _.Type)
                .WithMany(_ => _.CustomProperties)
                .IsRequired()
                .HasForeignKey("TypeId");
            modelBuilder.Entity<CustomProperty>()
                .HasOne(_ => _.Race)
                .WithMany(_ => _.CustomProperties)
                .IsRequired()
                .HasForeignKey("RaceId");
            modelBuilder.Entity<CustomProperty>()
                .HasMany(_ => _.CustomPropertyHasCustomFields)
                .WithOne(_ => _.CustomProperty)
                .HasForeignKey("PropertyId");
            modelBuilder.Entity<CustomProperty>()
                .HasOne(_ => _.Author)
                .WithMany(_ => _.CustomProperties)
                .HasForeignKey("UserId");
            
            // CustomPropertyType
            modelBuilder.Entity<CustomPropertyType>()
                .HasMany(_ => _.CustomProperties)
                .WithOne(_ => _.Type)
                .HasForeignKey("TypeId");
            modelBuilder.Entity<CustomPropertyType>()
                .HasMany(_ => _.Fields)
                .WithOne(_ => _.Type)
                .HasForeignKey("TypeId");
            modelBuilder.Entity<CustomPropertyType>()
                .HasOne(_ => _.Author)
                .WithMany(_ => _.CustomPropertieTypes)
                .HasForeignKey("UserId");
            
            // CustomField
            modelBuilder.Entity<CustomField>()
                .HasOne(_ => _.Type)
                .WithMany(_ => _.Fields)
                .HasForeignKey("TypeId");
            modelBuilder.Entity<CustomField>()
                .HasMany(_ => _.CustomPropertyHasCustomFields)
                .WithOne(_ => _.CustomField)
                .HasForeignKey("TypeId");
            modelBuilder.Entity<CustomField>()
                .HasOne(_ => _.Author)
                .WithMany(_ => _.CustomFields)
                .HasForeignKey("UserId");
            
            // CustomPropertyHasCustomField
            modelBuilder.Entity<CustomPropertyHasCustomField>()
                .HasOne(_ => _.CustomProperty)
                .WithMany(_ => _.CustomPropertyHasCustomFields)
                .HasForeignKey("PropertyId");
            modelBuilder.Entity<CustomPropertyHasCustomField>()
                .HasOne(_ => _.CustomField)
                .WithMany(_ => _.CustomPropertyHasCustomFields)
                .HasForeignKey("FieldId");
            modelBuilder.Entity<CustomPropertyHasCustomField>()
                .HasOne(_ => _.Author)
                .WithMany(_ => _.CustomPropertyHasCustomFields)
                .HasForeignKey("UserId");
            
            // Race
            modelBuilder.Entity<Race>()
                .HasMany(_ => _.CustomProperties)
                .WithOne(_ => _.Race)
                .HasForeignKey("RaceId");
            modelBuilder.Entity<Race>()
                .HasMany(_ => _.Characters)
                .WithOne(_ => _.Race)
                .HasForeignKey("RaceId");
            modelBuilder.Entity<Race>()
                .HasOne(_ => _.Author)
                .WithMany(_ => _.Races)
                .HasForeignKey("UserId");
            
            // CharacterType
            modelBuilder.Entity<CharacterType>()
                .HasMany(_ => _.Characters)
                .WithOne(_ => _.Type)
                .HasForeignKey("TypeId");
            modelBuilder.Entity<CharacterType>()
                .HasOne(_ => _.Author)
                .WithMany(_ => _.CharacterTypes)
                .HasForeignKey("UserId");
        }
        
        
    }
}