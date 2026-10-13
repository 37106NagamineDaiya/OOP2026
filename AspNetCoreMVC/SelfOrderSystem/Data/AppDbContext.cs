using Microsoft.EntityFrameworkCore;
using SelfOrderSystem.Models;

namespace SelfOrderSystem.Data;

public class AppDbContext : DbContext {
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) {
    }

    public DbSet<Category> Categories => Set<Category>();        // カテゴリ 
    public DbSet<Product> Products => Set<Product>();            // 商品 
}