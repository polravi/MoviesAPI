using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoviesAPI.BusinessLayer;
using MoviesAPI.DB;
using MoviesAPI.Interfaces;
using System;

namespace MoviesAPI.IOC
{
    public static class Container
    {
        public static IServiceCollection extendedServicesInjector(this IServiceCollection services,IConfiguration configuration)
        {
            //services.AddScoped<IMoviesContext, MoviesContext>();
            services.AddScoped<IMoviesBL, MoviesBL>();
            services.AddScoped<IUserRatingBL, UserRatingBL>();
            services.AddDbContext<MoviesContext>(
                option =>
                option.UseSqlServer(configuration.GetConnectionString("MovieServiceEntities"))
            );

            //We can add swagger plugin here 
            return services;
        }

        public static IApplicationBuilder extendedApplicationBuilderInjector(this IApplicationBuilder builder)
        {
            //We can inject SwaggerUI and start using swagger by calling UseSwagger method
            return builder;
        }
    }
}
