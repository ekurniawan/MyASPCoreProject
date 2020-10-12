using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyASPCoreProject.DAL;

namespace MyASPCoreProject.Controllers
{
    public class EnrollmentController : Controller
    {
        private IEnrollment _enrollment;
        public EnrollmentController(IEnrollment enrollment)
        {
            _enrollment = enrollment;
        }

        // GET: EnrollmentController
        public ActionResult Index()
        {
            var models = _enrollment.GetAll();
            return View(models);
        }

        // GET: EnrollmentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EnrollmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EnrollmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EnrollmentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EnrollmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EnrollmentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EnrollmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
