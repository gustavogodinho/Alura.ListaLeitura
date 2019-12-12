using System;
using System.Collections.Generic;
using System.Text;
using Alura.ListaLeitura.Business;

namespace Alura.ListaLeitura.Repository
{
    public interface IBookRepository
    {
        ReadingList ParaLer { get; }
        ReadingList Lendo { get; }
        ReadingList Lidos { get; }
        IEnumerable<Book> Todos { get; }
        void Incluir(Book livro);

    }
}
