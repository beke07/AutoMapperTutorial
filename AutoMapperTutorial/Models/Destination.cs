using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMapperTutorial.Models
{
    public class Destination<T>
    {
        public T Value { get; set; }
    }
}
