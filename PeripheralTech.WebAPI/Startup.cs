using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
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
using PeripheralTech.Model.Requests;
using PeripheralTech.WebAPI.Database;
using PeripheralTech.WebAPI.Filters;
using PeripheralTech.WebAPI.Security;
using PeripheralTech.WebAPI.Services;

namespace PeripheralTech.WebAPI
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
            services.AddControllers();
            services.AddMvc(x => x.Filters.Add<ErrorFilter>()).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddAutoMapper(typeof(Startup));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PeripheralTech API", Version = "v1" });

                c.AddSecurityDefinition("basicAuth", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "basicAuth" }
                        },
                        new string[]{}
                    }
                });
            });

            services.AddAuthentication("BasicAuthentication").AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IService<Model.Country, object>, BaseService<Model.Country, object, Country>>();
            services.AddScoped<IService<Model.ProductType, object>, BaseService<Model.ProductType, object, ProductType>>();
            services.AddScoped<IService<Model.UserRole, object>, BaseService<Model.UserRole, object, UserRole>>();
            services.AddScoped<IService<Model.OrderStatus, object>, BaseService<Model.OrderStatus, object, OrderStatus>>();

            services.AddScoped<ICRUDService<Model.City, CitySearchRequest, CityUpsertRequest, CityUpsertRequest>, CityService>();
            services.AddScoped<ICRUDService<Model.Product, ProductSearchRequest, ProductUpsertRequest, ProductUpsertRequest>, ProductService>();
            services.AddScoped<ICRUDService<Model.Company, CompanySearchRequest, CompanyUpsertRequest, CompanyUpsertRequest>, CompanyService>();
            services.AddScoped<ICRUDService<Model.Order, OrderSearchRequest, OrderInsertRequest, OrderUpdateRequest>, OrderService>();
            services.AddScoped<ICRUDService<Model.UserFavoriteProduct, UserFavoriteProductSearchRequest, UserFavoriteProductUpsertRequest, UserFavoriteProductUpsertRequest>, UserFavoriteProductService>();
            services.AddScoped<ICRUDService<Model.UserReview, UserReviewSearchRequest, UserReviewUpsertRequest, UserReviewUpsertRequest>, UserReviewService>();
            services.AddScoped<ICRUDService<Model.StaffReview, StaffReviewSearchRequest, StaffReviewUpsertRequest, StaffReviewUpsertRequest>, StaffReviewService>();
            services.AddScoped<ICRUDService<Model.ProductImage, ProductImageSearchRequest, ProductImageUpsertRequest, ProductImageUpsertRequest>, ProductImageService>();
            services.AddScoped<ICRUDService<Model.ProductVideo, ProductVideoSearchRequest, ProductVideoUpsertRequest, ProductVideoUpsertRequest>, ProductVideoService>();
            services.AddScoped<ICRUDService<Model.Discount, DiscountSearchRequest, DiscountUpsertRequest, DiscountUpsertRequest>, DiscountService>();
            services.AddScoped<ICRUDService<Model.OrderProduct, OrderProductSearchRequest, OrderProductUpsertRequest, OrderProductUpsertRequest>, OrderProductService>();
            services.AddScoped<ICRUDService<Model.News, NewsSearchRequest, NewsUpsertRequest, NewsUpsertRequest>, NewsService>();
            services.AddScoped<ICRUDService<Model.Question, QuestionSearchRequest, QuestionInsertRequest, QuestionUpdateRequest>, QuestionService>();
            services.AddScoped<ICRUDService<Model.QuestionComment, QuestionCommentSearchRequest, QuestionCommentUpsertRequest, QuestionCommentUpsertRequest>, QuestionCommentService>();

            var connection = Configuration.GetConnectionString("PeripheralTech");
            services.AddDbContext<PeripheralTechDbContext>(options => options.UseSqlServer(connection));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PeripheralTech");
            });
        }
    }
}
