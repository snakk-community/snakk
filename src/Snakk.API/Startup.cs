//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Snakk.API.MiddelWare;

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
        }

        private void AddRouteServices(IServiceCollection services)
        {
            services.AddScoped<Routes.Comment.IGet, Routes.Comment.Get>();
            services.AddScoped<Routes.Thread.IGet, Routes.Thread.Get>();
            services.AddScoped<Routes.Channel.IGet, Routes.Channel.Get>();
            services.AddScoped<Routes.Channel.Thread.List.IGet, Routes.Channel.Thread.List.Get>();
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
