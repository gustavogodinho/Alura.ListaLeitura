using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Alura.ListaLeitura.Business;
using Alura.ListaLeitura.Repository;
using Alura.ListaLeitura.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Alura.ListaLeitura
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }

        public void Configure(IApplicationBuilder app)
        {
            BookRead _bookServices = new BookRead();
            BookCreate _bookCreate = new BookCreate();

            var builder = new RouteBuilder(app);
            builder.MapRoute("Livros/ParaLer", _bookServices.LivrosParaLer);
            builder.MapRoute("Livros/Lendo", _bookServices.LivrosLendo);
            builder.MapRoute("Livros/Lidos", _bookServices.LivrosLidos);
            builder.MapRoute("cadastro/novolivro/{nome}/{autor}", _bookCreate.CadastroNovoLivro);
            builder.MapRoute("Livros/Detalhes/{id:int}", _bookServices.ExibeDetalhes);
            builder.MapRoute("cadastro/novolivro", _bookServices.ExibeFormulario);
            builder.MapRoute("Cadastro/Incluir", _bookServices.ProcessaFormulario);
            var rotas = builder.Build();
            app.UseRouter(rotas);
        }

       
    }
}
