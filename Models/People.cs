using System;
using System.ComponentModel.DataAnnotations;

namespace JobTo.Common.Models
{
    public class People
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public DateTime? Birthday { get; set; }
    }
}
