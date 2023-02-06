using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library1.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library1.Controllers
{
    public class CategoryController : Controller
    {
        private readonly Data.ApplicationDbContext _db;
        // GET: /<controller>/

        public CategoryController(Data.ApplicationDbContext db)   //for constructor type ctor tab tab
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;   // not require in ienum.ToList(); //no select is required only db.catogories and store inlist or somethingelse; 
            return View(objCategoryList);
        }

// creating data ..........................
        //get
        public IActionResult Create()
        {
                return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Display Name cannot be same");        //server side

            }
            if (ModelState.IsValid)
            {

                try
                {
                    _db.Categories.Add(obj);
                    _db.SaveChanges();
                    TempData["success"] = "Category created successfully";
                    return RedirectToAction("Index", new { message = "Category added successfully" });

                }
                catch (Exception)
                {
                    throw;
                }
            }

            return View(obj);
           
           
        }


        //get
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFormData = _db.Categories.Find(id);
           // var categoryFormData1 = _db.Categories.FirstOrDefault(u=>u.Id == id);  //same as above
           if(categoryFormData == null)
            {
                return NotFound();
            }
            return View(categoryFormData);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Display Name cannot be same");        //server side

            }
            if (ModelState.IsValid)
            {

                try
                {
                    _db.Categories.Update(obj);
                    _db.SaveChanges();
                    return RedirectToAction("Index", new { message = "Category added successfully" });

                }
                catch (Exception)
                {
                    throw;
                }
            }

            return View(obj);


        }

        //get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFormData = _db.Categories.Find(id);
            // var categoryFormData1 = _db.Categories.FirstOrDefault(u=>u.Id == id);  //same as above
            if (categoryFormData == null)
            {
                return NotFound();
            }
            return View(categoryFormData);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id )
        {
            var obj = _db.Categories.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
                    _db.Categories.Remove(obj);
                    _db.SaveChanges();
            return RedirectToAction("Index", new { message = "Category added successfully" });
        }




    }
}

