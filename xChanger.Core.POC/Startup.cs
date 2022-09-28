using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using xChanger.Core.POC.Brokers.Sheets;
using xChanger.Core.POC.Brokers.Storages;
using xChanger.Core.POC.Services.Coordinations;
using xChanger.Core.POC.Services.Foundations.ExternalPersons;
using xChanger.Core.POC.Services.Foundations.Persons;
using xChanger.Core.POC.Services.Foundations.Pets;
using xChanger.Core.POC.Services.Orchestrations.ExternalPersons;
using xChanger.Core.POC.Services.Orchestrations.PersonPets;
using xChanger.Core.POC.Services.Processings.ExternalPersons;
using xChanger.Core.POC.Services.Processings.Persons;
using xChanger.Core.POC.Services.Processings.Pets;

namespace xChanger.Core.POC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            AddBrokers(services);
            AddFoundationServices(services);
            AddProcessingServices(services);
            AddOrchestrationServices(services);
            AddCoordinationServices(services);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    name: "v1",
                    info: new OpenApiInfo
                    {
                        Title = "xChanger.Core.POC",
                        Version = "v1"
                    });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();

                app.UseSwaggerUI(config =>
                    config.SwaggerEndpoint(
                        url: "/swagger/v1/swagger.json",
                        name: "xChanger.Core.POC v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
                endpoints.MapControllers());
        }

        private static void AddBrokers(IServiceCollection services)
        {
            services.AddTransient<IStorageBroker, StorageBroker>();
            services.AddTransient<ISheetBroker, SheetBroker>();
        }

        private static void AddFoundationServices(IServiceCollection services)
        {
            services.AddTransient<IPersonService, PersonService>();
            services.AddTransient<IPetService, PetService>();
            services.AddTransient<IExternalPersonService, ExternalPersonService>();
        }

        private static void AddProcessingServices(IServiceCollection services)
        {
            services.AddTransient<IPersonProcessingService, PersonProcessingService>();
            services.AddTransient<IPetProcessingService, PetProcessingService>();
            services.AddTransient<IExternalPersonProcessingService, ExternalPersonProcessingService>();
        }

        private static void AddOrchestrationServices(IServiceCollection services)
        {
            services.AddTransient<IPersonPetOrchestrationService, PersonPetOrchestrationService>();
            services.AddTransient<IExternalPersonOrchestrationService, ExternalPersonOrchestrationService>();
        }

        private static void AddCoordinationServices(IServiceCollection services)
        {
            services.AddTransient<IExternalPersonWithPetsCoordinationService, ExternalPersonWithPetsCoordinationService>();
        }
    }
}
