using Alura.ListaLeitura.Business;
using Alura.ListaLeitura.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.Services
{
    public class CreateController
    {
        public Task NovoLivro(HttpContext context)
        {
            BookRepositoryBase _repositorio = new BookRepositoryBase();
            var livro = new Book
            {
                Titulo = context.GetRouteValue("nome").ToString(),
                Autor = context.GetRouteValue("autor").ToString()
            };
            _repositorio.Incluir(livro);
            return context.Response.WriteAsync("Livro adicionado com sucesso!");
        }

    }
}
