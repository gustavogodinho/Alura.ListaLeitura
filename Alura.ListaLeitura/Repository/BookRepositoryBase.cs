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
        private static readonly string nomeArquivoCSV = @"C:\txt\livros.csv";

        public BookRepositoryBase()
        {
            var arrayParaLer = new List<Book>();
            var arrayLendo = new List<Book>();
            var arrayLidos = new List<Book>();

            using (var file = File.OpenText(nomeArquivoCSV))
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

            ParaLer = new ReadingList("Para Ler", arrayParaLer.ToArray());
            Lendo = new ReadingList("Lendo", arrayLendo.ToArray());
            Lidos = new ReadingList("Lidos", arrayLidos.ToArray());
        }

        public ReadingList ParaLer { get; }
        public ReadingList Lendo { get; }
        public ReadingList Lidos { get; }

        public IEnumerable<Book> Todos => ParaLer.Livros.Union(Lendo.Livros).Union(Lidos.Livros);

        public Book BuscaLivroPorId(int id)
        {
            return Todos.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="livro"></param>
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
