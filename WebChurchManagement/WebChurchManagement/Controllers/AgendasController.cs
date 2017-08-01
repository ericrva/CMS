using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebChurchManagement.Models;

namespace WebChurchManagement.Controllers
{
    [RoutePrefix("Agendas")]
    public class AgendasController : Controller
    {
        private WebChurchManagementContext db = new WebChurchManagementContext();

        // GET: Agenda
        public ActionResult Index()
        {
            var agendas = db.Agendas.Include(a => a.Departamentos);
            return View(agendas.ToList());
        }

        // GET: Agenda/Details/5
        [Route("Detalhes/{id}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agenda agenda = db.Agendas.Find(id);
            if (agenda == null)
            {
                return HttpNotFound();
            }
            return View(agenda);
        }

        // GET: Agenda/Create
        [Route("Inserir")]
        public ActionResult Create()
        {
            ViewBag.Id_Deptos = new SelectList(db.Departamentos, "Id_Deptos", "Nm_Deptos");
            return View();
        }

        // POST: Agenda/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Inserir")]
        public ActionResult Create([Bind(Include = "Id_Agenda,Id_Deptos,Dt_Agenda,Evento,Desc_Agenda")] Agenda agenda)
        {
            if (ModelState.IsValid)
            {
                db.Agendas.Add(agenda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Deptos = new SelectList(db.Departamentos, "Id_Deptos", "Nm_Deptos", agenda.Id_Deptos);
            return View(agenda);
        }

        // GET: Agenda/Edit/5
        [Route("Editar/{id}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agenda agenda = db.Agendas.Find(id);
            if (agenda == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Deptos = new SelectList(db.Departamentos, "Id_Deptos", "Nm_Deptos", agenda.Id_Deptos);
            return View(agenda);
        }

        // POST: Agenda/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Editar/{id}")]
        public ActionResult Edit([Bind(Include = "Id_Agenda,Id_Deptos,Dt_Agenda,Evento,Desc_Agenda")] Agenda agenda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agenda).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Deptos = new SelectList(db.Departamentos, "Id_Deptos", "Nm_Deptos", agenda.Id_Deptos);
            return View(agenda);
        }

        // GET: Agenda/Delete/5
        [Route("Deletar/{id}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agenda agenda = db.Agendas.Find(id);
            if (agenda == null)
            {
                return HttpNotFound();
            }
            return View(agenda);
        }

        // POST: Agenda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Deletar/{id}")]
        public ActionResult DeleteConfirmed(int id)
        {
            Agenda agenda = db.Agendas.Find(id);
            db.Agendas.Remove(agenda);
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
