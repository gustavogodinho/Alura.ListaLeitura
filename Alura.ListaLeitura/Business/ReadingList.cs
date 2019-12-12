using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alura.ListaLeitura.Business
{
    public class ReadingList
    {
        private List<Book> _livros;


        public ReadingList(string titulo, params Book[] livros)
        {
            Titulo = titulo;
            _livros = livros.ToList();
            _livros.ForEach(l => l.Lista = this);
        }

        public string Titulo { get; set; }

        public IEnumerable<Book> Livros
        {
            get { return _livros; }
        }

        public override string ToString()
        {
            var linhas = new StringBuilder();
            linhas.AppendLine(Titulo);
            linhas.AppendLine("=========");
            foreach (var livro in Livros)
            {
                linhas.AppendLine(livro.ToString());
            }
            return linhas.ToString();
        }
    }
}
