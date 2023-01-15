using API.Services;
using Client.Clients;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services;
public static class DependencyInjection
{
    public static void ConfigureApplication(this IServiceCollection services)
    {
        services.AddHttpClient<IIMDBClient, IMDBClient>();
        services.AddTransient<IMovieService, MovieService>();

    }
}
