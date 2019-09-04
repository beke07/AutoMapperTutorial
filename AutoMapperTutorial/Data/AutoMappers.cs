using AutoMapper;
using AutoMapper.EquivalencyExpression;
using AutoMapperTutorial.Models;
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
            var configuration = new MapperConfiguration(cfg => {
                //Ha ez nincs beállítva akkor üres listát csinál a null helyett
                //hogyha a source is null volt, ha be van akkor null-t.
                cfg.AllowNullCollections = true;
                //Egy adott típus adott property-jét tudjuk vele manipulálni.
                //cfg.ValueTransformers.Add<EmberDto>(val => typeof());
                cfg.ValueTransformers.Add<string>(val => val + "??!!!");

                cfg.AddProfile(typeof(EmberProfile));
            });

            configuration.AssertConfigurationIsValid();

            return configuration;
        }

        public static Maps InitMaps()
        {
            var configuration = InitConfiguration();
            return new Maps(configuration.CreateMapper());
        }
    }
}
