using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.CartAPI.Model
{
    [Table("Product")]
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("id")]
        public long Id { get; set; }

        [Column("name"), Required, MaxLength(150)]
        public string Name { get; set; }
        [Column("price"), Required, Range(1, 10000)]//só vai aceitar entre 1 e 10000
        public decimal Price { get; set; }
        [Column("description"), MaxLength(500)]
        public string Description { get; set; }
        [Column("category_name"), MaxLength(50)]
        public string CategoryName { get; set; }
        [Column("image_url")]
        public string ImageUrl { get; set; }
    }
}
