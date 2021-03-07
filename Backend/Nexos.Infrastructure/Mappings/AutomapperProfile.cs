using AutoMapper;
using Nexos.Core.DTOs;
using Nexos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nexos.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Book, BookDto>();
            CreateMap<BookDto, Book>();

            CreateMap<AuthorDto, Author>();
            CreateMap<Author, AuthorDto>();

            CreateMap<EditorialDto, Editorial>();
            CreateMap<Editorial, EditorialDto>();

        }
    }
}
