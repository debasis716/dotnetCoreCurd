using Microsoft.AspNetCore.Mvc;
using WebApplication15.Models;
using WebApplication15.Data;
using System.Collections.Generic;

namespace WebApplication15.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {

            List<Category> objListCategory = _db.Categories.ToList();


            return View(objListCategory);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category Created Successfully";
                return RedirectToAction("Index");
            }
            return View();

        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb1 = _db.Categories.Find(id);
            //Category? categoryFromDb2 = _db.Categories.FirstOrDefault(c => c.Id == id);
            //Category? categoryFromDb3 = _db.Categories.Where(usss=>usss.Id==categoryId).FirstOrDefault();
            if (categoryFromDb1 == null)
            {
                return NotFound();
            }

            return View(categoryFromDb1);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category Update Successfully";
                return RedirectToAction("Index");
            }
            return View();

        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb1 = _db.Categories.Find(id);
            //Category? categoryFromDb2 = _db.Categories.FirstOrDefault(c => c.Id == id);
            //Category? categoryFromDb3 = _db.Categories.Where(usss=>usss.Id==categoryId).FirstOrDefault();
            if (categoryFromDb1 == null)
            {
                return NotFound();
            }

            return View(categoryFromDb1);
        }
        [HttpPost]
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["Success"] = "Category Deleted Successfully";
            return RedirectToAction("Index");


        }
    }
}
