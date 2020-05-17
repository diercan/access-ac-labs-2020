using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Entities.Base;

namespace Database.Entities
{
    [Table("OrderItem")]
    public class OrderItemEntity : SimpleEntity
    {
        [Required]
        public OrderEntity Order { get; set; }
        
        [Required]
        public MenuItemEntity Item { get; set; }
        
        [DefaultValue(1)]
        public uint Quantity { get; set; }
    }
}