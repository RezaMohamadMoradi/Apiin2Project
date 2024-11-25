using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using product.Models;
using product.Repository.Interfaces;

namespace product.Controllers
{
    public class productcategory : Controller
    {
        // ریپازیتوری دسته‌بندی محصولات
        private readonly icategory _icategoryRepository;
        private readonly Iproductrepository _productrepository;

        // سازنده با تزریق وابستگی
        public productcategory(icategory icategory,Iproductrepository iproductrepository)
        {
            _icategoryRepository = icategory;
            _productrepository = iproductrepository;
        }

        // اکشن برای نمایش فرم ایجاد محصول
        public async Task<IActionResult> createproduct()
        {
            // دریافت دسته‌بندی‌ها از ریپازیتوری
            var result = await _icategoryRepository.Getallcatshow();

            // بررسی موفقیت‌آمیز بودن عملیات
            if (result.issucses == true)
            {
                // تبدیل داده‌های JSON به لیست اشیاء
                var listcategory = JsonConvert.DeserializeObject<List<CategoryesDto>>(Convert.ToString(result.data));

                // تبدیل لیست به SelectListItem برای Dropdown
                var res = listcategory.Select(x => new SelectListItem()
                {
                    Text = x.name,  // نام دسته‌بندی
                    Value = x.id.ToString()  // شناسه دسته‌بندی
                }).ToList();

                // ارسال داده به ویو
                ViewBag.listcategor = res;
                return View();
            }

            // بازگشت ویو در صورت ناموفق بودن عملیات
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Createproduct(productmodel p)
        {
            try
            {
                await _productrepository.createproduct(p);
                return RedirectToAction("Index","Home");
            }
            catch (Exception)
            {
                return View(p);
                throw;
            }
        }
        [HttpGet]
        public async Task<IActionResult> showproduct()
        {
            var list =  await _productrepository.read(); 
            return View(list);
        }
        
    }
}
