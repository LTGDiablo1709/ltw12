using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneStore.Models;

namespace PhoneStore.Controllers
{
    public class CategoriesController : Controller
    {
        PhoneStoreEntities database = new PhoneStoreEntities();
        public ActionResult Index()
        {
            return View(database.Categories.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category cate)
        {
            try
            {
                database.Categories.Add(cate);
                database.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("Error Create New");
            }
        }
        public ActionResult Details(int id)
        {
            return View(database.Categories.Where(stt => stt.Id == id).FirstOrDefault());
        }

        public ActionResult Edit(int id)
        {
            return View(database.Categories.Where(s => s.Id == id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult Edit(Category info)
        {
            database.Entry(info).State = System.Data.Entity.EntityState.Modified;
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            return View(database.Categories.Where(s => s.Id == id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult Delete(int id, Category info)
        {
            try
            {
                info = database.Categories.Where(s => s.Id == id).FirstOrDefault();
                database.Categories.Remove(info);
                database.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("This data is using in other table, Error Delete !");
            }
        }
    }
}