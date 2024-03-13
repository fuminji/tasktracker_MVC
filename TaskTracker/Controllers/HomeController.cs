using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaskTracker.Controllers
{
    public class HomeController : Controller
    {
        MVCTASKCRUDDBContext _context = new MVCTASKCRUDDBContext();
        public ActionResult Index()
        {
            var listofData = _context.Tasks.ToList();
            return View(listofData);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Task model)
        {
            _context.Tasks.Add(model);
            _context.SaveChanges();
            ViewBag.Message = "Data Insert Success!";
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _context.Tasks.Where(x => x.Taskid == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Task Model)
        {
            var data = _context.Tasks.Where(x => x.Taskid == Model.Taskid).FirstOrDefault();
            if (data != null)
            {
                data.TaskTitle = Model.TaskTitle;
                data.TaskDescription = Model.TaskDescription;
                data.TaskDueDate = Model.TaskDueDate;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var data = _context.Tasks.Where(x => x.Taskid == id).FirstOrDefault();
            return View(data);
        }
        public ActionResult Delete(int id)
        {
            var data = _context.Tasks.Where(x => x.Taskid == id).FirstOrDefault();
            _context.Tasks.Remove(data);
            _context.SaveChanges();
            ViewBag.Message = "Task Delete Success!";
            return RedirectToAction("Index");
        }
    }
}