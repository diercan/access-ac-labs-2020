using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Domain.Entities
{
    public class Menu
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Menu must have name")]
        [MaxLength(200, ErrorMessage = "Menu name must be up to 200 characters")]
        public string Name { get; set; }
        public ICollection<MenuItem> MyProperty { get; set; } = new List<MenuItem>();
    }
}
