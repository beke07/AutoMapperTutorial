using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMapperTutorial.Models
{
    public class LeszarmazottDto : EmberDto
    {
        public string HajSzin { get; set; }

        public string SzemSzin { get; set; }

        public string BaratNev { get; set; }
    }
}
