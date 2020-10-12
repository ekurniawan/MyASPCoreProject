using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyASPCoreProject.DAL;
using MyASPCoreProject.Models;

namespace MyASPCoreProject.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        private ICourse _course;
        public CourseController(ICourse course)
        {
            _course = course;
        }

        // GET: CourseController
        [AllowAnonymous]
        public ActionResult Index()
        {
            var models = _course.GetAll();
            return View(models);
        }

        // GET: CourseController/Details/5
        public ActionResult Details(int id)
        {
            var model = _course.GetById(id.ToString());
            return View(model);
        }

        // GET: CourseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course course)
        {
            try
            {
                var result = _course.Insert(course);
                return Content("Data berhasil ditambah");
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _course.GetById(id.ToString());
            return View(model);
        }

        // POST: CourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Course course)
        {
            try
            {
                var result = _course.Update(course);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: CourseController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _course.GetById(id.ToString());
            return View(model);
        }

        // POST: CourseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            try
            {
                _course.Delete(id.ToString());
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View();
            }
        }
    }
}
