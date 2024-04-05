using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientApp.Models
{
    public class StockData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? asset_class { get; set; }
        public string? code { get; set; }
        public string? description { get; set; }
        public string? locale { get; set; }
    }
}
