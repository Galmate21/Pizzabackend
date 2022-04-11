using System;
using System.Collections.Generic;

#nullable disable

namespace Bolt.Models
{
    public partial class Termekek
    {
        public int Id { get; set; }
        public string Nev { get; set; }
        public string Leiras { get; set; }
        public int Ar { get; set; }
        public string Kep { get; set; }
    }
}
