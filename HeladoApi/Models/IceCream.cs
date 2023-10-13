using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeladoApi.Models
{
    [Table("IceCream", Schema = "dbo")]
    public class IceCream
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Column("sabor")]
        public string Sabor { get; set; }
        [Column("stock")]
        public int Stock { get; set; }
        [Column("precio")]
        public decimal Precio { get; set; }
    }
}
