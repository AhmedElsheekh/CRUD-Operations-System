using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Entities
{
	public class Employee : BaseEntity
	{
		public int Id { get; set; }
		[MaxLength(50)]
		public string Name { get; set; }
		public string Address { get; set; }
		[DataType(DataType.Currency)]
		public double Salary { get; set; }
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
		public bool IsActive { get; set; }
		public DateTime HireDate { get; set; } = DateTime.Now;
		public Department Department { get; set; }
		public int DepartmentId { get; set; }
		public string? ImageUrl { get; set; }
	}
}
