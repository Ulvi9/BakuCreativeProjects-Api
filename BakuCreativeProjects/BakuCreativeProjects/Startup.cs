
using System.Linq;
using System.Text;
using BakuCreativeProjects.Data;
using BakuCreativeProjects.Mapper;
using BakuCreativeProjects.Repo;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace BakuCreativeProjects
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<DataContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddSwaggerGen(opt =>  opt.SwaggerDoc("v1", new OpenApiInfo {Title = "BakuCreativeProjects", Version = "v1"}));
            
              services.AddAutoMapper(typeof(MapperProfile));
              
              //addingServices
              services.AddScoped<IAuthRepository, AuthRepository>();
              services.AddScoped<IProductRepository, ProductRepository>();

              services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
                  AddJwtBearer(opt =>
                      opt.TokenValidationParameters = new TokenValidationParameters
                      {
                          ValidateIssuerSigningKey = true,
                          IssuerSigningKey=
                              new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                          ValidateIssuer=false,
                          ValidateAudience=false
                      });
              services.AddCors(options =>
              {
                  options.AddPolicy("AllowAnyCorsPolicy", policy => 
                      policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
              });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("AllowAnyCorsPolicy");
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(opt => opt.SwaggerEndpoint("/swagger/v1/swagger.json",
                "BakuCreativeProjects API v1"));

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}