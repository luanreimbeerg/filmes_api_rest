using System;

namespace filmes_api_rest.Models.Response
{
    public class DiretorResponsePorNome
    {
        public int IdDiretor { get; set; }
        
        public int IdFilme { get; set; }
        
        public string NmDiretor { get; set; }

        public DateTime? DtNascimento { get; set; }


        public string NmFilme { get; set; }
    }
}