using AutoMapper;
using Billing.Applications;
using Billing.Applications.Contracts;
using Billing.AutoMapper;
using Billing.Domain.Entity;
using Billing.Domains.Services;
using Billing.Domains.Services.Contracts;
using Billing.Repositories;
using Billing.Repositories.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billing
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
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerDomainService, CustomerDomainService>();
            services.AddScoped<ICustomerAppService, CustomerAppService>();
            services.AddScoped<ITypeCustomerRepository, TypeCustomerRepository>();


            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductDomainService, ProductDomainService>();
            services.AddScoped<IProductAppService, ProductAppService>();
            services.AddScoped<IMarkRepository, MarkRepository>();

            services.AddScoped<IMovementBillRepository, MovementBillRepository>();
            services.AddScoped<IMovementBillDomainService, MovementBillDomainService>();
            services.AddScoped<IMovementBillAppService, MovementBillAppService>();

            services.AddScoped<IMovementProductRepository, MovementProductRepository>();
            services.AddScoped<IMovementProductDomainService, MovementProductDomainService>();
            services.AddScoped<IMovementProductAppService, MovementProductAppService>();

            services.AddScoped<IResidueRepository, ResidueRepository>();
            services.AddScoped<IResidueDomainService, ResidueDomainService>();

            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IPaymentDomainService, PaymentDomainService>();
            services.AddScoped<IPaymentAppService, PaymentAppService>();

            services.AddDbContext<BillingContext>(Options => Options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();
            services.AddCors(options => options.AddPolicy("AllowWebApp",
                                  builder => builder.AllowAnyOrigin()
                                                    .AllowAnyHeader()
                                                    .AllowAnyMethod()));
            services.AddMvc();

            var mapperConfig = new MapperConfiguration(m =>
            {
                m.AddProfile(new CustomerMapperProfile());
                m.AddProfile(new ProductMapperProfile());
                m.AddProfile(new MovementBillMapperProfile());
                m.AddProfile(new MovementProductMapperProfile());
                m.AddProfile(new PaymentMapperProfile());

            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Billing", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Billing v1"));
            }
            app.UseCors("AllowAll");

            app.UseCors("AllowWebApp");

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
