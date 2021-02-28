using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace JobTo.Commom.Models
{
    public partial class Person
    {
        public Person()
        {
            QuoteClients = new HashSet<Quote>();
            QuoteEmployees = new HashSet<Quote>();
        }
        [Key]
        public long? Grid { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Code { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime? Birthday { get; set; }
        [Required]
        public string Document { get; set; }
        public string Address { get; set; }
        public string AddressNr { get; set; }
        public string District { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string CityCode { get; set; }
        public string State { get; set; }
        public char Flag { get; set; }
        [StringLength(5, MinimumLength = 1)]
        public string PersonType { get; set; }

        public virtual ICollection<Quote> QuoteClients { get; set; }
        public virtual ICollection<Quote> QuoteEmployees { get; set; }
    }
}
