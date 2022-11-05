using BackEnd_BD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackEnd_BD.Controllers
{
    public class AlumnosController : Controller
    {
        // GET: Alumnos
        public ActionResult Index()
        {
            using (AlumnoDbContext dbAlumnos = new AlumnoDbContext())
            {
                //select * from alumnos

                return View(dbAlumnos.Alumnos.ToList());
            }
        }

        public ActionResult Details(int id)
        {
            using (AlumnoDbContext dbAlumnos = new AlumnoDbContext()) 
            {
                Alumnos alumnos = dbAlumnos.Alumnos.Find(id);
                if(alumnos == null)
                {
                    return HttpNotFound();
                }
                return View(alumnos);
                
            }
        }

        public ActionResult Edit(int? id)
        {
            using (AlumnoDbContext dbAlumnos = new AlumnoDbContext())
            {
                return View(dbAlumnos.Alumnos.Where(x => x.Id == id).FirstOrDefault());
             };
        }
        public ActionResult Delete(int? id)
        {
            using (AlumnoDbContext dbAlumnos = new AlumnoDbContext())
            {
                return View(dbAlumnos.Alumnos.Where(x => x.Id == id).FirstOrDefault());
            }

        }
        [HttpPost]
        public ActionResult Delete(Alumnos alum, int id)
        {
            using (AlumnoDbContext dbAlumnos = new AlumnoDbContext())
            {
                Alumnos al = dbAlumnos.Alumnos.Where(x => x.Id == id).FirstOrDefault();
                dbAlumnos.Alumnos.Remove(al);
                dbAlumnos.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Alumnos alum)
        {
            using (AlumnoDbContext dbAlumnos = new AlumnoDbContext())
            {
                dbAlumnos.Entry(alum).State = EntityState.Modified;
                dbAlumnos.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Alumnos alum)
        {
            using (AlumnoDbContext dbAlumnos = new AlumnoDbContext())
            {
                dbAlumnos.Alumnos.Add(alum);
                dbAlumnos.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}