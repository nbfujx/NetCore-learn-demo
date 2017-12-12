using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using netCore_efcore.Repository;
using netCore_efcore.Repository.Interfaces;
using netCore_efcore.Service;
using netCore_efcore.Service.Interfaces;
using netCore_efcore.Utils;

namespace netCore_efcore
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
            //添加efCore注入
            services.AddDbContext<EFCoreContext>(options => options.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));
            //添加repository注入
            services.AddTransient<ISysConfigRepository, SysConfigRepository>();
            //添加service注入
            services.AddTransient<ISysConfigService, SysConfigService>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
