using System.Net;
using System.Web.Mvc;
using YourNamespace.Models;
using YourNamespace.Repositories;

namespace YourNamespace.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriasController()
        {
            _categoriaRepository = new CategoriaRepository(new Data.OracleDbContext());
        }

        // GET: Categorias
        public ActionResult Index()
        {
            var categorias = _categoriaRepository.GetAll();
            return View(categorias);
        }

        // GET: Categorias/Details/5
        public ActionResult Details(int id)
        {
            var categoria = _categoriaRepository.GetById(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // GET: Categorias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categorias/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _categoriaRepository.Add(categoria);
                return RedirectToAction("Index");
            }

            return View(categoria);
        }

        // GET: Categorias/Edit/5
        public ActionResult Edit(int id)
        {
            var categoria = _categoriaRepository.GetById(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // POST: Categorias/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _categoriaRepository.Update(categoria);
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        // GET: Categorias/Delete/5
        public ActionResult Delete(int id)
        {
            var categoria = _categoriaRepository.GetById(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _categoriaRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}