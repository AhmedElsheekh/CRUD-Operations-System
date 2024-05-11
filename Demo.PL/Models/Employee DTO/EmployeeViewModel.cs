using Demo.DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace Demo.PL.Models.Employee_DTO
{
    public class EmployeeViewModel
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
        public int DepartmentId { get; set; }
        public string? ImageUrl { get; set; }
        public IFormFile Image { get; set; }

    }
}
