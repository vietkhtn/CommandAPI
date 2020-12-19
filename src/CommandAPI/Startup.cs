using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CommandAPI.Data;

namespace CommandAPI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        
        // Đăng khi service
        public void ConfigureServices(IServiceCollection services)
        {
            // Đăng kí services cấp quyền dùng Controller
            services.AddControllers();

            // Kết nối Repository Interface đến nơi code chức năng của các hàm khai báo trong nó
            services.AddScoped<ICommandAPIRepo, MockCommandAPIRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // Sau khi đăng kí service xong, hàm Config đc gọi để set up request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // Thêm MapControllers vào endpoints -> Dùng Controller services là điểm kết thúc của Request Pipeline
                endpoints.MapControllers();
                // endpoints.MapGet("/", async context =>
                // {
                //     await context.Response.WriteAsync("Hello World!");
                // });
            });
        }
    }
}
