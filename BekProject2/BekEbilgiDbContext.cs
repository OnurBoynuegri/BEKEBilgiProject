using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BekProject2
{
	public class BekEbilgiDbContext:DbContext
	{
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Job> Jobs { get; set; }
		public DbSet<EmployeeJob> EmployeeJobs { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=BekEbilgiDb;Trusted_Connection=True;");
		}
		
	}
}