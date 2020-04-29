using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database.Entities
{
    [Table("Restaurant")]
    public class RestaurantEntity : BaseEntity
    {
        [MaxLength(150)]
        public string Name { get; set; }
    }
}
