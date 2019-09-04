using AutoMapper;
using AutoMapperTutorial.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMapperTutorial.Profiles
{
    public class EmberProfile : Profile
    {
        public EmberProfile()
        {
            //MemberList.None - skippeli a validációt
            CreateMap<Ember, EmberDto>()
                .Include<Leszarmazott, LeszarmazottDto>()
                //Ignore azt amit nem akarunk mappelni így validáció nem száll el
                .ForMember(d => d.Korvalamikor, opt => opt.MapFrom(e => e.Kor))
                .ForMember(d => d.Valami, opt => opt.Ignore())
                //A NevResolver alapján adja vissza az eredményt
                .ForMember(d => d.ResolveNev, opt => opt.MapFrom<NevResolver>())
                .ReverseMap();

            CreateMap<Leszarmazott, LeszarmazottDto>()
                //Ugyanaz mint az Include csak a leszarmazott irányából.
                .IncludeBase<Ember, EmberDto>()
                .ForMember(d => d.BaratNev, opt =>
                {
                    //Ezt akkor csinálja meg ha null a barát
                    //opt.PreCondition(src => src.Barat == null);
                    opt.NullSubstitute("Sajnos nincs barátja. :/");
                })
                .ReverseMap();

            //stringet int-é konvertál egy mappingFunction-ön keresztül
            CreateMap<string, int>()
                .ConvertUsing(s => Convert.ToInt32(s));

            //string DateTime konvertálást végzi el, ahányszor stringet dateTime-ra szeretnénk konvertálni.
            CreateMap<string, DateTime>().ConvertUsing<DateTimeTypeConverter>();

            //Generikus mapper
            CreateMap(typeof(Source<>), typeof(Destination<>));
        }

        //Ezeken felül vannak a ValueConverterek ami globális, de meg kell mondanunk, hogy használni szeretnénk.
        //Before és AfterMap is van... gondolhatjuk mit csinál.
        //Lehet Attribute mappinget is használni, de kisebb a kifejező ereje
        //Dynamicet is mappel flatteninggel (pl: ViewBag-nél lehet jó)
        //Generikusokkal is megy CreateMap(typeof(Source<>), typeof(Destination<>)

        public class DateTimeTypeConverter : ITypeConverter<string, DateTime>
        {
            public DateTime Convert(string source, DateTime destination, ResolutionContext context)
            {
                return System.Convert.ToDateTime(source);
            }
        }

        public class NevResolver : IValueResolver<Ember, EmberDto, string>
        {
            public string Resolve(Ember source, EmberDto destination, string member, ResolutionContext context)
            {
                return $"{source.VezetekNev} {source.KeresztNev}";
            }
        }
    }
}
