using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDOperationInMVC.Models;

namespace CRUDOperationInMVC.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            StudentDBHandle dbhandle = new StudentDBHandle();
            ModelState.Clear();
            return View(dbhandle.GetStudents());
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Student smodel)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    StudentDBHandle sdb = new StudentDBHandle();
                    if (sdb.AddStudent(smodel))
                    {
                        ViewBag.Message = "Student Details Added Successfully";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
     {
            StudentDBHandle sdb = new StudentDBHandle();
            return View(sdb.GetStudents().Find(smodel => smodel.Id == id));
        
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Student smodel)
        {
            try
            {
                // TODO: Add update logic here
                StudentDBHandle sdb = new StudentDBHandle();
                if (sdb.Updatedetails(smodel))
                {
                    
                    ViewBag.Message = "Updated Successfully";
                    
                }
                return View();
                
            }
            catch
            {
                return View();
            }
        }


      
        //// GET: Student/Delete/5
        public ActionResult Delete(int id )
         {
            try
            {
               
                StudentDBHandle sdb = new StudentDBHandle();
                if(sdb.deletestudent(id))
                {
                    ViewBag.AlertMsg = "Student Deleted Successfully";
                   
                }


                return RedirectToAction("Index");
               
            }
            catch
            {
                return View();
            }
        }
    }
}
