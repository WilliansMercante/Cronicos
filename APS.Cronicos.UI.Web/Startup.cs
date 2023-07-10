using APS.Cronicos.Dominio.Email.Entidades;
using APS.Cronicos.Dominio.Helpers;
using APS.Cronicos.Dominio.Proxy.Entidades;
using APS.Cronicos.Infra.Data.Contexts;
using APS.Cronicos.IoC.App_Start;
using APS.Cronicos.UI.Web.Filters;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Rotativa.AspNetCore;
using System;
using System.Text;

namespace APS.Cronicos.UI.Web
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
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            services.AddDbContext<ConfiguracaoContext>(options => options.UseSqlServer(Configuration.GetConnectionString("APS.Cronicos")), ServiceLifetime.Scoped);
            services.AddDbContext<CronicosContext>(options => options.UseSqlServer(Configuration.GetConnectionString("APS.Cronicos")), ServiceLifetime.Scoped);

            services.Configure<EmailSettingsEntity>(Configuration.GetSection("EmailSettings"));
            services.Configure<ProxyEntity>(Configuration.GetSection("Proxy"));
            InjectionDependencyCore.ConfigureServices(services);

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton(Configuration);

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:AuthenticationKey").Value);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().Build();
                });
            });

            // The Tempdata provider cookie is not essential. Make it essential
            // so Tempdata is functional when tracking is disabled.
            services.Configure<CookieTempDataProviderOptions>(options => {
                options.Cookie.IsEssential = true;
            });

            services.AddSession(options =>
            {
                options.Cookie.Name = ".Cronicos.Session";
                options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                options.IdleTimeout = TimeSpan.FromMinutes(20);
                options.Cookie.IsEssential = true;
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options =>
                    {
                        options.LoginPath = "/Autenticar/Index";
                        options.LogoutPath = "/Autenticar/Logout";
                    });

            services.AddAuthentication(options =>
            {
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            });

            services.AddDataProtection()
                    //.PersistKeysToFileSystem(new DirectoryInfo(Path.GetTempPath()))
                    .UseCryptographicAlgorithms(new AuthenticatedEncryptorConfiguration
                    {
                        EncryptionAlgorithm = EncryptionAlgorithm.AES_256_CBC,
                        ValidationAlgorithm = ValidationAlgorithm.HMACSHA256
                    })
                    .SetApplicationName("Crônicos");

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = ".AspNet.SharedCookie";
                options.Cookie.Path = "/";
            });

            services.AddRazorPages().AddRazorRuntimeCompilation();

            services.AddMvc(options =>
            {
                options.Filters.Add(new AuthenticationFilter());
                options.Filters.Add(typeof(AuthenticationFilter));
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [Obsolete]
        public void Configure(IApplicationBuilder app, IWebHostEnvironment webHostingEnvironment, IAntiforgery antiforgery)
        {
            if (webHostingEnvironment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            //// This will add "Libs" as another valid static content location
            app.UseStaticFiles();

            app.UseCookiePolicy();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            AppHttpContextHelper.Services = app.ApplicationServices;

            app.UseSession();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Autenticar}/{action=Index}/{id?}"
               );

                endpoints.MapControllers();
            });

            RotativaConfiguration.Setup((Microsoft.AspNetCore.Hosting.IHostingEnvironment)webHostingEnvironment, "Rotativa");
        }
    }
}