using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyASPCoreProject.DAL;
using MyASPCoreProject.Models;

namespace MyASPCoreProject.Controllers
{
    public class StudentController : Controller
    {
        private IStudentDAL _student;
        public StudentController(IStudentDAL student)
        {
            _student = student;
        }

        // GET: StudentController
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("User")))
            {
                TempData["Pesan"] = "<span class='alert alert-danger'>Anda belum login/span>";
                return RedirectToAction("Login", "User");
            }
            else
                TempData["Pesan"] = string.Empty;

            if (TempData["Pesan"] != null)
                ViewBag.Pesan = TempData["Pesan"];

            var model = _student.GetAll().ToList();
            return View(model);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(string id)
        {
            var model = _student.GetById(id);
            return View(model);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            try
            {
                var result = _student.Insert(student);
                if (result == 1)
                {
                    TempData["Pesan"] = $"<span class='alert alert-success'>Berhasil menambah data student {student.Nama}</span><br/><br />";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.PesanError = $"<span class='alert alert-danger'>Gagal menambah data student {student.Nama}</span>";
                    return View();
                }
            }
            catch(Exception ex)
            {
                ViewBag.PesanError = $"<span class='alert alert-danger'>{ex.Message}</span>";
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(string id)
        {
            var model = _student.GetById(id);
            return View(model);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            try
            {
                var result = _student.Update(student);
                if (result == 1)
                {
                    TempData["Pesan"] = $"<span class='alert alert-success'>Berhasil mengupdate data student {student.Nama}</span><br/><br />";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.PesanError = $"<span class='alert alert-danger'>Gagal mengupdate data student {student.Nama}</span>";
                    return View();
                }
            }
            catch(Exception ex)
            {
                ViewBag.PesanError = $"<span class='alert alert-danger'>{ex.Message}</span>";
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(string id)
        {
            var model = _student.GetById(id);
            return View(model);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeletePost(string id)
        {
            try
            {
                var result = _student.Delete(id);
                if (result == 1)
                {
                    TempData["Pesan"] = $"<span class='alert alert-success'>Berhasil mendelete data nim:{id}</span><br/><br />";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.PesanError = $"<span class='alert alert-danger'>Gagal mendelete data student</span>";
                    return View();
                }
            }
            catch(Exception ex)
            {
                ViewBag.PesanError = $"<span class='alert alert-danger'>{ex.Message}</span>";
                return View();
            }
        }
    }
}
