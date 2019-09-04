using AutoMapper;
using AutoMapper.EquivalencyExpression;
using AutoMapperTutorial.Profiles;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMapperTutorial.Data
{
    public static class AutoMappers
    {
        public static IConfigurationProvider InitConfiguration()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddDbContext<ApplicationDbContext>();
            services.AddAutoMapper(typeof(EmberProfile));
            
            var configuration = new MapperConfiguration(cfg => {
                //Ha ez nincs beállítva akkor üres listát csinál a null helyett
                //hogyha a source is null volt, ha be van akkor null-t.
                cfg.AllowNullCollections = true;
                //Egy adott típus adott property-jét tudjuk vele manipulálni.
                //cfg.ValueTransformers.Add<string>(val => val + "!!!");

                cfg.AddCollectionMappers();
                cfg.UseEntityFrameworkCoreModel<ApplicationDbContext>(services);

                cfg.AddProfile(typeof(EmberProfile));
            });

            configuration.AssertConfigurationIsValid();

            return configuration;
        }

        public static Maps InitMaps()
        {
            var configuration = InitConfiguration();
            return new Maps(new Mapper(configuration));
        }
    }
}
