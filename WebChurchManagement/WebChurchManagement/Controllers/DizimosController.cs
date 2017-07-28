using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebChurchManagement.Models;

namespace WebChurchManagement.Controllers
{
    [RoutePrefix("Dizimos")]
    public class DizimosController : Controller
    {
        private WebChurchManagementContext db = new WebChurchManagementContext();

        // GET: Dizimos
        public ActionResult Index()
        {
            return View(db.Dizimos);
        }

        // GET: Dizimos/Details/5
        [Route("Detalhes/{id}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dizimo dizimo = db.Dizimos.Find(id);
            if (dizimo == null)
            {
                return HttpNotFound();
            }
            return View(dizimo);
        }

        // GET: Dizimos/Create
        [Route("Inserir")]
        public ActionResult Create()
        {
            ViewBag.Id_Membros = new SelectList(db.Membros, "Id_Membros", "Nome");
            return View();
        }

        // POST: Dizimos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Inserir")]
        public ActionResult Create([Bind(Include = "Id_Dizimo,Id_Membros,Mes_Ref,Dt_Mov,Vl_Dizimo")] Dizimo dizimo)
        {
            if (ModelState.IsValid)
            {
                db.Dizimos.Add(dizimo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dizimo);
        }

        // GET: Dizimos/Edit/5
        [Route("Editar/{id}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dizimo dizimo = db.Dizimos.Find(id);
            if (dizimo == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Membros = new SelectList(db.Membros, "Id_Membros", "Nome", dizimo.Id_Membros);
            return View(dizimo);
        }

        // POST: Dizimos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Editar")]
        public ActionResult Edit([Bind(Include = "Id_Dizimo,Id_Membros,Mes_Ref,Dt_Mov,Vl_Dizimo")] Dizimo dizimo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dizimo).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dizimo);
        }

        // GET: Dizimos/Delete/5
        [Route("Deletar/{id}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dizimo dizimo = db.Dizimos.Find(id);
            if (dizimo == null)
            {
                return HttpNotFound();
            }
            return View(dizimo);
        }

        // POST: Dizimos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Deletar/{id}")]
        public ActionResult DeleteConfirmed(int id)
        {
            Dizimo dizimo = db.Dizimos.Find(id);
            db.Dizimos.Remove(dizimo);
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
