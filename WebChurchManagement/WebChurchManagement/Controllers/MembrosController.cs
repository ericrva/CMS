using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebChurchManagement.Models;

namespace WebChurchManagement.Controllers
{
    [RoutePrefix("Membros")]
    public class MembrosController : Controller
    {
        private WebChurchManagementContext db = new WebChurchManagementContext();

        // GET: Membros/
        public ActionResult Index()
        {
            var membros = db.Membros.Include(m => m.Cargos).Include(m => m.Status);
            return View(membros.ToList());
        }

        // GET: Membros/Detalhes/5
        [Route("Detalhes/{id}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membro membro = db.Membros.Find(id);
            if (membro == null)
            {
                return HttpNotFound();
            }
            return View(membro);
        }

        // GET: Membros/Inserir
        [Route("Inserir")]
        public ActionResult Create()
        {
            ViewBag.Id_Cargo = new SelectList(db.Cargos.Where(c => c.Ativo), "Id_Cargo", "Nome");
            ViewBag.Id_Status = new SelectList(db.Status.Where(s => s.Ativo), "Id_Status", "Nm_Status");
            ViewBag.Uf = new SelectList(Enum.GetValues(typeof(EnumUF)));
            ViewBag.Matricula = Convert.ToInt32(db.Membros.Max(m => m.Matricula)) + 1;
            return View();
        }

        // POST: Membros/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Inserir")]
        public ActionResult Create([Bind(Include = "Id_Cargo,Id_Status,Nome,Mae,Pai,Sexo,Matricula,Dt_Nasc,Dt_Desde,Ativo,Tel1,Tel2,Tel3,Email,Cep,Rua,Bairro,Cidade,Uf,N_Casa,Foto,Obs")] Membro membro)
        {
            if (ModelState.IsValid)
            {
                membro.Foto = uploadArquivo(membro);

                db.Membros.Add(membro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(membro);
        }

        // GET: Membros/Editar/5
        [Route("Editar/{id}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membro membro = db.Membros.Find(id);
            if (membro == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Cargo = new SelectList(db.Cargos.Where(c => c.Ativo), "Id_Cargo", "Nome", membro.Id_Cargo);
            ViewBag.Id_Status = new SelectList(db.Status.Where(s => s.Ativo), "Id_Status", "Nm_Status", membro.Id_Status);
            ViewBag.Uf = new SelectList(Enum.GetValues(typeof(EnumUF)), membro.Uf);
            return View(membro);
        }

        // POST: Membros/Editar/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Editar")]
        public ActionResult Edit([Bind(Include = "Id_Membros,Id_Cargo,Id_Status,Nome,Mae,Pai,Sexo,Matricula,Dt_Nasc,Dt_Desde,Ativo,Tel1,Tel2,Tel3,Email,Cep,Rua,Bairro,Cidade,Uf,N_Casa,Foto,Obs")] Membro membro)
        {
            if (ModelState.IsValid)
            {
                membro.Foto = uploadArquivo(membro);

                db.Entry(membro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(membro);
        }

        // GET: Membros/Deletar/5
        [Route("Deletar/{id}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membro membro = db.Membros.Find(id);
            if (membro == null)
            {
                return HttpNotFound();
            }
            return View(membro);
        }

        // POST: Membros/Deletar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Deletar/{id}")]
        public ActionResult DeleteConfirmed(int id)
        {
            Membro membro = db.Membros.Find(id);
            db.Membros.Remove(membro);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private string uploadArquivo(Membro membro)
        {
            string nomeArquivo = string.Empty;
            //int arquivosSalvos = 0;
            //for (int i = 0; i < Request.Files.Count; i++)
            //{
            HttpPostedFileBase arquivo = Request.Files[0];

            //Salva o arquivo
            if (arquivo.ContentLength > 0)
            {
                string uploadPath = Server.MapPath("~/img");
                nomeArquivo = membro.Nome.Split(' ')[0] + membro.Dt_Nasc.ToString("yyyyMMdd") + ".png";
                string caminhoArquivo = Path.Combine(uploadPath, nomeArquivo);

                arquivo.SaveAs(caminhoArquivo);
                //arquivosSalvos++;

            }
            //}

            return nomeArquivo;

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
