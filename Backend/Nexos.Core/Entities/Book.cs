using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Nexos.Core.Entities
{
    [Table("Book")]
    public class Book
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
        [ForeignKey("IdEditorial")]
        public int IdEditorial { get; set; }
        [ForeignKey("IdAuthor")]
        public int IdAuthor { get; set; }
        public virtual Author Author { get; set; }
        public virtual Editorial Editorial { get; set; }

    }
}
