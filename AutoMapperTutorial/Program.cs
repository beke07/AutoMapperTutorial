using AutoMapper;
using AutoMapperTutorial.Data;
using AutoMapperTutorial.Models;
using AutoMapperTutorial.Profiles;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace AutoMapperTutorial
{
    class Program
    {
        private static Maps maps;

        static async Task Main(string[] args)
        {
            maps = AutoMappers.InitMaps();

            //await maps.SimpleMap();
            //await maps.LeszarmazottMap();
            //maps.ConverterMap();
            //await maps.ResolverMap();
            //maps.GenericMap();

            await maps.ProjectToMap();
            Console.ReadKey();
        }
    }
}
