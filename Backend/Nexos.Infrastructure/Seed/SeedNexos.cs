using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Nexos.Core.Entities;
using Nexos.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexos.Infrastructure.Seed
{
    public static class SeedNexos
    {

        public static void SeedNexosServerData(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<NexosContext>();
                context.Database.Migrate();

                if (!context.Author.Any())
                {
                    context.Author.Add(new Author()
                    {
                        FullName = "Gida Romo",
                        BirthTown = "Cienaga",
                        BirthDate = Convert.ToDateTime("06-12-1989"),
                        Email = "gidaromo@gmail.com"
                    });
                    context.Author.Add(new Author()
                    {
                        FullName = "Alirio Noche",
                        BirthTown = "Santa Marta",
                        BirthDate = Convert.ToDateTime("05-08-1986"),
                        Email = "ingeneironoche@gmail.com"
                    });
                    context.SaveChanges();
                }


                if (!context.Editorial.Any())
                {
                    context.Editorial.Add(new Editorial()
                    {
                        Name = "Nexos",
                        Email = "nexos@nexos-software.com",
                        Phone = "320-3567890",
                        MaxBook = 10,
                        Address = "Calle 56 no 67-23"
                    });

                    context.SaveChanges();
                }

                if (!context.Book.Any())
                {
                    context.Book.Add(new Book()
                    {
                        Title = "Libro uno",
                        Gender = "Comedia",
                        Year = 1995,
                        IdEditorial = 1,
                        IdAuthor = 1,
                        PageNumber = 30
                    });
                    context.Book.Add(new Book()
                    {
                        Title = "Libro diez",
                        Gender = "Infantil",
                        Year = 1890,
                        IdEditorial = 1,
                        IdAuthor = 2,
                        PageNumber = 300
                    });
                    context.Book.Add(new Book()
                    {
                        Title = "Libro Cuatro",
                        IdEditorial = 1,
                        Gender = "Suspenso",
                        Year = 2025,
                        IdAuthor = 1,
                        PageNumber = 30
                    });
                    context.Book.Add(new Book()
                    {
                        Title = "Libro dos",
                        IdEditorial = 1,
                        Gender = "Drama",
                        Year = 2025,
                        IdAuthor = 2,
                        PageNumber = 50
                    });
                    context.SaveChanges();
                }



            }
        }

    }
}
