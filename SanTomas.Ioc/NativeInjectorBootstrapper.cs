using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SanTomas.Ioc;

public class NativeInjectorBootStrapper
{
    public static void RegisterServices(IServiceCollection services)
    {

        // services.AddSingleton<ISessionFactory>(factory =>
        // {
        //     return Fluently.Configure().Database(() =>
        //     {
        //         string connectionString = configuration.GetConnectionString("Oracle");
        //
        //         if (!(env.EnvironmentName == "Development"))
        //         {
        //             connectionString = Credenciais.GerarConnectionStringApartirDeVariaveisAmbiente(connectionString, "DB_USER_KEY", "DB_SECRET_KEY");
        //         }
        //
        //         return FluentNHibernate.Cfg.Db.OracleManagedDataClientConfiguration.Oracle10
        //                 .FormatSql()
        //                 .ShowSql()
        //                 .ConnectionString(connectionString);
        //     })
        //        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ArtistaMap>())
        //        .CurrentSessionContext("call")
        //        .BuildSessionFactory();
        // }
        //  );
        
        
        // foreach (IConfigurationSection section in listaDeApis.GetChildren())
        // {
        //     var api = section.GetValue<string>("Api");
        //     var url = section.GetValue<string>("BaseUrl");
        //     var token = section.GetValue<string>("Token");
        //
        //     services.AddHttpClient(api, httpClient =>
        //     {
        //         httpClient.BaseAddress = new Uri(url);
        //         httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        //         httpClient.DefaultRequestHeaders.Add("User-Agent", AppDomain.CurrentDomain.FriendlyName);
        //
        //         if (!string.IsNullOrWhiteSpace(token))
        //             httpClient.DefaultRequestHeaders.Add("Token_Autorizacao", token);
        //     });
        // }

        services.AddTransient<HttpResponseMessage>();
        
        services.AddAutoMapper(typeof(MainCategoriesProfile).GetTypeInfo().Assembly);

        services.AddMvc(options => { options.Filters.Add(new CultureFilter()); });

        services.Scan(scan => scan
            .FromAssemblyOf<ArtistasAppServico>()
                .AddClasses()
                    .AsImplementedInterfaces()
                    .AsSelf()
                    .WithScopedLifetime());

        services.Scan(scan => scan
            .FromAssemblyOf<ArtistasRepositorio>()
                .AddClasses()
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());

        services.Scan(scan => scan
            .FromAssemblyOf<ArtistasServico>()
                .AddClasses()
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());
    }
}