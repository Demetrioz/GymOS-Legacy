using GymOS.DataModel.Contexts;
using GymOS.DataModel.Models.Identity;
using GymOS.Server.Configuration;
using GymOS.Services.EmailService;
using GymOS.Services.EmailService.MailchimpService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GymOS.Server
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
        public async void ConfigureServices(IServiceCollection services)
        {
            ServerSettings settings = new ServerSettings();
            Configuration.GetSection("ServerSettings").Bind(settings);

            // Make settings available via DI
            services.Configure<ServerSettings>(Configuration.GetSection("ServerSettings"));

            services.AddDbContext<GymOSContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<GymOSUser>()//options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<GymOSContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<GymOSUser, GymOSContext>();

            services.AddAuthentication()
                .AddIdentityServerJwt();

            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddHttpClient();

            services.AddTransient<IEmailService>(provider =>
            {
                IHttpClientFactory factory = provider.GetService<IHttpClientFactory>();
                return new MailchimpService(factory, settings.EmailServiceSettings);
            });

            await RunOneTimeSetup(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }

        private async Task RunOneTimeSetup(IServiceCollection services)
        {
            IServiceScopeFactory scopeFactory = services
                .BuildServiceProvider()
                .GetService<IServiceScopeFactory>();

            using (IServiceScope scope = scopeFactory.CreateScope())
            {
                IServiceProvider provider = scope.ServiceProvider;
                using (GymOSContext context = provider.GetService<GymOSContext>())
                {
                    GymOSUser user = context.Users
                        .Where(u => u.Id != null)
                        .FirstOrDefault();

                    IdentityRole role = context.Roles
                        .Where(r => r.Id != null)
                        .FirstOrDefault();

                    if(user == null && role == null)
                    {
                        RoleManager<IdentityRole> roleManager = provider.GetService<RoleManager<IdentityRole>>();
                        UserManager<GymOSUser> userManager = provider.GetService<UserManager<GymOSUser>>();
                        ServerSettings settings = provider.GetService<IOptions<ServerSettings>>().Value;

                        foreach(string roleName in settings.DefaultRoles)
                            await roleManager.CreateAsync(new IdentityRole 
                            { 
                                Name = roleName
                            });

                        GymOSUser adminUser = new GymOSUser
                        {
                            Email = settings.DefaultUser.Email,
                            UserName = settings.DefaultUser.Email,
                        };

                        await userManager.CreateAsync(adminUser);
                        await userManager.AddPasswordAsync(adminUser, settings.DefaultUser.Password);
                        await userManager.AddToRoleAsync(adminUser, settings.DefaultUser.Role);
                    }
                }
            }
        }
    }
}
