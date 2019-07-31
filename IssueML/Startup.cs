using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IssueML.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace IssueML
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
            services.AddScoped<IIssuePredictService, IssuePredictService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //services.AddMvcCore(options => options.OutputFormatters.Add(new ForcedUtf8JsonFormatter(new JsonSerializerSettings(), ArrayPool<char>.Shared))).AddJsonFormatters();

            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.Formatting = Formatting.Indented;
                options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
                options.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
            });


            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UsePathBase("/IssueML");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
