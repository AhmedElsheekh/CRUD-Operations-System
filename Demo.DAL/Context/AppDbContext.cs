using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Demo.DAL.Context
{
	public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
	{
		public AppDbContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			
		}

		public DbSet<Employee> Employees { get; set; }
		public DbSet<Department> Departments { get; set; }
	}
}
