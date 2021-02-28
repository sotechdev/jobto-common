using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace JobTo.Commom.Models
{
    public partial class PersonGroup
    {
        [Key]
        public long? Grid { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Code { get; set; }
        [Required]
        public string Name { get; set; }
        public char PersonType { get; set; }
    }
}
