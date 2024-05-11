using Demo.BLL.Interfaces;
using Demo.DAL.Context;
using Demo.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repositories
{
	public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
	{
		private readonly AppDbContext _context;

		public EmployeeRepository(AppDbContext context) : base(context)
		{
			_context = context;
		}

        public IEnumerable<Employee> GetEmployeesByDeptName(string DeptName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> Search(string word)
        {
            var employees = _context.Employees.Where(E => E.Name.Trim().ToLower().Contains(word.Trim().ToLower())
            || E.Email.Trim().ToLower().Contains(word.Trim().ToLower()));

            return employees;
        }
        //public int Add(Employee employee)
        //{
        //	_context.Employees.Add(employee);
        //	return _context.SaveChanges();
        //}

        //public int Delete(Employee employee)
        //{
        //	_context.Employees.Remove(employee);
        //	return _context.SaveChanges();
        //}

        //public IEnumerable<Employee> GetAll()
        //	=> _context.Employees.ToList();

        //public Employee GetById(int Id)
        //	=> _context.Employees.FirstOrDefault(emp => emp.Id == Id);

        //public int Update(Employee employee)
        //{
        //	_context.Employees.Update(employee);
        //	return _context.SaveChanges();
        //}
    }
}
