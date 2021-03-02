using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace EFCodeFirstTut.Models {
	public class AppDbContext : DbContext {

		public DbSet<Customer> Customers { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Item> Items { get; set; }
		public DbSet<Orderline> Orderlines { get; set; }

		public AppDbContext() { }

		protected override void OnConfiguring(DbContextOptionsBuilder builder) {
			if (!builder.IsConfigured) {
				var connectionString = "server=localhost\\sqlexpress;"+
					"database=AppDb1;"+
					"trusted_connection=true;";
				builder.UseSqlServer(connectionString);
			}
		}

		protected override void OnModelCreating(ModelBuilder builder) {
			// create an index for the table?
			builder.Entity<Customer>(cust => {
				cust.HasIndex(x => x.Code).IsUnique(true); //config/get idx for customers to use for code column. each Unique
			});
		}


	}
}
// PM> add-migration "Initialization" // Can be named anything but shoul be descriptive
// PM> Update-database