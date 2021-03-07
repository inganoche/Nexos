using System;
using System.Collections.Generic;
using System.Text;

namespace Nexos.Core.DTOs
{
    public class BookDtoOut
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Gender { get; set; }
        public int PageNumber { get; set; }
        public string NameEditorial { get; set; }
        public string NameAuthor { get; set; }
    }
}
