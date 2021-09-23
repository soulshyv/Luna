using Microsoft.EntityFrameworkCore;

namespace Luna.Commons.Models
{
    public class LunaDbContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<CustomProperty> CustomProperties { get; set; }
        public DbSet<CharacterType> CharacterTypes { get; set; }
        public DbSet<CustomPropertyType> CustomerPropertyTypes { get; set; }
        public DbSet<Race> Races { get; set; }

        // public LunaDbContext()
        // {
        // }

        public LunaDbContext(DbContextOptions<LunaDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CharacterMapping(modelBuilder);
            CustomPropertyMapping(modelBuilder);
            RaceMapping(modelBuilder);
            CharacterTypeMapping(modelBuilder);
            CustomPropertyTypeMapping(modelBuilder);

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
            
            modelBuilder.Entity<Character>().HasKey(_ => _.Id);
        }

        private void CustomPropertyMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomProperty>().ToTable("luna_rpg_custom_entity");
            modelBuilder.Entity<CustomProperty>().Property(_ => _.Id).HasColumnName("id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<CustomProperty>().Property(_ => _.Name).HasColumnName("nom").HasColumnType("varchar(255)").IsRequired();
            modelBuilder.Entity<CustomProperty>().Property(_ => _.Description).HasColumnName("description").HasColumnType("blob");
            modelBuilder.Entity<CustomProperty>().Property(_ => _.TypeId).HasColumnName("type_id").HasColumnType("int").IsRequired();
            modelBuilder.Entity<CustomProperty>().Property(_ => _.CharacterId).HasColumnName("character_id").HasColumnType("int");
            modelBuilder.Entity<CustomProperty>().Property(_ => _.RaceId).HasColumnName("race_id").HasColumnType("int");
            modelBuilder.Entity<CustomProperty>().Property(_ => _.Valeur).HasColumnName("valeur").HasColumnType("int").IsRequired();
            modelBuilder.Entity<CustomProperty>().Property(_ => _.ValeurMax).HasColumnName("valeur_max").HasColumnType("int");
            modelBuilder.Entity<CustomProperty>().Property(_ => _.Unite).HasColumnName("unite").HasColumnType("varchar(100)");
            
            modelBuilder.Entity<CustomProperty>().HasKey(_ => _.Id);
        }

        private void RaceMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Race>().ToTable("luna_rpg_race");
            modelBuilder.Entity<Race>().Property(_ => _.Id).HasColumnName("id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Race>().Property(_ => _.Name).HasColumnName("nom").HasColumnType("varchar(255)").IsRequired();
            modelBuilder.Entity<Race>().Property(_ => _.Description).HasColumnName("description").HasColumnType("blob");
            
            modelBuilder.Entity<Race>().HasKey(_ => _.Id);
        }

        private void CharacterTypeMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CharacterType>().ToTable("luna_rpg_character_type");
            modelBuilder.Entity<CharacterType>().Property(_ => _.Id).HasColumnName("id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<CharacterType>().Property(_ => _.Name).HasColumnName("nom").HasColumnType("varchar(255)").IsRequired();
            modelBuilder.Entity<CharacterType>().Property(_ => _.Description).HasColumnName("description").HasColumnType("blob");
            
            modelBuilder.Entity<CustomProperty>().HasKey(_ => _.Id);
        }

        private void CustomPropertyTypeMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomPropertyType>().ToTable("luna_rpg_custom_property_type");
            modelBuilder.Entity<CustomPropertyType>().Property(_ => _.Id).HasColumnName("id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<CustomPropertyType>().Property(_ => _.Name).HasColumnName("nom").HasColumnType("varchar(255)").IsRequired();
            modelBuilder.Entity<CustomPropertyType>().Property(_ => _.Description).HasColumnName("description").HasColumnType("blob");
            
            modelBuilder.Entity<CustomPropertyType>().HasKey(_ => _.Id);
        }

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
                .HasMany(_ => _.CustomProperties)
                .WithOne(_ => _.Character)
                .HasForeignKey("CharacterId");
            
            // CustomProperty
            modelBuilder.Entity<CustomProperty>()
                .HasOne(_ => _.Type)
                .WithMany(_ => _.CustomProperties)
                .IsRequired()
                .HasForeignKey("TypeId");
            modelBuilder.Entity<CustomProperty>()
                .HasOne(_ => _.Character)
                .WithMany(_ => _.CustomProperties)
                .IsRequired()
                .HasForeignKey("CharacterId");
            modelBuilder.Entity<CustomProperty>()
                .HasOne(_ => _.Race)
                .WithMany(_ => _.CustomProperties)
                .IsRequired()
                .HasForeignKey("RaceId");
            
            // Race
            modelBuilder.Entity<Race>()
                .HasMany(_ => _.CustomProperties)
                .WithOne(_ => _.Race)
                .HasForeignKey("RaceId");
            modelBuilder.Entity<Race>()
                .HasMany(_ => _.Characters)
                .WithOne(_ => _.Race)
                .HasForeignKey("RaceId");
            
            // CharacterType
            modelBuilder.Entity<CharacterType>()
                .HasMany(_ => _.Characters)
                .WithOne(_ => _.Type)
                .HasForeignKey("TypeId");
            
            // CustomPropertyType
            modelBuilder.Entity<CustomPropertyType>()
                .HasMany(_ => _.CustomProperties)
                .WithOne(_ => _.Type)
                .HasForeignKey("TypeId");
        }
        
        
    }
}