using System;
using System.Collections.Generic;
using Library1.Models;
using Microsoft.EntityFrameworkCore;

namespace Library1.Data
{
	public class ApplicationDbContext : DbContext
    {
		public ApplicationDbContext()
		{
		}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)  // ctor
        {
        }


        public DbSet<Category> Categories { get; set; }   //cateagories is the table name

    }
}

