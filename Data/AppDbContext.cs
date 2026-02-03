using Microsoft.EntityFrameworkCore;
using AngularSPA.Models;

namespace AngularSPA.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Activity> Activities => Set<Activity>();
    public DbSet<Company> Companies => Set<Company>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Activity>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Name).IsRequired().HasMaxLength(200);
        });

        modelBuilder.Entity<Company>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Name).IsRequired().HasMaxLength(200);
            e.HasOne(x => x.Activity)
                .WithMany(a => a.Companies)
                .HasForeignKey(x => x.ActivityId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // Начальные данные: 3 вида деятельности
        var activity1 = new Guid("a1000000-0000-0000-0000-000000000001");
        var activity2 = new Guid("a1000000-0000-0000-0000-000000000002");
        var activity3 = new Guid("a1000000-0000-0000-0000-000000000003");

        modelBuilder.Entity<Activity>().HasData(
            new Activity { Id = activity1, Name = "Продуктовая" },
            new Activity { Id = activity2, Name = "Транспортная" },
            new Activity { Id = activity3, Name = "Благотворительная" }
        );

        // 10 компаний (случайное распределение по видам деятельности)
        modelBuilder.Entity<Company>().HasData(
            new Company { Id = new Guid("c1000000-0000-0000-0000-000000000001"), Name = "ООО Восток", ActivityId = activity1 },
            new Company { Id = new Guid("c1000000-0000-0000-0000-000000000002"), Name = "ЗАО Север", ActivityId = activity2 },
            new Company { Id = new Guid("c1000000-0000-0000-0000-000000000003"), Name = "ООО Продукты плюс", ActivityId = activity1 },
            new Company { Id = new Guid("c1000000-0000-0000-0000-000000000004"), Name = "ТрансЛогистик", ActivityId = activity2 },
            new Company { Id = new Guid("c1000000-0000-0000-0000-000000000005"), Name = "Фонд Помощи", ActivityId = activity3 },
            new Company { Id = new Guid("c1000000-0000-0000-0000-000000000006"), Name = "ООО Свежий хлеб", ActivityId = activity1 },
            new Company { Id = new Guid("c1000000-0000-0000-0000-000000000007"), Name = "Автоперевозки", ActivityId = activity2 },
            new Company { Id = new Guid("c1000000-0000-0000-0000-000000000008"), Name = "Добрые руки", ActivityId = activity3 },
            new Company { Id = new Guid("c1000000-0000-0000-0000-000000000009"), Name = "ООО Молоко", ActivityId = activity1 },
            new Company { Id = new Guid("c1000000-0000-0000-0000-00000000000a"), Name = "Быстрая доставка", ActivityId = activity2 }
        );
    }
}
