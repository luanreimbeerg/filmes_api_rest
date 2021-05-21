using System;

namespace filmes_api_rest.Models.Request
{
    public class DiretorRequest
    {
        public string NmDiretor { get; set; }

        public DateTime DtNascimento { get; set; }


        public string NmFilme { get; set; }
    }
}