using Demo.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Demo.DAL.Entities;
using Demo.PL.Models.Employee_DTO;
using AutoMapper;
using Demo.PL.Helper;

namespace Demo.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public EmployeeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
			_mapper = mapper;
		}

        public IActionResult Index(string searchValue = "")
        {
            IEnumerable<Employee> employees;
            IEnumerable<EmployeeViewModel> employeeViewModels;



			if (string.IsNullOrEmpty(searchValue))
                employees = _unitOfWork.EmployeeRepository.GetAll();
            else
                employees = _unitOfWork.EmployeeRepository.Search(searchValue);

            //List<EmployeeViewModel> employeeViewModels = new List<EmployeeViewModel>();

            ////Manual Mapping
            //foreach (var item in employees)
            //{
            //    employeeViewModels.Add(new EmployeeViewModel()
            //    {
            //        Address = item.Address,
            //        DepartmentId = item.DepartmentId,
            //        Email = item.Email,
            //        HireDate = item.HireDate,
            //        Id = item.Id,
            //        IsActive = item.IsActive,
            //        Name = item.Name,
            //        Salary = item.Salary
            //    });
            //}

            employeeViewModels = _mapper.Map<IEnumerable<EmployeeViewModel>>(employees);

            return View(employeeViewModels);
        }

        public IActionResult Create()
        {
            ViewBag.Departments = _unitOfWork.DepartmentRepository.GetAll();

            return View(new EmployeeViewModel());
        }

        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeViewModel)
        {
            //ModelState["Department"].ValidationState = Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid;

            if(ModelState.IsValid)
            {
                //Manual Mapping from EmployeeViewModel Object To Employee Object

                //Employee employee = new Employee()
                //{
                //    Address = employeeViewModel.Address,
                //    DepartmentId = employeeViewModel.DepartmentId,
                //    Email = employeeViewModel.Email,
                //    HireDate = employeeViewModel.HireDate,
                //    IsActive = employeeViewModel.IsActive,
                //    Name = employeeViewModel.Name,
                //    Salary = employeeViewModel.Salary
                //};

                var employee = _mapper.Map<Employee>(employeeViewModel);

                employee.ImageUrl = DocumentSettings.UploadFile(employeeViewModel.Image, "Images");

                _unitOfWork.EmployeeRepository.Add(employee);

                _unitOfWork.Complete();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Departments = _unitOfWork.DepartmentRepository.GetAll();

            return View(employeeViewModel);
        }

        public IActionResult Details(int? id)
        {
            if (id is null)
                return BadRequest();

            var employee = _unitOfWork.EmployeeRepository.GetById(id);

            if (employee is null)
                return NotFound();

            //EmployeeViewModel employeeViewModel = new EmployeeViewModel()
            //{
            //    Address = employee.Address,
            //    DepartmentId = employee.DepartmentId,
            //    Salary = employee.Salary,
            //    Name = employee.Name,
            //    IsActive = employee.IsActive,
            //    HireDate = employee.HireDate,
            //    Email = employee.Email,
            //    Id = employee.Id
            //};

            EmployeeViewModel employeeViewModel = _mapper.Map<EmployeeViewModel>(employee);


            return View(employeeViewModel);
        }

        
        public IActionResult Update(int? id)
        {
            if (id is null)
                return BadRequest();

            var employee = _unitOfWork.EmployeeRepository.GetById(id);

            if (employee is null)
                return NotFound();

            ViewBag.Departments = _unitOfWork.DepartmentRepository.GetAll();

            //EmployeeViewModel employeeViewModel = new EmployeeViewModel()
            //{
            //    Address = employee.Address,
            //    DepartmentId = employee.DepartmentId,
            //    Email = employee.Email,
            //    HireDate = employee.HireDate,
            //    Id = employee.Id,
            //    IsActive = employee.IsActive,
            //    Name = employee.Name,
            //    Salary = employee.Salary
            //};

            var employeeViewModel = _mapper.Map<EmployeeViewModel>(employee);

            return View(employeeViewModel);
        }

        [HttpPost]
        public IActionResult Update(int id, EmployeeViewModel employeeViewModel)
        {
            if (id != employeeViewModel.Id)
                return BadRequest();

            //ModelState["Department"].ValidationState = Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid;

            if(ModelState.IsValid)
            {
                //Delete the old image if exists
                if(!string.IsNullOrEmpty(employeeViewModel.ImageUrl))
                {
                    if (!DocumentSettings.DeleteFile(employeeViewModel.ImageUrl, "Images"))
                        throw new Exception("Error with employee image");
                }

       
                var employee = _mapper.Map<Employee>(employeeViewModel);

                employee.ImageUrl = DocumentSettings.UploadFile(employeeViewModel.Image, "Images");

                _unitOfWork.EmployeeRepository.Update(employee);

                _unitOfWork.Complete();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Departments = _unitOfWork.DepartmentRepository.GetAll();

            return View(employeeViewModel);
        }

        public IActionResult Delete(int? id)
        {
            if (id is null)
                return BadRequest();

            var employee = _unitOfWork.EmployeeRepository.GetById(id);

            if (employee is null)
                return NotFound();

            var employeeViewModel = _mapper.Map<EmployeeViewModel>(employee);


            return View(employeeViewModel);
        }

        [HttpPost]
        public IActionResult Delete(int id, EmployeeViewModel employeeViewModel)
        {
            if (id != employeeViewModel.Id)
                return BadRequest();

            var employee = _mapper.Map<Employee>(employeeViewModel);

            //Delete employee image if exists
            if(!string.IsNullOrEmpty(employee.ImageUrl))
            {
                if (!DocumentSettings.DeleteFile(employee.ImageUrl, "Images"))
                    throw new Exception("Could not delete employee image");
            }

   
            _unitOfWork.EmployeeRepository.Delete(employee);

            _unitOfWork.Complete();

            return RedirectToAction(nameof(Index));
        }
    }
}
