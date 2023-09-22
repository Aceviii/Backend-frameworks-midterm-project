using midterm_project.Models;
using Microsoft.EntityFrameworkCore;

namespace midterm_project.Migrations;

public class PetDbContext : DbContext
{
    public DbSet<Fish> Fish { get; set; }

    public PetDbContext(DbContextOptions<PetDbContext> options)
    : base(options)
    {


    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Fish>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Description).IsRequired();
            entity.Property(e => e.Color).IsRequired();
            entity.Property(e => e.Url).IsRequired();
        });
    }
}

