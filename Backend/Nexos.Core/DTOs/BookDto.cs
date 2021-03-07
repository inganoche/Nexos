using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Nexos.Core.DTOs
{
   public class BookDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Range(1900, 2021)]
        public int Year { get; set; }
        public string Gender { get; set; }
        public int PageNumber { get; set; }
        public int MyProperty { get; set; }
        public int IdEditorial { get; set; }
        public int IdAuthor { get; set; }
    }
}
