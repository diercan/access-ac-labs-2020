using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class MenuItem
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "MenuItem must have name")]
        [MaxLength(200, ErrorMessage = "Menu name must be up to 200 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "MenuItem must have a Price")]
        public double Price { get; set; }
    }
}
