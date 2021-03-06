using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Nexos.Core.Entities
{
    [Table("Author")]
    public class Author
    {
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(500)]
        public string FullName { get; set; }
        [StringLength(500)]
        public string BirthTown { get; set; }
        public DateTime? BirthDate { get; set; }
        [StringLength(500)]
        public string Email { get; set; }
    }
}
