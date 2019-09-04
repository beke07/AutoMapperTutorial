using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMapperTutorial.Models
{
    public class Ember
    {
        public Guid Id { get; set; }

        public string VezetekNev { get; set; }

        public string KeresztNev { get; set; }

        public decimal Kor { get; set; }

        public string GetNev()
        {
            return $"{VezetekNev} {KeresztNev}";
        }
    }
}
