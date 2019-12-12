using System.Text;

namespace Alura.ListaLeitura.Business
{
    public class Book
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public ReadingList Lista { get; set; }

        public string Details()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Detalhes do Livro");
            stringBuilder.AppendLine("=====");
            stringBuilder.AppendLine($"Título: {Titulo}");
            stringBuilder.AppendLine($"Autor: {Autor}");
            stringBuilder.AppendLine($"Lista: {Lista.Titulo}");
            return stringBuilder.ToString();

        }
        public override string ToString()
        {
            return $"{Titulo} - {Autor}";
        }


    }
}
