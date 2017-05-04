using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebChurchManagement.Models;

namespace WebChurchManagement.Controllers
{
    [RoutePrefix("Cargos")]
    public class CargosController : Controller
    {
        private WebChurchManagementContext db = new WebChurchManagementContext();

        // GET: Cargos
        public ActionResult Index()
        {
            return View(db.Cargos.ToList());
        }

        // GET: Cargos/Detalhes/5
        [Route("Detalhes/{id}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo cargo = db.Cargos.Find(id);
            if (cargo == null)
            {
                return HttpNotFound();
            }
            return View(cargo);
        }

        // GET: Cargos/Inserir
        [Route("Inserir")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cargos/Inserir
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Inserir")]
        public ActionResult Create([Bind(Include = "Id_Cargo,Nome,Ativo")] Cargo cargo)
        {
            if (ModelState.IsValid)
            {
                db.Cargos.Add(cargo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cargo);
        }

        // GET: Cargos/Editar/5
        [Route("Editar/{id}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo cargo = db.Cargos.Find(id);
            if (cargo == null)
            {
                return HttpNotFound();
            }
            return View(cargo);
        }

        // POST: Cargos/Editar/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Editar")]
        public ActionResult Edit([Bind(Include = "Id_Cargo,Nome,Ativo")] Cargo cargo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cargo).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cargo);
        }

        // GET: Cargos/Deletar/5
        [Route("Deletar/{id}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo cargo = db.Cargos.Find(id);
            if (cargo == null)
            {
                return HttpNotFound();
            }
            return View(cargo);
        }

        // POST: Cargos/Deletar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Deletar/{id}")]
        public ActionResult DeleteConfirmed(int id)
        {
            Cargo cargo = db.Cargos.Find(id);
            db.Cargos.Remove(cargo);
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
