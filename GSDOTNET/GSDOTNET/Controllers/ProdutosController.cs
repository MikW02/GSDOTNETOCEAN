using System.Net;
using System.Web.Mvc;
using YourNamespace.Models;
using YourNamespace.Repositories;

namespace YourNamespace.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutosController()
        {
            _produtoRepository = new ProdutoRepository(new Data.OracleDbContext());
        }

        // GET: Produtos
        public ActionResult Index()
        {
            var produtos = _produtoRepository.GetAll();
            return View(produtos);
        }

        // GET: Produtos/Details/5
        public ActionResult Details(int id)
        {
            var produto = _produtoRepository.GetById(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Preco,CategoriaId")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                _produtoRepository.Add(produto);
                return RedirectToAction("Index");
            }

            return View(produto);
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(int id)
        {
            var produto = _produtoRepository.GetById(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Preco,CategoriaId")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                _produtoRepository.Update(produto);
                return RedirectToAction("Index");
            }
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(int id)
        {
            var produto = _produtoRepository.GetById(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _produtoRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}