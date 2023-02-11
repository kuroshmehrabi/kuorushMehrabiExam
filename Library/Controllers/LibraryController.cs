using Microsoft.AspNetCore.Mvc;
using Library.DTO;
using Library.Services.ServiceInterfaces;
using System;
using System.Threading.Tasks;

namespace Library.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryService _libraryService;
           public LibraryController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        // GET: Library
        [HttpGet]
        public async Task<IActionResult> Index() => ((IActionResult)await _libraryService.GetLibraries());

        [HttpGet("{id}")]

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            LibraryDTO library = await _libraryService.GetLibrary(id.Value);
            return (IActionResult)library;
        }

        //// GET: Library/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address,PhoneNumber,EmailAddress,LibraryNumber")] LibraryDTO library)
        {
            if (ModelState.IsValid)
            {
                await _libraryService.AddLibrary(library);
                return RedirectToAction(nameof(Index));
            }
            return (IActionResult)library;
        }


        [HttpPut]
        public async Task<IActionResult> Edit(int? id)
        {
            var library = await _libraryService.GetLibrary(id.Value);
            if (library == null)
            {
                return NotFound();
            }
            return (IActionResult)library; ;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,PhoneNumber,EmailAddress,LibraryNumber")] LibraryDTO library)
        {
            if (id != library.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _libraryService.UpdateLibrary(library);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
                return RedirectToAction(nameof(Index));
            }
            return (IActionResult)library;
        }

        // GET: Library/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var data = await _libraryService.GetLibrary(id.Value);
            return (IActionResult)data;
        }

        [HttpDelete, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _libraryService.RemoveLibrary(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
