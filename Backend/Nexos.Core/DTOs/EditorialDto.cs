using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Nexos.Core.DTOs
{
    public class EditorialDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(800)]
        public string Address { get; set; }
        [StringLength(50)]
        public string Phone { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        public int? MaxBook { get; set; }
    }
}
