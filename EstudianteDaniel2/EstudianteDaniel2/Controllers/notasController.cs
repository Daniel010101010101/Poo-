﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EstudianteDaniel2.Models;

namespace EstudianteDaniel2.Controllers
{
    public class notasController : Controller
    {
        private EstudiantesEntities db = new EstudiantesEntities();

        // GET: notas
        public ActionResult Index()
        {
            var notas = db.notas.Include(n => n.estudiante).Include(n => n.materia);
            return View(notas.ToList());
        }

        // GET: notas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            notas notas = db.notas.Find(id);
            if (notas == null)
            {
                return HttpNotFound();
            }
            return View(notas);
        }

        // GET: notas/Create
        public ActionResult Create()
        {
            ViewBag.idEstudiante = new SelectList(db.estudiante, "idEstudiante", "nombresEstudiante");
            ViewBag.idMateria = new SelectList(db.materia, "idMateria", "nombreMateria");
            return View();
        }

        // POST: notas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idNotas,idEstudiante,idMateria,nota")] notas notas)
        {
            if (ModelState.IsValid)
            {
                db.notas.Add(notas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEstudiante = new SelectList(db.estudiante, "idEstudiante", "nombresEstudiante", notas.idEstudiante);
            ViewBag.idMateria = new SelectList(db.materia, "idMateria", "nombreMateria", notas.idMateria);
            return View(notas);
        }

        // GET: notas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            notas notas = db.notas.Find(id);
            if (notas == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEstudiante = new SelectList(db.estudiante, "idEstudiante", "nombresEstudiante", notas.idEstudiante);
            ViewBag.idMateria = new SelectList(db.materia, "idMateria", "nombreMateria", notas.idMateria);
            return View(notas);
        }

        // POST: notas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idNotas,idEstudiante,idMateria,nota")] notas notas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEstudiante = new SelectList(db.estudiante, "idEstudiante", "nombresEstudiante", notas.idEstudiante);
            ViewBag.idMateria = new SelectList(db.materia, "idMateria", "nombreMateria", notas.idMateria);
            return View(notas);
        }

        // GET: notas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            notas notas = db.notas.Find(id);
            if (notas == null)
            {
                return HttpNotFound();
            }
            return View(notas);
        }

        // POST: notas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            notas notas = db.notas.Find(id);
            db.notas.Remove(notas);
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
