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
    public class UserController : Controller
    {
        private IUser _user;
        public UserController(IUser user)
        {
            _user = user;
        }
        // GET: UserController1cs
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            var cek = _user.CekLogin(user);
            if (cek)
            {
                HttpContext.Session.SetString("User", user.Username);
                TempData["Pesan"] = string.Empty;
                return RedirectToAction("Index","Student");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        // GET: UserController1cs/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController1cs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController1cs/Create
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

        // GET: UserController1cs/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController1cs/Edit/5
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

        // GET: UserController1cs/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController1cs/Delete/5
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
