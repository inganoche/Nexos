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

   
            CreateMap<Book, BookDtoOut>().ForMember(d=> d.NameAuthor, opt=> opt.MapFrom(x=> x.Author.FullName))
                .ForMember(d => d.NameEditorial, opt => opt.MapFrom(x => x.Editorial.Name)); ;

            CreateMap<AuthorDto, Author>();
            CreateMap<Author, AuthorDto>();

            CreateMap<EditorialDto, Editorial>();
            CreateMap<Editorial, EditorialDto>();

        }
    }
}
