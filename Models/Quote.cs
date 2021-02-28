using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace JobTo.Commom.Models
{
    public partial class Quote
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long? Grid { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Code { get; set; }
        public long? ClientId { get; set; }
        public long? EmployeeId { get; set; }
        public decimal? TotalPrice { get; set; }

        public virtual Person Client { get; set; }
        public virtual Person Employee { get; set; }
    }
}
