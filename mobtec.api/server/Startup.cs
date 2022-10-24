using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using server.Controllers;
using server.Data;
using server.Models.Entity;
using server.Repositories;
using server.Services;
using server.Utils;

namespace server
{
    public class Startup
    {
        public IConfiguration _configuration { get; }
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Este método é chamado pelo tempo de execução. Use este método para adicionar serviços ao contêiner.
        public void ConfigureServices(IServiceCollection services)
        {
            //Obtendo a string de conexão do appSetings
            var stringConexao = _configuration.GetSection("conexao").Value;

            //Configurando o banco de dados
            services.AddDbContext<DataContext>(options =>

            //localHost
            options.UseSqlServer(stringConexao));

            //prod
            //options.UseSqlServer("workstation id=mobtec-db.mssql.somee.com;packet size=4096;user id=veronesigabriel_SQLLogin_1;pwd=smbxnxl6zj;data source=mobtec-db.mssql.somee.com;persist security info=False;initial catalog=mobtec-db"));

            //teste
            //options.UseSqlServer("workstation id=mobtecbase.mssql.somee.com;packet size=4096;user id=veronesigabriel_SQLLogin_1;pwd=smbxnxl6zj;data source=mobtecbase.mssql.somee.com;persist security info=False;initial catalog=mobtecbase"));

            //Configurando injeção de dependencia
            services.AddScoped<AdmController, AdmController>();
            services.AddScoped<AdmService, AdmService>();
            services.AddScoped<AdmRepository, AdmRepository>();

            services.AddScoped<PainelController, PainelController>();
            services.AddScoped<PainelService, PainelService>();
            services.AddScoped<PainelRepository, PainelRepository>();

            services.AddScoped<SiteController, SiteController>();
            services.AddScoped<SiteService, SiteService>();
            services.AddScoped<SiteRepository, SiteRepository>();

            //Configurando os usuarios autenticados
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<AuthenticatedUser>();

            services.AddCors();
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "server", Version = "v1" });

                // // Definindo o caminho de comentários para o Swagger.
                // var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                // var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                // c.IncludeXmlComments(xmlPath);

                // Include 'SecurityScheme' to use JWT Authentication
                var jwtSecurityScheme = new OpenApiSecurityScheme
                {
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Name = "JWT Authentication",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Description = "Colocar apenas o token, sem o Bearer no início",

                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                c.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                { jwtSecurityScheme, Array.Empty<string>() }

                });
            });

            // //Configurando o JWT
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            services.AddAuthentication(x =>
            {
                //forçando para trabalhar com token na autenticação dos usuarios
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        // Este método é chamado pelo tempo de execução. Use este método para configurar o pipeline de solicitação HTTP.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "server v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
