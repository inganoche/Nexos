using Microsoft.EntityFrameworkCore;
using Nexos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nexos.Infrastructure.Data
{
   public class NexosContext: DbContext
    {
        public NexosContext(DbContextOptions<NexosContext> options) : base(options) { }
        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<Author> Author { get; set; }
        public virtual DbSet<Editorial> Editorial { get; set; }
    }
}
