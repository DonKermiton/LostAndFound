using System;
using System.Collections.Generic;
using api.Models;

namespace api.Entities
{
    public class Lost
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public DateTime LastTimeSaw { get; set; } 
                
        public string Nationality { get; set; }

        public virtual User? AddedBy { get; set; }
        public virtual List<Images>? Images { get; set; }
    }
}