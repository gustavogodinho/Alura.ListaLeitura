using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Alura.ListaLeitura.Business;

namespace Alura.ListaLeitura.Repository
{
    public class BookRepositoryBase : IBookRepository
    {
        private static readonly string nomeArquivoCSV = "C:\txt\\livros.csv";

        private ReadingList _paraLer;
        private ReadingList _lendo;
        private ReadingList _lidos;

        public BookRepositoryBase()
        {
            var arrayParaLer = new List<Book>();
            var arrayLendo = new List<Book>();
            var arrayLidos = new List<Book>();

            using (var file = File.OpenText(BookRepositoryBase.nomeArquivoCSV))
            {
                while (!file.EndOfStream)
                {
                    var textoLivro = file.ReadLine();
                    if (string.IsNullOrEmpty(textoLivro))
                    {
                        continue;
                    }
                    var infoLivro = textoLivro.Split(';');
                    var livro = new Book
                    {
                        Id = Convert.ToInt32(infoLivro[1]),
                        Titulo = infoLivro[2],
                        Autor = infoLivro[3]
                    };
                    switch (infoLivro[0])
                    {
                        case "para-ler":
                            arrayParaLer.Add(livro);
                            break;
                        case "lendo":
                            arrayLendo.Add(livro);
                            break;
                        case "lidos":
                            arrayLidos.Add(livro);
                            break;
                        default:
                            break;
                    }
                }
            }

            _paraLer = new ReadingList("Para Ler", arrayParaLer.ToArray());
            _lendo = new ReadingList("Lendo", arrayLendo.ToArray());
            _lidos = new ReadingList("Lidos", arrayLidos.ToArray());
        }

        public ReadingList ParaLer => _paraLer;
        public ReadingList Lendo => _lendo;
        public ReadingList Lidos => _lidos;

        public IEnumerable<Book> Todos => _paraLer.Livros.Union(_lendo.Livros).Union(_lidos.Livros);

        public Book BuscaLivroPorId(int id)
        {
            return Todos.FirstOrDefault(x => x.Id == id);
        }

        public void Incluir(Book livro)
        {
            var id = Todos.Select(l => l.Id).Max();
            using (var file = File.AppendText(nomeArquivoCSV))
            {
                file.WriteLine($"para-ler;{id + 1};{livro.Titulo};{livro.Autor}");
            }
        }
    }
}
