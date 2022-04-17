using E_Commerce.Business.Abstract;
using E_Commerce.Entities.Concrete;
using E_Commerce.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace E_Commerce.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;


        public List<Product> TempProducts { get; set; }
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index(int page = 1, int category = 0, int seperated = 1)
        {

            int pageSize = 10;
            var products = _productService.GetByCategory(category);
            if (seperated == 1)
            {
                TempProducts = products
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .OrderBy(p => p.ProductName)
                    .ToList();
            }
            if (seperated == 2)
            {
                TempProducts = products
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .OrderByDescending(p => p.ProductName)
                    .ToList();
            }
            if (seperated == 3)
            {
                TempProducts = products
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .OrderBy(p => p.UnitPrice)
                    .ToList();
            }
            if (seperated == 4)
            {
                TempProducts = products
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .OrderByDescending(p => p.UnitPrice)
                    .ToList();
            }

            var vm = new ProductListViewModel()
            {
                Products = TempProducts,
                CurrentCategory = category
            };
            return View(vm);




        }
    }
}