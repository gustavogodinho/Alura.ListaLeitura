using System;
using System.Collections.Generic;
using System.Text;
using Alura.ListaLeitura.Business;
using Alura.ListaLeitura.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Alura.ListaLeitura.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateController
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public string Create(Book book)
        {
            var repo = new BookRepositoryBase();
            repo.Incluir(book);
            return "Livro cadastrado com sucesso";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult ViewForm()
        {
            return new ViewResult { ViewName = "form"};
        }


    }
}
