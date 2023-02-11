using Microsoft.AspNetCore.Mvc;
using Library.DTO;
using Library.Services.ServiceInterfaces;
using System;
using System.Threading.Tasks;
using Library.Data.Models;

namespace Library.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userServic;
        public UserController(IUserService userService)
        {
            _userServic = userService;
        }
        [HttpGet]
        public async Task<IActionResult> Index() => (IActionResult)(await _userServic.GetUseries());

        public async Task<IActionResult> Details(int? id)
        {
            UserDTO user = await _userServic.GetUser(id.Value);
            return (IActionResult)user;
        }

        //public IActionResult Create()
        //{
        //    return View();
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] UserDTO user)
        {
            if (ModelState.IsValid)
            {
                await _userServic.AddUser(user);
                return RedirectToAction(nameof(Index));
            }
            return (IActionResult)user;
        }


        public async Task<IActionResult> Edit(int? id)
        {
            var user = await _userServic.GetUser(id.Value);
            if (user == null)
            {
                return NotFound();
            }
            return (IActionResult)user;
        }


        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] UserDTO user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _userServic.UpdatUser(user);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
                return RedirectToAction(nameof(Index));
            }
            return (IActionResult)user;
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var data = await _userServic.GetUser(id.Value);
            return (IActionResult)data;
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletConfirmed(int id)
        {
            await _userServic.RemoveUser(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
