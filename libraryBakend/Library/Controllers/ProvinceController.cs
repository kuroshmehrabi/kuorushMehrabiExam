using Microsoft.AspNetCore.Mvc;
using Library.DTO;
using Library.Services.ServiceInterfaces;
using System;
using System.Threading.Tasks;

namespace Library.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProvinceController : ControllerBase
    {
        private readonly IProvinceService _provinceService;
        public ProvinceController(IProvinceService provinceService)
        {
            _provinceService = provinceService;
        }

        // GET: Province
        [HttpGet]
        public async Task<IActionResult> Index() => (IActionResult)(await _provinceService.GetProvinces());

        // GET: Province/Create
      //  public IActionResult Create()
        //{
        //    return IActionResult;
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProvinceId,ProvinceName")] ProvinceDTO province)
        {
            if (ModelState.IsValid)
            {
                await _provinceService.AddProvince(province);
                return RedirectToAction(nameof(Index));
            }
            return (IActionResult)province;
        }

        // GET: Province/Edit/5
        public async Task<IActionResult> Edit(int? provinceId)
        {
            var province = await _provinceService.GetProvince(provinceId.Value);
            if (province == null)
            {
                return NotFound();
            }
            return (IActionResult)province;
        }

        // POST: Province/Edit/5
        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int provinceId, [Bind("ProvinceId,ProvinceName")] ProvinceDTO province)
        {
            if (provinceId != province.ProvinceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _provinceService.UpdateProvince(province);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
                return RedirectToAction(nameof(Index));
            }
            return (IActionResult)province;
        }

        // GET: Province/Delete/5
        public async Task<IActionResult> Delete(int? provinceId)
        {
            var data = await _provinceService.GetProvince(provinceId.Value);
            return (IActionResult) data;
        }

        // POST: Province/Delete/5
        [HttpPut, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int provinceId)
        {
            await _provinceService.RemoveProvince(provinceId);
            return RedirectToAction(nameof(Index));
        }
    }
}
