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
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            //ReadController _bookServices = new ReadController();
            //CreateController _bookCreate = new CreateController();

            app.UseMvcWithDefaultRoute();

            //var builder = new RouteBuilder(app);
            //builder.MapRoute("{controller}/{action}", null);
            //builder.MapRoute("Livros/ParaLer", _bookServices.ParaLer);
            //builder.MapRoute("Livros/Lendo", _bookServices.Lendo);
            //builder.MapRoute("Livros/Lidos", _bookServices.Lidos);
            //builder.MapRoute("cadastro/novolivro/{nome}/{autor}", _bookCreate.NovoLivro);
            //builder.MapRoute("Livros/Detalhes/{id:int}", _bookServices.Detalhes);
            //builder.MapRoute("cadastro/ExibeFormulario", _bookServices.ExibeFormulario);
            //builder.MapRoute("Cadastro/Incluir", _bookServices.Incluir);
            //var rotas = builder.Build();
            //app.UseRouter(rotas);
        }

       
    }
}
