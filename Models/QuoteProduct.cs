using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace JobTo.Commom.Models
{
    public partial class QuoteProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long? Grid { get; set; }
        public long? ProductId { get; set; }
        public decimal? Price { get; set; }
        public double? Qty { get; set; }
        public string Obs { get; set; }
        public long? QuoteId { get; set; }

        public virtual Product Product { get; set; }
    }
}
