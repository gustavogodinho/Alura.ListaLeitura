using Alura.ListaLeitura.Business;
using Alura.ListaLeitura.Repository;
using Alura.ListaLeitura.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.Controllers
{
    public class BookController : Controller
    {
        HtmlServices _htmlServices = new HtmlServices();

        public string Incluir(Book book)
        {
            var _repositorio = new BookRepositoryBase();
            _repositorio.Incluir(book);
            return "Livro adicionado com sucesso!";
        }

        public string Lendo()
        {
            var _repositorio = new BookRepositoryBase();
            return _repositorio.Lendo.ToString();
        }

        public string Lidos()
        {
            var _repositorio = new BookRepositoryBase();
            return _repositorio.Lidos.ToString();
        }

        public string ParaLer()
        {
            var _repo = new BookRepositoryBase();
            var conteudoArquivo = _htmlServices.CarregaArquivoHtml("bookforRead");

            foreach (var livro in _repo.ParaLer.Livros)
            {
                conteudoArquivo = conteudoArquivo
                    .Replace("#NOVO-ITEM#", $"<li>{livro.Titulo} - {livro.Autor}</li>#NOVO-ITEM#");
            }

            return  conteudoArquivo.Replace("#NOVO-ITEM#", "");
        }
   
        public string ExibeFormulario()
        {
            var html = _htmlServices.CarregaArquivoHtml("form");
            return html;
        }

        public string Detalhes(int id)
        {
            try
            {
                var _repositorio = new BookRepositoryBase();
                var livro = _repositorio.BuscaLivroPorId(id);

                return livro.Details();
            }
            catch (Exception e)
            {
                return "Não encontrado!";
            }
        }

        public string ProcessaFormulario(Book book)
        {
            try
            {
                var _repositorio = new BookRepositoryBase();
                _repositorio.Incluir(book);

                return "Cadastrado com sucesso!";
            }
            catch (Exception e)
            {
                return "Erro ao cadastrar";
            }
        }

        public string Teste()
        {
            return "Nova funcionalidade";
        }


    }
}
