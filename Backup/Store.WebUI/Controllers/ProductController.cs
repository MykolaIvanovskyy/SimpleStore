﻿using Store.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.WebUI.Models;

namespace Store.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int pageSize = 4;
        public ProductController(IProductRepository reposit)
        {
            this.repository = reposit;
        }

        public ViewResult List(string category,int page=1)
        {
            ProductListViewModel model = new ProductListViewModel
            {
                Products = repository.Products
                            .Where(p => category ==null || p.Category==category)
                            .OrderBy(p => p.ProductID)
                            .Skip((page - 1) * pageSize)
                            .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemPerPage = pageSize,
                    TotalItems = category == null ? 
                    repository.Products.Count() : 
                    repository.Products.Where(p => p.Category == category).Count()
                },
                CurrentCategory=category
            };
            return View(model);
        }
    }
}