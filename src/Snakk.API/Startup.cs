//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Snakk.API.MiddelWare;
using Weikio.PluginFramework.Catalogs;

namespace Snakk.API
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
            services.AddControllers(
                options =>
                {
                    options.Filters.Add(new HttpResponseExceptionFilter());
                    options.Filters.Add(new UnhandledExceptionFilter());
                }
            );

            services
                .AddDbContext<Snakk.DB.Context>(
                    x => x.UseSqlite(Configuration.GetConnectionString("SqliteConnection")));

            AddRouteServices(services);
            AddHelpers(services);
            AddPluginInterfaces(services);
        }

        private void AddRouteServices(IServiceCollection services)
        {
            services.AddScoped<Routes.Comment.Services.IGet, Routes.Comment.Services.Get>();
            services.AddScoped<Routes.Post.Services.IGet, Routes.Post.Services.Get>();
            services.AddScoped<Routes.Channel.Services.IGet, Routes.Channel.Services.Get>();
            services.AddScoped<Routes.Channel.Post.List.Services.IGet, Routes.Channel.Post.List.Services.Get>();
        }

        private void AddPluginInterfaces(IServiceCollection services)
        {
            services
                .AddPluginFramework()
                .AddPluginCatalog(new FolderPluginCatalog(@".\plugins", type =>
                {
                    type.Implements<PluginFramework.Routes.Comment.Services.IGet>();
                    type.Implements<PluginFramework.Routes.Post.Services.IGet>();
                    type.Implements<PluginFramework.Routes.Channel.Services.IGet>();
                    type.Implements<PluginFramework.Routes.Channel.Post.List.Services.IGet>();
                }))
                .AddPluginType<PluginFramework.Routes.Comment.Services.IGet>()
                .AddPluginType<PluginFramework.Routes.Post.Services.IGet>()
                .AddPluginType<PluginFramework.Routes.Channel.Services.IGet>()
                .AddPluginType<PluginFramework.Routes.Channel.Post.List.Services.IGet>();
        }

        private void AddHelpers(IServiceCollection services)
        {
            // HashIdConverters
            services.AddSingleton<Helpers.HashIdConverters.IPostHashIdConverter, Helpers.HashIdConverters.PostHashIdConverter>();
            services.AddSingleton<Helpers.HashIdConverters.ICommentHashIdConverter, Helpers.HashIdConverters.CommentHashIdConverter>();
            services.AddSingleton<Helpers.HashIdConverters.IUserHashIdConverter, Helpers.HashIdConverters.UserHashIdConverter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
