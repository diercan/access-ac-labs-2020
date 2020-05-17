using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Entities.Base;

namespace Database.Entities
{
    [Table("MenuItem")]
    public class MenuItemEntity : BaseEntity
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [DefaultValue(0)]
        public float Price { get; set; }
        
        [Required]
        public MenuEntity Menu { get; set; }

        // public FileEntity Image { get; set; }
    }
}