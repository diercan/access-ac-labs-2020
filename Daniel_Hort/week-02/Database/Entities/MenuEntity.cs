using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Entities.Base;
using Domain.Models;

namespace Database.Entities
{
    [Table("Menu")]
    public class MenuEntity : BaseEntity
    {
        [Required]
        public MenuType Type { get; set; }
        
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        
        public List<MenuItemEntity> Items { get; set; }
        
        [Required]
        public RestaurantEntity Restaurant { get; set; } 
    }
}
