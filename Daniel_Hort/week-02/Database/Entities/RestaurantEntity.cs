using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Text;
using Database.Entities.Base;

namespace Database.Entities
{
    [Table("Restaurant")]
    public class RestaurantEntity : BaseEntity
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        
        public PointF Location { get; set; }
        
        public List<MenuEntity> Menus { get; set; }
    }
}
