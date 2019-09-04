using AutoMapper.Configuration.Annotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMapperTutorial.Models
{
    public class EmberDto
    {
        public decimal Korvalamikor { get; set; }

        public string Nev { get; set; }

        public string Valami { get; set; }

        public string ResolveNev { get; set; }
    }
}
