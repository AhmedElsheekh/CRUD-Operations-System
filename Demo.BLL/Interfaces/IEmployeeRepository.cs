using Demo.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Interfaces
{
	public interface IEmployeeRepository : IGenericRepository<Employee>
	{
		IEnumerable<Employee> Search(string word);
		IEnumerable<Employee> GetEmployeesByDeptName(string DeptName);
		//public int Add(Employee employee);
		//public Employee GetById(int Id);
		//public int Update(Employee employee);
		//public int Delete(Employee employee);
		//public IEnumerable<Employee> GetAll();
	}
}
