using HttpClientTest.Repository.Seeds;

namespace HttpClientTest.Repository.Context;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Configurations

        modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
        modelBuilder.ApplyConfiguration(new AppUserConfiguration());
        modelBuilder.ApplyConfiguration(new AppUserRoleConfiguration());
        modelBuilder.ApplyConfiguration(new BlogConfiguration());
        modelBuilder.ApplyConfiguration(new BlogCategoryConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new CommentConfiguration());

        #endregion

        #region Seed Datas

        modelBuilder.ApplyConfiguration(new AppRoleSeed());
        modelBuilder.ApplyConfiguration(new AppUserRoleSeed());
        modelBuilder.ApplyConfiguration(new AppUserSeed());
        modelBuilder.ApplyConfiguration(new BlogSeed());
        modelBuilder.ApplyConfiguration(new BlogCategorySeed());
        modelBuilder.ApplyConfiguration(new CategorySeed());
        modelBuilder.ApplyConfiguration(new CommentSeed());

        #endregion

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<AppRole> AppRoles { get; set; }
    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<AppUserRole> AppUserRoles { get; set; }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<BlogCategory> BlogCategories { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Comment> Comments { get; set; }
}
