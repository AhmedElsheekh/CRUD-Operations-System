using Demo.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Demo.DAL.Entities;
using AutoMapper;
using Demo.PL.Models.Department_DTO;

namespace Demo.PL.Controllers
{
	public class DepartmentController : Controller
	{
		//private readonly IDepartmentRepository _departmentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DepartmentController> _loger;
        private readonly IMapper _mapper;

        public DepartmentController(IUnitOfWork unitOfWork,
			ILogger<DepartmentController> loger, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			//_departmentRepository = departmentRepository;
            _loger = loger;
            _mapper = mapper;
        }
		public IActionResult Index()
		{
			IEnumerable<Department> departments = _unitOfWork.DepartmentRepository.GetAll();

			ViewBag.Message = "Hello From View Bag";

			ViewData["Message"] = "Hellow From View Data";

			TempData["Message"] = "Hellow From Temp Data";

			TempData.Keep("Message");

			IEnumerable<DepartmentViewModel> departmentViewModels = _mapper.Map<IEnumerable<DepartmentViewModel>>(departments);

			return View(departmentViewModels);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View(new DepartmentViewModel());
		}

		[HttpPost]
		public IActionResult Create(DepartmentViewModel departmentViewModel)
		{
			if(ModelState.IsValid)
			{
				var department = _mapper.Map<Department>(departmentViewModel);

                _unitOfWork.DepartmentRepository.Add(department);

				_unitOfWork.Complete();

				TempData["CreateMessage"] = "Department has been created successfully";
				TempData.Keep("CreateMessage");

                return RedirectToAction(nameof(Index));
            }

			return View(departmentViewModel);
		}

		public IActionResult Details(int? id)
		{
			try
			{
				if (id is null)
					return BadRequest();

                var department = _unitOfWork.DepartmentRepository.GetById(id);

				if (department is null)
					return NotFound();

				var departmentViewModel = _mapper.Map<DepartmentViewModel>(department);

                return View(departmentViewModel);
            }
			catch(Exception ex)
			{
				_loger.LogError(ex.Message);
				return RedirectToAction("Error", "Home");
			}
	
		}

		[HttpGet]
		public IActionResult Delete(int? id)
		{
			try
			{
				if (id is null)
					return BadRequest();

				var department = _unitOfWork.DepartmentRepository.GetById(id);

				if (department is null)
					return NotFound();

				var departmentViewModel = _mapper.Map<DepartmentViewModel>(department);

				return View(departmentViewModel);
            }
            catch (Exception ex)
			{
				_loger.LogError(ex.Message);
				return RedirectToAction("Error", "Home");
			}

		}

		[HttpPost]
		public IActionResult Delete(DepartmentViewModel departmentViewModel)
		{
			var department = _mapper.Map<Department>(departmentViewModel);

			_unitOfWork.DepartmentRepository.Delete(department);

			_unitOfWork.Complete();

			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public IActionResult Update(int? id)
		{
            try
            {
                if (id is null)
                    return BadRequest();

                var department = _unitOfWork.DepartmentRepository.GetById(id);

                if (department is null)
                    return NotFound();

				var departmentViewModel = _mapper.Map<DepartmentViewModel>(department);

                return View(departmentViewModel);
            }
            catch (Exception ex)
            {
                _loger.LogError(ex.Message);
                return RedirectToAction("Error", "Home");
            }
        }

		[HttpPost]
		public IActionResult Update(DepartmentViewModel departmentViewModel)
		{
			var department = _mapper.Map<Department>(departmentViewModel);

			_unitOfWork.DepartmentRepository.Update(department);

			_unitOfWork.Complete();

			return RedirectToAction(nameof(Index));
		}
	}
}
