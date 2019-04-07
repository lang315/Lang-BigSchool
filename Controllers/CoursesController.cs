using Lang_BigSchool.Models;
using Lang_BigSchool.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lang_BigSchool.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public CoursesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        // GET: Courses
        public ActionResult Create()
        {
            var viewModel = new CourseViewModel()
            {
                Categories = _dbContext.Categories.ToList(),
                Heading = "Add Courses"
            };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseViewModel viewModel)
        {
            //var viewModel = new CourseViewModel
            //{
            //    Categories = _dbContext.Categories.ToList()
            //};
            //return View(viewModel);
            //if (!ModelState.IsValid)
            //{
            //    viewModel.Categories = _dbContext.Categories.ToList();
            //    return View("Create", viewModel);
            //}

            var course = new Course
            {
                LecturerID = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                CategroyID = viewModel.Category,
                Place = viewModel.Place,
            };
            _dbContext.Courses.Add(course);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}