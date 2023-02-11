using Microsoft.AspNetCore.Mvc;
using Library.Services.ServiceInterfaces;
using System.Threading.Tasks;
using System;
using Library.DTO;
using MLibrary.DTO;

namespace Library.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleService _userRoleServic;
        public UserRoleController(IUserRoleService userRoleService)
        {
            _userRoleServic = userRoleService;
        }

        public async Task<IActionResult> Index() => (IActionResult)(await _userRoleServic.GetUserRoleies());

        public async Task<IActionResult> Details(int? id)
        {
            UserRoleDTO userRole = await _userRoleServic.GetUserRole(id.Value);
            return (IActionResult)(userRole);
        }

        //public IActionResult Create()
        //{
        //    return View();
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] UserRoleDTO userRole)
        {
            if (ModelState.IsValid)
            {
                await _userRoleServic.AddUserRole(userRole);
                return RedirectToAction(nameof(Index));
            }
            return (IActionResult)(userRole);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            var userRole = await _userRoleServic.GetUserRole(id.Value);
            if (userRole == null)
            {
                return NotFound();
            }
            return (IActionResult)(userRole);
        }


        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] UserRoleDTO userRole)
        {
            if (id != userRole.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _userRoleServic.UpdatUserRole(userRole);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
                return RedirectToAction(nameof(Index));
            }
            return (IActionResult)(userRole);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var data = await _userRoleServic.GetUserRole(id.Value);
            return (IActionResult)(data);
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletConfirmed(int id)
        {
            await _userRoleServic.RemoveUserRole(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
