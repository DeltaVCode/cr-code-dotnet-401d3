using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class StudentsController : Controller
    {
        // GET: StudentsController
        public ActionResult Index()
        {
            var students = new[]{
                new Student
                {
                    Id = 1,
                    FirstName = "Keith",
                    LastName = "Dahlby",
                },
                new Student
                {
                    Id = 2,
                    FirstName = "Stacey",
                    LastName = "Teltser",
                },
            };
            return View(students);
        }

        // GET: StudentsController/Details/5
        public ActionResult Details(int id)
        {
            var student = new Student
            {
                FirstName = "Bob",
                LastName = "Barker",
                Id = id,
            };
            return base.View(student);
        }

        // GET: StudentsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentsController/Create
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

        // GET: StudentsController/Edit/5
        public ActionResult Edit(int id)
        {
            var student = new Student
            {
                FirstName = "Edit",
                LastName = "Me",
                Id = id,
            };
            return View(student);
        }

        // POST: StudentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Student student)
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

        // GET: StudentsController/Delete/5
        public ActionResult Delete(int id)
        {
            // TODO: Go to database (via repo) instead
            var student = new Student
            {
                FirstName = "Delete",
                LastName = "Me",
                Id = id,
            };
            return View();
        }

        // POST: StudentsController/Delete/5
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
