using Microsoft.OpenApi.Models;

namespace WebAPI.Extensions
{
	public static class SwaggerExtensions
	{
		public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
		{
			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });

				options.AddSecurityDefinition(
					"Bearer",
					new OpenApiSecurityScheme
					{
						In = ParameterLocation.Header,
						Description = "Please enter your access token below",
						Name = "Authorization",
						Type = SecuritySchemeType.ApiKey,
						Scheme = "Bearer",
					}
				);

				options.AddSecurityRequirement(
					new OpenApiSecurityRequirement
					{
						{
							new OpenApiSecurityScheme
							{
								Reference = new OpenApiReference
								{
									Type = ReferenceType.SecurityScheme,
									Id = "Bearer",
								},
							},
							Array.Empty<string>()
						},
					}
				);
			});

			return services;
		}

		public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
		{
			var env = app.ApplicationServices.GetRequiredService<IWebHostEnvironment>();
			if (env.IsDevelopment())
			{
				app.UseStaticFiles();
				app.UseSwagger();
				app.UseSwaggerUI(c =>
				{
					c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1");
					c.InjectJavascript("/swagger-ui/show-token.js");
				});
			}

			return app;
		}
	}
}
