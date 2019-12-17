using Alura.ListaLeitura.Business;
using Alura.ListaLeitura.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.Services
{
    public class BookRead
    {
        HtmlServices _htmlServices = new HtmlServices();
       

        public Task LivrosLendo(HttpContext context)
        {
            BookRepositoryBase _repositorio = new BookRepositoryBase();
            return context.Response.WriteAsync(_repositorio.Lendo.ToString());
        }

        public Task LivrosLidos(HttpContext context)
        {
            BookRepositoryBase _repositorio = new BookRepositoryBase();
            return context.Response.WriteAsync(_repositorio.Lidos.ToString());
        }

        public Task LivrosParaLer(HttpContext context)
        {
            var _repo = new BookRepositoryBase();

            var conteudoArquivo = _htmlServices.CarregaArquivoHtml("bookforRead");

            foreach (var livro in _repo.ParaLer.Livros)
            {
                conteudoArquivo = conteudoArquivo
                    .Replace("#NOVO-ITEM#", $"<li>{livro.Titulo} - {livro.Autor}</li>#NOVO-ITEM#");
            }
            conteudoArquivo = conteudoArquivo.Replace("#NOVO-ITEM#", "");

            return context.Response.WriteAsync(conteudoArquivo);
        }

        public Task ExibeFormulario(HttpContext context)
        {
            var html = _htmlServices.CarregaArquivoHtml("form");
            return context.Response.WriteAsync(html);
        }


        public Task ExibeDetalhes(HttpContext context)
        {
            try
            {
                int id = Convert.ToInt32(context.GetRouteValue("id"));
                BookRepositoryBase _repositorio = new BookRepositoryBase();
                var livro = _repositorio.BuscaLivroPorId(id);

                return context.Response.WriteAsync(livro.Details());
            }
            catch (Exception e)
            {
                return context.Response.WriteAsync("Não encontrado!");
            }

        }
        public Task ProcessaFormulario(HttpContext context)
        {
            var livro = new Book()
            {
                Titulo = context.Request.Form["titulo"].First(),
                Autor = context.Request.Form["autor"].First()
            };
            BookRepositoryBase _repositorio = new BookRepositoryBase();
            _repositorio.Incluir(livro);

            return context.Response.WriteAsync("Cadastrado com sucesso!");
        }



    }
}
