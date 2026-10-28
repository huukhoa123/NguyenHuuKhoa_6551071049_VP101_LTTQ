using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace NguyenHuuKhoa_6551071049_VP101_28_LTTQ;

public sealed class CongViecDbContext : DbContext
{
    public DbSet<CongViec> CongViecs => Set<CongViec>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            string path = Path.Combine(AppContext.BaseDirectory, "appsettings.json");
            string connectionString = "Server=.;Database=DuLieu;Trusted_Connection=True;TrustServerCertificate=True";

            if (File.Exists(path))
            {
                using JsonDocument config = JsonDocument.Parse(File.ReadAllText(path));
                if (config.RootElement.TryGetProperty("ConnectionStrings", out JsonElement strings) &&
                    strings.TryGetProperty("DefaultConnection", out JsonElement value))
                {
                    connectionString = value.GetString() ?? connectionString;
                }
            }

            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CongViec>(entity =>
        {
            entity.ToTable("CongViec");
            entity.HasKey(x => x.MaCongViec);
            entity.Property(x => x.MaCongViec).HasMaxLength(50).IsRequired();
            entity.Property(x => x.TenCongViec).HasColumnType("ntext").IsRequired();
            entity.Property(x => x.LuongThang).HasMaxLength(8).HasColumnType("nvarchar(8)").IsRequired();
        });
    }
}

public sealed class CongViec
{
    [Key]
    [StringLength(50)]
    public string MaCongViec { get; set; } = string.Empty;

    [Required]
    [StringLength(200)]
    public string TenCongViec { get; set; } = string.Empty;

    [StringLength(8)]
    public string LuongThang { get; set; } = string.Empty;
}
