using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Alura.ListaLeitura.Business;
using Alura.ListaLeitura.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Alura.ListaLeitura
{
    public class Startup
    {
        readonly BookRepositoryBase _repositorio = new BookRepositoryBase();

        public void Configure(IApplicationBuilder app)
        {
            var builder = new RouteBuilder(app);
            builder.MapRoute("Livros/ParaLer", LivrosParaLer);
            builder.MapRoute("Livros/Lendo", LivrosLendo);
            builder.MapRoute("Livros/Lidos", LivrosLidos);
            builder.MapRoute("cadastro/novolivro/{nome}/{autor}", CadastroNovoLivro);
            builder.MapRoute("Livros/Detalhes/{id:int}", ExibeDetalhes);
            builder.MapRoute("cadastro/novolivro", ExibeFormulario);
            builder.MapRoute("Cadastro/Incluir", ProcessaFormulario);
            var rotas = builder.Build();
            app.UseRouter(rotas);
        }

        private string CarregaArquivoHtml(string nomeArquivo)
        {
            try
            {
                var nomeCompletoArquivo = $"Views/{nomeArquivo}.html";
                using (var arquivo = File.OpenText(nomeCompletoArquivo))
                {
                    return arquivo.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                return "View não encontrada!";
            }

        }

        private Task ExibeFormulario(HttpContext context)
        {
            var html = CarregaArquivoHtml("formulario");
            return context.Response.WriteAsync(html);
        }


        private Task ExibeDetalhes(HttpContext context)
        {
            try
            {
                int id = Convert.ToInt32(context.GetRouteValue("id"));

                var livro = _repositorio.BuscaLivroPorId(id);

                return context.Response.WriteAsync(livro.Details());
            }
            catch (Exception e)
            {
                return context.Response.WriteAsync("Não encontrado!");
            }

        }
        private Task ProcessaFormulario(HttpContext context)
        {
            var livro = new Book()
            {
                Titulo = context.Request.Form["titulo"].First(),
                Autor = context.Request.Form["autor"].First()
            };
            _repositorio.Incluir(livro);

            return context.Response.WriteAsync("Cadastrado com sucesso!");
        }

        private Task CadastroNovoLivro(HttpContext context)
        {
            var livro = new Book
            {
                Titulo = context.GetRouteValue("nome").ToString(),
                Autor = context.GetRouteValue("autor").ToString()
            };
            _repositorio.Incluir(livro);
            return context.Response.WriteAsync("Livro adicionado com sucesso!");
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }

        private Task LivrosLendo(HttpContext context)
        {
            return context.Response.WriteAsync(_repositorio.Lendo.ToString());
        }

        private Task LivrosLidos(HttpContext context)
        {
            return context.Response.WriteAsync(_repositorio.Lidos.ToString());
        }

        private Task LivrosParaLer(HttpContext context)
        {
            var conteudoArquivo = CarregaArquivoHtml("livrosparaler");

            foreach (var livro in _repositorio.ParaLer.Livros)
            {
                conteudoArquivo = conteudoArquivo
                    .Replace("#NOVO-ITEM#", $"<li>{livro.Titulo} - {livro.Autor}</li>#NOVO-ITEM#");
            }
            conteudoArquivo = conteudoArquivo.Replace("#NOVO-ITEM#", "");

            return context.Response.WriteAsync(conteudoArquivo);
        }

    }
}
