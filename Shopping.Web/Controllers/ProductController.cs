﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shopping.Web.Models;
using Shopping.Web.Services.IServices;
using Shopping.Web.Utils;

namespace Shopping.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [Authorize]
        public async Task<IActionResult> ProductIndex()
        {
            var products = await _productService.FindAllProducts();
            return View(products);
        }        
        public IActionResult ProductCreate()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductViewModel model)
        {
            if (ModelState.IsValid) 
            {
                var token = await HttpContext.GetTokenAsync("access_token");
                var response = await _productService.CreateProduct(model, token!);
                if(response is ProductViewModel and { Name: not null})
                    return RedirectToAction(nameof(ProductIndex));
            }
            return View(model);
        }
        [Authorize]
        public async Task<IActionResult> ProductUpdate(int id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var model = await _productService.FindProductById(id, token!);
            if (model is ProductViewModel and {Name: not null }) 
                return View(model);

            return NotFound();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ProductUpdate(ProductViewModel model)
        {
            if (ModelState.IsValid) 
            {
                var token = await HttpContext.GetTokenAsync("access_token");
                var response = await _productService.UpdateProduct(model, token!);
                if(response is ProductViewModel and { Name: not null})
                    return RedirectToAction(nameof(ProductIndex));
            }
            return View(model);
        }
        [Authorize]
        public async Task<IActionResult> ProductDelete(int id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var model = await _productService.FindProductById(id, token!);
            if (model is ProductViewModel and {Name: not null }) 
                return View(model);

            return NotFound();
        }
        
        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> ProductDelete(ProductViewModel model)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _productService.DeleteProductById(model.Id, token!);
            if(response)
                return RedirectToAction(nameof(ProductIndex));
            return View(model);
        }
    }
}
