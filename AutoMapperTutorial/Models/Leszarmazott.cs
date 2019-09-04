using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AutoMapperTutorial.Models
{
    public class Leszarmazott : Ember
    {
        public string HajSzin { get; set; }

        public string SzemSzin { get; set; }

        public Barat Barat { get; set; }
    }

    public class Barat
    {
        public Guid Id { get; set; }

        public string Nev { get; set; }
    }
}
