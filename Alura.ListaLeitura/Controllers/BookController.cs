using Alura.ListaLeitura.Repository;
using Microsoft.AspNetCore.Mvc;
using System;


namespace Alura.ListaLeitura.Controllers
{
    /// <inheritdoc />
    public class BookController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult ParaLer()
        {
            var repo = new BookRepositoryBase();
            ViewBag.Livros = repo.ParaLer.Livros;
            return View($"list");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Lendo()
        {
            var repo = new BookRepositoryBase();
            ViewBag.Livros = repo.ParaLer.Livros;
            return View($"list");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Lidos()
        {
            var repo = new BookRepositoryBase();
            ViewBag.Livros = repo.ParaLer.Livros;
            return View($"list");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Detalhes(int id)
        {
            try
            {
                var repo = new BookRepositoryBase();
                var livro = repo.BuscaLivroPorId(id);

                return livro.Details();
            }
            catch (Exception e)
            {
                return "Não encontrado!";
            }
        }
    }
}
