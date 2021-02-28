using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace JobTo.Commom.Models
{
    public partial class Product
    {
        public Product()
        {
            QuoteProducts = new HashSet<QuoteProduct>();
        }
        [Key]
        public long? Grid { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Code { get; set; }
        public decimal? PurchasePrice { get; set; }
        public decimal? SalePrice { get; set; }
        public char? ProductType { get; set; }
        [Display(Description = "Units of Measurement")]
        public string Uom { get; set; }
        public char? Flag { get; set; }
        public bool NegativeStock { get; set; }

        public virtual ICollection<QuoteProduct> QuoteProducts { get; set; }
    }
}
