using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessoSeletivoTotvs.API.Authorization
{
    public class CorsConfiguration
    {
        public static void AddCors(IServiceCollection services)
        {
            services.AddCors(
                s => s.AddPolicy("DefaultPolicy",
                builder =>
                {
                    builder.AllowAnyOrigin()  
                           .AllowAnyMethod()  
                           .AllowAnyHeader(); 
                }));
        }

        public static void UseCors(IApplicationBuilder app)
        {
            //aplicando a politica CORS definida.
            app.UseCors("DefaultPolicy");
        }
    }
}
