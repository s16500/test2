using Microsoft.EntityFrameworkCore;

namespace WebAPI_Test.Models
{
    public class APBDContext : DbContext
    {
        public DbSet<VolunteerPet> VolunteerPets { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<BreedType> BreedTypes { get; set; }
        public DbSet<Volunterr> Volunterrs { get; set; }

        public APBDContext()
        {

        }

        public APBDContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VolunteerPet>(entity =>
            {
                entity.HasKey(e => new { e.IdVolunteer, e.IdPet });
                entity.Property(e => e.IdVolunteer);
                entity.Property(e => e.IdPet);

                entity.HasOne(e => e.Pet).WithMany(x => x.VolunteerPets).HasForeignKey(x => x.IdPet);

                entity.HasOne(e => e.Volunterr).WithMany(x => x.VolunteerPets).HasForeignKey(x => x.IdVolunteer);

            });

            modelBuilder.Entity<Pet>(entity =>
            {
                entity.HasKey(e => e.IdPet);
                entity.Property(e => e.IdPet).ValueGeneratedOnAdd();

                entity.Property(e => e.Name).HasMaxLength(80).IsRequired();

                entity.Property(e => e.DateAdopted).IsRequired();

            });

            modelBuilder.Entity<BreedType>(entity =>
            {
                entity.HasKey(e => e.IdBreedType);
                entity.Property(e => e.IdBreedType).ValueGeneratedOnAdd();

                entity.Property(e => e.Name).HasMaxLength(500).IsRequired();

                entity.Property(e => e.Description).HasMaxLength(500);
                
            });

            modelBuilder.Entity<Volunterr>(entity =>
            {
                entity.HasKey(e => e.IdVolunterr);
                entity.Property(e => e.IdVolunterr).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).HasMaxLength(80).IsRequired();
                entity.Property(e => e.Surname).HasMaxLength(80).IsRequired();
                entity.Property(e => e.Phone).HasMaxLength(30).IsRequired();
                entity.Property(e => e.Addess).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Email).HasMaxLength(80).IsRequired();
            });

        }

    }
}
