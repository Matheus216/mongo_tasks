using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using mongo_dotnet_ep1.Models;
using mongo_dotnet_ep1.Services;
using Newtonsoft.Json;

namespace mongo_dotnet_ep1
{
    public class Startup
    {
        private IConfiguration Configuration; 

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration; 
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //Configuração criada para o mapeamento do appsettings.json para classes modelo criadas 
            //Pode verificar que os nomes das propriedades são equivalentes para facilitar o mapeamento
            services.Configure<TaskDataBaseSettings>(Configuration.GetSection(nameof(TaskDataBaseSettings))); 
            services.AddSingleton<ITaskDataBaseSettings>(sp =>  
                sp.GetRequiredService<IOptions<TaskDataBaseSettings>>().Value);
            
            services.AddSingleton<ITaskService, TaskService>();
            services.AddControllers()
                .AddNewtonsoftJson(options => options.UseMemberCasing()); 
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection(); 

            app.UseRouting();

            //Permite qualquer origem header ou método acessar o nosso código
            app.UseCors(config => { 
                config.AllowAnyHeader();
                config.AllowAnyMethod();
                config.AllowAnyOrigin();
            }); 

            app.UseEndpoints(end => {
                end.MapControllers(); 
            });
        }
    }
}
