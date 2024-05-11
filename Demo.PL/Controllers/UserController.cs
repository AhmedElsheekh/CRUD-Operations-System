using AutoMapper;
using Demo.DAL.Entities;
using Demo.PL.Models.User_DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo.PL.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly ILogger<UserController> _logger;

        public UserController(
            UserManager<ApplicationUser> userManager,
            IMapper mapper,
            ILogger<UserController> logger)
        {
            _userManager = userManager;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IActionResult> Index(string SearchValue = "")
        {
            IEnumerable<ApplicationUser> users;
            IEnumerable<UserViewModel> userViewModels;

            if (string.IsNullOrEmpty(SearchValue))
                users = await _userManager.Users.ToListAsync();
            else
                users = await _userManager.Users.Where(user => user.NormalizedEmail.Trim().Contains(
                    SearchValue.Trim().ToUpper())).ToListAsync();

            userViewModels = _mapper.Map<IEnumerable<UserViewModel>>(users);

            return View(userViewModels);
        }

        public async Task<IActionResult> Details(string id, string viewName = "Details")
        {
            if (id is null)
                return NotFound();

            var user = await _userManager.FindByIdAsync(id);

            if (user is null)
                return NotFound();

            UserViewModel userViewModel = _mapper.Map<UserViewModel>(user);

            return View(userViewModel);
        }

        public async Task<IActionResult> Update(string id)
        {
            return await Details(id, "Update");
        }
        [HttpPost]
        public async Task<IActionResult> Update(string id, UserViewModel userViewModel)
        {
            if (id != userViewModel.Id)
                return NotFound();

            if(ModelState.IsValid)
            {
                try
                {
                    var user = await _userManager.FindByIdAsync(id);

                    user.UserName = userViewModel.Username;
                    user.NormalizedUserName = userViewModel.Username.ToUpper();

                    var result = await _userManager.UpdateAsync(user);

                    if (result.Succeeded)
                        return RedirectToAction("Index");

                    foreach(var error in result.Errors)
                    {
                        _logger.LogError(error.Description);
                        ModelState.AddModelError("", error.Description);
                    }
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex.Message);
                }
            }

            return View(userViewModel);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id is null)
                return NotFound();

            try
            {
                var user = await _userManager.FindByIdAsync(id);

                if (user is null)
                    return NotFound();

                var result = await _userManager.DeleteAsync(user);

                if (result.Succeeded)
                    return RedirectToAction("Index");

                foreach(var error in result.Errors)
                {
                    _logger.LogError(error.Description);
                    ModelState.AddModelError("", error.Description);
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return RedirectToAction("Index");
        }

    }
}
