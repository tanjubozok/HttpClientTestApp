using HttpClientTest.Service.Manager;

namespace HttpClientTest.Service.DependencyResolvers;

public static class DependencyExtension
{
    public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        #region Database ConnectionString

        services.AddDbContext<DatabaseContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("LocalSqlServer"));
        });

        #endregion

        #region Validators

        //services.AddTransient<IValidator<CategoryAddDto>, CategoryAddDtoValidator>();
        //services.AddTransient<IValidator<CategoryUpdateDto>, CategoryUpdateDtoValidator>();

        //services.AddTransient<IValidator<BlogAddDto>, BlogAddDtoValidator>();
        //services.AddTransient<IValidator<BlogUpdateDto>, BlogUpdateDtoValidator>();

        //services.AddTransient<IValidator<AppUserLoginDto>, AppUserLoginDtoValidator>();
        //services.AddTransient<IValidator<AppUserRegisterDto>, AppUserRegisterDtoValidator>();

        #endregion

        #region DI

        // repositories
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IBlogRepository, BlogRepository>();
        services.AddScoped<IAppUserRepository, AppUserRepository>();

        // services
        services.AddScoped<ICategoryService, CategoryManager>();

        #endregion        
    }
}
