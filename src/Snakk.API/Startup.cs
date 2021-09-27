//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Snakk.API.MiddelWare;
using Weikio.PluginFramework.Catalogs;
using SqlKata.Compilers;
using SqlKata.Execution;
using Npgsql;

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
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<BrotliCompressionProvider>();
                options.Providers.Add<GzipCompressionProvider>();
            });

            services.AddControllers(
                options =>
                {
                    options.Filters.Add(new HttpResponseExceptionFilter());
                    options.Filters.Add(new UnhandledExceptionFilter());
                }
            );

            services.AddScoped(_ => new QueryFactory(
                new NpgsqlConnection(Configuration.GetConnectionString("ThreadgresConnectionString")),
                new PostgresCompiler()));

            //services.AddDbContext<DB.Context>(options =>
            //  options.UseSqlite(Configuration.GetConnectionString("SqliteConnection")));

            AddHelpers(services);
            AddPluginInterfaces(services);
            AddRouteServices(services);
        }

        private void AddRouteServices(IServiceCollection services)
        {
            services.AddScoped<Routes.Comment.Services.Get.IService, Routes.Comment.Services.Get.Service>();
            services.AddScoped<Routes.Thread.Services.Get.IService, Routes.Thread.Services.Get.Service>();
            services.AddScoped<Routes.Channel.Services.Get.IService, Routes.Channel.Services.Get.Service>();
            services.AddScoped<Routes.Channel.Thread.List.Services.Get.IService, Routes.Channel.Thread.List.Services.Get.Service>();
        }

        private void AddPluginInterfaces(IServiceCollection services)
        {
            System.IO.Directory.CreateDirectory(@".\plugins");

            //PluginRegistry.LoadPlugins();

            services
                .AddPluginFramework()

                .AddPluginCatalog(new FolderPluginCatalog(@".\plugins", type =>
                {
                    type.Implements<PluginFramework.IPlugin>();
                }))
            .AddPluginType<PluginFramework.Hooks.Routes.Thread.Services.Get.IService>()
            .AddPluginType<PluginFramework.Hooks.Routes.Comment.Services.Get.IService>()
            .AddPluginType<PluginFramework.Hooks.Routes.Channel.Services.Get.IService>()
            .AddPluginType<PluginFramework.Hooks.Routes.Channel.Thread.List.Services.Get.IService>();
        }

        private void AddHelpers(IServiceCollection services)
        {
            // HashIdConverters
            services.AddSingleton<Helpers.HashIdConverters.IThreadHashIdConverter, Helpers.HashIdConverters.ThreadHashIdConverter>();
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

            app.UseResponseCompression();

            //app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
