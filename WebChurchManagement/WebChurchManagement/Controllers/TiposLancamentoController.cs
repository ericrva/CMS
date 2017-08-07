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
    [RoutePrefix("TiposLancamento")]
    public class TiposLancamentoController : Controller
    {
        private WebChurchManagementContext db = new WebChurchManagementContext();

        // GET: TiposLancamento
        public ActionResult Index()
        {
            return View(db.TipoLancamentos.ToList());
        }

        // GET: TiposLancamento/Details/5
        [Route("Detalhes/{id}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoLancamento tipoLancamento = db.TipoLancamentos.Find(id);
            if (tipoLancamento == null)
            {
                return HttpNotFound();
            }
            return View(tipoLancamento);
        }

        // GET: TiposLancamento/Create
        [Route("Inserir")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: TiposLancamento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Inserir")]
        public ActionResult Create([Bind(Include = "Id_Tpo_Lanc,Desc_Lanc,Ativo")] TipoLancamento tipoLancamento)
        {
            if (ModelState.IsValid)
            {
                db.TipoLancamentos.Add(tipoLancamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoLancamento);
        }

        // GET: TiposLancamento/Edit/5
        [Route("Editar/{id}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoLancamento tipoLancamento = db.TipoLancamentos.Find(id);
            if (tipoLancamento == null)
            {
                return HttpNotFound();
            }
            return View(tipoLancamento);
        }

        // POST: TiposLancamento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Editar")]
        public ActionResult Edit([Bind(Include = "Id_Tpo_Lanc,Desc_Lanc,Ativo")] TipoLancamento tipoLancamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoLancamento).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoLancamento);
        }

        // GET: TiposLancamento/Delete/5
        [Route("Deletar/{id}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoLancamento tipoLancamento = db.TipoLancamentos.Find(id);
            if (tipoLancamento == null)
            {
                return HttpNotFound();
            }
            return View(tipoLancamento);
        }

        // POST: TiposLancamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Deletar/{id}")]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoLancamento tipoLancamento = db.TipoLancamentos.Find(id);
            db.TipoLancamentos.Remove(tipoLancamento);
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
