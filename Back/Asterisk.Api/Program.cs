using Asterisk.Domain.Handlers.Alerts;
using Asterisk.Domain.Handlers.Authentications;
using Asterisk.Domain.Handlers.Lines;
using Asterisk.Domain.Handlers.Temperatures;
using Asterisk.Domain.Handlers.Users;
using Asterisk.Domain.Interfaces;
using Asterisk.Infra.Data.Contexts;
using Asterisk.Infra.Data.Repositories;
using Asterisk.Shared.Services;
using Asterisk.Shared.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.Net;

namespace Asterisk.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddTransient<IMailService, MailService>();
            builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));

            builder.Services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Asterisk.Api", Version = "v1" });
            });

            builder.Services.AddDbContext<AsteriskContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            })
            .AddJwtBearer("JwtBearer", options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("avanade-authentication-key")),
                    ClockSkew = TimeSpan.FromMinutes(30),
                    ValidIssuer = "asterisk",
                    ValidAudience = "asterisk"
                };
            });

            builder.Services.AddHttpsRedirection(options =>
            {
                options.RedirectStatusCode = (int)HttpStatusCode.TemporaryRedirect;
                options.HttpsPort = 5001;
            });

            // Users
            builder.Services.AddTransient<IUserRepository, UserRepository>();
            builder.Services.AddTransient<LoginHandle, LoginHandle>();
            builder.Services.AddTransient<CreateAccountHandle, CreateAccountHandle>();
            builder.Services.AddTransient<DeleteAccountHandle, DeleteAccountHandle>();
            builder.Services.AddTransient<UpdateAccountHandle, UpdateAccountHandle>();
            builder.Services.AddTransient<ListAccountHandle, ListAccountHandle>();
            builder.Services.AddTransient<SearchByEmailHandle, SearchByEmailHandle>();
            builder.Services.AddTransient<SearchByIdHandle, SearchByIdHandle>();

            // Alerts
            builder.Services.AddTransient<IAlertRepository, AlertRepository>();
            builder.Services.AddTransient<CreateAlertHandle, CreateAlertHandle>();
            builder.Services.AddTransient<ListAlertHandle, ListAlertHandle>();
            builder.Services.AddTransient<ListByOrderHandle, ListByOrderHandle>();

            // Temperatures
            builder.Services.AddTransient<ITemperatureRepository, TemperatureRepository>();
            builder.Services.AddTransient<CreateTemperatureHandle, CreateTemperatureHandle>();
            builder.Services.AddTransient<ReadTemperaturesHandle, ReadTemperaturesHandle>();

            // Lines
            builder.Services.AddTransient<ILineRepository, LineRepository>();
            builder.Services.AddTransient<ReadLinesHandle, ReadLinesHandle>();
            builder.Services.AddTransient<EditLinePositionHandle, EditLinePositionHandle>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Asterisk.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseStaticFiles();

            app.UseCors("CorsPolicy");

            app.MapControllers();

            app.Run();
        }
    }
}
