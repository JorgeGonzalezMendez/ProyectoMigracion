using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppGestionEMS.Models;
using Microsoft.AspNet.Identity;

namespace AppGestionEMS.Controllers
{
    [Authorize(Roles = " tipoUsuario")]
    public class MisEvaluacionesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MisEvaluaciones
        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            var evaluaciones = db.Evaluaciones.Include(e => e.Curso).Include(e => e.User).Where(p => p.UserId == currentUserId);
            return View(evaluaciones.ToList());
        }

        // GET: MisEvaluaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MisEvaluaciones misEvaluaciones = db.MisEvaluaciones.Find(id);
            if (misEvaluaciones == null)
            {
                return HttpNotFound();
            }
            return View(misEvaluaciones);
        }

        // GET: MisEvaluaciones/Create
        public ActionResult Create()
        {
            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "Id");
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name");
            return View();
        }

        // POST: MisEvaluaciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CursoId,UserId,Convocatoria,Trabajo1,Trabajo2,Trabajo3,Test,Practica")] MisEvaluaciones misEvaluaciones)
        {
            if (ModelState.IsValid)
            {
                db.MisEvaluaciones.Add(misEvaluaciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "Id", misEvaluaciones.CursoId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", misEvaluaciones.UserId);
            return View(misEvaluaciones);
        }

        // GET: MisEvaluaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MisEvaluaciones misEvaluaciones = db.MisEvaluaciones.Find(id);
            if (misEvaluaciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "Id", misEvaluaciones.CursoId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", misEvaluaciones.UserId);
            return View(misEvaluaciones);
        }

        // POST: MisEvaluaciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CursoId,UserId,Convocatoria,Trabajo1,Trabajo2,Trabajo3,Test,Practica")] MisEvaluaciones misEvaluaciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(misEvaluaciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "Id", misEvaluaciones.CursoId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", misEvaluaciones.UserId);
            return View(misEvaluaciones);
        }

        // GET: MisEvaluaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MisEvaluaciones misEvaluaciones = db.MisEvaluaciones.Find(id);
            if (misEvaluaciones == null)
            {
                return HttpNotFound();
            }
            return View(misEvaluaciones);
        }

        // POST: MisEvaluaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MisEvaluaciones misEvaluaciones = db.MisEvaluaciones.Find(id);
            db.MisEvaluaciones.Remove(misEvaluaciones);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
