using System;
using System.IO;

namespace Alura.ListaLeitura.Services
{
    public class HtmlServices
    {
        public string CarregaArquivoHtml(string nomeArquivo)
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

    }
}
