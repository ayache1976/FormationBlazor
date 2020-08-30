using AutoMapper;
using Initiation.Server.Data;
using Initiation.Server.Data.Seed;
using Initiation.Server.Mappings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using NSwag;
using NSwag.Generation.Processors.Security;
using System.Linq;
using System.Text;

namespace Initiation.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();
            services.AddDbContext<DataContext>(x => x.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddOpenApiDocument(document =>
            {
                document.AddSecurity("JWT", Enumerable.Empty<string>(), new NSwag.OpenApiSecurityScheme
                {
                    Type = NSwag.OpenApiSecuritySchemeType.ApiKey,
                    Name = "Autorization",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Description = "Insérer JWT: Bearer {JWT}."
                });
                document.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
            });
            services.AddTransient<Seed>();
            services.AddAutoMapper(typeof(Startup));
            var mappingConfiguration = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mappingConfiguration.CreateMapper();
            services.AddSingleton(mapper);
            services.AddScoped<IInstrumentRepository, InstrumentRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
                options => options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                }
                );
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Seed seeder)
        {
            app.UseOpenApi();
            app.UseSwaggerUi3();
            seeder.SeedInstruments();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
