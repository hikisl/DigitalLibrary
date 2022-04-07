using System;
using Microsoft.EntityFrameworkCore;
using DigitalLibrary.Entities;

namespace DigitalLibrary.Data
{
	public class AppContexts : DbContext
	{
		
		public DbSet<User> Users { get; set; }

		public	DbSet<Book> Books { get; set; }

        public AppContexts()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Database=LibraryDB;Trusted_Connection=True;");
		}
	}
}

