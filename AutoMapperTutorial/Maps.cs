using AutoMapper;
using AutoMapperTutorial.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapperTutorial.Extensions;
using AutoMapperTutorial.Data;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Shouldly;
using AutoMapper.QueryableExtensions;
using AutoMapper.EntityFrameworkCore;

namespace AutoMapperTutorial
{
    public class Maps
    {
        private readonly IMapper mapper;

        public Maps(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async Task SimpleMap()
        {
            Ember ember;
            using (var context = new ApplicationDbContext())
            {
                ember = await context.Emberek.FirstAsync();
            }

            var emberDto = mapper.Map<EmberDto>(ember);
            emberDto.Kor.ShouldBe(20);
            emberDto.Nev.ShouldBe("Kovács József");

            emberDto.WriteToConsole();
        }

        public async Task LeszarmazottMap()
        {
            Leszarmazott leszarmazott;
            using (var context = new ApplicationDbContext())
            {
                leszarmazott = await context.Leszarmazottak.FirstAsync();
            }

            //Ha beadunk neki egy ember listát amiben leszármazottak vannak, akkor 
            //a leszármazottakat automatikusan leszarmazottDto-ra fogja mappelni.
            var leszarmazottDto = mapper.Map<LeszarmazottDto>(leszarmazott);
            leszarmazottDto.ShouldBeOfType<LeszarmazottDto>();

            if (leszarmazott.Barat == null)
            {
                leszarmazottDto.BaratNev.ShouldBe("Sajnos nincs barátja. :/");
            }
            else
            {
                leszarmazottDto.BaratNev.ShouldBe("Barátom");
            }

            leszarmazottDto.WriteToConsole();
        }

        public void ConverterMap()
        {
            var dateString = "2019.01.01.";
            var date = mapper.Map<DateTime>(dateString);

            date.ShouldNotBeNull();
            date.ShouldBeOfType<DateTime>();
            date.Year.ShouldBe(2019);
            date.Month.ShouldBe(1);
            date.Day.ShouldBe(1);

            Console.WriteLine(date.ToString("yyyy.MM.dd."));

            var intString = "123";
            var intNumber = mapper.Map<int>(intString);

            intNumber.ShouldBe(123);

            Console.WriteLine(intNumber);
        }

        public async Task ResolverMap()
        {
            Ember ember;
            using (var context = new ApplicationDbContext())
            {
                ember = await context.Emberek.FirstAsync();
            }

            var emberDto = mapper.Map<EmberDto>(ember);
            emberDto.ResolveNev.ShouldBe(emberDto.Nev);

            emberDto.WriteToConsole();
        }

        public async Task ProjectToMap()
        {
            using (var context = new ApplicationDbContext())
            {
                //var entities = await context.Emberek
                //    .Where(e => e.Kor == 30)
                //    .ProjectTo<EmberDto>(mapper.ConfigurationProvider)
                //    .ToListAsync();

                //context.Emberek.Persist().Remove(new EmberDto()
                //{
                //    Kor = 30,
                //    Nev = "Kovács József",
                //    ResolveNev = "Kovács József"
                //});

                //await context.SaveChangesAsync();
            }
        }
    }
}
